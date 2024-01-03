namespace CheetahToolbox;

#region Using Statements
using CheetahUtils;
using System;
using System.Collections.Generic;
#endregion

public static class Chocolatey
{
    private static readonly List<AppEntry> appEntries = [];

    public static string Version => NativeTerminal.Execute("choco", ["version"]);

    /// <summary>
    /// WIP: Check if Chocolatey result is valid.
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    public static AppEntry? CheckResult(string line)
    {
        List<string> lines = [.. line.Split(' ')];
        if (string.IsNullOrEmpty(lines[0])) return null;
        if (lines.Count != 2) return null;

        return new AppEntry(lines[0], lines[0], AppSource.CHOCOLATEY);
    }

    /// <summary>
    /// WIP: Cache Programs installed by Chocolatey.
    /// </summary>
    public static void CachePrograms()
    {
        appEntries.Clear();

        string test = NativeTerminal.Execute("choco", ["list"]);
        List<string> tempList = [.. test.Split('\n')];
        tempList.RemoveAt(0);

        foreach (string temp in tempList)
        {
            AppEntry? item = CheckResult(temp);
            if (item != null)
            {
                appEntries.Add(item);
            }
        }
        Console.WriteLine($"Chocolatey has {tempList.Count} packages installed.");
    }
}