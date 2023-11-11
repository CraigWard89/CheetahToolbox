namespace WinToolbox;

using System;
using System.Runtime.Versioning;
using CheesyUtils;

internal class Program
{
    [SupportedOSPlatform("windows")]
    private static void Main(string[] args)
    {
        Console.WriteLine($"WinToolbox v{Version}");
        Console.WriteLine($"CheesyUtils v{CheesyUtils.Version}");
        Console.WriteLine("This program is in early development and is not ready for use.");
        WinToolbox.Initialize(args);
    }

    public static Version Version = typeof(Program).Assembly.GetName().Version ?? throw new NullReferenceException("Version is null");
}