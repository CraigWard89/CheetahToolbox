namespace WinToolbox.Registry;

using System.Runtime.Versioning;
using CheeseyUtils;
using Microsoft.Win32;

internal static class Scanner
{
    [SupportedOSPlatform("windows")]
    public static void DoScan()
    {
        Log.Warning("This feature is still in development and may not work properly.");

        var uninstallKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall")
            ?? throw new Exception("Uninstall key not found.");

        foreach (var subKeyName in uninstallKey.GetSubKeyNames())
        {
            var subKey = uninstallKey.OpenSubKey(subKeyName);
            if (subKey is not null)
            {
                if (CheckUninstallEntry(subKey))
                {
                    uninstallKey.DeleteSubKey(subKeyName, true);
                }
            }
        }
    }

    /// <summary>
    /// Checks if the given uninstall entry is a ghost app.
    /// </summary>
    /// <param name="subKey"></param>
    /// <returns>true if the entry is a ghost app, otherwise false</returns>
    [SupportedOSPlatform("windows")]
    private static bool CheckUninstallEntry(RegistryKey subKey)
    {
        bool isGhostApp = false;

        var displayName = subKey.GetValue("DisplayName")?.ToString();
        var displayIcon = subKey.GetValue("DisplayIcon")?.ToString();
        var installLocation = subKey.GetValue("InstallLocation")?.ToString();
        var uninstallString = subKey.GetValue("UninstallString")?.ToString();

        if (!string.IsNullOrEmpty(displayIcon))
        {
            displayIcon = displayIcon.Split(',')[0];
            if (!File.Exists(displayIcon))
            {
                //Log.WriteLine($"{Colors.DarkRed}Invalid{Colors.Gray} Display Icon: {displayIcon}");
                isGhostApp = true;
            }
        }

        if (!string.IsNullOrEmpty(installLocation))
        {
            if (!Directory.Exists(installLocation))
            {
                //Log.WriteLine($"{Colors.DarkRed}Invalid{Colors.Gray} Install Location: {installLocation}");
                isGhostApp = true;
            }
        }

        if (isGhostApp && !string.IsNullOrEmpty(displayName))
        {
            Log.Info($"{Colors.DarkOrange}{displayName}{Log.DefaultColor} is a ghost app");
        }

        return false; // TODO: Return true if the entry is a ghost app
    }
}
