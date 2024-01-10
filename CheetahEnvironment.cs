/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox;
/// <summary>
/// Contains information about the current environment.
/// </summary>
public class CheetahEnvironment : ManagerBase
{
    public string UserName = Environment.UserName;
    public string MachineName = Environment.MachineName;
    public string MachineVersion = Environment.OSVersion.VersionString;
    //public string Path = Environment.GetEnvironmentVariable("Path") ?? string.Empty;
    public bool IsAdmin = Environment.IsPrivilegedProcess;
    public string ProcessPath = Environment.ProcessPath ?? string.Empty;
    public string TempPath = Path.GetTempPath();
    public string CurrentDirectory = Environment.CurrentDirectory;
    public string InstallPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "CheetahToolbox");


    public CheetahEnvironment(ToolboxContext context) : base(context, "Environment")
    {
        Log.Write($"ProcessPath: {Environment.ProcessPath}");
        Log.Write($"Args: {string.Join(" ", Environment.GetCommandLineArgs().Skip(1))}");

        Log.Write($"UserName: {UserName}");
        Log.Write($"MachineName: {MachineName}");
        Log.Write($"MachineVersion: {MachineVersion}");
        //Log.Write($"Path: {Path}");
        Log.Write($"Privileged: {Environment.IsPrivilegedProcess}");
        Log.Write($"TempPath: {TempPath}");

        Log.Write($"CurrentDirectory: {CurrentDirectory}");
        Log.Write($"InstallPath: {InstallPath}");
    }
}
