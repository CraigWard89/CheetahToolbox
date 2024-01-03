#if WIP
namespace CheetahTerminal;

#region Using Statements
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CheetahTerminal.Modules;
using CheetahUtils;
using Microsoft.Win32.SafeHandles;
#endregion

public static class Terminal
{
	public static TerminalEnvironment Environment { get; } = new TerminalEnvironment();
	public static string Version { get; } = typeof(Terminal).Assembly.GetName().Version?.ToString() ?? string.Empty;
	public static ShutdownRequest? ShutdownRequest { get; set; }
	public static int Width { get; set; } = 80;
	public static int Height { get; set; } = 25;
	internal static ConsoleUtils.CharInfo[] CharBuffer { get; set; } = new ConsoleUtils.CharInfo[80 * 25];
	internal static SafeFileHandle OutputHandle { get; set; } = ConsoleUtils.CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);

	internal static StringBuilder LastInput { get; } = new();
	internal static List<string> Output { get; } = [];

	internal static int CursorX { get; set; } = 0;
	internal static int CursorY { get; set; } = 0;

	internal static void Initialize(string[] args)
	{
#if WINDOWS
#pragma warning disable CA1416 // Validate platform compatibility
		if (!Installer.IsInstalled)
		{
			Installer.Start();
		}
#pragma warning restore CA1416 // Validate platform compatibility
#endif
		Console.TreatControlCAsInput = true;
		Log.PrintToConsole = true;
		Log.Clear();
		Output.Add($"CheetahTerminal v{Version}" +
#if DEBUG
			$" (Debug)" +
#endif
			$"");

		if (args.Length > 0)
		{
			string command = args[0];
			string[] arguments = args.Skip(1).ToArray();

			if (!command.StartsWith('-'))
			{
				Output.Add("Invalid flags");
				return;
			}
		}

		if (OutputHandle.IsInvalid) throw new Exception("outputHandle is invalid!");

		ModuleManager.Start();
		Start();
	}

	internal static void Start()
	{
		List<Task> tasks = [];

		Output.Add($"Welcome to CheetahTerminal!");
		Output.Add($"	Try typing 'help'");

		tasks.Add(Task.Run(() =>
		{
			while (true)
			{
				if (ShutdownRequest != null) break;
				UpdateInput();
			}
		}));

		tasks.Add(Task.Run(() =>
		{
			while (true)
			{
				if (ShutdownRequest != null) break;
				UpdateOutput();
				Thread.Sleep(1);
			}
		}));

		Environment.CurrentDirectory = Environment.HomeDirectory;
		Task.WaitAll([.. tasks]);
		Console.Clear();
		Console.WriteLine("CheetahTerminal Terminated..");
	}

	internal static void UpdateInput()
	{
		ConsoleKeyInfo keyInfo = Console.ReadKey(true);
		Console.SetCursorPosition(CursorX, CursorY);
		ConsoleKey key = keyInfo.Key;
		char c = keyInfo.KeyChar;

		if (keyInfo.Modifiers == ConsoleModifiers.Control)
		{
			switch (key)
			{
				case ConsoleKey.C:
					{
						_ = LastInput.Clear();
						Output.Clear();
						return;
					}
			}
		}

		switch (key)
		{
			case ConsoleKey.Enter:
				{
					if (string.IsNullOrEmpty(LastInput.ToString())) return;

					string cmd = LastInput.ToString().Split(' ')[0];
					string[] args = LastInput.ToString().Split(' ').Skip(1).ToArray();
					Console.Clear();
					Output.Clear();

					Commands.CommandResult? result = ModuleManager.ExecuteCommand(cmd, args);
					if (result != null)
					{
						Output.Add(result.Message);
					}
					_ = LastInput.Clear();
					return;
				}
			case ConsoleKey.Backspace:
				if (LastInput.Length > 0)
				{
					_ = LastInput.Remove(LastInput.Length - 1, 1);
				}
				return;
			case ConsoleKey.Tab:
				Output.Clear();
				_ = LastInput.Clear();
				return;
			case ConsoleKey.Escape:
				ShutdownRequest = new ShutdownRequest();
				return;
		}

		_ = LastInput.Append(c);
	}

	internal static void UpdateOutput()
	{
		// Fill CharBuffer with empty spaces
		for (int i = 0; i < CharBuffer.Length; i++)
		{
			CharBuffer[i].Char = ' ';
			CharBuffer[i].Attributes = 1;
		}

		// Draw Header
		WriteAt(0, DateTime.Now.ToString());

		// Draw Output
		int y = 23;
		string[] output = [.. Output];
		Array.Reverse(output);
		string[] tmp = output.Take(y).ToArray();

		foreach (string s in tmp)
		{
			WriteAt(y, s);
			y--;
		}

		// Draw Prompt
		WriteAt(24, $"{Environment.CurrentDirectory} > {LastInput}", true);

		ConsoleUtils.Rectangle rect = new(0, 0, (short) Width, (short) Height);
		_ = ConsoleUtils.WriteConsoleOutputW(OutputHandle, CharBuffer, new ConsoleUtils.Coord((short) Width, (short) Height), new ConsoleUtils.Coord(0, 0), ref rect);
	}

	internal static void ClearLine(int y)
	{
		for (int i = 0; i < Width; i++)
		{
			CharBuffer[i + (y * Width)].Char = ' ';
			CharBuffer[i + (y * Width)].Attributes = 0;
		}
	}

	internal static void WriteAt(int y, string line, bool placeCursorAfter = false)
	{
		// TODO: Line Wrapping
		if (line.Length > Width) return;

		ClearLine(y);
		for (int i = 0; i < line.Length; i++)
		{
			WriteAt(i, y, line[i], 7);
		}
		if (placeCursorAfter)
		{
			try
			{
				Console.SetCursorPosition(line.Length, y);
			}
			catch { }
		}
	}

	internal static void WriteAt(int x, int y, char c, short attributes)
	{
		CharBuffer[x + (y * Width)].Char = c;
		CharBuffer[x + (y * Width)].Attributes = attributes;
	}

	internal static void Stop()
	{

	}
}
#endif