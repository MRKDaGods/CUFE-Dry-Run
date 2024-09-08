using System;
using System.Collections.Generic;

namespace MRK.Models
{
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

    public enum CourseParseFormat
    {
        Regular,
        IrregularWithoutNameGroupPrefixed,
        IrregularWithoutNameGroupPostFixed,
        IrregularWithoutName,
        IrregularWithNameNoGroup,
        IrregularWithName
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
        public Course CourseDefinition { get; init; }
        public int Group { get; init; }
        public CourseType CourseType { get; init; }
        public CourseDay Day { get; init; }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
        public bool Selected { get; set; }
        public int ClassSize { get; set; }
        public int Enrolled { get; set; }
        public CourseParseFormat ParseFormat { get; init; }
        public int MultipleLectureIndex { get; set; }

        public bool IsOpen => ClassSize > Enrolled;

        public CourseRecord(
            Course courseDefinition,
            int group, CourseType courseType,
            CourseDay day,
            TimeSpan from,
            TimeSpan to,
            int classSize,
            int enrolled,
            CourseParseFormat parseFormat)
        {
            CourseDefinition = courseDefinition;
            Group = group;
            CourseType = courseType;
            Day = day;
            From = from;
            To = to;
            ClassSize = classSize;
            Enrolled = enrolled;
            ParseFormat = parseFormat;

            Selected = false;

            MultipleLectureIndex = 0;
        }
    }
}
