namespace CheetahToolbox;

using System.Runtime.Versioning;

internal class Program
{
#if WINDOWS
	[SupportedOSPlatform("windows")]
	private static void Main(string[] args) => WinToolbox.Initialize(args);
#else
    private static void Main(string[] args) => throw new Exception("Windows is the only supported OS.");
#endif
}