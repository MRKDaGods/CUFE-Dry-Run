using System.Text;

try
{
    Console.WriteLine("1-Timetable update\n2-App update");

    bool hasChoice = false;
    int choice;
    do 
        hasChoice = int.TryParse(Console.ReadLine(), out choice);
    while (!hasChoice || choice > 2 || choice < 1);

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

    var date = DateTime.Now;
    var filename = string.Join("_", $"updatedata-{date.Ticks}.dryupd".Split(Path.GetInvalidFileNameChars()));

    using var fs = new FileStream(filename, FileMode.Create);
    using var writer = new BinaryWriter(fs);

    writer.Write(isAppUpdate);
    writer.Write(date.Ticks);
    writer.Write(resource);
    writer.Write(semester);
    writer.Write(version);

    // write version
    using var versionFs = new FileStream(isAppUpdate ? "appversion" : "version", FileMode.Create);
    using var versionWriter = new BinaryWriter(versionFs);
    versionWriter.Write(isAppUpdate);
    versionWriter.Write(date.Ticks);
    versionWriter.Write(semester);
    versionWriter.Write(version);

    Console.WriteLine($"done written to {filename}");
}
catch
{
    Console.WriteLine("error");
}

Console.ReadLine();