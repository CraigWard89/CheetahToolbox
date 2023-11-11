namespace WinToolbox.Commands;

public class Exit : Command
{
    public Exit() : base("exit", "quit the program") { }

    public override void Execute(string[] args)
    {
        WinToolbox.Close();
    }
}