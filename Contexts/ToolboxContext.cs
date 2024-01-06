/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox.Contexts;

#if WINDOWS
using Managers.Packages;
#endif
using Managers;

/// <summary>
/// <br>Contains all the managers and context for the toolbox.</br>
/// <br>Managers are used to manage the state of the system.</br>
/// <br>Contexts are used to provide information about the system.</br>
/// </summary>
public class ToolboxContext
{
    #region Core Managers
    public CheetahToolbox Toolbox;
#if WINDOWS
    public RegistryManager Registry;
#endif
    public EnvironmentManager Environment;
#if WINDOWS
    public ApplicationManager Applications;
    public InstallManager Installer;
#endif
    public ModuleManager Modules;
    public CommandManager Commands;
    #endregion

    #region Package Managers
#if WINDOWS
    /// <summary>
    /// Package Managers
    /// </summary>
    public PackageManagers Packages;
    public struct PackageManagers(ToolboxContext context)
    {
        public ChocolateyManager Chocolatey = new(context);
        public WingetManager Winget = new(context);
        public ScoopManager Scoop = new(context);

        public readonly bool HasAny
        {
            get
            {
                bool flag = false;
                if (Chocolatey.IsInstalled) flag = true;
                if (Scoop.IsInstalled) flag = true;
                if (Winget.IsInstalled) flag = true;
                return flag;
            }
        }

        public void Update()
        {
            if (Chocolatey.IsInstalled)
            {
                Chocolatey.Update();
            }

            if (Scoop.IsInstalled)
            {
                Scoop.Update();
            }

            if (Winget.IsInstalled)
            {
                Winget.Update();
            }
        }
    }
#endif
    #endregion

    public ToolboxContext(CheetahToolbox toolbox)
    {
        Toolbox = toolbox;
#if WINDOWS
        Registry = new(this);
#endif
        Environment = new(this);
#if WINDOWS
        Applications = new(this);
        Installer = new(this);
#endif
        Modules = new(this);
        Commands = new(this);
#if WINDOWS
        Packages = new(this);
#endif
    }
}