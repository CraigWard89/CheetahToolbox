namespace WinToolbox;

public class ExitCommand : Command
{
    public ExitCommand() : base("exit") { }

    public override void Execute(string[] args)
    {
        WinToolbox.Close();
    }
}