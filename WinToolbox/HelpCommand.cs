namespace WinToolbox;

using System.Text;

public class HelpCommand : Command
{
    public HelpCommand() : base("help") { }

    public override void Execute(string[] args)
    {
        Console.WriteLine("Commands:");
        StringBuilder sb = new();
        foreach (var command in CommandHandler.Commands)
        {
            _ = sb.Append(command.Key);
            if (!CommandHandler.Commands.Last().Equals(command))
            {
                _ = sb.Append(", ");
            }
        }
        Console.WriteLine(sb.ToString());
    }
}