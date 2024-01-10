/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
#if DEBUG && EDITOR
namespace CheetahToolbox.Commands;

[CommandGroup("Search")]
public class Search() : CommandBase()
{
    [Command(defaultCommand: true)]
    public static void Default() => Console.WriteLine("WIP: Coming Soon.."); // WIP: Search

    // TODO: Search Files
    // TODO: Search Registry
    // TODO: Search Package Managers
}
#endif