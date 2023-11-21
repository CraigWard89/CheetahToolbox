﻿namespace CheetahToolbox;

using System;
using CheetahApp;

public static class CheetahToolbox
{
	private static ConsoleApp? _app;

	public static void Initialize(string[] args)
	{
		//App.Name = "WinToolbox";
		//App.Author = "Craig Craig";
		//App.Version = Program.Version;
		var debug = args.Contains("--debug");

#if DEBUG
		debug = true;
#endif

		if (!OperatingSystem.IsWindows())
		{
			throw new Exception("Windows is the only supported OS.");
		}

		//string title = $"WinToolbox v{App.Version}";
		//if (debug) title += " (Debug)";
		//title += $" . CheeseyUtils v{CheeseyUtils.Version}";

		//_app = new(new AppSettings(800, 600, title));
		//var label = new Label(_app.RootElement, new(0, 0), new(128, 64), "Label");
		//_ = new Button(_app.RootElement, new(0, 0), new(128, 64), "Button", Scanner.DoScan);
		//_app.Run();
	}

	internal static void Close()
	{
		//App.Close();
	}
}