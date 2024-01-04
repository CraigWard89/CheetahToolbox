namespace CheetahToolbox.Modules.Core.Commands;

using global::CheetahToolbox.Commands;

public class HelpCommand() : CommandBase("help", "this menu")
{
    public override CommandResult Execute(CommandContext context)
    {
        StringBuilder sb = new();
        foreach (ModuleBase module in ModuleManager.Modules)
        {
            _ = sb.Append($"Module: {module.Info.Name}{Environment.NewLine}");

            foreach (CommandBase command in module.Commands)
            {
                _ = sb.Append($"\tCommand: {command.Name}");
            }
        }

        return new CommandResult(true, sb.ToString());
    }
}