/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
/// TODO: Entries to investigate
/// SOFTWARE\Microsoft\Windows\CurrentVersion\Communications
#if WINDOWS
namespace CheetahToolbox.Registry;
public static partial class RegistryTweaker
{
    public static void ApplyDefaults()
    {
        // TODO: Implement Apply Defaults

        // RegistryLocations.Desktop.PaintDesktopVersion.Reset();
    }

    public static void ApplyRecommended()
    {
        // TODO: Implement Apply Recommended

        //RegistryLocations.Desktop.PaintDesktopVersion.Bool = false;
        // Telemetry.AdvertisingInfo = false;
    }
}
#endif