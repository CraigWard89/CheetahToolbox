namespace WinToolbox.Commands;

public class Exit : Command
{
    public Exit() : base("exit") { }

    public override void Execute(string[] args)
    {
        WinToolbox.Close();
    }
}