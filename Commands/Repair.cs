namespace CheetahToolbox.Commands;

using CheetahApp.Commands;

public class Repair() : Command("repair", "runs a variety of repair utilites, in attempts to fix the system.")
{
	public override void Execute(string[] args)
	{
		Program.App?.Close();
	}
}