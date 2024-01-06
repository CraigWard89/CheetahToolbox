namespace CheetahToolbox.Modules.Core;

public class Core : ModuleBase
{
    public Core(ToolboxContext context) : base(context, new ModuleInfo("core"))
    {
        Console.WriteLine("Core Initialized");
    }
}