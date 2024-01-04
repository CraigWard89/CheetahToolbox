namespace CheetahToolbox;

using CheetahUtils;
using System;

public static class ShortcutManager
{
    public static void Scan()
    {
        Console.WriteLine("Shortcut Scan");

        string startMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
        Console.WriteLine($"Start Menu Path: {startMenuPath}");

        string[] startMenuFiles = Directory.GetFiles(startMenuPath, "*.lnk", SearchOption.AllDirectories);
        foreach (string file in startMenuFiles)
        {
            //Console.WriteLine($"Start Menu File: {file}");
            if (ShortcutUtils.IsValid(file))
            {
                Console.WriteLine("File is a valid shortcut");
            }
        }

        Console.WriteLine("Shortcut Scan Done");
    }
}