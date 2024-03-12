namespace Toolbox.Windows;

using System.Diagnostics;

public static class Terminal
{
    public static void Test()
    {
        Run(TerminalType.CMD, "choco -v");
        Run(TerminalType.PWSH, "choco -v");
        Run2(TerminalType.CMD, "choco list");
    }

    public static void Run(TerminalType terminalType, string arguments)
    {
        Process process = new();
        switch (terminalType)
        {
            case TerminalType.CMD:
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = $"/c {arguments}";
                break;
            case TerminalType.PWSH:
                process.StartInfo.FileName = "pwsh.exe";
                process.StartInfo.Arguments = $"-c {arguments}";
                break;
            default:
                break;
        }
        _ = process.Start();
        process.WaitForExit();
    }

    public static void Run2(TerminalType terminalType, string arguments)
    {
        Process process = new();

        process.StartInfo.FileName = terminalType switch
        {
            TerminalType.CMD => "cmd.exe",
            TerminalType.PWSH => "pwsh.exe",
            _ => throw new NotImplementedException()
        };

        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.OutputDataReceived += OutputDataReceived;
        _ = process.Start();
        process.BeginOutputReadLine();
    }

    private static void OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        Console.WriteLine($"{sender} -> {e.Data}");
    }

    public enum TerminalType
    {
        CMD, PWSH
    }
}