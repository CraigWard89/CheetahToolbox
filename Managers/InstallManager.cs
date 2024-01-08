/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
#if WINDOWS
namespace CheetahToolbox.Managers;

using Contexts;
using Microsoft.Win32;
using System.Runtime.Versioning;

public class InstallManager(ToolboxContext context) : ManagerBase(context, "Installer")
{
    [SupportedOSPlatform("windows")]
    public static bool IsInstalled
    {
        get
        {
            try
            {
                return Environment.CurrentDirectory.Equals(FolderPaths.ProgramFiles, StringComparison.Ordinal);
            }
            catch { }
            return false;
        }
    }

    [SupportedOSPlatform("windows")]
    public void Execute()
    {
        Console.WriteLine("Installing CheetahTerminal..");
        RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\CheetahTerminal");
        if (key == null)
        {
            key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\CheetahTerminal");
            if (key != null)
            {
                //Console.WriteLine($"Key Found: {key}");
            }
            else
            {
                key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\CheetahTerminal");
                //Console.WriteLine($"Key Created: {key}");
            }

            string? value = key.GetValue(key.Name) as string;

            if (!string.IsNullOrEmpty(value))
            {
                Console.WriteLine($"Found: {value}");
                key.SetValue("InstallPath", FolderPaths.ProgramFiles);
            }
            //Console.WriteLine($"Found: {value}");
            //key.SetValue("InstallPath", FolderPaths.ProgramFiles);
            //Console.WriteLine($"Registry Entry: {key}");
        }

        //key.SetValue("InstallPath", FolderPaths.ProgramFiles);

        //RegistryKey uninstallKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\CheetahTerminal");
        //uninstallKey.SetValue("DisplayName", "CheetahTerminal");

        //string path = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine) ?? string.Empty;
        //if (path != null && !path.Contains(FolderPaths.ProgramFiles))
        //    Environment.SetEnvironmentVariable("Path", path + ";" + FolderPaths.ProgramFiles, EnvironmentVariableTarget.Machine);

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