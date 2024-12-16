using MRK.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MRK
{
    public partial class StandardCourseParser : CourseParser<string>
    {
        public StandardCourseParser()
        {
            CourseRecords = [];
        }

        public override void Parse(string rawRecords)
        {
            // clear records
            CourseRecords.Clear();

            // clear courses
            CourseRegistry.ResetCourses(true);

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

                var course = CourseRegistry.GetOrCreateCourse(code, name);

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

            // postprocessing
            PostProcessRecords();
        }

        private static string Sanitize(string str)
        {
            return str.Replace("_", "").Trim();
        }

        [GeneratedRegex("<td>__([^_]+)__(?:[^<]*)<\\/td><td>([^<]*)<\\/td><td>([^<]*)<\\/td><td>([^<]*)<\\/td><td>([^<]*)<\\/td><td>([^<]*)<\\/td><td>([^<]*)<\\/td><td>([^<]*)<\\/td><td>([^<]*)<\\/td><td>([^<]*)<\\/td><td>([^<]*)<\\/td><td>([^<]*)<\\/td>")]
        private static partial Regex CourseRecordRegex();
    }
}
