/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
/// Chocolatey Website
/// https://chocolatey.org/
/// Information on Chocolatey
/// https://renenyffenegger.ch/notes/Windows/Chocolatey/index
#if WINDOWS
namespace CheetahToolbox.Managers.Packages;
public class ChocolateyManager(ToolboxContext context) : ManagerBase(context, "Chocolatey")
{
    private readonly List<AppEntry> apps = [];

    public string Version => NativeTerminal.Execute("choco", ["-v"])?.Trim() ?? string.Empty;

    public bool IsInstalled
    {
        get
        {
            string? result = null;
            try
            {
                result = NativeTerminal.Execute("choco", []);
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

    public static void Uninstall()
    {
        // TODO: Remove Folders

        // TODO: Remove Registry Entries

        // TODO: Remove Environment Variables
    }

    /// <summary>
    /// Run Choco Updates
    /// </summary>
    public void Update()
    {
        if (!WindowsUtils.IsRunningAsAdmin())
        {
            Log.Warn("Update Failed: Not running with Administrator privileges.");
            throw new Exceptions.PackageManagerUpdateException();
        }
        string? result = NativeTerminal.Execute("choco", ["upgrade", "all", "-y"]);
        if (result != null)
        {
            Log.Write(result);
        }
        else
        {
            Log.Warn("Failed to update Chocolatey");
        }
    }

    public void Install()
    {
        if (!WindowsUtils.IsRunningAsAdmin())
        {
            Log.Write("Must run this command as admin");
            return;
        }

        if (!IsInstalled)
        {
            Log.Write("Chocolatey is not installed.");
            Log.Write("Do you want to install it? Y / N: ");
            ConsoleKeyInfo input = Console.ReadKey();

            string? result = NativeTerminal.Execute("pwsh", ["-Command", "Get-ExecutionPolicy"]);
            if (!string.IsNullOrEmpty(result))
                Log.Write(result);

            if (input.KeyChar is 'Y' or 'y')
            {
                string[] lines = GlobalStrings.Chocolatey.InstallCommand.Split(';');

                foreach (string line in lines)
                {
                    string cleanLine = line.Trim();
                    Log.Write(cleanLine);

                    string[] args = cleanLine.Split(' ');
                    string[] args2 = args.Prepend("-Command").ToArray();

                    string? result1 = NativeTerminal.Execute("pwsh", args2);
                    if (!string.IsNullOrEmpty(result1)) Log.Write(result1);
                    if (result1 == null)
                    {
                        Log.Write("Chocolatey Install Failed..");
                        return;
                    }
                    else
                    {
                        if (result1.Contains("Chocolatey (choco.exe) is now ready"))
                        {
                            Log.Write("Chocolatey Installed");
                            return;
                        }
                        else
                        {
                            Log.Write("Chocolatey Install Failed..");
                            return;
                        }
                    }
                }
            }
            else
            {
                Log.Write("Chocolatey Install Skipped..");
                return;
            }
        }
        Log.Write("Chocolatey already installed..");
    }

    /// <summary>
    /// WIP: Check if Chocolatey result is valid.
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    public AppEntry? CheckResult(string line)
    {
        List<string> lines = [.. line.Split(' ')];
        if (string.IsNullOrEmpty(lines[0])) return null;
        if (lines.Count != 2) return null;

        return new AppEntry(lines[0], lines[0], null, null, AppEntry.AppSource.CHOCOLATEY);
    }

    /// <summary>
    /// Start the Chocolatey Manager
    /// </summary>
    public void Start()
    {
        apps.Clear();

        string? test = NativeTerminal.Execute("choco", ["list"]);
        if (test == null) return;
        List<string> tempList = [.. test.Split('\n')];
        tempList.RemoveAt(0);

        foreach (string temp in tempList)
        {
            AppEntry? item = CheckResult(temp);
            if (item != null)
                apps.Add(item);
        }
        Log.Write($"Chocolatey has {tempList.Count} packages installed.");
    }
}
#endif