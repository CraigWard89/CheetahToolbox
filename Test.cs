/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox;
using CliWrap;
public static class Test
{
    public const string InstallCommand = "Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))";

    //public static List<CommandBase> Cmds { get; private set; } = [];
    //private static readonly List<CommandAttribute> attributes = [];

    public static void LoadCommands()
    {
        //Assembly? assembly = Assembly.GetEntryAssembly();
        //if (assembly == null) return;
        //Log.Super($"Assembly: {assembly.FullName}");

        //    foreach (Type type in assembly.GetExportedTypes())
        //    {
        //        CommandGroupAttribute? attribute = type.GetCustomAttribute<CommandGroupAttribute>();
        //        if (attribute == null) continue;

        //        if (string.IsNullOrEmpty(attribute.Name))
        //        {
        //            attribute.Name = type.Name;
        //        }

        //        Log.Super($"Group: {attribute.Name}");

        //        foreach (MethodInfo method in type.GetMethods())
        //        {
        //            CommandAttribute? attribute2 = method.GetCustomAttribute<CommandAttribute>();
        //            if (attribute2 == null) continue;

        //            Log.Super($"\t{method.Name}");
        //        }

        //        if (type.DeclaringType == null) // Root Types/Commands
        //        {
        //            Log.Super("\tRoot");
        //        }
        //    }
    }

    //public List<CommandAttribute> GetCommandAttributes(Type type)
    //{
    //    List<CommandAttribute> temp = [];

    //    temp.AddRange(type.GetCustomAttributes().OfType<CommandAttribute>());

    //    foreach (MethodInfo method in type.GetMethods())
    //    {
    //        temp.AddRange(method.GetCustomAttributes().OfType<CommandAttribute>());
    //    }

    //    return temp;
    //}

    public static CommandResult? HandleCommand(string command, string[] arguments) => null;

    //if (string.IsNullOrEmpty(command))
    //    return new CommandResult(false, "Command is null or empty");

    //Log.Write($"Commands:\n{string.Join("\n", Cmds)}");

    //foreach (CommandBase cmd in Cmds)
    //{
    //    if (cmd.Name == command)
    //        Log.Write($"{cmd.Name}");
    //}

    //return new CommandResult(true, "reworking commands");

    //public void AddCommand(CommandBase command) => _commands.Add(command);
}