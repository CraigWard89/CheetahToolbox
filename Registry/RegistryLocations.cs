/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
#if WINDOWS
namespace CheetahToolbox.Registry;

public static class RegistryLocations
{
    // WIP: Add other locations
    public static readonly RegistryLocation Software = new(GlobalStrings.Registry.Toolbox.SoftwareKey, string.Empty);
    public static readonly RegistryLocation InstallPath = new(GlobalStrings.Registry.Toolbox.SoftwareKey, "InstallPath");
    public static readonly RegistryLocation Uninstall = new(GlobalStrings.Registry.Toolbox.UninstallKey, string.Empty);
    public static readonly RegistryLocation UninstallName = new(GlobalStrings.Registry.Toolbox.UninstallKey, "DisplayName");

    public static class Desktop
    {
        public static readonly RegistryLocation PaintDesktopVersion = new(GlobalStrings.Registry.DesktopKey, "PaintDesktopVersion");
        public static readonly RegistryLocation MenuShowDelay = new(GlobalStrings.Registry.DesktopKey, "MenuShowDelay");
    }

    public static class Explorer
    {
        public static readonly RegistryLocation ShowRecommendations = new(GlobalStrings.Registry.ExplorerKey, "ShowRecommendations", RegistryTarget.HKCU);
        public static readonly RegistryLocation ShowCloudFilesInQuickAccess = new(GlobalStrings.Registry.ExplorerKey, "ShowCloudFilesInQuickAccess", RegistryTarget.HKCU);

        public static class Advanced
        {
            public static readonly RegistryLocation ShowHiddenFiles = new(GlobalStrings.Registry.ExplorerAdvancedKey, "Hidden", RegistryTarget.HKCU);
            public static readonly RegistryLocation HideFileExtensions = new(GlobalStrings.Registry.ExplorerAdvancedKey, "HideFileExt", RegistryTarget.HKCU);
            public static readonly RegistryLocation ShowCopilotButton = new(GlobalStrings.Registry.ExplorerAdvancedKey, "ShowCopilotButton", RegistryTarget.HKCU);
            public static readonly RegistryLocation ShowSystemFiles = new(GlobalStrings.Registry.ExplorerAdvancedKey, "ShowSuperHidden", RegistryTarget.HKCU);
            public static readonly RegistryLocation SeparateProcess = new(GlobalStrings.Registry.ExplorerAdvancedKey, "SeparateProcess", RegistryTarget.HKCU);
            public static readonly RegistryLocation ShowInfoTip = new(GlobalStrings.Registry.ExplorerAdvancedKey, "ShowInfoTip", RegistryTarget.HKCU);
            public static readonly RegistryLocation ShowCompColor = new(GlobalStrings.Registry.ExplorerAdvancedKey, "ShowCompColor", RegistryTarget.HKCU);
            public static readonly RegistryLocation TaskbarAnimations = new(GlobalStrings.Registry.ExplorerAdvancedKey, "TaskbarAnimations", RegistryTarget.HKCU);
        }

        /// <summary>
        /// Doesn't automatically search for network folders and printers.
        /// </summary>
        public static readonly RegistryLocation NoNetCrawling = new(GlobalStrings.Registry.ExplorerAdvancedKey, "NoNetCrawling", RegistryTarget.HKCU);
    }

    public static class DWM
    {

    }

    /// <summary>
    /// Items in this category do not have their own yet.
    /// </summary>
    public static class Misc
    {
        //  \Control Panel\Desktop\WindowMetrics
        public static readonly RegistryLocation MinAnimate = new(GlobalStrings.Registry.WindowMetricsKey, "MinAnimate", RegistryTarget.HKCU);

        // HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System
    }
}
#endif