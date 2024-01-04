namespace CheetahToolbox.Modules.Core.Commands;

using global::CheetahToolbox.Commands;

public class ExitCommand() : CommandBase("exit", "quit the program")
{
    public override CommandResult Execute(CommandContext context)
    {
        Environment.Exit(0);
        return new CommandResult(true, "Exiting..");
    }
}