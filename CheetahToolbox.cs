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
using Contexts;
using Commands.Utils;

public class CheetahToolbox
{
    public readonly ToolboxContext Context;
    public readonly Logger Log;

    public CheetahToolbox(List<string> args)
    {
        Log = new Logger("CheetahToolbox");

        Version version = typeof(CheetahToolbox).Assembly.GetName().Version ?? throw new VersionNotFoundException();
        Log.Write($"CheetahToolbox v{version}");

        Context = new(this);

#if WINDOWS
        if (Context.Packages.Chocolatey.IsInstalled)
        {
            Log.Write($"Chocolatey v{Context.Packages.Chocolatey.Version}");
        }

        if (Context.Packages.Scoop.IsInstalled)
        {
            Log.Write($"Scoop {Context.Packages.Scoop.Version}");
        }

        if (Context.Packages.Winget.IsInstalled)
        {
            Log.Write($"Winget {Context.Packages.Winget.Version}");
        }

        if (Context.Packages.HasAny)
        {
            Log.Write("Package Managers Detected");
            Log.Write("Would you like to auto update?");
            Log.Write("Y/N");
            string? line = Console.ReadLine();
            if (line != null && line.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                Context.Packages.Update();
            }
        }
#endif

        // TODO: Command Flags (e.g. --help, --version, etc.)
        if (args.Count > 0)
        {
            string command = args[0];
            string[] arguments = args.Take(1).ToArray();
            CommandResult? result = Context.Commands.HandleCommand(command, arguments);
            if (result == null) return;
            Log.Write(result.Message);
        }
        else
        {
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
    }
}