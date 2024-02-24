///// ======================================================================
/////		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
/////				Project:  Craig's CheetahToolbox a Swiss Army Knife
/////
/////
/////			Author: Craig Craig (https://github.com/CraigCraig)
/////		License:     MIT License (http://opensource.org/licenses/MIT)
///// ======================================================================
//#if WINDOWS
//namespace CheetahToolbox.Registry;

//#region Using Statements
//using Exceptions;
//using Microsoft.Win32;
//using System;
//#endregion

//public static class RegistryUtils
//{
//    public static RegistryKey[]? GetKeys(string key)
//    {
//        return null; // WIP
//    }

//    public static RegistryKey? GetKey(string name)
//    {
//        RegistryKey? result;
//        RegistryTarget target = RegistryTarget.HKCU;
//        if (string.IsNullOrEmpty(name)) throw new RegistryException();
//        string[] parts = name.Split('\\');
//        if (parts[0].Equals("HKLM", StringComparison.OrdinalIgnoreCase))
//        {
//            target = RegistryTarget.HKLM;
//            name = name.Replace("HKLM\\", "");
//            Console.WriteLine(name);
//        }

//        try
//        {
//            result = target switch
//            {
//                RegistryTarget.HKLM => Microsoft.Win32.Registry.LocalMachine.OpenSubKey(name),
//                RegistryTarget.HKCU => Microsoft.Win32.Registry.CurrentUser.OpenSubKey(name),
//                _ => throw new UnknownKeyException()
//            };
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(ex.Message);
//            result = null;
//        }

//        if (result == null) throw new RegistryException();
//        return result;
//    }
//}
//#endif