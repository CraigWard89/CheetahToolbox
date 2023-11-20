namespace CheetahToolbox.Commands;

using System.Reflection;

public class Version : Command
{
	public Version() : base("version", "version") { }

	public override void Execute(string[] args)
	{
		Console.WriteLine($"WinToolbox v{Assembly.GetExecutingAssembly().GetName().Version}");
	}
}