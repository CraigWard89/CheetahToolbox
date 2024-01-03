#if WIP
namespace CheetahTerminal.Modules;

#region Using Statements
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using CheetahTerminal.Commands;
#endregion

public static class ModuleManager
{
	public static List<Module> Modules { get; private set; } = [];

	public static int ModuleCount => Modules.Count;

	public static int CommandCount
	{
		get
		{
			int count = 0;
			foreach (Module module in Modules)
			{
				count += module.Commands.Count;
			}
			return count;
		}
	}

	public static void Start()
	{
		string modulesPath = FolderPaths.Modules;
		if (!Directory.Exists(modulesPath)) _ = Directory.CreateDirectory(modulesPath);

		foreach (string entry in Directory.GetFiles(modulesPath))
		{
			if (entry.EndsWith(".module.dll"))
			{
				Assembly assembly = Assembly.LoadFile(entry);
			}
		}

		foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
		{
			Type[] types = assembly.GetTypes();
			foreach (Type type in types)
			{
				if (type.BaseType == null || type.BaseType.FullName == null) continue;
				if (type.BaseType.FullName.Equals(typeof(Module).FullName))
				{
					if (type == null || string.IsNullOrEmpty(type.FullName)) continue;
					if (assembly.FullName == null) continue;
					if (assembly.CreateInstance(type.FullName) is Module module)
					{
						module.Initialize();
						Modules.Add(module);

						// Add Commands from Modules Namespace
						foreach (Type type2 in types)
						{
							if (type2.BaseType == null || type2.BaseType.FullName == null) continue;
							if (!type2.BaseType.FullName.Equals(typeof(Command).FullName)) continue;
							{
								if (type2 == null || string.IsNullOrEmpty(type2.FullName)) continue;
								if (assembly.CreateInstance(type2.FullName) is not Command command) continue;
								module.Commands.Add(command);
							}
						}
					}
				}
			}
		}
	}

	public static Module? GetModule(string command)
	{
		foreach (Module module in Modules)
		{
			if (module.Info.Name == command)
			{
				return module;
			}
		}
		return null;
	}

	internal static CommandResult? ExecuteCommand(string command, string[] cmdArgs)
	{
		// TODO: Split commands by | and execute them in order, allowing for piping
		if (command.StartsWith('?'))
		{
			command = command[1..];
			if (string.IsNullOrEmpty(command)) return new CommandResult(false, "No Module Specified");

			StringBuilder response = new();

			_ = response.Append($"Modules");

			return new CommandResult(true, response.ToString());
		}

		foreach (Module module in Modules)
		{
			foreach (Command cmd in module.Commands)
			{
				if (cmd.Name.ToLower().Equals(command.ToLower()))
				{
					return cmd.Execute(new CommandContext(module, command, cmdArgs));
				}
			}
		}
		return new CommandResult(false, $"Command Not Found: {command}");
	}
}
#endif