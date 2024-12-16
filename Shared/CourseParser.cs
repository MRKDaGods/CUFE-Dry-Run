using MRK.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MRK
{
    public abstract class CourseParser<T> : ICourseParser
    {
        private const int MinHour = 8;

        public List<CourseRecord> CourseRecords { get; set; }

        public CourseParser()
        {
            // register the parser
            CourseRegistry.RegisterParser(this);

            CourseRecords = [];
        }

        public abstract void Parse(T rawRecords);

        protected void ValidateTimeSpan(ref TimeSpan time)
        {
            if (time.Hours < MinHour)
            {
                time = time.Add(new TimeSpan(12, 0, 0));
            }
        }

        protected void PostProcessRecords()
        {
            // sort courses
            CourseRegistry.Sort();

            // sort records by day and time
            CourseRecords = [.. CourseRecords.OrderBy(x => x.Day).ThenBy(x => x.From)];

            // set some flags for Courses Defs
            CourseRegistry.UpdateCourseFlags(this);
        }
    }
}
