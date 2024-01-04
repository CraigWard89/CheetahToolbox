namespace CheetahToolbox;

public class CheetahToolbox
{
    // TODO: CommandHandler

    public CheetahToolbox(List<string> args)
    {
        Console.WriteLine("CheetahToolbox");
        Console.WriteLine($"Chocolatey {Chocolatey.Version}");

        ApplicationManager.Start();
        RegistryManager.Start();

        Modules.ModuleManager.Start();

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

                Commands.CommandResult? result = Modules.ModuleManager.ExecuteCommand(command, arguments);
                if (result == null) break;

                Console.WriteLine(result.Message);
            }
        }
    }
}