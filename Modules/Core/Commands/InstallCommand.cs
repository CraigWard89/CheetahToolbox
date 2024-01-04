#if WINDOWS
namespace CheetahToolbox.Modules.Core.Commands;

using global::CheetahToolbox.Commands;

public class InstallCommand() : CommandBase("install", "Install CheetahToolbox to this machine")
{
    public override CommandResult Execute(CommandContext context)
    {
        string path = Path.Combine(FolderPaths.ProgramFiles, "CheetahToolbox");
        Console.WriteLine(path);

        if (!context.Toolbox.Chocolatey.IsInstalled)
        {
            context.Toolbox.Chocolatey.Install();
        }

        OS.Windows.Installer.Start();

        return new CommandResult(true);
    }
}
#endif