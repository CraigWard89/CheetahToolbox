namespace CheetahToolbox.Modules.Core.Commands;

using global::CheetahToolbox.Commands;

public class ScanCommand() : CommandBase("scan", "scan")
{
    public override CommandResult Execute(CommandContext context)
    {
        string[] args = context.Args;
        if (args.Length < 1)
        {
            return new CommandResult(false, "invalid arguments");
        }

        string subcommand = args[0];
        if (subcommand == "apps")
        {
            Console.WriteLine("Scanning Applications");
            ApplicationManager.Scan();
        }

        return new CommandResult(true);
    }
}