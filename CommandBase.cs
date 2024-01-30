/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================

//    public CommandBase(string? name = null, string? description = null, bool subCommands = false)
//    {
//        Name = name ?? GetType().Name;
//        Description = description ?? "No description provided.";
//        if (subCommands) SubCommands = [];
//    }

//    public override string? ToString()
//    {
//        if (SubCommands == null) return $"cmd[\"{Name}\", \"{Description}\"]";
//        return $"cmd[\"{Name}\", \"{Description}\"] {string.Join("|", SubCommands)}";
//    }

//    public virtual CommandResult Execute(string? subCommand, string[]? args)
//    {
//        Environment.Exit(0);
//        return new CommandResult(true, "Exiting..");
//    }
//}