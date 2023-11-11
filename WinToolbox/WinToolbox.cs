namespace WinToolbox;

using System;
using System.Runtime.Versioning;

public static class WinToolbox
{
    private static bool _isRunning;

    [SupportedOSPlatform("windows")]
    public static void Initialize(string[] args)
    {
        var debug = args.Contains("--debug");

        if (debug)
        {
            Console.WriteLine("Debug mode enabled.");
        }

        if (!OperatingSystem.IsWindows())
        {
            Console.WriteLine("This program is only supported on Windows.");
            return;
        }

        CommandHandler.Initialize();
        Console.Write($"$ ");
        _isRunning = true;
        while (true)
        {
            if (!_isRunning)
            {
                break;
            }

            var line = Console.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                string command = line.Split(' ')[0];
                string[] arguments = line.Split(' ')[1..];
                Console.Clear();
                CommandHandler.HandleCommand(command, arguments);
                Console.Write($"$ ");
            }
            else
            {
                continue;
            }
        }

        Console.WriteLine("Exiting...");
        Console.WriteLine("Press any key to close...");
    }

    internal static void Close()
    {
        _isRunning = false;
    }
}