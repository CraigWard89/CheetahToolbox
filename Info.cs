/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigWard89/CheetahToolbox)
///				Project:  CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Ward (https://github.com/CraigWard89)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace Toolbox;

using Modules;

public class Info : ModuleBase
{
    public override string Name { get; set; } = "Info";

    public override string[] Aliases { get; set; } = ["info"];

    public override string Description { get; set; } = "Information Module";

    public override void Initialize()
    {
    }

    public override void Execute(string command, string[] args)
    {
        Console.WriteLine("WIP Feature!");
    }
}