namespace CheetahToolbox;

using CheetahUtils;

internal class PluginManager
{
	public static void Initialize()
	{
		Log.WriteLine("PluginManager Initialized");
	}
}

/// <summary>
/// Base class for plugins.
/// </summary>
internal class Plugin(string name)
{
	public string Name { get; private set; } = name;
}