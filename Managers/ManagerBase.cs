namespace CheetahToolbox.Managers;

public abstract class ManagerBase
{
    public readonly string Name;
    public readonly Logger Log;

    public ManagerBase(ToolboxContext context, string name)
    {
        Name = name;
        Log = new Logger($"[{Name}]");
        Log.Write("Initialized.");
    }
}