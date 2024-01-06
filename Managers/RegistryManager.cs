#if WINDOWS || WINDOWS_FAKE
namespace CheetahToolbox.Managers;

#region Using Statements
using Exceptions;
using Microsoft.Win32;
#endregion

public static class RegistryUtils
{
    public static string? GetString(RegistryTarget target, string keyPath, string? valuePath = null)
    {
        RegistryKey? key = target switch
        {
            RegistryTarget.HKLM => Registry.LocalMachine.OpenSubKey(keyPath),
            RegistryTarget.HKCU => Registry.CurrentUser.OpenSubKey(keyPath),
            _ => throw new UnknownKeyException()
        };

        if (key != null)
        {
            if (key.GetValue(valuePath) is string value)
            {
                Console.WriteLine($"{keyPath} => {value}");
                return value;
            }
            else
            {
                Console.WriteLine(key.Name);
                return null;
            }
        }

        return null;
    }

    public static void SetString(RegistryTarget target, string keyPath, string? valuePath, string? value)
    {
        // TODO: Implement
    }
}

public enum RegistryTarget
{
    HKLM, HKCU
}

/// <summary>
/// Registry Manager
/// </summary>
public class RegistryManager : ManagerBase
{
    private readonly List<string> CLSID = [];

    public RegistryManager(ToolboxContext context) : base(context, "Registry")
    {
        string path = RegistryUtils.GetString(RegistryTarget.HKCU, GlobalStrings.RegistryInstallPath) ?? string.Empty;
        Console.WriteLine($"Registry InstallPath: {path}");


        return;
        //Console.WriteLine("Registry Manager Initializing..");
        Stopwatch sw = Stopwatch.StartNew();

        // Scan Root Key
        RegistryKey? root = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Classes\CLSID");

        if (root != null)
        {
            string[]? keys = root.GetSubKeyNames();

            foreach (string key in keys)
            {
                RegistryKey? skey = root.OpenSubKey(key);
                if (skey?.GetValue(string.Empty) is string value)
                {
                    //Console.WriteLine($"{key} => {value}");
                }
            }
            //Console.WriteLine($"[RegistryManager] Cached: {CLSID.Count} CSLID");
        }

        // Census
        RegistryKey? census = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Census");
        if (census != null)
        {
            if (census?.GetValue("StartTimeBin") is long startTimeBin)
            {
                string startTime = new DateTime(startTimeBin).ToString();
            }
        }

        // Privacy
        RegistryKey? privacy = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Privacy");
        if (privacy != null)
        {
            if (privacy?.GetValue("TailoredExperiencesWithDiagnosticDataEnabled") is int tailoredExperiencesWithDiagnosticDataEnabled)
            {
                if (tailoredExperiencesWithDiagnosticDataEnabled == 1)
                    tailoredExperiencesWithDiagnosticDataEnabled = 0;
            }
        }

        // Desktop Settings
        RegistryKey? desktop = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop");
        if (desktop != null)
        {
            string[] values = desktop.GetValueNames();
            foreach (string value in values)
            {
                //Console.WriteLine($"{value}");

                if (desktop.GetValue(value) is string data)
                {
                    //Console.WriteLine($"{data}");
                }

                if (desktop.GetValue(value) is int data2)
                {
                    //Console.WriteLine($"{data2}");
                }
            }
        }

        if (RegistryTweaker.PaintDesktopVersion)
        {
            //Console.WriteLine("PaintDesktopVersion is Enabled");
        }

        // Check Advertising Info
        if (RegistryTweaker.AdvertisingInfo)
        {
            //Console.WriteLine("AdvertisingInfo is Enabled");
        }

        //Console.WriteLine("================");
        // Check Startup
        RegistryKey? startupKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
        if (startupKey != null)
        {
            //Console.WriteLine(startupKey.Name);
            foreach (string valueName in startupKey.GetValueNames())
            {
                //Console.WriteLine($"{valueName} -> {startupKey.GetValue(valueName)}");
            }
        }

        //Console.WriteLine("================");
        // Uninstall Entries
        List<RegistryKey> toCheck = [];
        toCheck.Add(Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall") ?? throw new UnknownKeyException());
        toCheck.Add(Registry.CurrentUser.OpenSubKey(@"Software\\Microsoft\Windows\CurrentVersion\Uninstall") ?? throw new UnknownKeyException());

        foreach (RegistryKey root2 in toCheck)
        {
            foreach (string subKeyName in root2.GetSubKeyNames())
            {
                RegistryKey? subKey = root2.OpenSubKey(subKeyName);
                if (subKey != null)
                {
                    string? displayName = subKey.GetValue("DisplayName")?.ToString();

                    if (string.IsNullOrEmpty(displayName))
                        //Console.WriteLine($"Name for {subKey.Name} was NULL, using Key name");
                        displayName = subKey.Name;

                    string? displayIcon = subKey.GetValue("DisplayIcon")?.ToString();
                    if (string.IsNullOrEmpty(displayIcon))
                    {
                        //Console.WriteLine($"DisplayIcon not set for {displayName}");
                    }

                    string? installLocation = subKey.GetValue("InstallLocation")?.ToString();
                    if (string.IsNullOrEmpty(installLocation))
                    {
                        //Console.WriteLine($"InstallLocation not set for {displayName}");
                    }
                    else
                    {
                        if (!Directory.Exists(installLocation) && !File.Exists(installLocation))
                        {
                            //Console.WriteLine($"Invalid Install Path: {installLocation}");
                        }
                    }
                }
            }
        }

        sw.Stop();
    }

    private static bool CheckUninstallEntry(RegistryKey subKey)
    {
        bool result = false;
        string? displayName = subKey.GetValue("DisplayName")?.ToString();
        string? displayIcon = subKey.GetValue("DisplayIcon")?.ToString()?.Split(',')[0];
        string? installLocation = subKey.GetValue("InstallLocation")?.ToString();
        // string? uninstallString = subKey.GetValue("UninstallString")?.ToString();

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