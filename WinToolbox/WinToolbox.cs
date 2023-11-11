namespace WinToolbox;

using System;
using System.Runtime.Versioning;
using CheeseyUI;

public static class WinToolbox
{
    private static App? _app;

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

        _app = new(new AppSettings(800, 600, "WinToolbox"));
        _app.RootElements.Add(new Button(new(32, 32), new(128, 64), "Test", () => Console.WriteLine("Clicked!")));
        _app.Run();
        Console.WriteLine("Exiting...");
    }

    internal static void Close()
    {
        _app?.Close();
    }
}