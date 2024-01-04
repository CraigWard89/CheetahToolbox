namespace CheetahToolbox;

public class AppEntry(string name, string? version, AppEntry.AppSource source)
{
    public string Name = name;
    public string? Version = version; // TODO: Compare AppEntry Versions
    public AppSource Source = source;

    public enum AppSource
    {
        LOCAL, CHOCOLATEY
    }
}