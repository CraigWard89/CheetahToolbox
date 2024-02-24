/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
//#if WINDOWS
//namespace CheetahToolbox;

//using CheetahUtils;
//using Microsoft.Win32;

//public static class Cygwin
//{
//    public static string Version => TerminalUtils.Cmd("cygwin -V") ?? string.Empty;

//    public static bool IsInstalled
//    {
//        get
//        {
//            try
//            {
//                string? result = TerminalUtils.Cmd("cygwin");
//                return result switch
//                {
//                    null => false,
//                    _ => true
//                };
//            }
//            catch
//            {
//                return false;
//            }
//        }
//    }

//    /// <summary>
//    /// Run Cygwin Updates
//    /// </summary>
//    public static void Update()
//    {
//        if (!WindowsUtils.IsRunningAsAdmin())
//        {
//            Log.Warn("Update Failed: Not running with Administrator privileges.");
//            throw new Exceptions.PackageManagerUpdateException();
//        }

//        Log.Write("Updating Cygwin");

//        RegistryKey? cygPath = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Cygwin\Installations");
//        if (cygPath == null)
//        {
//            Log.Error("cygPath was null");
//            return;
//        }

//        string[] keys = cygPath.GetValueNames();
//        foreach (string t in keys)
//        {
//            Log.Write(t);

//            if (cygPath.GetValue(t) is string line)
//            {
//                line = line.Replace(@"\??\", string.Empty);
//                Log.Write(line);

//                foreach (string? file in Directory.GetFiles(line))
//                {
//                    if (file.Contains("setup", StringComparison.OrdinalIgnoreCase))
//                    {
//                        Log.Write(file);
//                        string? result = TerminalUtils.Cmd($"{file}");
//                        if (result == null)
//                        {
//                        }
//                    }
//                }

//                //string? result = TerminalUtils.Cmd($"{line}\\setup-x86.exe -q -P {line}");
//            }
//        }

//        // setup-x86.exe -q -P packagename1,packagename2

//        // Get Cygwin Install Path
//        //RegistryLocation[]? installs = RegistryLocations.InstallPaths.Cygwin;
//        //if (installs == null || installs.Length == 0)
//        //{
//        //    Log.Warn("Update Failed: Cygwin Install Path not found.");
//        //    throw new Exceptions.PackageManagerUpdateException();
//        //}

//        //foreach (RegistryLocation install in installs)
//        //{
//        //    Console.WriteLine($"Cygwin Install: {install}");
//        //string? result = TerminalUtils.Cmd($"setup-x86.exe -q -P {install}");
//        //if (result == null)
//        //{
//        //    Log.Warn("Update Failed: Cygwin Update Failed.");
//        //    throw new Exceptions.PackageManagerUpdateException();
//        //}
//        //}
//    }
//}
//#endif