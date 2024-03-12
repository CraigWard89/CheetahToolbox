/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace Toolbox;

using Modules;
using System.Reflection;

public static class Manager
{
    private static List<ModuleBase> Modules { get; set; } = [];

    public static void Initialize()
    {
        // Load Modules
        Assembly assembly = Assembly.GetExecutingAssembly();
        foreach (Type type in assembly.GetTypes())
        {
            if (type.IsSubclassOf(typeof(ModuleBase)))
            {
                if (Activator.CreateInstance(type) is ModuleBase module)
                {
                    Modules.Add(module);
                    module.Initialize();
                }
            }
        }

        Modules.ForEach((m) => m.PostInitialize());

#if VERBOSE
        Console.WriteLine($"Modules Loaded [{Modules.Count}]: {string.Join(", ", Modules)}");
#endif
    }

    public static void ExecuteCommand(string command, string[] args)
    {
        Console.WriteLine($"Command: {command}");
        foreach (ModuleBase module in Modules)
        {
            if (module.Name.Equals(command, StringComparison.OrdinalIgnoreCase))
            {
                string subCommand = args.Length > 0 ? args[0] : string.Empty;
                args = args.Length > 1 ? args[1..] : [];
                Console.WriteLine($"SubCommand: {subCommand}");
                Console.WriteLine($"Args: {string.Join(", ", args)}");
                module.Execute(command, args);
                break;
            }
        }
    }
}