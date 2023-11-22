namespace CheetahToolbox.Commands;

using System.Text;
using CheetahApp.Commands;
using CheetahUtils;

public class Help() : Command("help", "help")
{
	public override void Execute(string[] args)
	{
		Log.WriteLine("Commands:");
		StringBuilder sb = new();
		foreach (var command in CommandHandler.Commands)
		{
			_ = sb.AppendLine($"{command.Key} - {command.Value.Description}");
		}
		Log.WriteLine(sb.ToString());
	}
}