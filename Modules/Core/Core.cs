namespace CheetahToolbox.Modules.Core;

public class Core : ModuleBase
{
    public Core(CheetahToolbox toolbox) : base(toolbox, new ModuleInfo("core"))
    {
        Console.WriteLine("Core Initialized");
    }
}