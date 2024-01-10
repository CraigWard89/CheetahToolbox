/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox.Commands;

/// <summary>
/// <br>Defines a class as a group of commands.</br>
/// <br>Be sure to inherit the <seealso cref="CommandGroup"/> class.</br>
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class CommandGroupAttribute : Attribute
{
    public string Name;
    public string[] Aliases;
    public string Description;

    public List<CommandGroupAttribute> Children = [];
    public List<CommandAttribute> Commands = [];

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "Breaks Reflection")]
    public CommandGroupAttribute(string? name = null, string[]? aliases = null, string? description = null) : base()
    {
        Name = name ?? string.Empty;
        Aliases = aliases ?? [];
        Description = description ?? string.Empty;
    }
}