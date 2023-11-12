namespace WinToolbox.Registry;

using System.Runtime.Versioning;
using CheeseyUtils;
using Microsoft.Win32;

internal static class Scanner
{
    [SupportedOSPlatform("windows")]
    public static void DoScan()
    {
        // TODO: Check for ghost apps in "Uninstall" registry key
        var uninstallKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
        if (uninstallKey == null) throw new Exception("Uninstall key not found.");
        foreach (var subKeyName in uninstallKey.GetSubKeyNames())
        {
            var subKey = uninstallKey.OpenSubKey(subKeyName);
            if (subKey is not null)
            {
                CheckUninstallEntry(subKey);
            }
        }
    }

    [SupportedOSPlatform("windows")]
    private static void CheckUninstallEntry(RegistryKey subKey)
    {
        var displayName = subKey.GetValue("DisplayName")?.ToString();
        if (!string.IsNullOrEmpty(displayName))
        {
            Log.WriteLine(displayName);
        }

        var displayIcon = subKey.GetValue("DisplayIcon")?.ToString();
        if (!string.IsNullOrEmpty(displayIcon))
        {
            Log.WriteLine($"\t{displayIcon}");
        }

        var installLocation = subKey.GetValue("InstallLocation")?.ToString();
        if (!string.IsNullOrEmpty(installLocation))
        {
            Log.WriteLine($"\t{installLocation}");
        }

        var uninstallString = subKey.GetValue("UninstallString")?.ToString();
        if (!string.IsNullOrEmpty(uninstallString))
        {
            Log.WriteLine($"\t{uninstallString}");
        }
    }
}
