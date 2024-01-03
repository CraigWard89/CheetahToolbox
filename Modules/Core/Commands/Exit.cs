#if WIP
namespace CheetahTerminal.Modules.Core.Commands;

using CheetahTerminal.Commands;
using System;

public class Exit() : Command("exit", "quit the program")
{
	public override CommandResult Execute(CommandContext context)
	{
		Terminal.ShutdownRequest = new ShutdownRequest();
		return new CommandResult(true, "Shutdown Request Sent.");
	}
}
#endif