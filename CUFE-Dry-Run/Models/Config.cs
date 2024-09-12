using System.IO;

namespace MRK.Models
{
    public class Config
    {
        public bool Highlight { get; set; } = true;
        public bool ShowCode { get; set; } = false;
        public bool ShowOpenOnly { get; set; } = false;
        public bool TransparencyEnabled { get; set; } = false;
        public bool WrapTimeTable { get; set; } = true;
        public int DaysPerRow { get; set; } = 2;
        public bool DisplayTransparencyWarning { get; set; } = true;

        public void Serialize(BinaryWriter writer)
        {
            writer.Write(Highlight);
            writer.Write(ShowCode);
            writer.Write(ShowOpenOnly);
            writer.Write(TransparencyEnabled);
            writer.Write(WrapTimeTable);
            writer.Write(DaysPerRow);
            writer.Write(DisplayTransparencyWarning);
        }

        public static Config Deserialize(BinaryReader reader)
        {
            return new Config
            {
                Highlight = reader.ReadBoolean(),
                ShowCode = reader.ReadBoolean(),
                ShowOpenOnly = reader.ReadBoolean(),
                TransparencyEnabled = reader.ReadBoolean(),
                WrapTimeTable = reader.ReadBoolean(),
                DaysPerRow = reader.ReadInt32(),
                DisplayTransparencyWarning = reader.ReadBoolean(),
            };
        }
    }
}
