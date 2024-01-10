/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox;

using Exceptions;
using Commands;
using Packages;

/// <summary>
/// <br>Main class for CheetahToolbox</br>
/// <br></br>
/// <br>All contexts can be accessed by using the <see cref="Context"/> property</br>
/// </summary>
public class CheetahToolbox
{
    public readonly ToolboxContext Context;
    public readonly Logger Log;

    public Version ToolboxVersion;

    public CheetahToolbox(List<string> args)
    {
        ToolboxVersion = typeof(CheetahToolbox).Assembly.GetName().Version ?? throw new VersionNotFoundException();
        Log = new Logger("CheetahToolbox");
        Context = new(this);

        if (args.Count > 0)
        {
            string command = args[0];

            // Handle Settings Flags
            foreach (string arg in args)
            {
                switch (command)
                {
                    case "-d":
                        Log.Write("Debug Mode");
                        break;
                    default:
                        break;
                }
            }

            // TODO: Make flags loads via reflection like commands 
            switch (command)
            {
                case "-v":
                    Console.WriteLine(ToolboxVersion);
                    break;
                case "-h":
                    Log.Write($"Help Coming Soon..");
                    break;
                case "-c":
                    Console.WriteLine("Coming soon");
                    break;
                case "-clsid":
                    if (args.Count > 1)
                    {
                        Context.Experimental.CheckCLSID(args[1]);
                    }
                    else
                    {
                        Log.Error("Failed: No ID Provided");
                    }
                    break;
                case "-s":
                    string? result = TerminalUtils.PowerShell("pwsh get-AppxPackage");
                    Console.WriteLine(result);
                    break;
                case "-u":
                    Context.Packages.Update();
                    break;
                case "-e":
                    Context.Experimental.CheckStartMenu();
                    break;
                case "-e2":
                    Context.Packages.Cygwin.Update();
                    break;
                case "-e3":
                    Context.Experimental.DoExperiment3();
                    break;
                case "-nada": // This is a command that does nothing, mainly for testing purposes from CLI
                    break;
                default:
                    break;
            }
            return;
        }

        Version version = typeof(CheetahToolbox).Assembly.GetName().Version ?? throw new VersionNotFoundException();
        Log.Write($"CheetahToolbox v{version}");

#if WINDOWS
        if (ChocolateyManager.IsInstalled)
        {
            Log.Write($"Chocolatey v{ChocolateyManager.Version}");
        }

        if (ScoopManager.IsInstalled)
        {
            Log.Write($"Scoop {ScoopManager.Version}");
        }

        if (WingetManager.IsInstalled)
        {
            Log.Write($"Winget {WingetManager.Version}");
        }
#endif

        while (true)
        {
            Console.Write(Prompt.Build(Context));
            string? line = Console.ReadLine();

            if (!string.IsNullOrEmpty(line))
            {
                string[] split = line.Split(' ');
                string command = split[0];
                string[] arguments = split[1..];

                CommandResult? result = Context.Commands.HandleCommand(command, arguments);
                if (result == null) break;

                Log.Write(result.Message);
            }
        }
    }

    internal static void Main(string[] args) => _ = new CheetahToolbox([.. args]);
}