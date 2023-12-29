namespace CheetahToolbox;

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Versioning;
using CliWrap;
using Microsoft.Win32;

public class CheetahToolbox
{
    [SupportedOSPlatform("windows")]
    public CheetahToolbox()
    {
        Console.WriteLine("CheetahToolbox");
        var cu = Registry.CurrentUser.Name;
        Console.WriteLine(cu.ToString());

        Experimental.TestPhase0();
        //Experimental.TestPhase1();
        //Experimental.TestPhase2();

        Console.WriteLine("======");
        Console.WriteLine("Press Any Key to Exit");
        Console.ReadKey();
    }

    [SupportedOSPlatform("windows")]
    public static void Main(string[] args)
    {
        _ = new CheetahToolbox();
    }
}

public class AppEntry
{

}

public static class KnownApplications
{
}

public static class Chocolatey
{
    public static bool Installed
    {
        get
        {
            try
            {
                // WIP
                var result = Cli.Wrap("choco").WithArguments("list").ExecuteAsync();
                Console.WriteLine(result);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
    }

    public static List<string> Apps
    {
        get
        {
            try
            {
                // WIP
                var result = Cli.Wrap("choco").WithArguments("list").ExecuteAsync();
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return [];
        }
    }
}

public static class Experimental
{
    public static void TestPhase0()
    {
        if (Chocolatey.Installed)
        {
            Console.WriteLine("Chocolatey Detected");
        }
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