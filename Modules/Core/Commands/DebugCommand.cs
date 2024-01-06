namespace CheetahToolbox.Modules.Core.Commands;

using global::CheetahToolbox.Commands;

public class DebugCommand(ModuleBase module) : CommandBase(module, "debug", "debug command")
{
    public override CommandResult Execute(string? subCommand, string[]? args)
    {
        StringBuilder output = new();
        _ = output.AppendLine("Debug: ");
        _ = output.AppendLine($"  Module: {Module.Info.Name}");
        return new CommandResult(true, output.ToString());
    }
}