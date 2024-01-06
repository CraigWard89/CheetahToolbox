namespace CheetahToolbox;

public class AppEntry(string? name, string? version, string? installPath, AppEntry.AppSource source)
{
    public string? Name = name;
    public string? Version = version; // TODO: Compare AppEntry Versions
    public string? InstallPath = installPath;
    public AppSource Source = source;

    public enum AppSource
    {
        LOCAL, CHOCOLATEY
    }
}