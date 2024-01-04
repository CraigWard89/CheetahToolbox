#if WINDOWS || WINDOWS_FAKE
namespace CheetahToolbox.OS.Windows;

using System.Runtime.Versioning;
using Microsoft.Win32;

public static class Installer
{
    [SupportedOSPlatform("windows")]
    public static bool IsInstalled => Environment.CurrentDirectory.Equals(FolderPaths.ProgramFiles, StringComparison.Ordinal);

    [SupportedOSPlatform("windows")]
    public static void Start()
    {
        Log.Write("Installing CheetahTerminal..");

        RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\CheetahTerminal");
        key.SetValue("InstallPath", FolderPaths.ProgramFiles);

        RegistryKey uninstallKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\CheetahTerminal");
        uninstallKey.SetValue("DisplayName", "CheetahTerminal");

        string path = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine) ?? string.Empty;
        if (path != null && !path.Contains(FolderPaths.ProgramFiles))
            Environment.SetEnvironmentVariable("Path", path + ";" + FolderPaths.ProgramFiles, EnvironmentVariableTarget.Machine);

        //if (!Directory.Exists(FolderPaths.LocalAppData))
        //    _ = Directory.CreateDirectory(FolderPaths.LocalAppData);

        //if (!Directory.Exists(FolderPaths.RoamAppData))
        //    _ = Directory.CreateDirectory(FolderPaths.RoamAppData);

        //if (!Directory.Exists(FolderPaths.ProgramFiles))
        //    _ = Directory.CreateDirectory(FolderPaths.ProgramFiles);

        //Process[] others = Process.GetProcessesByName("CheetahTerminal");
        //List<Task> tasks = [];
        //foreach (Process o in others)
        //{
        //    Task task = Task.Run(() =>
        //    {
        //        if (o.Id != Environment.ProcessId && o.StartInfo.WorkingDirectory.Equals(FolderPaths.ProgramFiles, StringComparison.Ordinal))
        //        {
        //            Console.WriteLine($"Killing Old CheetahTerminal: pid {o.Id}");
        //            o.Kill();
        //        }
        //    });
        //    tasks.Add(task);
        //}
        //Task.WaitAll([.. tasks]);

        //CopyFolder(Environment.CurrentDirectory, FolderPaths.ProgramFiles);

        Log.Write($"Installed CheetahTerminal -> {FolderPaths.ProgramFiles}");
    }

    private static void CopyFolder(string source, string target, bool overwrite = false)
    {
        if (!Directory.Exists(target))
            _ = Directory.CreateDirectory(target);

        try
        {
            foreach (string file in Directory.GetFiles(source))
            {
                string fileName = Path.GetFileName(file);
                string destination = Path.Combine(target, fileName);
                File.Copy(file, destination, overwrite);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        try
        {
            foreach (string directory in Directory.GetDirectories(source))
            {
                string dirName = Path.GetFileName(directory);
                string destination = Path.Combine(target, dirName);
                CopyFolder(directory, destination, overwrite);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}
#endif