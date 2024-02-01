/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox;
using System.Runtime.InteropServices.Marshalling;
public static class Experimental
{
    /// <summary>
    /// Learning to mess with CLSID Com Objects
    /// </summary>
    public static void CheckCLSID(string id)
    {
        id = id.Replace("{", string.Empty);
        id = id.Replace("}", string.Empty);

        // {374DE290-123F-4565-9164-39C4925E467B} Downloads
        //TerminalUtils.CLSID("{374DE290-123F-4565-9164-39C4925E467B}");

        // {B4BFCC3A-DB2C-424C-B029-7FE99A87C641} Desktop
        //TerminalUtils.CLSID("{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}");

        //string? result = TerminalUtils.Cmd("cmd /c ::{374DE290-123F-4565-9164-39C4925E467B}");
        //if (result != null)
        //{
        //    Console.WriteLine(result);
        //}

        //Type comType = Type.GetTypeFromProgID("MyProg.ProgId");

        Type? comType = Type.GetTypeFromCLSID(new Guid(id), true);
        if (comType == null)
        {
            Log.Error("comType was null");
            return;
        }

        object? instance = Activator.CreateInstance(comType);
        if (instance == null)
        {
            Log.Error("instance was null");
            return;
        }

        if (instance is ComObject comObject)
        {
            Log.Error($"ComObject cast worked: {comObject}");
        }
        else
        {
            Log.Error("Failed..");
        }

        //Console.WriteLine($"CLSID Valid: {}");
        //Console.WriteLine($"CLSID: {instance}");
        //instance.InvokeMember();

        //Test result = new();
        //Console.WriteLine(result);
    }

    public static void CheckStartMenu()
    {
        Log.Write("Shortcut Scan");

        string startMenuPath = Environment.GetFolderPath(System.Environment.SpecialFolder.Programs);
        Log.Write($"Start Menu Path: {startMenuPath}");

        string[] startMenuFiles = Directory.GetFiles(startMenuPath, "*.lnk", SearchOption.AllDirectories);
        foreach (string file in startMenuFiles)
        {
            Log.Write($"Start Menu File: {file}");
            if (!ShortcutUtils.IsValid(file))
            {
                Log.Write("File is an invalid shortcut");
            }
        }

        Log.Write("Shortcut Scan Done");
    }

    public static void DoExperiment3()
    {
        Log.Write("Experiment 3 Starting..");

        string? winPath = Environment.GetFolderPath(System.Environment.SpecialFolder.Windows);
        if (winPath == null)
        {
            Log.Error("Failed to get Windows Path");
            return;
        }

        string? resourcePath = Path.Combine(winPath, "SystemResources");
        if (resourcePath == null)
        {
            Log.Error("Failed to get SystemResources Path");
            return;
        }

        foreach (string file in Directory.GetFiles(resourcePath).Where(f => f.EndsWith(".mun", StringComparison.OrdinalIgnoreCase)))
        {
            Log.Write(file);
        }
    }
}