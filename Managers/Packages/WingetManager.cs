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

using Contexts;

public class WingetManager(ToolboxContext context) : ManagerBase(context, "Winget")
{
    public string Version => NativeTerminal.Execute("winget", ["-v"]) ?? string.Empty;

    public bool IsInstalled
    {
        get
        {
            string? result = null;
            try
            {
                result = NativeTerminal.Execute("winget", []);
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
    /// Run Winget Updates
    /// </summary>
    public void Update()
    {
        if (!WindowsUtils.IsRunningAsAdmin())
        {
            Log.Warn("Update Failed: Not running with Administrator privileges.");
            throw new Exceptions.PackageManagerUpdateException();
        }
        string? result = NativeTerminal.Execute("winget", ["update"]);
        if (result != null)
        {
            Log.Write(result);
        }
        else
        {
            Log.Warn("Failed to update Winget");
        }
    }
}
#endif