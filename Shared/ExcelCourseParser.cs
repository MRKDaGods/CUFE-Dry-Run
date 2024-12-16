using MRK.Models;
using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MRK
{
    public partial class ExcelCourseParser : CourseParser<byte[]>
    {
        static ExcelCourseParser()
        {
            // set license
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public override void Parse(byte[] xlsxFile)
        {
            // check if we have parsed courses metadata previously
            if (CourseRegistry.Courses.Count == 0)
            {
                throw new Exception("Courses metadata not found");
            }

            // clear previous records
            CourseRecords.Clear();

            // reset courses
            CourseRegistry.ResetCourses(false);

            using var stream = new MemoryStream(xlsxFile);
            using var pkg = new ExcelPackage(stream);

            foreach (var sheet in pkg.Workbook.Worksheets)
            {
                Console.WriteLine($"Sheet: {sheet.Name}");

                // check if sheet corresponds to day of week
                if (!Enum.TryParse<DayOfWeek>(sheet.Name, true, out var day))
                {
                    continue;
                }

                // row by row
                for (int row = 1; row <= sheet.Dimension.End.Row; row++)
                {
                    var firstCell = sheet.Cells[row, 1].Value?.ToString() ?? string.Empty;

                    // try parse time slot in format "HH[:mm] - HH[:mm]"
                    var match = TimeSlotRegex().Match(firstCell);
                    if (!match.Success)
                    {
                        continue;
                    }

                    // parse time
                    if (!TimeSpan.TryParse(EnsureTimeConsistent(match.Groups["start"].Value), out var start) ||
                        !TimeSpan.TryParse(EnsureTimeConsistent(match.Groups["end"].Value), out var end))
                    {
                        continue;
                    }

                    // validate time
                    ValidateTimeSpan(ref start);

                    // find cells that start here
                    var cells = sheet.Cells[row, 2, row, sheet.Dimension.End.Column];

                    // iterate through cells that start here
                    foreach (var cell in cells)
                    {
                        var courseContent = cell.Value?.ToString() ?? string.Empty;
                        if (string.IsNullOrWhiteSpace(courseContent))
                        {
                            continue;
                        }

                        // try parse course content
                        var contentMatch = CourseContentRegex().Match(courseContent);
                        if (!contentMatch.Success)
                        {
                            continue;
                        }

                        // parsed content
                        var courseName = contentMatch.Groups["courseName"].Value;
                        var courseType = contentMatch.Groups["courseType"].Value;
                        var group = contentMatch.Groups["group"].Value;
                        var courseCode = contentMatch.Groups["courseCode"].Value;
                        var location = contentMatch.Groups["location"].Value;

                        // validate group and type
                        if (!int.TryParse(group, out var groupNum))
                        {
                            throw new Exception($"Invalid group {group}");
                        }

                        var type = courseType switch
                        {
                            "L" => CourseRecordType.Lecture,
                            "T" => CourseRecordType.Tutorial,
                            _ => throw new Exception($"Invalid course type {courseType}")
                        };

                        // get cell height in rows and calculate end time
                        var height = 1;
                        if (cell.Merge)
                        {
                            var cellEnd = int.Parse(
                                sheet.MergedCells[row, cell.Start.Column].Split(':').Last().Where(char.IsDigit).ToArray());

                            height = cellEnd - row + 1;
                        }

                        // end = start + height - 10 minutes
                        var to = start.Add(new TimeSpan(height, -10, 0));

                        // get course record
                        var course = CourseRegistry.GetOrCreateCourse(courseCode, courseName);

                        // update lec/tut count
                        switch (type)
                        {
                            case CourseRecordType.Lecture:
                                course.LectureCount++;
                                break;

                            case CourseRecordType.Tutorial:
                                course.TutorialCount++;
                                break;

                            default:
                                throw new Exception($"Invalid course type {course}");
                        }

                        var convertedDay = day switch
                        {
                            DayOfWeek.Monday => CourseRecordDay.Monday,
                            DayOfWeek.Tuesday => CourseRecordDay.Tuesday,
                            DayOfWeek.Wednesday => CourseRecordDay.Wednesday,
                            DayOfWeek.Thursday => CourseRecordDay.Thursday,
                            DayOfWeek.Saturday => CourseRecordDay.Saturday,
                            DayOfWeek.Sunday => CourseRecordDay.Sunday,

                            // no Friday
                            _ => CourseRecordDay.None,
                        };

                        var record = new CourseRecord(
                            course,
                            groupNum,
                            type,
                            convertedDay,
                            start,
                            to,
                            0,
                            0,
                            0,
                            "Opened",
                            location,
                            CourseParseFormat.Excel);

                        CourseRecords.Add(record);
                    }
                }
            }

            // postprocessing
            PostProcessRecords();
        }

        private string EnsureTimeConsistent(string time)
        {
            return time.Contains(':') ? time : $"{time}:00";
        }

        [GeneratedRegex(@"^(?<start>\d{1,2}(:\d{2})?)\s*-\s*(?<end>\d{1,2}(:\d{2})?)")]
        private static partial Regex TimeSlotRegex();
        [GeneratedRegex(@"^(?<courseName>.+?)\s+\(\s*(?<courseType>[LT])\s*(?<group>\d+)\s*\)\s+\(\s*(?<courseCode>[A-Z]+\d+)\s*\)\s+(?<location>.+)")]
        private static partial Regex CourseContentRegex();
    }
}
