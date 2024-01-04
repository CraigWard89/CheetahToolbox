#if WINDOWS || WINDOWS_FAKE
namespace CheetahToolbox.OS.Windows;

public static class Machine
{
    private static readonly List<StringNameValuePair> variables = [];

    public static string Name
    {
        get
        {
            string? name = Environment.MachineName;
            if (string.IsNullOrEmpty(name))
                name = Environment.GetEnvironmentVariable("COMPUTERNAME");
            return name ?? "";
        }
    }

    public static string DomainName
    {
        get
        {
            string? name = Environment.UserDomainName;
            if (string.IsNullOrEmpty(name))
                name = Environment.GetEnvironmentVariable("USERDOMAIN");
            return name ?? "";
        }
    }

    public static string GetNativeVariable(string name) => Environment.GetEnvironmentVariable(name) ?? "";


}
#endif