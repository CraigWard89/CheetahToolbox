#if WIP
namespace CheetahTerminal.Modules.Core.Commands;

using System.Text;
using CheetahTerminal.Commands;

public class Help() : Command("help", "this menu")
{
	public override CommandResult Execute(CommandContext context)
	{
		foreach (Module module in ModuleManager.Modules)
		{
			Terminal.Output.Add($"Module: {module.Info.Name}{System.Environment.NewLine}");

			foreach (Command command in module.Commands)
			{
				Terminal.Output.Add($"\tCommand: {command.Name}");
			}
		}

		return new CommandResult(true, "");
	}
}
#endif