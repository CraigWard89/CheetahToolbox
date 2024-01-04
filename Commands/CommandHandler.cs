namespace CheetahToolbox.Commands;

#region Using Statements
using System.Collections.Generic;
#endregion

public class CommandHandler(Modules.ModuleBase module)
{
    public readonly Modules.ModuleBase Module = module;
    private readonly List<CommandBase> _commands = [];

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "WIP")]
    public void Start()
    {
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "WIP")]
    public void Stop()
    {
    }

    public CommandResult? HandleCommand(CheetahToolbox toolbox, string command, string[] arguments)
    {
        if (string.IsNullOrEmpty(command))
            return new CommandResult(false, "Command is null or empty");

        foreach (CommandBase cmd in _commands)
        {
            if (cmd.Name == command)
                return cmd.Execute(new(toolbox, Module, command, arguments));
        }

        return new CommandResult(false, $"Command not found: {command}");
    }

    public void AddCommand(CommandBase command) => _commands.Add(command);
}