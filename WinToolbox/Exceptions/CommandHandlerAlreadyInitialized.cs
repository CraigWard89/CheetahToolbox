namespace WinToolbox.Exceptions;

using System;

[Serializable]
internal class CommandHandlerAlreadyInitialized : Exception
{
    public CommandHandlerAlreadyInitialized() : base("Command handler already initialized.")
    {
    }
}