/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox;
using System.IO;
public static class Paths
{
    public static string RoamAppData => Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), "CheetahToolbox");
    public static string LocalAppData => Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "CheetahToolbox");
    public static string ProgramFiles => Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles), "CheetahToolbox");
    public static string Modules => Path.Combine(Environment.CurrentDirectory, "Modules");
}