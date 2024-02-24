///// ======================================================================
/////		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
/////				Project:  Craig's CheetahToolbox a Swiss Army Knife
/////
/////
/////			Author: Craig Craig (https://github.com/CraigCraig)
/////		License:     MIT License (http://opensource.org/licenses/MIT)
///// ======================================================================
//namespace Toolbox;

//using CheetahUtils;
//using System.Reflection;

//public static class CommandHandler
//{
//    private static readonly List<CommandBase> commands = [];

//    public static CommandResult? ExecuteCommand(string command, string[]? args)
//    {
//        foreach (CommandBase cmd in commands)
//        {
//            if (cmd.Name == command)
//            {
//                return cmd.Execute(args);
//            }
//        }

//        return new(false, "Command not found");
//    }

//    public static void LoadCommands()
//    {
//        Assembly? assembly = Assembly.GetEntryAssembly();
//        if (assembly == null) return;

//        foreach (Type type in assembly.GetExportedTypes())
//        {
//            CommandGroupAttribute? attribute = type.GetCustomAttribute<CommandGroupAttribute>();
//            if (attribute == null) continue;

//            Log.Write($"Command Group: {attribute.Name}");

//            if (string.IsNullOrEmpty(attribute.Name))
//            {
//                attribute.Name = type.Name;
//            }

//            foreach (MethodInfo method in type.GetMethods())
//            {
//                CommandAttribute? attribute2 = method.GetCustomAttribute<CommandAttribute>();
//                if (attribute2 == null) continue;

//                Log.Write($"Command: {attribute2.Name}");

//                // commands.Add((CommandBase)Activator.CreateInstance(type));
//            }
//        }
//    }
//}