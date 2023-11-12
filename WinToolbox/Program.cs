namespace WinToolbox;

using System.Runtime.Versioning;
using CheeseyUtils;

internal class Program
{
    [SupportedOSPlatform("windows")]
    private static void Main(string[] args) => WinToolbox.Initialize(args);

    public static Version Version = new(0, 0, 1, 0, 0, Version.ReleaseChannel.Development);
}