#if WIP
namespace CheetahTerminal;

#region Using Statements
using System;
#endregion

/// <summary>
/// This class contains information about the environment for the terminal
/// </summary>
public class TerminalEnvironment
{
	public string CurrentDirectory { get; set; } = Environment.CurrentDirectory;
	public string HomeDirectory { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
}
#endif