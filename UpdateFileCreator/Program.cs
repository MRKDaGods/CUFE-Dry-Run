using System.Text;
using MRK.Models;

try
{
    Console.WriteLine("1-Timetable update\n2-App update\n3-Excel Update");

    bool hasChoice = false;
    int choice;
    do
        hasChoice = int.TryParse(Console.ReadLine(), out choice);
    while (!hasChoice || choice > 3 || choice < 1);

    bool isAppUpdate = choice == 2;

    string semester = "";
    string resource = "";
    string version = "";
    if (!isAppUpdate)
    {
        Console.Write("Semester: ");
        semester = Console.ReadLine()!;

        // read timetable res
        resource = Convert.ToBase64String(Encoding.UTF8.GetBytes(File.ReadAllText("payload.txt")));
    }
    else
    {
        Console.Write("Version: ");
        version = Console.ReadLine()!;

        resource = Convert.ToBase64String(File.ReadAllBytes("payload.zip"));
    }

    // update features
    foreach (var v in Enum.GetValues<UpdateFeatures>())
    {
        Console.WriteLine($"{(int)v}-{v}");
    }

    Console.Write("Features (Comma seperated): ");
    var features = Console.ReadLine()!.Split(',').Select(int.Parse).ToArray();

    var updateFeatures = UpdateFeatures.None;
    foreach (var f in features)
    {
        updateFeatures |= (UpdateFeatures)f;
    }

    var extraResources = string.Empty;
    if (updateFeatures.HasFlag(UpdateFeatures.XLSX))
    {
        Console.Write("Excel file: ");
        extraResources = Convert.ToBase64String(File.ReadAllBytes(Console.ReadLine()!));
    }

    // actual binary write
    var date = DateTime.Now;
    var filename = string.Join("_", $"updatedata-{date.Ticks}.dryupd".Split(Path.GetInvalidFileNameChars()));

    using var fs = new FileStream(filename, FileMode.Create);
    using var writer = new BinaryWriter(fs);

    writer.Write(isAppUpdate);
    writer.Write(date.Ticks);
    writer.Write(resource);
    writer.Write(semester);
    writer.Write(version);
    writer.Write((uint)updateFeatures);
    writer.Write(extraResources);

    // write version
    using var versionFs = new FileStream(isAppUpdate ? "appversion" : "version", FileMode.Create);
    using var versionWriter = new BinaryWriter(versionFs);
    versionWriter.Write(isAppUpdate);
    versionWriter.Write(date.Ticks);
    versionWriter.Write(semester);
    versionWriter.Write(version);
    writer.Write((uint)updateFeatures);

    Console.WriteLine($"done written to {filename}");
}
catch
{
    Console.WriteLine("error");
}

Console.ReadLine();