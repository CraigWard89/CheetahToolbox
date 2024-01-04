namespace CheetahToolbox;

using Microsoft.Win32;
using System.Runtime.Versioning;

/// <summary>
/// Contains information about the current environment.
/// </summary>
public class CheetahEnvironment
{
    public string UserName = string.Empty;
    public string MachineName = string.Empty;
    public string MachineVersion = string.Empty;

    public string Path = string.Empty;
    public string InstallPath = string.Empty;

    public string RegistryInstallPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\CheetahTerminal";

    public CheetahEnvironment()
    {
        UserName = Environment.UserName;
        MachineName = Environment.MachineName;
        MachineVersion = Environment.OSVersion.VersionString;
    }

    [SupportedOSPlatform("windows")]
    public void Start()
    {
        Console.WriteLine("Cheetah Environment Starting");
        Console.WriteLine("Settings Environment Variables");
        Console.WriteLine("==============================");
        Console.WriteLine($"UserName: {UserName}");
        Console.WriteLine($"MachineName: {MachineName}");
        Console.WriteLine($"MachineVersion: {MachineVersion}");
        Console.WriteLine("===============================");
        Console.WriteLine("Setting Paths");
        Path = Environment.GetEnvironmentVariable("PATH") ?? "";
        RegistryKey? key = Registry.CurrentUser.OpenSubKey(RegistryInstallPath);
        Console.WriteLine(key);
        if (key == null)
        {
            key = Registry.CurrentUser.CreateSubKey(RegistryInstallPath);
            Console.WriteLine(key);
            if (key == null)
            {
                Console.WriteLine("Error: Unable to create registry key");
                return;
            }
            key.SetValue("InstallPath", InstallPath);
            return;
        }
        else
        {
            Console.WriteLine("Key Found");
        }
    }
}
