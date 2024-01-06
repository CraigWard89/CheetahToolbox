namespace CheetahToolbox.Modules.Core.Commands;

using global::CheetahToolbox.Commands;

public class ClearCommand(ModuleBase module) : CommandBase(module, "clear", "clear the console")
{
    public override CommandResult Execute(string? subCommand, string[]? args)
    {
        Console.Clear();
        return new CommandResult(true);
    }
}