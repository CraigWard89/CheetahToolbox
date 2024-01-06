/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
#if WIP
namespace CheetahTerminal.Modules.Core.Commands;

using System.IO;
using CheetahTerminal.Commands;

public class Ls() : Command("ls", "")
{
	public override CommandResult Execute(CommandContext context)
	{
		foreach (string entry in Directory.GetFileSystemEntries(Terminal.Environment.CurrentDirectory))
		{
			Terminal.Output.Add(entry);
		}
		return new CommandResult(true, "");
	}
}
#endif