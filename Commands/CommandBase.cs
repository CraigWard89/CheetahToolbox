namespace CheetahToolbox.Commands;
public abstract class CommandBase(string name, string description)
{
    public string Name = name;
    public string Description = description;

    public abstract CommandResult Execute(CommandContext context);
}