namespace WinToolbox;

using System;
using System.Runtime.Versioning;

internal class Program
{
    [SupportedOSPlatform("windows")]
    private static void Main(string[] args)
    {
        WinToolbox.Initialize(args);
    }

    public static Version Version = typeof(Program).Assembly.GetName().Version ?? throw new NullReferenceException("Version is null");
}