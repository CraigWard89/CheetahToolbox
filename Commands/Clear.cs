/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox.Commands;

[CommandGroup("Clear", null, "Clear the console")]
public class Clear() : CommandBase()
{
    [Command(defaultCommand: true)]
    public static CommandResult? Default()
    {
        Console.Clear();
        return new CommandResult(true);
    }
}