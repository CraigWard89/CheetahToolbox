///// ======================================================================
/////		CheetahUtils: (https://github.com/CraigCraig/CheetahUtils)
/////				Project:  Craig's CheetahUtils a Collection of C# Utils
/////
/////
/////			Author: Craig Craig (https://github.com/CraigCraig)
/////		License:     MIT License (http://opensource.org/licenses/MIT)
///// ======================================================================
//namespace Toolbox;

//#region Usings
//using System;
//using System.Diagnostics;
//using System.Globalization;
//using System.IO;
//using System.Runtime.CompilerServices;
//#endregion

///// <summary>
///// Logger class for CheetahUtils
///// </summary>
//public static partial class Log
//{
//    public static LogLevel Level { get; set; }
//    public static string Prefix { get; set; } = string.Empty;
//    public static Utils.Color PrefixColor { get; set; } = Utils.Color.White;
//    public static Utils.Color BracketColor { get; set; } = Utils.Color.White;
//    public static bool DisplayTime { get; set; }
//    public static bool IsInitialized { get; private set; }

//    public static string FolderPath { get; private set; } = string.Empty;
//    public static string LogPath { get; private set; } = string.Empty;
//    public static string OldLogPath { get; private set; } = string.Empty;

//    public static void Init(string? prefix = "", string? folderPath = "", LogLevel level = LogLevel.INFO)
//    {
//        if (IsInitialized) return;
//        Level = level;
//        PrefixColor = Utils.Color.Gray;
//        BracketColor = Utils.Color.Gray;
//        Prefix = prefix ?? string.Empty;
//        FolderPath = folderPath ?? Path.Combine(Environment.CurrentDirectory, "logs");

//        LogPath = !string.IsNullOrEmpty(prefix)
//            ? Path.Combine(FolderPath, $"latest.{prefix.ToLower(CultureInfo.CurrentCulture)}.log")
//            : Path.Combine(FolderPath, $"latest.log");

//        OldLogPath = Path.Combine(FolderPath, $"old_{(DateTime.Now - DateTime.MinValue).TotalMilliseconds}.log");

//        if (!string.IsNullOrEmpty(FolderPath))
//        {
//            if (!Directory.Exists(FolderPath)) _ = Directory.CreateDirectory(FolderPath);
//            if (File.Exists(LogPath)) File.Move(LogPath, OldLogPath);
//        }
//    }

//    /// <summary>
//    /// Opens the latest log file in Notepad
//    /// </summary>
//    public static void OpenLatestLogFile()
//    {
//        try
//        {
//            _ = Process.Start(LogPath);
//        }
//        catch (Exception e)
//        {
//            Error($"Failed to open Log: {e.Message} - {LogPath}");
//        }
//    }

//    /// <summary>
//    /// Writes an <see cref="Exception"/> to the logger as <see cref="LogLevel.ERROR"/>
//    /// </summary>
//    /// <param name="ex"></param>
//    /// <param name="code"></param>
//    /// <param name="name"></param>
//    /// <param name="line"></param>
//    public static void Exception<T>(T ex, string code = "", [CallerMemberName] string name = "", [CallerLineNumber] int line = -1)
//    {
//        Write($"[{name}] [{line}] An Exception Occurred -> {ex?.GetType()}", LogLevel.ERROR);
//        if (!string.IsNullOrEmpty(code))
//            Write($"Error Code: {code}");
//        Write($"");
//        if ((ex as Exception) != null)
//        {
//            string? message = (ex as Exception)?.Message;
//            string? stackTrace = (ex as Exception)?.StackTrace;
//            System.Reflection.MethodBase? targetSite = (ex as Exception)?.TargetSite;
//            string? source = (ex as Exception)?.Source;
//            if (message != null)
//                Write($"Exception Message: {message}", LogLevel.ERROR);

//            if (stackTrace != null)
//                Write($"Exception StackTrace: {stackTrace}", LogLevel.ERROR);

//            if (targetSite != null)
//                Write($"Exception TargetSite: {targetSite}", LogLevel.ERROR);

//            if (source != null)
//                Write($"Exception Source: {source}", LogLevel.ERROR);
//        }
//        else
//        {
//            Write($"Exception Was Null!", LogLevel.ERROR);
//        }
//    }

