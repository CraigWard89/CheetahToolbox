namespace CheetahToolbox.Modules.Core.Commands;

using global::CheetahToolbox.Commands;

public class ScanCommand(ModuleBase module) : CommandBase(module, "scan", "scan")
{
    public override CommandResult Execute(string? subCommand, string[] args)
    {
        if (args.Length < 1)
        {
            return new CommandResult(false, "invalid arguments");
        }

        if (!string.IsNullOrEmpty(subCommand))
        {
            return subCommand switch
            {
                _ => new CommandResult(false, $"Unknown SubCommand: {subCommand}"),
            };
        }

        return new CommandResult(true);
    }
}