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
        Console.WriteLine(Chocolatey.Version);

        // WIP: Chocolatey Caching
        Chocolatey.CachePrograms();

        // TODO: Port Command Handler from link:CommandHandler.cs#L2
        while (true)
        {
            Console.Write("> ");
            string? line = Console.ReadLine();
            switch (line)
            {
                case "help":
                    Console.WriteLine("help - Show this help");
                    Console.WriteLine("exit - Exit the program");
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine($"Unknown Command: {line}");
                    break;
            }
        }
    }
}