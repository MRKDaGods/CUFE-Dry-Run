using System.Diagnostics;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using static System.Console;

using var customWriter = new CustomWriter();

// parse cmdline
var cmdLine = GetOriginalCommandLine();
WriteLine($"CmdLine: {cmdLine}");

var cmdMatches = Regex.Matches(cmdLine, "--(\\w+)[\"'=]{0,2}((?:(?<=[\"'])[^\"']*(?:[^\"']+)*?(?=['\"]))|([^\"'\\s]*(?:[^\"']+)*?))[\"']?");

var cmdOptions = new Dictionary<string, string>(
    cmdMatches.Select(x => new KeyValuePair<string, string>(x.Groups[1].Value, x.Groups[2].Value)));

EnsureOptionExists("updateZipFilename", out var updateZipFilename);
EnsureOptionExists("targetDirectory", out var targetDirectory);

// wait for exit
if (cmdOptions.TryGetValue("executableName", out var executableName))
{
    WriteLine($"Checking for processes with name {executableName}");

    var procs = Process.GetProcessesByName(executableName);
    if (procs.Length > 0)
    {
        WriteLine($"Found {string.Join(' ', procs.Select(x => $"pid={x.Id}"))}\nKilling...");

        foreach (var proc in procs)
        {
            WriteLine($"Killing {proc.Id}");
            proc.Kill();
        }
    }
}

if (!cmdOptions.TryGetValue("proxy", out var proxy) || proxy == "false")
{
    // copy ourselves somewhere
    // since we might get updated too

    // create temp dir
    var tempDir = Directory.CreateTempSubdirectory("mrkdryupd");
    WriteLine($"Copying ourselves to {tempDir.FullName}");

    // write temp log
    customWriter.OutputDir = tempDir.FullName;

    var asm = Assembly.GetExecutingAssembly();
    var asmDir = Path.GetDirectoryName(asm.Location);
    var asmName = asm.GetName().Name;

    string[] updaterFiles = [$"{asmName}.exe", $"{asmName}.dll", $"{asmName}.deps.json", $"{asmName}.runtimeconfig.json"];

    // copy these to tempdir
    string? tmpExecutablePath = null;
    foreach (var updaterFile in updaterFiles)
    {
        var src = Path.Join(asmDir, updaterFile);
        if (File.Exists(src))
        {
            var dst = Path.Join(tempDir.FullName, updaterFile);
            File.Copy(src, dst);

            if (Path.GetExtension(dst) == ".exe")
            {
                tmpExecutablePath = dst;
            }

            WriteLine($"{src} -> {dst}");
        }
    }

    if (tmpExecutablePath == null)
    {
        WriteLine("[ERROR] Cannot locate temp executable path");
        return;
    }

    WriteLine("Starting proxy updater...");

    // run proxy executable with --proxy
    Process.Start(new ProcessStartInfo
    {
        FileName = tmpExecutablePath,
        Arguments = string.Join(' ', cmdLine, "--proxy", $"--proxyDir=\"{tempDir}\""),
    });

    return;
}

WriteLine("Proxy instance");
EnsureOptionExists("proxyDir", out var proxyDir);

// check for old log
var oldLogPath = Path.Join(proxyDir, "UpdaterLog.txt");
if (File.Exists(oldLogPath))
{
    customWriter.OldLog = File.ReadAllText(oldLogPath);
}

// proxy instance
if (!File.Exists(updateZipFilename))
{
    WriteLine("Update file doesnt exist");
    ScheduleDeletion(proxyDir);
}

var updateDir = Path.Join(proxyDir, "updateZipExtracted");
Directory.CreateDirectory(updateDir);

// extract zip
ZipFile.ExtractToDirectory(updateZipFilename, updateDir);

WriteLine("Waiting...");
await Task.Delay(3000);

// delete old dir
if (Directory.Exists(targetDirectory))
{
    try
    {
        Directory.Delete(targetDirectory, true);
    }
    catch
    {
        // silent
    }
}

// create target dir
Directory.CreateDirectory(targetDirectory);
customWriter.OutputDir = targetDirectory;

// copy extracted files to dir
foreach (var file in Directory.EnumerateFiles(updateDir))
{
    var dst = Path.Join(targetDirectory, Path.GetFileName(file));
    File.Copy(file, dst);

    WriteLine($"{file} -> {dst}");
}

WriteLine("Waiting...");
await Task.Delay(3000);

// start executable
if (executableName != null)
{
    var execPath = Path.Join(targetDirectory, executableName + ".exe");
    WriteLine($"ExecPath={execPath}");
    if (File.Exists(execPath))
    {
        Process.Start(execPath);
    }
}

customWriter.Output();

// clean ourselves
ScheduleDeletion(proxyDir);

void EnsureOptionExists(string option, out string value)
{
    if (!cmdOptions.TryGetValue(option, out var val))
    {
        throw new ArgumentException($"Missing option \"{option}\"\n" +
            "Usage: --updateZipFilename --targetDirectory [--proxy] [--executableName]");
    }

    // workaround possible null ref
    value = val;
}

static void ScheduleDeletion(string directoryPath)
{
    WriteLine("Cleaning...");

    var batchFilePath = Path.Combine(Path.GetTempPath(), "mrkdryupddel.bat");
    using (var writer = new StreamWriter(batchFilePath))
    {
        writer.WriteLine("@echo off");
        writer.WriteLine("timeout /t 2 > nul");
        writer.WriteLine($"rmdir /s /q \"{directoryPath}\"");
        writer.WriteLine("del \"%~f0\"");
    }

    Process.Start(new ProcessStartInfo
    {
        FileName = batchFilePath,
        CreateNoWindow = true,
        WindowStyle = ProcessWindowStyle.Hidden,
        UseShellExecute = false
    });

    Environment.Exit(0);
}

[DllImport("kernel32", CharSet = CharSet.Auto)]
static extern IntPtr GetCommandLine();

static string GetOriginalCommandLine()
{
    var cmd = GetCommandLine();
    var result = Marshal.PtrToStringAuto(cmd) ?? "";
    return result;
}

class CustomWriter : TextWriter, IDisposable
{
    private readonly TextWriter _stdWriter;
    private readonly StringWriter _captured;

    public override Encoding Encoding => Encoding.ASCII;

    public string? OutputDir { get; set; }
    public string? OldLog { get; set; }

    public CustomWriter()
    {
        _stdWriter = Out;
        _captured = new();
        SetOut(this);
    }

    public override void Write(string? output)
    {
        _captured.Write(output);
        _stdWriter.Write(output);
    }

    public override void WriteLine(string? output)
    {
        _captured.WriteLine(output);
        _stdWriter.WriteLine(output);
    }

    public void Output()
    {
        if (OutputDir != null && Directory.Exists(OutputDir))
        {
            // write captured
            File.WriteAllText(Path.Join(OutputDir, "UpdaterLog.txt"), (OldLog ?? string.Empty) + _captured.ToString());
        }
    }

    protected override void Dispose(bool disposing)
    {
        Output();
        base.Dispose(disposing);
    }
}