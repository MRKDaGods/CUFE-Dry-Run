using MRK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Console;

namespace MRK
{
    public partial class CourseManager
    {
        private const int MinHour = 8;

        public List<Course> Courses { get; init; }
        public List<CourseRecord> CourseRecords { get; set; }

        private static CourseManager? _instance;

        public static CourseManager Instance => _instance ??= new();

        public CourseManager()
        {
            Courses = [];
            CourseRecords = [];
        }

        public void ParseCourses(string rawRecords)
        {
            // show console window
            WriteLine("Parsing courses...");

            Courses.Clear();
            CourseRecords.Clear();

            var matches = CourseRecordRegex().Matches(rawRecords);
            foreach (Match m in matches)
            {
                var code = m.Groups[1].Value;

                // irregular format detection
                var hasIrregularFormat = code is "LECS000" or "TUTS000";

                var name = m.Groups[2].Value.Trim().Replace("&amp;", "&");

                // group
                var groupString = m.Groups[3].Value;
                hasIrregularFormat |= groupString.Contains(code);

                int group;
                CourseParseFormat format;
                if (hasIrregularFormat)
                {
                    //determine which format
                    //x-yyyy
                    int sep;
                    if (groupString.Length < 9 || (sep = groupString.IndexOf('-')) == -1) // assuming group < 10
                    {
                        throw new Exception("Irregular format is invalid");
                    }

                    //which format?
                    //	1-MTHS002
                    //  MDPS478-Vehicle System Dynamics and Control- 3

                    // okay
                    // find next
                    var sep2 = groupString[(sep + 1)..].LastIndexOf('-');
                    if (sep2 != -1)
                    {
                        format = CourseParseFormat.IrregularWithName;
                        code = groupString[..sep];
                        name = groupString.Substring(sep + 1, sep2);
                        group = int.Parse(groupString[(sep + sep2 + 2)..]);
                    }
                    else
                    {
                        //	5-MTHS003
                        //	INTS203-G.1
                        if (int.TryParse(groupString[..sep], out group))
                        {
                            format = CourseParseFormat.IrregularWithoutName;

                            group = int.Parse(groupString[..sep]);
                            code = groupString[(sep + 1)..];

                            //	5-5MTHS003
                            if (char.IsDigit(code[0]))
                            {
                                format = CourseParseFormat.IrregularWithoutNameGroupPrefixed;
                                code = code[1..];
                            }
                        }
                        else
                        {
                            format = CourseParseFormat.IrregularWithoutNameGroupPostFixed;
                            code = groupString[..sep];
                            if (!int.TryParse(groupString.Substring(sep + 1).Replace("G.", ""), out group))
                            {
                                format = CourseParseFormat.IrregularWithNameNoGroup;
                                group = -1;
                                name = groupString[(sep + 1)..];
                            }
                        }
                    }
                }
                else
                {
                    group = int.Parse(m.Groups[3].Value);
                    format = CourseParseFormat.Regular;
                }

                var type = Enum.Parse<CourseRecordType>(Sanitize(m.Groups[4].Value));
                var day = Enum.Parse<CourseRecordDay>(Sanitize(m.Groups[5].Value));
                var from = TimeSpan.Parse(Sanitize(m.Groups[6].Value));
                var to = TimeSpan.Parse(Sanitize(m.Groups[7].Value));
                var classSize = int.Parse(Sanitize(m.Groups[8].Value));
                var enrolled = int.Parse(Sanitize(m.Groups[9].Value));
                var waiting = int.Parse(Sanitize(m.Groups[10].Value));
                var status = Sanitize(m.Groups[11].Value);
                var location = m.Groups[12].Value;

                // fix from-to
                ValidateTimeSpan(ref from);
                ValidateTimeSpan(ref to);

                var course = GetOrCreateCourse(code, name);

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

                var record = new CourseRecord(
                    course,
                    group,
                    type,
                    day,
                    from,
                    to,
                    classSize,
                    enrolled,
                    waiting,
                    status,
                    location,
                    format);

                CourseRecords.Add(record);
            }


            //sort courses
            Courses.Sort((x, y) => x.Code.CompareTo(y.Code));

            CourseRecords = [.. CourseRecords.OrderBy(x => x.Day).ThenBy(x => x.From)];

            //set some flags for Courses Defs
            foreach (var def in Courses)
            {
                var map = new Dictionary<int, int>();

                foreach (var lecture in CourseRecords.Where(x => x.Course.Code == def.Code
                                                                 && x.Type == CourseRecordType.Lecture))
                {
                    if (!map.ContainsKey(lecture.Group))
                    {
                        map[lecture.Group] = 0;
                    }

                    lecture.MultipleLectureIndex = map[lecture.Group]++;
                }

                if (map.Any(x => x.Value >= 2))
                {
                    //multiple lectures
                    def.Flags |= CourseFlags.MultipleLectures;
                }
            }

            WriteLine($"Parsed {Courses.Count} courses {CourseRecords.Count} records");
        }

        private Course GetOrCreateCourse(string code, string? name = null)
        {
            var course = Courses.Find(x => x.Code == code);
            if (course == null)
            {
                ArgumentNullException.ThrowIfNull(name);

                course = new Course(code, name);
                Courses.Add(course);
            }

            return course;
        }

        private static string Sanitize(string str)
        {
            return str.Replace("_", "").Trim();
        }

        private void ValidateTimeSpan(ref TimeSpan time)
        {
            if (time.Hours < MinHour)
            {
                time = time.Add(new TimeSpan(12, 0, 0));
            }
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

        [GeneratedRegex("<td>__([^_]+)__(?:[^<]*)<\\/td><td>([^<]*)<\\/td><td>([^<]*)<\\/td><td>([^<]*)<\\/td><td>([^<]*)<\\/td><td>([^<]*)<\\/td><td>([^<]*)<\\/td><td>([^<]*)<\\/td><td>([^<]*)<\\/td><td>([^<]*)<\\/td><td>([^<]*)<\\/td><td>([^<]*)<\\/td>")]
        private static partial Regex CourseRecordRegex();
    }
}
