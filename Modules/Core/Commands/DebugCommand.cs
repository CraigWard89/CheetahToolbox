namespace CheetahToolbox.Modules.Core.Commands;

using global::CheetahToolbox.Commands;

public class DebugCommand() : CommandBase("debug", "debug command")
{
    public override CommandResult Execute(CommandContext context)
    {
        StringBuilder output = new();
        _ = output.AppendLine("Debug: ");
        _ = output.AppendLine($"Modules Count: {ModuleManager.ModuleCount}");
        _ = output.AppendLine($"Commands Count: {ModuleManager.CommandCount}");

        return new CommandResult(true, output.ToString());
    }
}