#if WIP
namespace CheetahTerminal.Commands;

using CheetahTerminal.Modules;

public class CommandContext(Module module, string name, string[] args)
{
	/// <summary>
	/// The module this command belongs to
	/// </summary>
	public Module Module { get; private set; } = module;

	/// <summary>
	/// The name of the command executed
	/// </summary>
	public string Name { get; private set; } = name;

	/// <summary>
	/// The arguments passed to the command
	/// </summary>
	public string[] Args { get; private set; } = args;
}
#endif