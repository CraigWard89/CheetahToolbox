#if WINDOWS || EDITOR
namespace CheetahToolbox;

using System.Diagnostics;

public static class KnownApplications
{
}

/// <summary>
/// WIP: This is a placeholder for now.
/// </summary>
public static class ApplicationManager
{
    // TODO: Cache Locally Installed Programs
    private static readonly List<AppEntry> apps = [];

    public static void Start()
    {
        Console.WriteLine("Application Manager Starting..");
        Stopwatch sw = Stopwatch.StartNew();
        Scan();
        sw.Stop();
        Console.WriteLine($"Application Manager Started: {sw.ElapsedMilliseconds}ms");
    }

    private static AppEntry? GetApp(string path)
    {
        if (!Directory.Exists(path)) return null;

        try
        {
            string[] files = Directory.GetFiles(path, "*.exe", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                // WIP: Cache AppEntry
                return new AppEntry(Path.GetFileNameWithoutExtension(file), null, AppEntry.AppSource.LOCAL);
            }
            return null;
        }
        catch /*(UnauthorizedAccessException ex)*/
        {
            // TODO: Abort and request admin
            // Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
    }

    private static void ScanAppFolder(string path)
    {
        //Console.WriteLine($"Scanning App Folder: {path}");

        AppEntry? app = GetApp(path);
        if (app == null) return;

        //Console.WriteLine($"Application Found: {app.Name}");
    }

    private static void Scan()
    {
        string startMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
        //Console.WriteLine($"Start Menu Path: {startMenuPath}");

        string startMenuPath2 = Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms);
        //Console.WriteLine($"Start Menu Path 2: {startMenuPath2}");

        string programDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        //Console.WriteLine($"Program Data Path: {programDataPath}");

        List<string> programDataFilesDirs = [.. Directory.GetDirectories(programDataPath)];
        foreach (string dir in programDataFilesDirs)
        {
            //Console.WriteLine($"\tProgram Data Directory: {dir}");
            ScanAppFolder(dir);
        }

        string commonPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles);
        //Console.WriteLine($"Common Program Files Path: {commonPath}");

        List<string> commonFilesDirs = [.. Directory.GetDirectories(commonPath)];
        foreach (string dir in commonFilesDirs)
        {
            //Console.WriteLine($"\tCommon Program Directory: {dir}");
            ScanAppFolder(dir);
        }

        string commonPathX86 = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86);
        //Console.WriteLine($"Common Program X86 Files Path: {commonPathX86}");

        List<string> commonFilesX86Dirs = [.. Directory.GetDirectories(commonPathX86)];
        foreach (string dir in commonFilesX86Dirs)
        {
            //Console.WriteLine($"\tCommon Program X86 Directory: {dir}");
            ScanAppFolder(dir);
        }

        string programPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        //Console.WriteLine($"Program Files Path: {programPath}");

        List<string> programFilesDirs = [.. Directory.GetDirectories(programPath)];
        foreach (string dir in programFilesDirs)
        {
            //Console.WriteLine($"\tProgram Directory: {dir}");
            ScanAppFolder(dir);
        }

        string programPathX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
        //Console.WriteLine($"Program X86 Files Path: {programPathX86}");

        List<string> commonFilesDirsX86 = [.. Directory.GetDirectories(commonPathX86)];
        foreach (string dir in commonFilesDirsX86)
        {
            //Console.WriteLine($"\tCommon Program X86 Directory: {dir}");
            ScanAppFolder(dir);
        }

        Console.WriteLine($"Cached: {apps.Count} Applications");
    }
}
#endif