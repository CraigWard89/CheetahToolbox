namespace CheetahToolbox.Modules;

using Commands;
using System.Collections.Generic;

/// <summary>
/// Base class for all modules.
/// </summary>
/// <param name="name"></param>
/// <param name="description"></param>
public class ModuleBase(CheetahToolbox toolbox, ModuleInfo info)
{
    public CheetahToolbox Toolbox { get; private set; } = toolbox;
    public ModuleInfo Info { get; private set; } = info;
    public List<CommandBase> Commands { get; private set; } = [];
}