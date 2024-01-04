namespace CheetahToolbox;

public class CheetahToolbox
{
    // TODO: CommandHandler

    public CheetahToolbox(List<string> args)
    {
        Console.WriteLine("CheetahToolbox");
        Console.WriteLine($"Chocolatey {Chocolatey.Version}");

        Modules.ModuleManager.Start();

#if WINDOWS
        // WIP: Application Scanning
        //ApplicationManager.Scan();

        // WIP: Registry Scanning
#pragma warning disable CA1416 // Validate platform compatibility
        //RegistryManager.Scan(); // Warning Disabled: Compiler Constant Check
#pragma warning restore CA1416 // Validate platform compatibility

        // WIP: Chocolatey Caching
        //Chocolatey.CachePrograms();

        // TODO: Scan for broken shortcuts in Start Menu
        //ShortcutManager.Scan();
#endif
        // TODO: Port Command Handler from link:CommandHandler.cs#L2
        while (true)
        {
            Console.Write(" > ");
            string? line = Console.ReadLine();

            if (!string.IsNullOrEmpty(line))
            {
                string[] split = line.Split(' ');
                string command = split[0];
                string[] arguments = split[1..];

                Commands.CommandResult? result = Modules.ModuleManager.ExecuteCommand(command, arguments);
                if (result == null) break;

                Console.WriteLine(result.Message);
            }
        }
    }
}