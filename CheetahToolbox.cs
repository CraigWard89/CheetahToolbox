namespace CheetahToolbox;

using Commands;
using Modules;
using OS.Windows;
using System;

public class CheetahToolbox
{
    public readonly CheetahEnvironment Environment = new();

    public readonly ChocolateyManager Chocolatey = new();

    public CheetahToolbox(List<string> args)
    {
        Log.Level = Log.LogLevel.SUPER;
        Log.Write("CheetahToolbox");

#if WINDOWS
        Environment.Start();
#endif

        ApplicationManager.Init();
        RegistryManager.Init();

        ModuleManager.Start();

        if (Chocolatey.IsInstalled)
        {
            Console.WriteLine($"Chocolatey {Chocolatey.Version}");
        }

        // WIP: Better Prompt

        string username = Environment.UserName;
        string hostname = Environment.MachineName;
        string prompt = string.Join("", username, "@", hostname, " $ ");

        while (true)
        {
            Console.Write(prompt);
            string? line = Console.ReadLine();

            if (!string.IsNullOrEmpty(line))
            {
                string[] split = line.Split(' ');
                string command = split[0];
                string[] arguments = split[1..];

                CommandResult? result = ModuleManager.ExecuteCommand(this, command, arguments);
                if (result == null) break;

                Console.WriteLine(result.Message);
            }
        }
    }
}