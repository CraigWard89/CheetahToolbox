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
    public static string Build()
    {
        string username = Environment.UserName;
        string hostname = Environment.MachineName;
        string current = Environment.CurrentDirectory;
        string token = Environment.IsAdmin ? "$" : ">";
        return string.Join("", username, "@", hostname, $" {current} {token} ");
    }
}