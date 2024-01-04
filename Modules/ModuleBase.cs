namespace CheetahToolbox.Modules;

using System.Collections.Generic;

/// <summary>
/// Base class for all modules.
/// </summary>
/// <param name="name"></param>
/// <param name="description"></param>
public class ModuleBase(ModuleInfo info)
{
    public ModuleInfo Info { get; private set; } = info;
    public List<Commands.Command> Commands { get; private set; } = [];

    internal void Initialize() => Console.WriteLine($"Module: {Info.Name} initialized.");
}