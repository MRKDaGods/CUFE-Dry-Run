using System.IO;

namespace MRK
{
    public class Config
    {
        public bool Highlight { get; set; } = false;
        public bool ShowCode { get; set; } = false;
        public bool ShowOpenOnly { get; set; } = false;

        public void Serialize(BinaryWriter writer)
        {
            writer.Write(Highlight);
            writer.Write(ShowCode);
            writer.Write(ShowOpenOnly);
        }

        public static Config Deserialize(BinaryReader reader)
        {
            return new Config
            {
                Highlight = reader.ReadBoolean(),
                ShowCode = reader.ReadBoolean(),
                ShowOpenOnly = reader.ReadBoolean()
            };
        }
    }
}
