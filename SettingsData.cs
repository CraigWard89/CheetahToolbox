/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox.Features;

[Serializable]
public class SettingsData
{
    public class Chocolatey
    {
        public bool AutoUpdate { get; set; } = true;
    }
}

//public void Load()
//{
// // WIP: Implement Settings Manager

// // Get Settings File Path
//    string data = File.ReadAllText(filePath);

//    Deserialize Settings
//    Settings = JsonConvert.DeserializeObject<Settings>(data) ?? new();

//    Log.Write("Config Loaded");
//}
