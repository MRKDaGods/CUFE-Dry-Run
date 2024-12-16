using MRK.Models;
using System.Collections.Generic;

namespace MRK
{
    public interface ICourseParser
    {
        public List<CourseRecord> CourseRecords { get; protected set; }
    }
}
