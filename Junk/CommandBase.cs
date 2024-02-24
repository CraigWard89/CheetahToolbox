/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace Toolbox;

public class CommandBase
{
    public string Name { get; set; }
    public string Description { get; set; }

    public CommandBase(string? name = null, string? description = null)
    {
        Name = name ?? GetType().Name;
        Description = description ?? "No description provided.";
    }

    public virtual CommandResult? Execute(string[]? args)
    {
        return null;
    }
}