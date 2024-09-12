using System;
using System.Linq;

namespace MRK.Models
{
    public enum CourseFlags
    {
        None = 0,
        MultipleLectures = 1 << 0,
    }

    public class Course
    {
        public string Code { get; init; }
        public string Name { get; init; }
        public bool Checked { get; set; }
        public bool IsNewSystem { get; init; }
        public int LectureCount { get; set; }
        public int TutorialCount { get; set; }
        public CourseFlags Flags { get; set; }

        public bool IsGen
        {
            get
            {
                return Code.StartsWith("GEN");
            }
        }

        public bool HasNoTutorial => IsGen || Code == "CMPS425"; // consultation

        public Course(string code, string name)
        {
            Code = code;
            Name = name;

            IsNewSystem = Code.Where(x => char.IsLetter(x)).Last() == 'S';
            Flags = CourseFlags.None;

            Checked = false;
        }

        public override bool Equals(object? obj)
        {
            return obj is Course definition &&
                   Code == definition.Code &&
                   Name == definition.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Code, Name);
        }
    }
}
