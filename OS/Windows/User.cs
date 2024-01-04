#if WINDOWS || WINDOWS_FAKE
namespace CheetahToolbox.OS.Windows;

public static class User
{
    public static string Name
    {
        get
        {
            string? name = Environment.UserName;
            if (string.IsNullOrEmpty(name))
                name = Environment.GetEnvironmentVariable("USERNAME");
            return name ?? "";
        }
    }
}
#endif