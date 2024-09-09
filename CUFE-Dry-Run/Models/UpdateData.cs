using System;

namespace MRK.Models
{
    public struct UpdateData
    {
        public DateTime LastUpdated { get; set; }
        public string Resource { get; set; }
        public string Semester { get; set; }
    }
}
