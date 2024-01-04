namespace CheetahToolbox;

public static class FolderPaths
{
    public static string RoamAppData => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CheetahTerminal");
    public static string LocalAppData => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CheetahTerminal");
    public static string ProgramFiles => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "CheetahTerminal");
    public static string Modules => Path.Combine(Environment.CurrentDirectory, "Modules");
}