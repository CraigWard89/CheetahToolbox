/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigWard89/CheetahToolbox)
///				Project:  CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Ward (https://github.com/CraigWard89)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
#if WINDOWS
namespace Toolbox;

using Microsoft.Win32;
using System.Runtime.Versioning;

[SupportedOSPlatform("windows")]
public static class WindowsRegistry
{
    public static void ListInstalledApplications()
    {
        using RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
        if (key != null)
        {
            foreach (string subkey in key.GetSubKeyNames())
            {
                using RegistryKey? subKey = key.OpenSubKey(subkey);
                if (subKey != null)
                {
                    Console.WriteLine($"{subKey.Name} -> {subKey.GetValue("DisplayName")}");
                }
            }
        }

        //using RegistryKey? key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
        //if (key != null)
        //{
        //    foreach (string subkey in key.GetSubKeyNames())
        //    {
        //        using RegistryKey? subKey = key.OpenSubKey(subkey);
        //        if (subKey != null)
        //        {
        //            Console.WriteLine($"{subKey.Name} -> {subKey.GetValue("DisplayName")}");
        //        }
        //    }
        //}
    }
}
#endif