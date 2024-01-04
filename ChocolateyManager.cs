namespace CheetahToolbox;

using CheetahUtils;

public class ChocolateyManager
{
    private static readonly string installCommand = "Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))";

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

        if (!IsInstalled)
        {
            Console.WriteLine("Chocolatey is not installed.");
            Console.WriteLine("Do you want to install it? Y / N: ");
            ConsoleKeyInfo input = Console.ReadKey();

            if (input.KeyChar is 'Y' or 'y')
            {
                string? result = NativeTerminal.Execute("pwsh", [installCommand]);
                if (result == null)
                {
                    Console.WriteLine("Chocolatey Install Failed..");
                    return;
                }
                else
                {
                    Console.WriteLine(result);
                }

                Console.WriteLine("Chocolatey Installed");
            }
            else
            {
                Console.WriteLine("Chocolatey Install Skipped..");
                return;
            }
        }
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
            {
                apps.Add(item);
            }
        }
        Console.WriteLine($"Chocolatey has {tempList.Count} packages installed.");
    }
}