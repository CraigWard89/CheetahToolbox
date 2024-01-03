#if WIP
namespace CheetahTerminal;

#region Using Statements
using System;
#endregion

/// <summary>
/// This struct is used to request a shutdown of the terminal
/// </summary>
/// <param name="RequestTime">Time of request</param>
public record struct ShutdownRequest(DateTime RequestTime);
#endif