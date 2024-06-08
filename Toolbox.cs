/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigWard89/CheetahToolbox)
///				Project:  CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Ward (https://github.com/CraigWard89)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace Toolbox;

using Core;

public static class Toolbox
{
    public static Version? ToolboxVersion { get; } = typeof(Toolbox).Assembly.GetName().Version;

    public static bool IsDebug { get; private set; }
    public static bool IsInteractive { get; private set; }

    internal static void Initialize(string[] pargs)
    {
        Log.Write($"CheetahToolbox v{ToolboxVersion}");
        Log.Write($"https://github.com/CraigWard89/CheetahToolbox");
        if (pargs.Length > 0)
        {
            foreach (string arg in pargs)
            {
                if (arg.StartsWith('-'))
                {
                    switch (arg)
                    {
                        case "-d":
                            Console.WriteLine("Debug Mode");
                            break;
                        case "-v":
                            Console.WriteLine(ToolboxVersion);
                            break;
                        case "-i":
                            IsInteractive = true;
                            break;
                        case "-e":
                            Console.WriteLine("Experiment");
                            //WindowsRegistry.ListInstalledApplications();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        // Interactive Mode
        if (pargs.Length == 0) IsInteractive = true;
        if (!IsInteractive) return;

        Manager.Initialize();

        Window window = new("main", "Main Window");

        while (true)
        {
            Console.Write("toolbox $ ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;

            string[] parts = input.Split(' ');
            string command = parts[0];
            string[] cargs = parts.Length > 1 ? parts[1..] : [];

            Manager.ExecuteCommand(command, cargs);
        }
    }
}