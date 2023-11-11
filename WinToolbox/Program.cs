namespace WinToolbox;

using System;
using System.Runtime.Versioning;
using CheesyUtils;

internal class Program
{
    [SupportedOSPlatform("windows")]
    private static void Main(string[] args)
    {
        var version = typeof(Program).Assembly.GetName().Version ?? throw new NullReferenceException("Version is null");
        Console.WriteLine($"WinToolbox v{version}");
        Console.WriteLine($"CheesyUtils v{CheesyUtils.Version}");
        Console.WriteLine("This program is in early development and is not ready for use.");
        WinToolbox.Initialize(args);
    }
}