//    /// <summary>
//    /// Writes a line to the logger as <see cref="LogLevel.ERROR"/>
//    /// </summary>
//    /// <param name="line"></param>
//    public static void Error(string msg, [CallerMemberName] string name = "", [CallerLineNumber] int line = -1)
//    {
//        Write($"An Error Occurred");
//        Write($"CallerName: {name}", LogLevel.ERROR);
//        Write($"CallerLine: {line}", LogLevel.ERROR);
//        Write($"{msg}", LogLevel.ERROR);
//    }

//    /// <summary>
//    /// Writes a line to the logger as <see cref="LogLevel.ERROR"/>
//    /// This particular method does not use the <see cref="CallerMemberName"/> and <see cref="CallerLineNumber"/> attributes
//    /// </summary>
//    /// <param name="msg"></param>
//    public static void ErrorNoCall(string msg)
//    {
//        Write(!string.IsNullOrEmpty(msg) ? $"An Error Occurred: {msg}" : $"An Error Occurred");
//    }

//    /// <summary>
//    /// Writes a line to the logger as <see cref="LogLevel.FINE"/>
//    /// </summary>
//    /// <param name="line"></param>
//    public static void Fine(string line)
//    {
//        Write($"{line}", Utils.Color.Grey, LogLevel.FINE);
//    }

//    /// <summary>
//    /// Writes a line to the logger as <see cref="LogLevel.SUPER"/> if client is in Super mode
//    /// </summary>
//    /// <param name="line"></param>
//    public static void Super(string line)
//    {
//        //if (Config.Data.Logger.Super)
//        Write($"{line}", Utils.Color.Grey, LogLevel.SUPER);
//    }

//    /// <summary>
//    /// Writes a line to the logger as <see cref="LogLevel.SUPER"/> if client is in Super mode
//    /// </summary>
//    /// <param name="line"></param>
//    public static void Super(string line, Utils.Color Color)
//    {
//        //if (Config.Data.Logger.Super)
//        Write($"{line}", Utils.Color.CheetoOrange, LogLevel.SUPER);
//    }

//    /// <summary>
//    /// Writes a line to the logger as <see cref="LogLevel.INFO"/>
//    /// </summary>
//    /// <param name="line"></param>
//    public static void Info(string line)
//    {
//        Write($"{line}", Utils.Color.Grey, LogLevel.INFO);
//    }

//    /// <summary>
//    /// Writes a line to the logger as <see cref="LogLevel.ATTENTION"/>
//    /// </summary>
//    /// <param name="line"></param>
//    public static void Attention(string line)
//    {
//        Write($"{line}", Utils.Color.CheetoYellow, LogLevel.ATTENTION);
//    }

//    /// <summary>
//    /// Writes a line to the logger as <see cref="LogLevel.DEBUG"/>
//    /// </summary>
//    /// <param name="line"></param>
//    public static void Debug(string line)
//    {
//        Write($"{line}", Utils.Color.White, LogLevel.DEBUG);
//    }

//    /// <summary>
//    /// Writes a line to the logger as <see cref="LogLevel.DEBUG"/>
//    /// </summary>
//    /// <param name="line"></param>
//    /// <param name="Utils.Color"></param>
//    public static void Debug(string line, System.Drawing.Color Color)
//    {
//        Write($"{line}", new Utils.Color(Color.R, Color.G, Color.B), LogLevel.DEBUG);
//    }

//    /// <summary>
//    /// Writes a line to the logger as <see cref="LogLevel.DEBUG"/>
//    /// </summary>
//    /// <param name="line"></param>
//    public static void Debug(string line, Utils.Color Color)
//    {
//        Write($"{line}", Color, LogLevel.DEBUG);
//    }

//    /// <summary>
//    /// Writes a line to the logger as <see cref="LogLevel.WARNING"/>
//    /// </summary>
//    /// <param name="line"></param>
//    public static void Warn(string line)
//    {
//        Write($"{line}", LogLevel.WARNING);
//    }

