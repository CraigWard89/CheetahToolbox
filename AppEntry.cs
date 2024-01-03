namespace CheetahToolbox;

public class AppEntry(string name, string version)
{
    public string Name = name;
    public string Version = version; // TODO: Compare AppEntry Versions
    public AppSource Source;
}