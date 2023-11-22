namespace CheetahToolbox.Commands;

using System.Reflection;
using CheetahApp.Commands;
using CheetahUtils;

public class Version() : Command("version", "version")
{
	public override void Execute(string[] args)
	{
		Log.WriteLine($"WinToolbox v{Assembly.GetExecutingAssembly().GetName().Version}");
	}
}