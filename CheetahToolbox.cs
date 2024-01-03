namespace CheetahToolbox;

#region Using Statements
using System;
using System.Collections.Generic;
#endregion

public class CheetahToolbox
{
    public CheetahToolbox(List<string> args)
    {
        Console.WriteLine("CheetahToolbox");
        //var cu = Registry.CurrentUser.Name;
        //Console.WriteLine(cu.ToString());

        Console.WriteLine(Chocolatey.Version);

        // WIP: Chocolatey Caching
        Chocolatey.CachePrograms();

        // TODO: Command Handler
        while (true)
        {
            var line = Console.ReadLine();
            switch (line)
            {
                case "help":
                    Console.WriteLine("help - Show this help");
                    Console.WriteLine("exit - Exit the program");
                    Console.WriteLine("choco - Chocolatey Experiments");
                    Console.WriteLine("gh - Git/GitHub Experiments");
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                case "gh":
                    Console.WriteLine("Git/GitHub WIP");
                    break;
                default:
                    Console.WriteLine($"Unknown Command: {line}");
                    break;
            }
        }
    }
}