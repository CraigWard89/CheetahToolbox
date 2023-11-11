namespace WinToolbox;

using System;
using System.Runtime.Versioning;
using CheeseyUI;
using CheeseyUtils;

public static class WinToolbox
{
    private static App? _app;

    [SupportedOSPlatform("windows")]
    public static void Initialize(string[] args)
    {
        AppInfo.Version = Program.Version;
        var debug = args.Contains("--debug");

#if DEBUG
        debug = true;
#endif

        if (!OperatingSystem.IsWindows())
        {
            throw new Exception("Windows is the only supported OS.");
        }

        string title = $"WinToolbox v{AppInfo.Version}";
        if (debug) title += " (Debug)";
        title += $" . CheeseyUtils v{CheesyUtils.Version}";

        _app = new(new AppSettings(800, 600, title));
        _ = new Button(_app.RootElement, new(0, 0), new(128, 64), "Test 1", () => throw new NotImplementedException());
        _app.Run();
    }

    internal static void Close()
    {
        _app?.Close();
    }
}