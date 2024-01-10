/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
/// link:CommandBase.cs
/// ======================================================================
namespace CheetahToolbox.Commands;

using System;
using System.Reflection;

public class CommandManager : ManagerBase
{
    public readonly List<CommandBase> Commands = [];
    private readonly List<CommandAttribute> attributes = [];

    public CommandManager(ToolboxContext context) : base(context, "Commands")
    {
        LoadCommands();
    }

    public void LoadCommands()
    {
        Assembly? assembly = Assembly.GetEntryAssembly();
        if (assembly == null) return;
        Log.Super($"Assembly: {assembly.FullName}");

        foreach (Type type in assembly.GetExportedTypes())
        {
            CommandGroupAttribute? attribute = type.GetCustomAttribute<CommandGroupAttribute>();
            if (attribute == null) continue;

            if (string.IsNullOrEmpty(attribute.Name))
            {
                attribute.Name = type.Name;
            }

            Log.Super($"Group: {attribute.Name}");

            foreach (MethodInfo method in type.GetMethods())
            {
                CommandAttribute? attribute2 = method.GetCustomAttribute<CommandAttribute>();
                if (attribute2 == null) continue;

                Log.Super($"\t{method.Name}");
            }

            if (type.DeclaringType == null) // Root Types/Commands
            {
                Log.Super("\tRoot");
            }


        }
    }

    public List<CommandAttribute> GetCommandAttributes(Type type)
    {
        List<CommandAttribute> temp = [];

        temp.AddRange(type.GetCustomAttributes().OfType<CommandAttribute>());

        foreach (MethodInfo method in type.GetMethods())
        {
            temp.AddRange(method.GetCustomAttributes().OfType<CommandAttribute>());
        }

        return temp;
    }

    public CommandResult? HandleCommand(string command, string[] arguments)
    {
        // WIP: Finish Command Reworks

        if (string.IsNullOrEmpty(command))
            return new CommandResult(false, "Command is null or empty");

        Log.Write($"Commands:\n{string.Join("\n", Commands)}");

        foreach (CommandBase cmd in Commands)
        {
            if (cmd.Name == command)
                Log.Write($"{cmd.Name}");
        }

        return new CommandResult(true, "reworking commands");
        //return new CommandResult(false, $"Command not found: {command}");
    }

    //public void AddCommand(CommandBase command) => _commands.Add(command);
}