using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MRK.Models;
using static System.Console;

namespace MRK
{
    public class CourseManager
    {
        private const int MinHour = 8;

        public List<Course> Courses { get; init; }
        public List<CourseRecord> CourseRecords { get; set; }

        public CourseManager()
        {
            Courses = new List<Course>();
            CourseRecords = new List<CourseRecord>();
        }

        public void ParseCourses(string raw)
        {
            // show console window
            WriteLine("Parsing courses...");

            //WriteLine(raw);

            Courses.Clear();
            CourseRecords.Clear();

            var cur = raw;

            while (true)
            {
                //code
                int codeBegin = cur.IndexOf("__");
                if (codeBegin == -1) break;

                int codeEnd = cur[(codeBegin + 2)..].IndexOf("__") + codeBegin + 2;
                if (codeEnd == -1) break;

                int len = codeEnd - codeBegin - 2;
                string potentialCode = len > 0 ? cur.Substring(codeBegin + 2, len) : "";

                //all codes are of 7 chars
                if (potentialCode.Length == 7 && !potentialCode.StartsWith('_'))
                {
                    //name
                    int nameBegin = codeEnd + 11; //2 + 9
                    int nameEnd = cur[nameBegin..].IndexOf("</td>") + nameBegin;
                    string name = cur[nameBegin..nameEnd].Replace("amp;", "&").Trim();

                    // idk why
                    var isNewformat = potentialCode == "LECS000" || potentialCode == "TUTS000";

                    //group
                    int groupBegin = nameEnd + 9;
                    int groupEnd = cur[groupBegin..].IndexOf("</td>") + groupBegin;
                    string group = cur[groupBegin..groupEnd].Trim();
                    isNewformat |= group.Contains(potentialCode);

                    //type (Tutorial_ or Lecture_)
                    int typeBegin = groupEnd + 9;
                    int typeEnd = cur[typeBegin..].IndexOf("</td>") + typeBegin;
                    string type = cur.Substring(typeBegin, typeEnd - typeBegin - 1).Trim(); // -1 to omit the suffixed _

                    //day
                    int dayBegin = typeEnd + 9;
                    int dayEnd = cur[dayBegin..].IndexOf("</td>") + dayBegin;
                    string day = cur[dayBegin..dayEnd].Trim();

                    //from
                    int fromBegin = dayEnd + 9;
                    int fromEnd = cur[fromBegin..].IndexOf("</td>") + fromBegin;
                    string from = cur[fromBegin..fromEnd].Replace("_", "").Trim(); //remove padding _

                    //to
                    int toBegin = fromEnd + 9;
                    int toEnd = cur[toBegin..].IndexOf("</td>") + toBegin;
                    string to = cur[toBegin..toEnd].Replace("_", "").Trim(); //remove padding _

                    //class size
                    int csBegin = toEnd + 9;
                    int csEnd = cur[csBegin..].IndexOf("</td>") + csBegin;
                    string classSize = cur[csBegin..csEnd].Replace("_", "").Trim(); //remove padding _

                    //enrolled
                    int enrBegin = csEnd + 9;
                    int enrEnd = cur[enrBegin..].IndexOf("</td>") + enrBegin;
                    string enrolled = cur[enrBegin..enrEnd].Trim();

                    int courseGroup;
                    CourseParseFormat parseFormat;

                    if (isNewformat)
                    {
                        //determine which format
                        //x-yyyy
                        int sep;
                        if (group.Length < 9 || (sep = group.IndexOf("-")) == -1) // assuming group < 10
                        {
                            throw new Exception("New format is invalid");
                        }

                        //which format?
                        //	1-MTHS002
                        //  MDPS478-Vehicle System Dynamics and Control- 3

                        // okay
                        // find next
                        var sep2 = group[(sep + 1)..].LastIndexOf("-");
                        if (sep2 != -1)
                        {
                            parseFormat = CourseParseFormat.IrregularWithName;
                            potentialCode = group[..sep];
                            name = group.Substring(sep + 1, sep2);
                            courseGroup = int.Parse(group[(sep + sep2 + 2)..]);
                        }
                        else
                        {
                            //	5-MTHS003
                            //	INTS203-G.1
                            if (int.TryParse(group[..sep], out courseGroup))
                            {
                                parseFormat = CourseParseFormat.IrregularWithoutName;

                                courseGroup = int.Parse(group[..sep]);
                                potentialCode = group[(sep + 1)..];

                                //	5-5MTHS003
                                if (char.IsDigit(potentialCode[0]))
                                {
                                    parseFormat = CourseParseFormat.IrregularWithoutNameGroupPrefixed;
                                    potentialCode = potentialCode[1..];
                                }
                            }
                            else
                            {
                                parseFormat = CourseParseFormat.IrregularWithoutNameGroupPostFixed;
                                potentialCode = group[..sep];
                                if (!int.TryParse(group.Substring(sep + 1).Replace("G.", ""), out courseGroup))
                                {
                                    parseFormat = CourseParseFormat.IrregularWithNameNoGroup;
                                    courseGroup = -1;
                                    name = group[(sep + 1)..];
                                }
                            }
                        }
                    }
                    else
                    {
                        courseGroup = int.Parse(group);
                        parseFormat = CourseParseFormat.Regular;
                    }

                    var courseType = Enum.GetValues<CourseType>()
                                                .FirstOrDefault(x => x.ToString() == type);

                    var courseDay = Enum.GetValues<CourseDay>()
                                                .FirstOrDefault(x => x.ToString() == day);

                    var courseClassSize = int.Parse(classSize);
                    var courseEnrolled = int.Parse(enrolled);

                    var timeFrom = TimeSpan.Parse(from); //hour:min
                    ValidateTimeSpan(ref timeFrom);

                    var timeTo = TimeSpan.Parse(to); //hour:min
                    ValidateTimeSpan(ref timeTo);

                    //register definition if needed
                    var definition = GetOrRegisterDefinition(potentialCode, name);

                    switch (courseType)
                    {
                        case CourseType.Lecture:
                            definition.LectureCount++;
                            break;

                        case CourseType.Tutorial:
                            definition.TutorialCount++;
                            break;

                        default:
                            throw new Exception("Course Record has none course type");
                    }

                    // lecture are split into 2??
                    bool modified = false;
                    /*if (isNewformat)
                    {
                        // find old
                        var other = CourseRecords.Find(x => x.CourseDefinition == definition && x.Group == courseGroup && x.CourseType == courseType);

                        if (other != null)
                        {
                            other.From = MinTimeSpan(other.From, timeFrom);
                            other.To = MaxTimeSpan(other.To, timeTo);
                            
                            // set flag
                            modified = true;
                        }
                    }*/

                    if (!modified)
                    {
                        CourseRecords.Add(new CourseRecord(definition, courseGroup, courseType, courseDay, timeFrom, timeTo, courseClassSize, courseEnrolled, parseFormat));
                    }

                    cur = cur[enrEnd..];
                }
                else
                {
                    cur = cur[codeEnd..];
                }
            }

            //sort courses
            Courses.Sort((x, y) => x.Code.CompareTo(y.Code));

            CourseRecords = CourseRecords.OrderBy(x => x.Day)
                                         .ThenBy(x => x.From)
                                         .ToList();

            //set some flags for Courses Defs
            foreach (var def in Courses)
            {
                var map = new Dictionary<int, int>();

                foreach (var lecture in CourseRecords.Where(x => x.CourseDefinition.Code == def.Code && x.CourseType == CourseType.Lecture))
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

            WriteLine("Done!");

            //ParseNewAndCompare(raw);
        }

        private Course GetOrRegisterDefinition(string code, string name)
        {
            var def = Courses.Find(x => x.Code == code);
            if (def == null)
            {
                def = new Course(code, name);
                Courses.Add(def);
            }

            return def;
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
            return CourseRecords.Where(x => x.CourseDefinition.Checked && (!openOnly || x.IsOpen)).ToList();
        }

        public bool HasAvailableCourseRecords(bool openOnly)
        {
            return CourseRecords.Any(x => x.CourseDefinition.Checked && (!openOnly || x.IsOpen));
        }

        public List<CourseRecord> GetSelectedCourseRecords()
        {
            return CourseRecords.Where(x => x.CourseDefinition.Checked && x.Selected).ToList();
        }

        public void SelectCourseRecord(CourseRecord record, out CourseRecord? deselected)
        {
            deselected = null;

            //course toggled
            if (record.Selected)
            {
                record.Selected = false;
                deselected = record;

                //todo: deselect multiple lectures?

                return;
            }

            //find other selected coures of same type and deselect them
            var other = CourseRecords.Find(x => x.Selected && x.CourseDefinition == record.CourseDefinition && x.CourseType == record.CourseType);

            if (other != null)
            {
                other.Selected = false;
                deselected = other;
            }

            record.Selected = true;

            //manually select all other lectures (multiple lectures)
            /* if (record.CourseType == CourseType.Lecture && (record.CourseDefinition.Flags & CourseFlags.MultipleLectures) != 0)
            {
                foreach (var item in CourseRecords.FindAll(x =>
                    x != record &&
                    x.CourseDefinition == record.CourseDefinition &&
                    x.CourseType == record.CourseType &&
                    x.Group == record.Group))
                {
                    item.Selected = true;
                }
            } */
        }

        public List<CourseRecord> FindClashingCourseRecords(CourseRecord primary)
        {
            return CourseRecords.FindAll(x => x.Selected
                                              && x.CourseDefinition.Checked
                                              && x.Day == primary.Day
                                              && (x.From == primary.From || (x.From > primary.From && x.From < primary.To) || (primary.From > x.From && primary.From < x.To))
                                              && x != primary);
        }
    }
}
