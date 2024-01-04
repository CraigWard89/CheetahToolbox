namespace CheetahToolbox.Modules.Core.Commands;

using global::CheetahToolbox.Commands;

public class ClearCommand() : CommandBase("clear", "clear the console")
{
    public override CommandResult Execute(CommandContext context)
    {
        Console.Clear();
        return new CommandResult(true);
    }
}