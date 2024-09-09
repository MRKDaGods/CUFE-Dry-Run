using MRK.Models;
using System;
using System.Collections.Generic;

namespace MRK
{
    public class CourseSpan : Dictionary<TimeSpan, List<CourseRecord>>
    {
        public TimeSpan? MinFrom { get; private set; }
        public TimeSpan? MaxTo { get; private set; }

        public void AddCourseRecord(CourseRecord record)
        {
            if (!ContainsKey(record.From))
            {
                this[record.From] = [];
            }

            this[record.From].Add(record);

            if (!MinFrom.HasValue || record.From < MinFrom)
            {
                MinFrom = record.From;
            }

            if (!MaxTo.HasValue || record.To > MaxTo)
            {
                MaxTo = record.To;
            }
        }

        public int GetPeriodCount()
        {
            //8->8:50 period
            //9->9:50 period, etc
            if (!MinFrom.HasValue || !MaxTo.HasValue) return 0;

            return MaxTo.Value.Hours - MinFrom.Value.Hours + 1;
        }
    }
}
