#if WIP
namespace CheetahTerminal.Commands;
public abstract class Command(string name, string description)
{
	public string Name = name;
	public string Description = description;

	public abstract CommandResult Execute(CommandContext context);
}
#endif