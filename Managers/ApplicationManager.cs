/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
#if WINDOWS
namespace CheetahToolbox;
/// <summary>
/// WIP: This is a placeholder for now.
/// </summary>
public class ApplicationManager(ToolboxContext context) : ManagerBase(context, "Applications")
{
    // TODO: Cache Locally Installed Programs
    private static readonly List<AppEntry> apps = [];

    private static AppEntry? GetApp(string path)
    {
        if (!Directory.Exists(path)) return null;

        try
        {
            string[] files = Directory.GetFiles(path, "*.exe", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                // WIP: Cache AppEntry
                return new AppEntry(Path.GetFileNameWithoutExtension(file), null, null, file, AppEntry.AppSource.LOCAL);
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
        AppEntry? app = GetApp(path);
        if (app == null) return;
        apps.Add(app);
    }

    public void Scan()
    {
        Console.WriteLine("Application Manager Scanning..");
        Stopwatch sw = Stopwatch.StartNew();

        string startMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
        Log.Super($"Start Menu Path: {startMenuPath}");

        string startMenuPath2 = Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms);
        Log.Super($"Start Menu Path 2: {startMenuPath2}");

        string programDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        Log.Super($"Program Data Path: {programDataPath}");

        List<string> programDataFilesDirs = [.. Directory.GetDirectories(programDataPath)];
        foreach (string dir in programDataFilesDirs)
        {
            Log.Super($"\tProgram Data Directory: {dir}");
            ScanAppFolder(dir);
        }

        string commonPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles);
        Log.Super($"Common Program Files Path: {commonPath}");

        List<string> commonFilesDirs = [.. Directory.GetDirectories(commonPath)];
        foreach (string dir in commonFilesDirs)
        {
            Log.Super($"\tCommon Program Directory: {dir}");
            ScanAppFolder(dir);
        }

        string commonPathX86 = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86);
        Log.Super($"Common Program X86 Files Path: {commonPathX86}");

        List<string> commonFilesX86Dirs = [.. Directory.GetDirectories(commonPathX86)];
        foreach (string dir in commonFilesX86Dirs)
        {
            Log.Super($"\tCommon Program X86 Directory: {dir}");
            ScanAppFolder(dir);
        }

        string programPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        Log.Super($"Program Files Path: {programPath}");

        List<string> programFilesDirs = [.. Directory.GetDirectories(programPath)];
        foreach (string dir in programFilesDirs)
        {
            Log.Super($"\tProgram Directory: {dir}");
            ScanAppFolder(dir);
        }

        string programPathX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
        Log.Super($"Program X86 Files Path: {programPathX86}");

        List<string> commonFilesDirsX86 = [.. Directory.GetDirectories(commonPathX86)];
        foreach (string dir in commonFilesDirsX86)
        {
            Log.Super($"\tCommon Program X86 Directory: {dir}");
            ScanAppFolder(dir);
        }

        sw.Stop();
        Console.WriteLine($"Cached: {apps.Count} Applications: {sw.ElapsedMilliseconds}ms");
    }
}
#endif