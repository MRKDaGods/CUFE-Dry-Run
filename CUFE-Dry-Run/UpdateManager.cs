using MRK.Models;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRK
{
    public class UpdateManager
    {
        private const string UpdateFileName = "updatedata.dryupd";

        private static UpdateManager? _instance;

        public UpdateData? UpdateData { get; private set; }

        public static UpdateManager Instance
        {
            get
            {
                return _instance ??= new();
            }
        }

        public bool LoadUpdate(string? filename, bool save = false)
        {
            if (filename == null)
            {
                filename = UpdateFileName;
            }

            Console.WriteLine($"Loading update data from {filename}");

            try
            {
                using (var fs = new FileStream(filename, FileMode.Open))
                using (var reader = new BinaryReader(fs))
                {
                    var lastUpdated = reader.ReadInt64();

                    var data = reader.ReadString();
                    var resource = Encoding.UTF8.GetString(Convert.FromBase64String(data));

                    var semester = reader.ReadString() ?? string.Empty;

                    UpdateData = new()
                    {
                        LastUpdated = new DateTime(lastUpdated),
                        Resource = resource,
                        Semester = semester,
                    };

                    if (save)
                    {
                        File.Copy(filename, UpdateFileName, true);
                        Task.Delay(3000)
                            .ContinueWith(_ => Application.Restart());
                    }

                    Console.WriteLine($"Update data loaded successfully {semester} at {UpdateData.Value.LastUpdated:G}");
                    return true;
                }
            }
            catch
            {
                Console.WriteLine("Cannot load update data");
                return false;
            }
        }
    }
}
