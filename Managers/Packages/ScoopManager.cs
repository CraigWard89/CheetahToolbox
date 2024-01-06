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

public class ScoopManager(ToolboxContext context) : ManagerBase(context, "Scoop")
{
    public string Version
    {
        get
        {
            string? result = NativeTerminal.Execute("scoop", ["-v"]) ?? string.Empty;
            string[] split = result.Replace("\r", "").Split("\n");
            string line = split[1].Replace("\n", "").Trim();
            string[] split2 = line.Split(' ');
            return split2[0].Replace("\n", "").Trim();
        }
    }

    public bool IsInstalled
    {
        get
        {
            string? result = null;
            try
            {
                result = NativeTerminal.Execute("scoop", []);
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
    /// Run Scoop Updates
    /// </summary>
    public void Update()
    {
        if (!WindowsUtils.IsRunningAsAdmin())
        {
            Log.Warn("Update Failed: Not running with Administrator privileges.");
            throw new Exceptions.PackageManagerUpdateException();
        }
        string? result = NativeTerminal.Execute("scoop", ["update"]);
        if (result != null)
        {
            Log.Write(result);
        }
        else
        {
            Log.Warn("Failed to update Scoop");
        }
    }
}
#endif