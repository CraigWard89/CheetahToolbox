namespace CheetahToolbox;

using CheetahUtils;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;

public class CheetahToolbox
{
    public CheetahToolbox()
    {
        Console.WriteLine("CheetahToolbox");
        //var cu = Registry.CurrentUser.Name;
        //Console.WriteLine(cu.ToString());

        while (true)
        {
            var line = Console.ReadLine();
            switch (line)
            {
                case "help":
                    Console.WriteLine("help - Show this help");
                    Console.WriteLine("exit - Exit the program");
                    Console.WriteLine("choco - Chocolatey Experiments");
                    Console.WriteLine("gh - Git/GitHub Experiments");
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                case "":
                    Console.WriteLine("Doing Chocolatey Experiments..");

                    var test = NativeTerminal.Execute("choco", ["list"]);
                    List<string> tempList = [.. test.Split('\n')];

                    foreach (string temp in tempList)
                    {
                        var item = Chocolatey.CheckResult(temp);
                        if (!string.IsNullOrEmpty(item))
                        {
                            Console.WriteLine($"Found: {item}");
                        }
                    }
                    Console.WriteLine($"Chocolatey has {tempList.Count} packages installed.");
                    break;
                case "gh":
                    Console.WriteLine("Git/GitHub WIP");
                    break;
                default:
                    Console.WriteLine($"Unknown Command: {line}");
                    break;
            }
        }
    }

    public static void Main(string[] args) => _ = new CheetahToolbox();
}

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
}
//    public static bool Installed
//    {
//        get
//        {
//            try
//            {
//                var result = NativeTerminal.Execute("choco", []);
//                if (!string)
//                return true;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            return false;
//        }
//    }

//    public static List<string> Apps
//    {
//        get
//        {
//            try
//            {
//                // WIP
//                var result = Cli.Wrap("choco").WithArguments("list").ExecuteAsync();
//                Console.WriteLine(result);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            return [];
//        }
//    }
//}

public static class Experimental
{
    public static void TestPhase0()
    {
        //if (Chocolatey.Installed)
        //{
        //    Console.WriteLine("Chocolatey Detected");
        //}
        // TODO: Check if Chocolatey is installed
        //try
        //{
        //	await using var stdOut = Console.OpenStandardOutput();
        //	await using var stdErr = Console.OpenStandardError();

        //	var result = await Cli.Wrap("choco")
        //		.WithArguments("list")
        //		.WithStandardOutputPipe(PipeTarget.ToStream(stdOut))
        //		.WithStandardErrorPipe(PipeTarget.ToStream(stdErr))
        //		.ExecuteAsync();

        //	if (result is null)
        //	{
        //		throw new Exception("ERROR");
        //	}



        //	Console.WriteLine(result.ToString());
        //}
        //catch (Exception ex)
        //{
        //	Console.WriteLine(ex.Message);
        //}

        Console.WriteLine("Chocolatey Checks Done..");

        // TODO: Add Installed Programs to Chocolatey
    }

    public static void TestPhase1()
    {
        // TODO: Print All Installed Bloatware

        var uninstallKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall") ?? throw new Exception("Uninstall key not found.");

        foreach (var subKeyName in uninstallKey.GetSubKeyNames())
        {
            var subKey = uninstallKey.OpenSubKey(subKeyName);
            if (subKey != null)
            {
                var displayName = subKey.GetValue("DisplayName")?.ToString();
                var displayIcon = subKey.GetValue("DisplayIcon")?.ToString()?.Split(',')[0];
                var installLocation = subKey.GetValue("InstallLocation")?.ToString();
                var uninstallString = subKey.GetValue("UninstallString")?.ToString();

                if (!string.IsNullOrEmpty(displayName))
                {
                    Console.WriteLine(displayName);
                }
            }
        }
    }

    public static void TestPhase2()
    {
        // TODO: Uninstaller Checker
    }

    private static bool CheckUninstallEntry(RegistryKey subKey)
    {
        bool result = false;
        var displayName = subKey.GetValue("DisplayName")?.ToString();
        var displayIcon = subKey.GetValue("DisplayIcon")?.ToString()?.Split(',')[0];
        var installLocation = subKey.GetValue("InstallLocation")?.ToString();
        var uninstallString = subKey.GetValue("UninstallString")?.ToString();

        if (!string.IsNullOrEmpty(displayIcon) && !File.Exists(displayIcon))
        {
            result = true;
        }

        if (!string.IsNullOrEmpty(installLocation))
        {
            if (!Directory.Exists(installLocation))
            {
                result = true;
            }
        }

        if (result && !string.IsNullOrEmpty(displayName))
        {
            Console.WriteLine($"{displayName} - is a ghost app");
        }

        return result;
    }
}