namespace CheetahToolbox.Managers;

/// <summary>
/// Contains information about the current environment.
/// </summary>
public class EnvironmentManager(ToolboxContext context) : ManagerBase(context, "Environment")
{
    public string UserName = Environment.UserName;
    public string MachineName = Environment.MachineName;
    public string MachineVersion = Environment.OSVersion.VersionString;
    public string Path = Environment.GetEnvironmentVariable("Path") ?? string.Empty;
    public string CurrentDirectory = Environment.CurrentDirectory;

    //Console.WriteLine("Cheetah Environment Starting");
    //Console.WriteLine("Settings Environment Variables");
    //Console.WriteLine("==============================");
    //Console.WriteLine($"UserName: {UserName}");
    //Console.WriteLine($"MachineName: {MachineName}");
    //Console.WriteLine($"MachineVersion: {MachineVersion}");
    //Console.WriteLine("===============================");
    //Console.WriteLine("Setting Paths");
    //Path = Environment.GetEnvironmentVariable("PATH") ?? "";
    //RegistryKey? key = Registry.CurrentUser.OpenSubKey(GlobalStrings.InstallPath);
    //Console.WriteLine(key);
    //if (key == null)
    //{
    //    key = Registry.CurrentUser.CreateSubKey(GlobalStrings.InstallPath);
    //    Console.WriteLine(key);
    //    if (key == null)
    //    {
    //        Console.WriteLine("Error: Unable to create registry key");
    //        return;
    //    }
    //    key.SetValue("InstallPath", InstallPath);
    //    return;
    //}
    //else
    //{
    //    Console.WriteLine("Key Found");
    //}
}
