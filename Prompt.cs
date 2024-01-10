/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox;
public static class Prompt
{
    public static string Build(ToolboxContext context)
    {
        string username = context.Environment.UserName;
        string hostname = context.Environment.MachineName;
        string current = context.Environment.CurrentDirectory;
        string token = context.Environment.IsAdmin ? "$" : ">";
        return string.Join("", username, "@", hostname, $" {current} {token} ");
    }
}