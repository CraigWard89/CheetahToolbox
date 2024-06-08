namespace Toolbox.Core;

public static class Log
{
    public static void Write(string message)
    {
        Console.WriteLine(message);
    }

    public static void Debug(string message)
    {
        Write($"[DEBUG] {message}");
    }
}