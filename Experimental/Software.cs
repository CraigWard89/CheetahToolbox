namespace Toolbox.Experimental;

using Microsoft.Win32;

/// <summary>
/// This class is a POC for identifying programs from choco, winget, etc
/// </summary>
public static class Software
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
    public static void Test()
    {
        // Get All Installed Programs - Entire PC
        RegistryKey? machine = Registry.LocalMachine.OpenSubKey(@"HSoftware\Microsoft\Windows\CurrentVersion\Uninstall\Spotify");
        if (machine != null)
        {
            Console.WriteLine($"{machine}");
        }

        // Get All Installed Programs - Current User
    }
}