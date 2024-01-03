namespace CheetahToolbox;

using CheetahUtils;
using System;
using System.Collections.Generic;
using System.Linq;

public static class Chocolatey
{
    private static readonly List<AppEntry> appEntries = [];

    /// <summary>
    /// WIP: Check if Chocolatey result is valid.
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    public static string CheckResult(string line)
    {
        var lines = line.Split(' ').ToList();
        if (string.IsNullOrEmpty(lines[0])) return string.Empty; // Empty
        if (lines.Count != 2) return string.Empty;

        return lines[0];
    }

    /// <summary>
    /// WIP: Cache Programs installed by Chocolatey.
    /// </summary>
    public static void CachePrograms()
    {
        Console.WriteLine("Caching Chocolatey List");
        appEntries.Clear();

        var test = NativeTerminal.Execute("choco", ["list"]);
        List<string> tempList = [.. test.Split('\n')];
        tempList.RemoveAt(0);

        foreach (string temp in tempList)
        {
            var item = Chocolatey.CheckResult(temp);
            if (!string.IsNullOrEmpty(item))
            {
                Console.WriteLine(item);
                string[] split = item.Split(' ');
                string name = split[0];
                string version = split[1];
                Console.WriteLine($"Found: {name} - {version}");
                appEntries.Add(new AppEntry(name, version));
            }
        }
        Console.WriteLine($"Chocolatey has {tempList.Count} packages installed.");
    }
}
