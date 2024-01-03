namespace CheetahToolbox;

using Microsoft.Win32;
using System;
using System.IO;

/// <summary>
/// WIP: This is a placeholder for now.
/// </summary>
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