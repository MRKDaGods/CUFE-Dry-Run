using System;
using System.Collections.Generic;
using System.Linq;

namespace MRK.Models
{
    public enum CourseFlags
    {
        None = 0,
        MultipleLectures = 1 << 0,
        MultipleTutorials = 1 << 1
    }

    public class Course
    {
        private static readonly HashSet<string> CoursesWithoutTutorial = [
            "CMPS425", // consultation
            "CCES481" // gp1 cce
        ];

        public string Code { get; init; }
        public string Name { get; set; }
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

        public bool HasNoTutorial => IsGen || CoursesWithoutTutorial.Contains(Code);

        public Course(string code, string name)
        {
            Code = code;
            Name = name;

            IsNewSystem = Code.Last(char.IsLetter) == 'S';
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

        public override string ToString()
        {
            return $"{Code} - {Name}";
        }
    }
}
