/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace Toolbox.Modules;

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