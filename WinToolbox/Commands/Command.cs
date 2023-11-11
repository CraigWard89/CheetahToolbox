namespace WinToolbox.Commands;

public abstract class Command(string name)
{
    public string Name = name;
    public abstract void Execute(string[] args);
}