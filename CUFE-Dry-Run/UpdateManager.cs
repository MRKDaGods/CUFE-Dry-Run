using MRK.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRK
{
    public class UpdateManager
    {
        private const string UpdateFileName = "updatedata.dryupd";
        private const string UpdateAppVersionUrl = "https://github.com/MRKDaGods/CUFE-Dry-Run/raw/{0}/Data/appversion";
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
                using var reader = new BinaryReader(stream);

                var isAppUpdate = reader.ReadBoolean();
                var lastUpdated = reader.ReadInt64();

                var data = reader.ReadString();
                var resourceBytes = Convert.FromBase64String(data);

                var semester = reader.ReadString();
                var version = reader.ReadString();

                UpdateData = new()
                {
                    IsAppUpdate = isAppUpdate,
                    LastUpdated = new DateTime(lastUpdated),
                    Resource = isAppUpdate ? string.Empty : Encoding.UTF8.GetString(resourceBytes),
                    Semester = semester,
                    Version = version,
                };

                if (!isAppUpdate)
                {
                    Console.WriteLine("Loading timetable update");

                    if (save)
                    {
                        using var fs = new FileStream(UpdateFileName, FileMode.Create);
                        using var writer = new BinaryWriter(fs);

                        writer.Write(isAppUpdate);
                        writer.Write(lastUpdated);
                        writer.Write(data);
                        writer.Write(semester);
                        writer.Write(version);
                        writer.Close();

                        Task.Delay(2000)
                            .ContinueWith(_ => Application.Restart());
                    }

                    Console.WriteLine($"Update data loaded successfully {UpdateData}");
                }
                else if (save)
                {
                    // install update
                    Console.WriteLine("Installing app update...");

                    // write data somewhere
                    var updateZipFilename = Path.GetTempFileName();
                    File.WriteAllBytes(updateZipFilename, resourceBytes);

                    // start updater
                    if (!File.Exists("Updater.exe"))
                    {
                        Console.WriteLine("Updater.exe not found");
                        return false;
                    }

                    var asm = Assembly.GetExecutingAssembly();
                    var dir = Path.GetDirectoryName(asm.Location);
                    var exeName = asm.GetName().Name;

                    var updaterArgs = $"--updateZipFilename=\"{updateZipFilename}\" --targetDirectory=\"{dir}\" --executableName=\"{exeName}\"";
                    Console.WriteLine($"Running Updater.exe as admin\nArgs: {updaterArgs}");

                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "Updater.exe",
                        Arguments = updaterArgs,
                        UseShellExecute = true,
                        Verb = "runas"
                    });
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot load update data ({ex})");
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

            string[] urls =
            [
                string.Format(UpdateAppVersionUrl, channel),
                    string.Format(UpdateVersionUrl, channel)
            ];

            using var client = new HttpClient();

            foreach (var url in urls)
            {
                Stream content;
                try
                {
                    Console.WriteLine($"GET {url}");
                    content = await client.GetStreamAsync(url);

                    using var reader = new BinaryReader(content);
                    var isAppUpdate = reader.ReadBoolean();
                    var lastUpdated = reader.ReadInt64();
                    var semester = reader.ReadString();
                    var version = reader.ReadString();

                    var needsUpdate = isAppUpdate ? (Version.TryParse(version, out var v) && v > Constants.Version) 
                        : (UpdateData == null || lastUpdated > UpdateData.Value.LastUpdated.Ticks);

                    if (needsUpdate)
                    {
                        var date = new DateTime(lastUpdated);
                        var newData = new UpdateData
                        {
                            IsAppUpdate = isAppUpdate,
                            LastUpdated = date,
                            Semester = semester,
                            Version = version,
                        };

                        Console.WriteLine($"New update found: {newData}");
                        return newData;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Checking for update failed ({ex.GetType().Name})");
                    continue;
                }
            }

            return null;
        }

        public async Task<bool> DownloadUpdate(UpdateData updateData, string channel = "main")
        {
            Console.WriteLine($"Downloading update ({updateData}) on channel {channel}");

            try
            {
                var client = new HttpClient();
                var filename = string.Join("_", $"updatedata-{updateData.LastUpdated.Ticks}.dryupd".Split(Path.GetInvalidFileNameChars()));

                var url = string.Format(UpdateUrl, channel, filename);
                Console.WriteLine($"GET {url}");

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
