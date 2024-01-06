namespace CheetahToolbox;
using Managers;

public class ToolboxContext
{
    public CheetahToolbox Toolbox;
    public EnvironmentManager Environment;
    public ChocolateyManager Chocolatey;
    public ApplicationManager Applications;
    public InstallManager Installer;
    public ModuleManager Modules;

    public ToolboxContext(CheetahToolbox toolbox)
    {
        Toolbox = toolbox;
        Environment = new(this);
        Chocolatey = new(this);
        Applications = new(this);
        Installer = new(this);
        Modules = new(this);
    }
}