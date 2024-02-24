/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace Toolbox;

using Modules;

public class Test : ModuleBase
{
    public override string Name { get; set; } = "Test";
    public override string Description { get; set; } = "Test Module";

    public override void Initialize()
    {
        Experimental.Terminal.Test();
    }

    public override void Execute(string command, string[] args)
    {
        Console.WriteLine("Success");
    }
}