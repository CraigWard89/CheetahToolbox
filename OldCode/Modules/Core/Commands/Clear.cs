#if WIP
namespace CheetahTerminal.Modules.Core.Commands;

using CheetahTerminal.Commands;

public class Clear() : Command("clear", "clear the console")
{
	public override CommandResult Execute(CommandContext context)
	{
		Terminal.Output.Clear();
		return new CommandResult(true);
	}
}
#endif