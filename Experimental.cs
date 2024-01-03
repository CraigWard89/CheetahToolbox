namespace CheetahToolbox;

using Microsoft.Win32;
using System;
using System.Runtime.Versioning;

/// <summary>
/// WIP: This is a placeholder for now.
/// </summary>
public static class RegistryManager
{
    public static void Initialize()
    {
        // TODO: Initialize the Manager
    }

    [SupportedOSPlatform("windows")]
    public static void TestPhase1()
    {
        // TODO: Print All Installed Bloatware

        var uninstallKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall") ?? throw new Exception("Uninstall key not found.");

        foreach (var subKeyName in uninstallKey.GetSubKeyNames())
        {
            var subKey = uninstallKey.OpenSubKey(subKeyName);
            if (subKey != null)
            {
                var displayName = subKey.GetValue("DisplayName")?.ToString();
                //var displayIcon = subKey.GetValue("DisplayIcon")?.ToString()?.Split(',')[0];
                //var installLocation = subKey.GetValue("InstallLocation")?.ToString();
                //var uninstallString = subKey.GetValue("UninstallString")?.ToString();

                if (!string.IsNullOrEmpty(displayName))
                {
                    Console.WriteLine(displayName);
                }
            }
        }
    }

    public static void TestPhase2()
    {
        // TODO: Uninstaller Checker
    }

#if WINDOWS
    [SupportedOSPlatform("windows")]
    private static bool CheckUninstallEntry(RegistryKey subKey)
    {
        bool result = false;
        var displayName = subKey.GetValue("DisplayName")?.ToString();
        var displayIcon = subKey.GetValue("DisplayIcon")?.ToString()?.Split(',')[0];
        var installLocation = subKey.GetValue("InstallLocation")?.ToString();
        var uninstallString = subKey.GetValue("UninstallString")?.ToString();

        if (!string.IsNullOrEmpty(displayIcon) && !File.Exists(displayIcon))
        {
            result = true;
        }

        if (!string.IsNullOrEmpty(installLocation))
        {
            if (!Directory.Exists(installLocation))
            {
                result = true;
            }
        }

        if (result && !string.IsNullOrEmpty(displayName))
        {
            Console.WriteLine($"{displayName} - is a ghost app");
        }

        return result;
    }
#endif
}