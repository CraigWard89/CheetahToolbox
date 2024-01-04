namespace CheetahToolbox.Commands;

public class CommandResult(bool success, string message = "")
{
    public bool Success { get; private set; } = success;
    public string Message { get; private set; } = message;
}