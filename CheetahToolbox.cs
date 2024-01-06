namespace CheetahToolbox;

using Commands;
using Exceptions;
using System;

public class CheetahToolbox
{
    public readonly ToolboxContext Context;
    public readonly Logger Log;

    public CheetahToolbox(List<string> args)
    {
        Log = new Logger("[CheetahToolbox]", Logger.LogLevel.WARNING);
        Log.Write("test");

        Version version = typeof(CheetahToolbox).Assembly.GetName().Version ?? throw new VersionNotFoundException();
        Console.WriteLine($"CheetahToolbox v{version}");

        Context = new(this);

        if (Context.Chocolatey.IsInstalled)
        {
            Console.WriteLine($"Chocolatey {Context.Chocolatey.Version}");
        }

        if (args.Count > 0)
        {
            // WIP: Argument Parsing
            Console.WriteLine("Arguments detected, parsing..");
        }

        while (true)
        {
            Console.Write(Prompt.Build(Context));
            string? line = Console.ReadLine();

            if (!string.IsNullOrEmpty(line))
            {
                string[] split = line.Split(' ');
                string command = split[0];
                string[] arguments = split[1..];

                CommandResult? result = Context.Modules.ExecuteCommand(command, arguments);
                if (result == null) break;

                Console.WriteLine(result.Message);
            }
        }
    }
}

public static class Prompt
{
    public static string Build(ToolboxContext context)
    {
        string username = context.Environment.UserName;
        string hostname = context.Environment.MachineName;
        return string.Join("", username, "@", hostname, " $ ");
    }
}