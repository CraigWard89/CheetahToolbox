/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace Toolbox;

/// <summary>
/// <br>Defines a method as a command.</br>
/// <br>Be sure to inherit the <seealso cref="CommandBase"/> class.</br>
/// <br>Make sure to use <seealso cref="CommandGroupAttribute"/> on the class the command is in.</br>
/// </summary>
[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public class CommandAttribute : Attribute
{
    public string Name;
    public string[] Aliases;
    public string Description;

    /// <summary>
    /// <br>Defines this command as the default for the command group.</br>
    /// <br>Meaning this command will be invoked when the group is called directly by the user.</br>
    /// </summary>
    public bool Default;

    public CommandAttribute(string? name = null, string[]? aliases = null, string? description = null, bool defaultCommand = false) : base()
    {
        Name = name ?? GetType().Name;
        Aliases = aliases ?? [];
        Description = description ?? string.Empty;
        Default = defaultCommand;
    }
}