#if WINDOWS || WINDOWS_FAKE
namespace CheetahToolbox.OS.Windows;

#region Using Statements
using Exceptions;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Runtime.Versioning;
#endregion

/// <summary>
/// WIP: This is a placeholder for now.
/// </summary>
public static class RegistryManager
{
    private static readonly List<string> CLSID = [];

    public static void Start()
    {
        Console.WriteLine("Registry Manager Starting..");
        Stopwatch sw = Stopwatch.StartNew();
#if WINDOWS
#pragma warning disable CA1416 // Validate platform compatibility
        Scan();
#pragma warning restore CA1416 // Validate platform compatibility
#endif
        sw.Stop();
        Console.WriteLine($"Registry Manager Started: {sw.ElapsedMilliseconds}ms");
    }

    [SupportedOSPlatform("windows")]
    private static void Scan()
    {
        // WIP: Cache CLSID
        string[]? keys = Registry.ClassesRoot.GetSubKeyNames();

        foreach (string key in keys)
        {
            RegistryKey? skey = Registry.ClassesRoot.OpenSubKey(key);

            // Scan Root Key
            string[]? values = skey?.GetValueNames();
            if (values == null) return;
            foreach (string value in values)
            {
                if (value == "CLSID")
                {
                    string? clsid = skey?.GetValue(value)?.ToString();
                    if (clsid == null) return;
                    if (!string.IsNullOrEmpty(clsid))
                    {
                        CLSID.Add(clsid);
                        Console.WriteLine($"{key} -> {clsid}");
                    }
                }
            }

            RegistryKey? ckey = skey?.OpenSubKey("CLSID");
            if (ckey == null) return;
            string[]? cvalues = ckey.GetValueNames();
            if (cvalues == null) return;

            foreach (string cvalue in cvalues)
            {
                string? clsid = ckey.GetValue(cvalue)?.ToString();
                if (clsid == null) return;
                if (!string.IsNullOrEmpty(clsid))
                {
                    CLSID.Add(clsid);
                    Console.WriteLine($"{key} -> {clsid}");
                }
            }

            //Console.WriteLine($"{key}");
            //CLSID.Add(key);
        }

        Console.WriteLine($"Cached: {CLSID.Count} CLSIDs");


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
                    Console.WriteLine(displayName);
            }
        }
    }

    [SupportedOSPlatform("windows")]
    private static bool CheckUninstallEntry(RegistryKey subKey)
    {
        bool result = false;
        string? displayName = subKey.GetValue("DisplayName")?.ToString();
        string? displayIcon = subKey.GetValue("DisplayIcon")?.ToString()?.Split(',')[0];
        string? installLocation = subKey.GetValue("InstallLocation")?.ToString();
        //string? uninstallString = subKey.GetValue("UninstallString")?.ToString();

        if (!string.IsNullOrEmpty(displayIcon) && !File.Exists(displayIcon))
            result = true;

        if (!string.IsNullOrEmpty(installLocation))
        {
            if (!Directory.Exists(installLocation))
                result = true;
        }

        if (result && !string.IsNullOrEmpty(displayName))
            Console.WriteLine($"{displayName} - is a ghost app");

        return result;
    }
}
#endif