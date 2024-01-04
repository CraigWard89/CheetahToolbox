namespace CheetahToolbox;

public class AppEntry(string name, string? version, AppSource source)
{
    public string Name = name;
    public string? Version = version; // TODO: Compare AppEntry Versions
    public AppSource Source = source;
}