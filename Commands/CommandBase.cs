namespace CheetahToolbox.Commands;

using Modules;

public abstract class CommandBase(ModuleBase module, string name, string description)
{
    public ModuleBase Module = module;
    public string Name = name;
    public string Description = description;
    public Logger Log { get; private set; } = new($"[{name}]");

    public abstract CommandResult Execute(string? subCommand, string[] args);
}