namespace CheetahToolbox.Modules.Core.Commands;

using global::CheetahToolbox.Commands;

public class EchoCommand(ModuleBase module) : CommandBase(module, "echo", "echo command")
{
    public override CommandResult Execute(string? subCommand, string[]? args) => new(true, string.Join(" ", args ?? []));
}