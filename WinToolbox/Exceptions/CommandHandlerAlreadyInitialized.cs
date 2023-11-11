namespace WinToolbox.Exceptions;

using System;

/// <summary>
/// Exception thrown when the command handler is already initialized.
/// </summary>
[Serializable]
internal class CommandHandlerAlreadyInitialized : Exception
{
    public CommandHandlerAlreadyInitialized() : base("Command handler already initialized.")
    {
    }
}