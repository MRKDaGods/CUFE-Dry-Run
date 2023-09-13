using System.Diagnostics.CodeAnalysis;

namespace MRK
{
    public class CourseDefinition
    {
        public string Code { get; init; }
        public string Name { get; init; }
        public bool Checked { get; set; }
        public bool IsNewSystem { get; init; }

        public CourseDefinition(string code, string name)
        {
            Code = code;
            Name = name;

            IsNewSystem = Code.Where(x => char.IsLetter(x)).Last() == 'S';

            Checked = false;
        }

        public override bool Equals(object? obj)
        {
            return obj is CourseDefinition definition &&
                   Code == definition.Code &&
                   Name == definition.Name;
        }

        public override int GetHashCode()
        {
            return Code.GetHashCode() ^ Name.GetHashCode();
        }
    }

    public enum CourseType
    {
        None,
        Lecture,
        Tutorial
    }

    public enum CourseDay
    {
        None,
        Saturday,
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday
    }

    public class CourseDayComparer : IComparer<CourseDay>
    {
        public int Compare(CourseDay x, CourseDay y)
        {
            return x.CompareTo(y);
        }
    }

    public class CourseRecord
    {
        public CourseDefinition CourseDefinition { get; init; }
        public int Group { get; init; }
        public CourseType CourseType { get; init; }
        public CourseDay Day { get; init; }
        public TimeSpan From { get; init; }
        public TimeSpan To { get; init; }
        public bool Selected { get; set; }
        public int ClassSize { get; set; }
        public int Enrolled { get; set; }

        public bool IsOpen => ClassSize > Enrolled;

        public CourseRecord(CourseDefinition courseDefinition, int group, CourseType courseType, CourseDay day, TimeSpan from, TimeSpan to, int classSize, int enrolled)
        {
            CourseDefinition = courseDefinition;
            Group = group;
            CourseType = courseType;
            Day = day;
            From = from;
            To = to;
            ClassSize = classSize;
            Enrolled = enrolled;

            Selected = false;
        }
    }

    public class CourseManager
    {
        private const int MinHour = 8;

        public List<CourseDefinition> CourseDefs { get; init; }
        public List<CourseRecord> CourseRecords { get; init; }

        public CourseManager()
        {
            CourseDefs = new List<CourseDefinition>();
            CourseRecords = new List<CourseRecord>();
        }

        public void ParseCourses([NotNull] string raw)
        {
            CourseDefs.Clear();
            CourseRecords.Clear();

            var cur = raw;

            while (true)
            {
                //code
                int codeBegin = cur.IndexOf("__");
                if (codeBegin == -1) break;

                int codeEnd = cur.Substring(codeBegin + 2).IndexOf("__") + codeBegin + 2;
                if (codeEnd == -1) break;

                int len = codeEnd - codeBegin - 2;
                string potentialCode = len > 0 ? cur.Substring(codeBegin + 2, len) : "";

                //all codes are of 7 chars
                if (potentialCode.Length == 7 && !potentialCode.StartsWith('_'))
                {
                    //name
                    int nameBegin = codeEnd + 11; //2 + 9
                    int nameEnd = cur.Substring(nameBegin).IndexOf("</td>") + nameBegin;
                    string name = cur.Substring(nameBegin, nameEnd - nameBegin);

                    //register definition if needed
                    var definition = GetOrRegisterDefinition(potentialCode, name);

                    //group
                    int groupBegin = nameEnd + 9;
                    int groupEnd = cur.Substring(groupBegin).IndexOf("</td>") + groupBegin;
                    string group = cur.Substring(groupBegin, groupEnd - groupBegin);

                    //type (Tutorial_ or Lecture_)
                    int typeBegin = groupEnd + 9;
                    int typeEnd = cur.Substring(typeBegin).IndexOf("</td>") + typeBegin;
                    string type = cur.Substring(typeBegin, typeEnd - typeBegin - 1); // -1 to omit the suffixed _

                    //day
                    int dayBegin = typeEnd + 9;
                    int dayEnd = cur.Substring(dayBegin).IndexOf("</td>") + dayBegin;
                    string day = cur.Substring(dayBegin, dayEnd - dayBegin);

                    //from
                    int fromBegin = dayEnd + 9;
                    int fromEnd = cur.Substring(fromBegin).IndexOf("</td>") + fromBegin;
                    string from = cur.Substring(fromBegin, fromEnd - fromBegin).Replace("_", ""); //remove padding _

                    //to
                    int toBegin = fromEnd + 9;
                    int toEnd = cur.Substring(toBegin).IndexOf("</td>") + toBegin;
                    string to = cur.Substring(toBegin, toEnd - toBegin).Replace("_", ""); //remove padding _

                    //class size
                    int csBegin = toEnd + 9;
                    int csEnd = cur.Substring(csBegin).IndexOf("</td>") + csBegin;
                    string classSize = cur.Substring(csBegin, csEnd - csBegin).Replace("_", ""); //remove padding _

                    //enrolled
                    int enrBegin = csEnd + 9;
                    int enrEnd = cur.Substring(enrBegin).IndexOf("</td>") + enrBegin;
                    string enrolled = cur.Substring(enrBegin, enrEnd - enrBegin);

                    var courseGroup = int.Parse(group);

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

                    CourseRecords.Add(new CourseRecord(definition, courseGroup, courseType, courseDay, timeFrom, timeTo, courseClassSize, courseEnrolled));

                    cur = cur.Substring(enrEnd);
                }
                else
                {
                    cur = cur.Substring(codeEnd);
                }
            }

            //sort courses
            CourseDefs.Sort((x, y) => x.Code.CompareTo(y.Code));
        }

        private CourseDefinition GetOrRegisterDefinition(string code, string name)
        {
            var def = CourseDefs.Find(x => x.Code == code && x.Name == name);
            if (def == null)
            {
                def = new CourseDefinition(code, name);
                CourseDefs.Add(def);
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
        }

        public List<CourseRecord> FindClashingCourseRecords(CourseRecord primary)
        {
            return CourseRecords.FindAll(x => x.Selected && x.CourseDefinition.Checked && x.Day == primary.Day && (x.From == primary.From || (x.From > primary.From && x.From < primary.To) || (primary.From > x.From && primary.From < x.To)) && x != primary);
        }
    }
}
