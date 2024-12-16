using MRK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace MRK
{
    public class CourseManager
    {
        private static CourseManager? _instance;

        /// <summary>
        /// All course records
        /// </summary>
        public List<CourseRecord> CourseRecords { get; private set; }

        public static CourseManager Instance => _instance ??= new();
        public static List<Course> Courses => CourseRegistry.Courses;

        public CourseManager()
        {
            CourseRecords = [];
        }

        public void ParseCourses(UpdateData? data)
        {
            // show console window
            WriteLine("Parsing courses...");

            if (!data.HasValue)
            {
                WriteLine("No data to parse");
                return;
            }

            // parse normal courses xml
            var standardCourseParser = CourseRegistry.GetOrCreateParser<StandardCourseParser>();
            standardCourseParser.Parse(data.Value.Resource);

            // get parsed records
            CourseRecords = standardCourseParser.CourseRecords;

            // is it an excel update?
            if (data.Value.Features.HasFlag(UpdateFeatures.XLSX))
            {
                // parse excel courses
                var xlsx = Convert.FromBase64String(data.Value.Extra);
                WriteLine($"Parsing {xlsx.Length} bytes of excel data");

                var excelCourseParser = CourseRegistry.GetOrCreateParser<ExcelCourseParser>();
                excelCourseParser.Parse(xlsx);

                // update records
                CourseRecords = excelCourseParser.CourseRecords;
            }

            WriteLine($"Parsed {Courses.Count} courses {CourseRecords.Count} records");
        }

        public List<CourseRecord> GetAvailableCourseRecords(bool openOnly)
        {
            return CourseRecords.Where(x => x.Course.Checked && (!openOnly || x.IsOpen)).ToList();
        }

        public bool HasAvailableCourseRecords(bool openOnly)
        {
            return CourseRecords.Any(x => x.Course.Checked && (!openOnly || x.IsOpen));
        }

        public List<CourseRecord> GetSelectedCourseRecords()
        {
            return CourseRecords.Where(x => x.Course.Checked && x.Selected).ToList();
        }

        public void SelectCourseRecord(CourseRecord record, out CourseRecord? deselected)
        {
            deselected = null;

            //course toggled
            if (record.Selected)
            {
                record.Selected = false;
                deselected = record;
                return;
            }

            //find other selected coures of same type and deselect them
            var other = CourseRecords.Find(x => x.Selected
                                                && x.Course == record.Course
                                                && x.Type == record.Type);

            if (other != null)
            {
                other.Selected = false;
                deselected = other;
            }

            record.Selected = true;
        }

        public List<CourseRecord> FindClashingCourseRecords(CourseRecord primary)
        {
            return CourseRecords.FindAll(x => x.Selected
                                              && x.Course.Checked
                                              && x.Day == primary.Day
                                              && (x.From == primary.From || (x.From > primary.From && x.From < primary.To) || (primary.From > x.From && primary.From < x.To))
                                              && x != primary);
        }
    }
}
