/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================

//#if WINDOWS
//using System;

///// ======================================================================
/////		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
/////				Project:  Craig's CheetahToolbox a Swiss Army Knife
/////
/////
/////			Author: Craig Craig (https://github.com/CraigCraig)
/////		License:     MIT License (http://opensource.org/licenses/MIT)
///// ======================================================================
//namespace CheetahToolbox.Modules.Core.Commands;

//using Attribute;
//using Commands;

//[AdminRequired]
//public class Installer
//{
//    public override CommandResult Execute(string? subCommand, string[]? args)
//    {
//        if (string.IsNullOrEmpty(subCommand)) return new CommandResult(false, "No argument provided");

//        switch (subCommand)
//        {
//            case "toolbox":
//                Module.Context.Installer.Execute();
//                break;
//            case "chocolatey":
//                if (Module.Context.Chocolatey != null && !Module.Context.Chocolatey.IsInstalled)
//                {
//                    Log.Write("Installing Chocolatey, Please Wait..");
//                    Module.Context.Chocolatey.Install();
//                    return new CommandResult(true);
//                }
//                break;
//            default:
//                return new CommandResult(false, "Invalid argument");
//        }

//        return new CommandResult(true);
//    }
//}
//#endif