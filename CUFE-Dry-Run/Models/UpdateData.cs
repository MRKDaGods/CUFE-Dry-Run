using System;

namespace MRK.Models
{
    public struct UpdateData
    {
        public bool IsAppUpdate { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Resource { get; set; }
        public string Semester { get; set; }
        public string Version { get; set; }

        public override readonly string ToString()
        {
            return IsAppUpdate ? $"App update v{Version} at {LastUpdated:G}" : $"TimeTable update {Semester} {LastUpdated:G}";
        }
    }
}
