namespace WinToolbox;

public abstract class Command(string name)
{
    public string Name = name;
    public abstract void Execute(string[] args);
}