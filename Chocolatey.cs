namespace CheetahToolbox;
using CheetahUtils;
using System.Collections.Generic;

using System;
using System.Linq;

public static class Chocolatey
{
    /// <summary>
    /// WIP: Check if Chocolatey result is valid.
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    public static string CheckResult(string line)
    {
        string result = string.Empty;
        var lines = line.Split(' ').ToList();
        if (string.IsNullOrEmpty(lines[0])) return string.Empty; // Empty
        if (lines.Count != 2) return string.Empty;

        return lines[0];
    }

    public static void CheckPrograms()
    {
        Console.WriteLine("Doing Chocolatey Experiments..");

        var test = NativeTerminal.Execute("choco", ["list"]);
        List<string> tempList = [.. test.Split('\n')];

        foreach (string temp in tempList)
        {
            var item = Chocolatey.CheckResult(temp);
            if (!string.IsNullOrEmpty(item))
            {
                Console.WriteLine($"Found: {item}");
                // TODO: Cache this list
            }
        }
        Console.WriteLine($"Chocolatey has {tempList.Count} packages installed.");
    }
}
