namespace CheetahToolbox;

#region Using Statements
using Microsoft.Win32;
using System;
using System.Collections;
using System.Runtime.Versioning;
#endregion

public class UnknownKeyException : Exception
{
    public override IDictionary Data => base.Data;

    public override string? HelpLink { get => base.HelpLink; set => base.HelpLink = value; }

    public override string Message => base.Message;

    public override string? Source { get => base.Source; set => base.Source = value; }

    public override string? StackTrace => base.StackTrace;

    public override bool Equals(object? obj) => base.Equals(obj);
    public override Exception GetBaseException() => base.GetBaseException();
    public override int GetHashCode() => base.GetHashCode();
    public override string ToString() => base.ToString();
}

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

        RegistryKey uninstallKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall") ?? throw new UnknownKeyException();

        foreach (string subKeyName in uninstallKey.GetSubKeyNames())
        {
            RegistryKey? subKey = uninstallKey.OpenSubKey(subKeyName);
            if (subKey != null)
            {
                string? displayName = subKey.GetValue("DisplayName")?.ToString();
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