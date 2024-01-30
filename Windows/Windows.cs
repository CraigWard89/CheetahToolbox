/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
#if WINDOWS
namespace CheetahToolbox.Modules;
[Module("Windows")]
public static class Windows
{
    public static void Init()
    {
        if (WindowsUtils.IsWin11())
        {
            // TODO: Implement Windows 11 Specific Features
        }

        // TODO: Implement Windows 10 Specific Features

        // TODO: Implement Universal Windows Features
    }

    public static void Close()
    {
    }
}
#endif