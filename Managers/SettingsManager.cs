/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox;

using Newtonsoft.Json;

public class SettingsManager : ManagerBase
{
    private Settings Settings { get; set; } = new();

    private readonly string folderPath;
    private readonly string filePath;

    public SettingsManager(ToolboxContext context) : base(context, "Settings")
    {
        folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "CheetahToolbox");
        filePath = Path.Combine(folderPath, "settings.json");

        Log.Super(filePath);

        if (!Directory.Exists(folderPath))
        {
            _ = Directory.CreateDirectory(folderPath);
        }

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(Settings));
        }

        Load();
    }

    public void Load()
    {
        // WIP: Implement Settings Manager

        // Get Settings File Path
        string data = File.ReadAllText(filePath);

        // Deserialize Settings
        Settings = JsonConvert.DeserializeObject<Settings>(data) ?? new();

        Log.Write("Config Loaded");
    }

    public void Save()
    {
        File.WriteAllText(filePath, JsonConvert.SerializeObject(Settings));
        Log.Write("Config Saved");
    }
}

[Serializable]
public class Settings
{
    public bool AutoUpdate { get; set; } = true;


}