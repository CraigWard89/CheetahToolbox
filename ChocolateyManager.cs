namespace CheetahToolbox;

using CheetahUtils;

public class ChocolateyManager
{
    private readonly List<AppEntry> apps = [];

    public string Version => NativeTerminal.Execute("choco", ["-v"]) ?? string.Empty;

    public bool IsInstalled
    {
        get
        {
            string? result = null;
            try
            {
                result = NativeTerminal.Execute("choco", ["-v"]);
                if (result != null)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }

    public ChocolateyManager()
    {
        Console.WriteLine($"Chocolatey Manager Starting..");

        Console.WriteLine("Chocolatey Manager Started");
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

        return new AppEntry(lines[0], lines[0], AppEntry.AppSource.CHOCOLATEY);
    }

    /// <summary>
    /// WIP: Cache Programs installed by Chocolatey.
    /// </summary>
    public void CachePrograms()
    {
        apps.Clear();

        string test = NativeTerminal.Execute("choco", ["list"]);
        List<string> tempList = [.. test.Split('\n')];
        tempList.RemoveAt(0);

        foreach (string temp in tempList)
        {
            AppEntry? item = CheckResult(temp);
            if (item != null)
            {
                apps.Add(item);
            }
        }
        Console.WriteLine($"Chocolatey has {tempList.Count} packages installed.");
    }
}