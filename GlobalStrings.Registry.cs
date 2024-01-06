/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
#if WINDOWS
namespace CheetahToolbox;

public static partial class GlobalStrings
{
    public static class Registry
    {
        /// <summary>
        /// Run Key - Startup Programs
        /// <br>HKCU</br>
        /// </summary>
        public const string RunKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        /// <summary>
        /// Tracks certain stats like how many times you've opened a program
        /// <br>HKCU</br>
        /// </summary>
        public const string CensusKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Census";

        /// <summary>
        /// Desktop Settings Key
        /// <br>HKCU</br>
        /// </summary>
        public const string DesktopKey = @"Control Panel\Desktop";

        /// <summary>
        /// Entry for storing the install path and other program settings
        /// <br>HKCU, HKLM</br>
        /// </summary>
        public const string SoftwareKey = @"Software";

        /// <summary>
        /// <br>Windows Metrics Key</br>
        /// <br>HKLM</br>
        /// </summary>
        public const string WindowMetricsKey = @" Control Panel\Desktop\WindowMetrics";

        /// <summary>
        /// Windows Key
        /// <br>HKCU, HKLM</br>
        /// </summary>
        public const string WindowsKey = @$"{SoftwareKey}\Microsoft\Windows";

        /// <summary>
        /// Current Version Key
        /// </summary>
        public const string CurrentVersionKey = @$"{WindowsKey}\CurrentVersion";

        /// <summary>
        /// Uninstall Key - Programs and Features Install/Uninstall Programs
        /// </summary>
        public const string UninstallKey = @$"{CurrentVersionKey}\Uninstall";

        /// <summary>
        /// Classes CLSID Key
        /// </summary>
        public const string ClassesCLSIDKey = @$"{SoftwareKey}\Classes\CLSID";

        /// <summary>
        /// Explorer Key
        /// </summary>
        public const string ExplorerKey = @$"{CurrentVersionKey}\Explorer";

        /// <summary>
        /// Explorer Key
        /// </summary>
        public const string DWMKey = @$"{WindowsKey}\DWM";

        /// <summary>
        /// Explorer Advanced Key
        /// </summary>
        public const string ExplorerAdvancedKey = @$"{ExplorerKey}\Advanced";

        public static class Toolbox
        {
            /// <summary>
            /// Toolbox's <inheritdoc cref="Registry.UninstallKey"/>
            /// </summary>
            public const string UninstallKey = @"Software\Microsoft\Windows\CurrentVersion\Uninstall\CheetahToolbox";

            /// <summary>
            /// Toolbox's <inheritdoc cref="Registry.SoftwareKey"/>
            /// </summary>
            public const string SoftwareKey = @$"{Registry.SoftwareKey}\CheetahToolbox";
        }
    }
}
#endif