/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigWard89/CheetahToolbox)
///				Project:  CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Ward (https://github.com/CraigWard89)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace Toolbox;

public class ModuleBase
{
    public virtual string Name { get; set; } = string.Empty;
    public virtual string[] Aliases { get; set; } = [];
    public virtual string Description { get; set; } = string.Empty;

    public virtual void Initialize()
    {
    }

    /// <summary>
    /// Is called after all mods are initialized
    /// </summary>
    public virtual void PostInitialize()
    {
    }

    public virtual void Execute(string command, string[] args)
    {
    }
}