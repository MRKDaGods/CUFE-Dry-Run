using System.Text;

try
{
    Console.Write("Semester: ");
    var semester = Console.ReadLine()!;

    var resource = File.ReadAllText("payload.txt");

    var date = DateTime.Now;
    var filename = string.Join("_", $"updatedata-{date:G}.dryupd".Split(Path.GetInvalidFileNameChars()));

    using var fs = new FileStream(filename, FileMode.Create);
    using var writer = new BinaryWriter(fs);

    writer.Write(date.Ticks);
    writer.Write(Convert.ToBase64String(Encoding.UTF8.GetBytes(resource)));
    writer.Write(semester);

    Console.WriteLine($"done written to {filename}");
}
catch
{
    Console.WriteLine("error");
}

Console.ReadLine();