namespace CheetahToolbox.Commands;


public class CommandContext(Modules.ModuleBase module, string name, string[] args)
{
    /// <summary>
    /// The module this command belongs to
    /// </summary>
    public Modules.ModuleBase Module { get; private set; } = module;

    /// <summary>
    /// The name of the command executed
    /// </summary>
    public string Name { get; private set; } = name;

    /// <summary>
    /// The arguments passed to the command
    /// </summary>
    public string[] Args { get; private set; } = args;
}