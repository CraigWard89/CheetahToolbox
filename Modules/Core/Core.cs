namespace CheetahToolbox.Modules.Core;

public class Core : ModuleBase
{
    public Core() : base(new ModuleInfo("core"))
    {
        Console.WriteLine("Core Initialized");
    }
}