#if WIP
namespace CheetahTerminal.Commands;

#region Using Statements
using System.Collections.Generic;
using Module = Modules.Module;
#endregion

public class CommandHandler(Module module)
{
	public readonly Module Module = module;
	private readonly List<Command> _commands = [];

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "WIP")]
	public void Start()
	{
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "WIP")]
	public void Stop()
	{
	}

	public CommandResult? HandleCommand(string command, string[] arguments)
	{
		if (string.IsNullOrEmpty(command))
		{
			return new CommandResult(false, "Command is null or empty");
		}

		foreach (Command cmd in _commands)
		{
			if (cmd.Name == command)
			{
				return cmd.Execute(new CommandContext(Module, command, arguments));
			}
		}

		return new CommandResult(false, $"Command not found: {command}");
	}

	public void AddCommand(Command command)
	{
		_commands.Add(command);
	}
}
#endif