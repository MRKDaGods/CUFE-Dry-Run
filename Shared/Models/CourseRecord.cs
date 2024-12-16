using System;
using System.Collections.Generic;

namespace MRK.Models
{
    public enum CourseRecordType
    {
        None,
        Lecture,
        Tutorial
    }

    public enum CourseRecordDay
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
        IrregularWithName,
        Excel
    }

    public class CourseDayComparer : IComparer<CourseRecordDay>
    {
        public int Compare(CourseRecordDay x, CourseRecordDay y)
        {
            return x.CompareTo(y);
        }
    }

    public class CourseRecord(
        Course course,
        int group,
        CourseRecordType type,
        CourseRecordDay day,
        TimeSpan from,
        TimeSpan to,
        int classSize,
        int enrolled,
        int waiting,
        string status,
        string location,
        CourseParseFormat parseFormat)
    {
        public Course Course { get; init; } = course;
        public int Group { get; init; } = group;
        public CourseRecordType Type { get; init; } = type;
        public CourseRecordDay Day { get; init; } = day;
        public TimeSpan From { get; init; } = from;
        public TimeSpan To { get; init; } = to;
        public int ClassSize { get; init; } = classSize;
        public int Enrolled { get; init; } = enrolled;
        public int Waiting { get; init; } = waiting;
        public string Status { get; init; } = status;
        public string Location { get; init; } = location;
        public CourseParseFormat ParseFormat { get; init; } = parseFormat;
        public bool Selected { get; set; } = false;
        public int MultipleLectureIndex { get; set; } = 0;

        public bool IsOpen => Status == "Opened";
    }
}
