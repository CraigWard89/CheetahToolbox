/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox;
using System.IO;
using NativeEnvironment = System.Environment;
/// <summary>
/// Contains information about the current environment.,
/// </summary>
public static class Environment
{
    public static object OSVersion { get; private set; } = NativeEnvironment.OSVersion;
    public static string UserName { get; private set; } = NativeEnvironment.UserName;
    public static string MachineName { get; private set; } = NativeEnvironment.MachineName;
    public static string MachineVersion { get; private set; } = NativeEnvironment.OSVersion.VersionString;
    public static bool IsAdmin { get; private set; } = NativeEnvironment.IsPrivilegedProcess;
    public static string ProcessPath { get; private set; } = NativeEnvironment.ProcessPath ?? string.Empty;
    public static string TempPath { get; private set; } = Path.GetTempPath();
    public static string CurrentDirectory { get; private set; } = NativeEnvironment.CurrentDirectory;
    public static string InstallPath { get; private set; } = Path.Combine(NativeEnvironment.GetFolderPath(NativeEnvironment.SpecialFolder.ProgramFiles), "CheetahToolbox");

    public static void Init()
    {
        Log.Write($"ProcessPath: {NativeEnvironment.ProcessPath}");

        Log.Write($"Args: {string.Join(" ", NativeEnvironment.GetCommandLineArgs().Skip(1))}");

        Log.Write($"UserName: {UserName}");
        Log.Write($"MachineName: {MachineName}");
        Log.Write($"MachineVersion: {MachineVersion}");
        Log.Write($"Privileged: {NativeEnvironment.IsPrivilegedProcess}");
        Log.Write($"TempPath: {TempPath}");

        Log.Write($"CurrentDirectory: {CurrentDirectory}");
        Log.Write($"InstallPath: {InstallPath}");
    }

    /// <summary>
    /// <inheritdoc path="./README.md" />
    /// Test
    /// </summary>
    /// <param name="code"></param>
    public static void Exit(int code) => NativeEnvironment.Exit(code);

    public static string GetFolderPath(NativeEnvironment.SpecialFolder folder) => NativeEnvironment.GetFolderPath(folder);
}
