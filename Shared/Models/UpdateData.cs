using System;

namespace MRK.Models
{
    [Flags]
    public enum UpdateFeatures : uint
    {
        None = 0,
        XLSX = 1 << 0,
        Regex = 1 << 1
    }

    public struct UpdateData
    {
        public bool IsAppUpdate { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Resource { get; set; }
        public string Semester { get; set; }
        public string Version { get; set; }
        public UpdateFeatures Features { get; set; } // 4 bytes
        public string Extra { get; set; }

        public override readonly string ToString()
        {
            return IsAppUpdate ? $"App update v{Version} at {LastUpdated:G}" : $"TimeTable update {Semester} {LastUpdated:G}";
        }
    }
}
