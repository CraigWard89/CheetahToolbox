/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigWard89/CheetahToolbox)
///				Project:  CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Ward (https://github.com/CraigWard89)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace Toolbox;

using System.Runtime.CompilerServices;

public static class Log
{
    public static void Write(string message)
    {
        Console.WriteLine(message);
    }

    public static void Debug(string message, [CallerMemberName] string caller = "")
    {
        Write($"[DEBUG] [{caller}] {message}");
    }
}