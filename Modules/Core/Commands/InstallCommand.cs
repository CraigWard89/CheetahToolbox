#if WINDOWS
namespace CheetahToolbox.Modules.Core.Commands;

using global::CheetahToolbox.Commands;
using System;

/// <summary>
/// Attribute to mark a command as requiring admin privileges to be executed.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class AdminRequiredAttribute() : Attribute();

[AdminRequired]
public class InstallCommand(ModuleBase module) : CommandBase(module, "install", "Install CheetahToolbox to this machine")
{
    public override CommandResult Execute(string? subCommand, string[]? args)
    {
        if (string.IsNullOrEmpty(subCommand)) return new CommandResult(false, "No argument provided");

        switch (subCommand)
        {
            case "toolbox":
                Module.Toolbox.Context.Installer.Execute();
                break;
            case "chocolatey":
                if (Module.Toolbox.Context.Chocolatey != null && !Module.Toolbox.Context.Chocolatey.IsInstalled)
                {
                    Log.Write("Installing Chocolatey, Please Wait..");
                    Module.Toolbox.Context.Chocolatey.Install();
                    return new CommandResult(true);
                }
                break;
            default:
                return new CommandResult(false, "Invalid argument");
        }

        return new CommandResult(true);
    }
}
#endif