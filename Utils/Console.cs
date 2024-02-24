/// ======================================================================
///		CheetahUtils: (https://github.com/CraigCraig/CheetahUtils)
///				Project:  Craig's CheetahUtils a Collection of C# Utils
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
#if WINDOWS
namespace Toolbox.Utils;
public static class Console
{
    public enum ColorType : int
    {
        FOREGROUND = 38,
        BACKGROUND = 48
    }

    public static void AppendTitle(string value)
    {
        System.Console.Title = $"{System.Console.Title} {value}";
    }

    public static void SetColor(ColorType type, Color color)
    {
        switch (type)
        {
            case ColorType.FOREGROUND:
                System.Console.Write(ForegroundColor(color));
                break;
            case ColorType.BACKGROUND:
                System.Console.Write(BackgroundColor(color));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }

    public static string ForegroundColor(Color color)
    {
        return $"\x1b[{38};2;{color.R};{color.G};{color.B}m";
    }

    public static string BackgroundColor(Color color)
    {
        return $"\x1b[{48};2;{color.R};{color.G};{color.B}m";
    }
}
#endif