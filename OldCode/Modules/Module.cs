#if WIP
namespace CheetahTerminal.Modules;

using System.Collections.Generic;
using CheetahTerminal.Commands;

/// <summary>
/// Base class for all modules.
/// </summary>
/// <param name="name"></param>
/// <param name="description"></param>
public class Module(ModuleInfo info)
{
	public ModuleInfo Info { get; private set; } = info;
	public List<Command> Commands { get; private set; } = [];

	internal void Initialize()
	{
		Terminal.Output.Add($"Module: {Info.Name} initialized.");
	}
}
#endif