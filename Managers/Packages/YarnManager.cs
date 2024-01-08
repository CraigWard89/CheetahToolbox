/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
#if WINDOWS
namespace CheetahToolbox.Managers.Packages;

public class YarnManager(ToolboxContext context) : ManagerBase(context, "Yarn")
{
    public string Version => NativeTerminal.Execute("yarn", ["-v"]) ?? string.Empty;

    public bool IsInstalled
    {
        get
        {
            string? result = null;
            try
            {
                result = NativeTerminal.Execute("yarn", []);
                if (result != null)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
    }

    /// <summary>
    /// Run Yarn Updates
    /// </summary>
    public void Update()
    {
        if (!WindowsUtils.IsRunningAsAdmin())
        {
            Log.Warn("Update Failed: Not running with Administrator privileges.");
            throw new Exceptions.PackageManagerUpdateException();
        }
    }
}
#endif