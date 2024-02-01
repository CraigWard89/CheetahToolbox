/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox;

using Features;

[Module("Settings")]
public static class Settings
{
    public static SettingsData Data { get; private set; } = Load();

    private static SettingsData Load() => new();

    //private static readonly string folderPath = Path.Combine();
    //private static readonly string filePath = string.Empty;

    public static void Init()
    {
        //folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "CheetahToolbox");
        //filePath = Path.Combine(folderPath, "settings.json");
    }

    public static void Close()
    {
    }
}

//Log.Super(filePath);

//if (!Directory.Exists(folderPath))
//{
//    _ = Directory.CreateDirectory(folderPath);
//}

//if (!File.Exists(filePath))
//{
//    File.WriteAllText(filePath, JsonConvert.SerializeObject(Settings));

//public void Load()
//{

// // Get Settings File Path
//    string data = File.ReadAllText(filePath);

//    Deserialize Settings
//    Settings = JsonConvert.DeserializeObject<Settings>(data) ?? new();

//    Log.Write("Config Loaded");
//}

//public void Save()
//{
//    File.WriteAllText(filePath, JsonConvert.SerializeObject(Settings));
//    Log.Write("Config Saved");
//}

