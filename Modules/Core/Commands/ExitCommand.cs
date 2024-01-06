namespace CheetahToolbox.Modules.Core.Commands;

using global::CheetahToolbox.Commands;

public class ExitCommand(ModuleBase module) : CommandBase(module, "exit", "quit the program")
{
    public override CommandResult Execute(string? subCommand, string[]? args)
    {
        Environment.Exit(0);
        return new CommandResult(true, "Exiting..");
    }
}