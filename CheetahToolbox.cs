namespace CheetahToolbox;

#region Using Statements
using CheetahUtils;
using System;
using System.Collections.Generic;
using System.Runtime.Versioning;
#endregion

public class CheetahToolbox
{
    public CheetahToolbox()
    {
        Console.WriteLine("CheetahToolbox");
        //var cu = Registry.CurrentUser.Name;
        //Console.WriteLine(cu.ToString());

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
                case "":
                    Chocolatey.CheckPrograms();
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