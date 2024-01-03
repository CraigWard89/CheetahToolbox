#if WIP
namespace CheetahTerminal.Modules;

public class ModuleInfo(string name)
{
	public string Name { get; private set; } = name;
	public string Author { get; private set; } = string.Empty;

	public ModuleInfo WithAuthor(string author)
	{
		Author = author;
		return this;
	}
}
#endif