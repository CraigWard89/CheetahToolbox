namespace WinToolbox.Commands;

using System.Text;

public class Help : Command
{
    public Help() : base("help", "get a list of commands") { }

    public override void Execute(string[] args)
    {
        Console.WriteLine("Commands:");
        StringBuilder sb = new();
        foreach (var command in CommandHandler.Commands)
        {
            _ = sb.AppendLine($"{command.Key} - {command.Value.Description}");
        }
        Console.WriteLine(sb.ToString());
    }
}