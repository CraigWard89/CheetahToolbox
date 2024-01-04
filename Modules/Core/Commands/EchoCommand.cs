namespace CheetahToolbox.Modules.Core.Commands;

using global::CheetahToolbox.Commands;

public class EchoCommand() : CommandBase("echo", "echo command")
{
    public override CommandResult Execute(CommandContext context) => new(true, string.Join(" ", context.Args));
}