//    /// <summary>
//    /// Logs "----------------------" to the logger.
//    /// </summary>
//    public static void Bars()
//    {
//        Write(string.Empty, Utils.Color.Black, noNewline: true);
//        for (int i = 0; i < 16; i++)
//        {
//            Append("-", Utils.Color.Random);
//        }
//        Append(Environment.NewLine, Utils.Color.Black);
//    }

//    /// <summary>
//    /// Writes a line to the logger.
//    /// </summary>
//    /// <param name="message"></param>
//    /// <param name="level"></param>
//    public static void Write(object? message, LogLevel level = LogLevel.INFO)
//    {
//        Write(message, Utils.Color.White, level);
//    }

//    /// <summary>
//    /// Writes a line to the logger, with a specific <see cref="System.Drawing.Color"/>.
//    /// </summary>
//    /// <param name="message"></param>
//    /// <param name="Utils.Color"></param>
//    /// <param name="level"></param>
//    public static void Write(object message, System.Drawing.Color Color, LogLevel level = LogLevel.INFO)
//    {
//        Write(message, new Utils.Color(Color.R, Color.G, Color.B), level);
//    }

//    public static void Append(object message, Utils.Color? Color)
//    {
//        Utils.Color lColor = Color ?? Utils.Color.White;
//        Write(message, lColor, append: true);
//    }

//    /// <summary>
//    /// Writes a line to the logger, with a specific <see cref="Utils.Color"/>.
//    /// </summary>
//    /// <param name="message"></param>
//    /// <param name="Utils.Color"></param>
//    /// <param name="level"></param>
//    public static void Write(object? message, Utils.Color Color, LogLevel level = LogLevel.INFO, bool append = false, bool noNewline = false)
//    {
//        if (message == null) return;
//        if (append)
//        {
//            PrivateWrite(message, Color);
//        }
//        else
//        {
//            if (Level >= level)
//            {
//                Utils.Color lColor = Utils.Color.White;
//                if (level == LogLevel.SUPER)
//                    lColor = Utils.Color.Html.Teal;
//                if (level == LogLevel.FINE)
//                    lColor = Utils.Color.Html.Olive;
//                if (level == LogLevel.INFO)
//                    lColor = Utils.Color.Html.Gray;
//                if (level == LogLevel.DEBUG)
//                    lColor = Utils.Color.CheetoYellow;
//                if (level == LogLevel.ATTENTION)
//                    lColor = Utils.Color.Crayola.Original.RosePink;
//                if (level == LogLevel.WARNING)
//                    lColor = Utils.Color.Crayola.Original.Yellow;
//                if (level == LogLevel.ERROR)
//                    lColor = Utils.Color.Crayola.Original.Red;

//                CultureInfo ci = CultureInfo.CurrentCulture;
//                if (DisplayTime)
//                {
//                    PrivateWrite($"[", BracketColor);
//                    PrivateWrite($"{DateTime.Now.ToString("hh:mm:ss.fff", ci)}", Utils.Color.Crayola.Present.BananaMania);
//                    PrivateWrite($"] ", BracketColor);
//                }

//                PrivateWrite($"[", BracketColor);
//                PrivateWrite($"{Enum.GetName(typeof(LogLevel), level)}", lColor);
//                PrivateWrite($"] ", BracketColor);

//                PrivateWrite($"[", BracketColor);
//                PrivateWrite($"{Prefix}", PrefixColor);
//                PrivateWrite($"] ", BracketColor);

//                PrivateWriteLine(message, Color, noNewline);
//            }
//        }
//    }

//    private static void PrivateWriteLine(object message, Utils.Color Color, bool noNewline = false)
//    {
//        if (noNewline)
//        {
//            PrivateWrite(message, Color);
//        }
//        else
//        {
//            PrivateWrite(message + Environment.NewLine, Color);
//        }
//    }

//    private static void PrivateWrite(object message, Utils.Color Color)
//    {
//#if WINDOWS
//        Console.Write($"{Utils.Console.ForegroundColor(Color)}{message}");
//#else
//        Console.Write($"{message}");
//#endif
//        if (!string.IsNullOrEmpty(LogPath))
//        {
//            File.AppendAllText(LogPath, message.ToString());
//        }
//    }
//}