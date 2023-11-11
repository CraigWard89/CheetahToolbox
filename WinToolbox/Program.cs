namespace WinToolbox;

using System.Runtime.Versioning;

internal class Program
{
    [SupportedOSPlatform("windows")]
    private static void Main(string[] args)
    {
        WinToolbox.Initialize(args);
    }

    public static CheeseyUtils.Version Version = new(0, 0, 1);
}