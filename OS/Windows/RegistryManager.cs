#if WINDOWS || WINDOWS_FAKE
namespace CheetahToolbox.OS.Windows;

#region Using Statements
using Exceptions;
using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.Versioning;
#endregion

/// <summary>
/// Registry Manager
/// </summary>
public static class RegistryManager
{
    private static readonly List<string> CLSID = [];

    public static void Init()
    {
        CLSID.Clear();
        Console.WriteLine("Registry Manager Initialized");
    }

    [SupportedOSPlatform("windows")]
    private static void Scan()
    {
        Console.WriteLine("Registry Manager Scanning..");
        Stopwatch sw = Stopwatch.StartNew();
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

            using RegistryKey? ckey = skey?.OpenSubKey("CLSID");
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

        sw.Stop();
        Console.WriteLine($"Cached: {CLSID.Count} CLSIDs: {sw.ElapsedMilliseconds}ms");
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