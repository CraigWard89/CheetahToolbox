/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
//#if WINDOWS
//namespace CheetahToolbox.Registry;

//#region Using Statements
//using Exceptions;
//using Microsoft.Win32;
//#endregion

//public static class RegistryUtils
//{
//    public static string? GetString(RegistryTarget target, RegistryLocation location)
//    {
//        RegistryKey? key = Getkey(target, location);
//        if (key?.GetValue(location.value) is string value)
//        {
//            return value;
//        }
//        else
//        {
//            return null;
//        }
//    }

//    public static int? GetInt(RegistryTarget target, RegistryLocation location)
//    {
//        RegistryKey? key = Getkey(target, location);
//        if (key?.GetValue(location.value) is int value)
//        {
//            return value;
//        }
//        else
//        {
//            return null;
//        }
//    }

//    public static void SetString(RegistryTarget target, RegistryLocation location, string value)
//    {
//        RegistryKey? key = Getkey(target, location);
//        key?.SetValue(location.key, value, RegistryValueKind.String);
//    }

//    public static void SetInt(RegistryTarget target, RegistryLocation location, int value)
//    {
//        RegistryKey? key = Getkey(target, location);
//        key?.SetValue(location.key, value, RegistryValueKind.DWord);
//    }

//    private static RegistryKey? Getkey(RegistryTarget target, RegistryLocation location)
//    {
//        return target switch
//        {
//            RegistryTarget.HKLM => Registry.LocalMachine.OpenSubKey(location.key),
//            RegistryTarget.HKCU => Registry.CurrentUser.OpenSubKey(location.key),
//            _ => throw new UnknownKeyException()
//        };
//    }
//}
//#endif