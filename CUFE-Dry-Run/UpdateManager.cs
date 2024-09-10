using MRK.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MRK
{
    public class UpdateManager
    {
        private const string UpdateFileName = "updatedata.dryupd";
        private const string UpdateVersionUrl = "https://github.com/MRKDaGods/CUFE-Dry-Run/raw/{0}/Data/version";
        private const string UpdateUrl = "https://github.com/MRKDaGods/CUFE-Dry-Run/raw/{0}/Data/{1}";

        private static UpdateManager? _instance;

        public UpdateData? UpdateData { get; private set; }

        public static UpdateManager Instance
        {
            get
            {
                return _instance ??= new();
            }
        }

        public bool LoadUpdate(Stream stream, bool save = false)
        {
            try
            {
                using (var reader = new BinaryReader(stream))
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
                        using var fs = new FileStream(UpdateFileName, FileMode.Create);
                        using var writer = new BinaryWriter(fs);

                        writer.Write(lastUpdated);
                        writer.Write(data);
                        writer.Write(semester);
                        writer.Close();

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

        public bool LoadUpdate(string? filename, bool save = false)
        {
            if (string.IsNullOrEmpty(filename))
            {
                filename = UpdateFileName;
            }

            Console.WriteLine($"Loading update data from {filename}");

            try
            {
                using var fs = new FileStream(filename, FileMode.Open);
                return LoadUpdate(fs, save);
            }
            catch
            {
                Console.WriteLine("Cannot load update data");
                return false;
            }
        }

        public async Task<UpdateData?> CheckForUpdates(string channel = "main")
        {
            Console.WriteLine($"Checking for updates on channel {channel}");

            try
            {
                var client = new HttpClient();
                var content = await client.GetStreamAsync(string.Format(UpdateVersionUrl, channel));

                using var reader = new BinaryReader(content);
                var lastUpdated = reader.ReadInt64();
                var semester = reader.ReadString();

                if (UpdateData == null || lastUpdated > UpdateData.Value.LastUpdated.Ticks)
                {
                    var date = new DateTime(lastUpdated);
                    Console.WriteLine($"New update found: {semester} {date:G}");

                    return new UpdateData
                    {
                        LastUpdated = date,
                        Semester = semester
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Checking for update failed ({ex.GetType().Name})");
            }

            return null;
        }

        public async Task<bool> DownloadUpdate(UpdateData updateData, string channel = "main")
        {
            Console.WriteLine($"Downloading update ({updateData.Semester} {updateData.LastUpdated:G}) on channel {channel}");

            try
            {
                var client = new HttpClient();
                var filename = string.Join("_", $"updatedata-{updateData.LastUpdated.Ticks}.dryupd".Split(Path.GetInvalidFileNameChars()));
                var content = await client.GetStreamAsync(string.Format(UpdateUrl, channel, filename));
                return LoadUpdate(content, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Downloading update failed ({ex.GetType().Name})");
            }

            return false;
        }
    }
}
