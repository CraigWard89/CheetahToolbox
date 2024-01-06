#if WINDOWS || WINDOWS_FAKE
namespace CheetahToolbox;

using Microsoft.Win32;

public static class RegistryTweaker
{
    #region Advertising Info
    public static bool AdvertisingInfo
    {
        get
        {
            RegistryKey? telemetryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\AdvertisingInfo");
            if (telemetryKey != null)
            {
                string? value = telemetryKey.GetValue("Enabled")?.ToString();
                if (value != null)
                {
                    if (value == "0")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return true;
        }
        set
        {
            RegistryKey? telemetryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\AdvertisingInfo");
            if (telemetryKey != null)
            {
                if (value)
                {
                    telemetryKey.SetValue("Enabled", 1);
                }
                else
                {
                    telemetryKey.SetValue("Enabled", 0);
                }
            }
        }
    }
    #endregion

    #region Paint Desktop Version
    public static bool PaintDesktopVersion
    {
        get
        {
            RegistryKey? telemetryKey = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop");
            if (telemetryKey != null)
            {
                if (telemetryKey.GetValue("PaintDesktopVersion") is int paintDesktopVersion)
                {
                    if (paintDesktopVersion == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return true;
        }
        set
        {
            RegistryKey? telemetryKey = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop");
            if (telemetryKey != null)
            {
                if (value)
                {
                    telemetryKey.SetValue("PaintDesktopVersion", 1);
                }
                else
                {
                    telemetryKey.SetValue("PaintDesktopVersion", 0);
                }
            }
        }
    }
    #endregion


    public static void ApplyDefaults()
    {
        // WIP:
        // SOFTWARE\Microsoft\Windows\CurrentVersion\AdvertisingInfo
        // SOFTWARE\Microsoft\Windows\CurrentVersion\Communications
    }
}
#endif