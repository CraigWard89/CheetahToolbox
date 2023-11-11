namespace WinToolbox;

using System;
using System.Runtime.Versioning;
using CheeseyUI;

public static class WinToolbox
{
    private static bool _isRunning;

    [SupportedOSPlatform("windows")]
    public static void Initialize(string[] args)
    {
        var debug = args.Contains("--debug");

#if DEBUG
        debug = true;
#endif

        if (debug)
        {
            Console.WriteLine("Debug mode enabled.");
        }

        if (!OperatingSystem.IsWindows())
        {
            Console.WriteLine("This program is only supported on Windows.");
            return;
        }

        App app = new();

        //CommandHandler.Initialize();
        //Console.Write($"$ ");
        //_isRunning = true;
        //while (true)
        //{
        //    if (!_isRunning)
        //    {
        //        break;
        //    }

        //    var line = Console.ReadLine();
        //    if (!string.IsNullOrEmpty(line))
        //    {
        //        string command = line.Split(' ')[0];
        //        string[] arguments = line.Split(' ')[1..];
        //        Console.Clear();
        //        CommandHandler.HandleCommand(command, arguments);
        //        Console.Write($"$ ");
        //    }
        //    else
        //    {
        //        continue;
        //    }
        //}
        //Console.Clear();
        Console.WriteLine("Exiting...");
    }

    internal static void Close()
    {
        _isRunning = false;
    }
}