#if WIP
namespace CheetahTerminal.Modules.Core.Commands;

using System.Text;
using CheetahTerminal.Commands;

public class Debug() : Command("debug", "debug command")
{
	public override CommandResult Execute(CommandContext context)
	{
		StringBuilder output = new();
		_ = output.AppendLine("Debug: ");
		_ = output.AppendLine($"Modules Count: {ModuleManager.ModuleCount}");
		_ = output.AppendLine($"Commands Count: {ModuleManager.CommandCount}");

		return new CommandResult(true, output.ToString());
	}
}
#endif