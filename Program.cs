namespace CheetahToolbox;
internal static class Program
{
	public static CheetahToolbox? App { get; private set; }

	private static void Main(string[] args)
	{
		new CheetahToolbox().Start();
	}
}