namespace Toolbox;

using SFML.Window;

public class Window
{
    // TODO: Generate random handle/id
    public string Name { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;

    public Window(string name, string title)
    {
        Log.Debug($"Window '{name}' Created");

        Name = name;
        Title = title;

        SFML.Graphics.RenderWindow window = new(new(800, 600), title);

        window.Display();
        window.MouseEntered += Window_MouseEntered;
        window.MouseLeft += Window_MouseLeft;
        window.JoystickButtonPressed += Window_JoystickButtonPressed;
        window.MouseButtonPressed += Window_MouseButtonPressed;
        window.KeyPressed += Window_KeyPressed;
        window.Resized += Window_Resized;
        window.Closed += Window_Closed;

        while (true)
        {
            window.DispatchEvents();
        }
    }
    private void Window_MouseEntered(object? sender, EventArgs e)
    {
        Log.Debug($"{e}");
    }

    private void Window_MouseLeft(object? sender, EventArgs e)
    {
        Log.Debug($"{e}");
    }

    private void Window_JoystickButtonPressed(object? sender, JoystickButtonEventArgs e)
    {
        Log.Debug($"{e}");
    }

    private void Window_MouseButtonPressed(object? sender, MouseButtonEventArgs e)
    {
        Log.Debug($"{e}");
    }

    private void Window_KeyPressed(object? sender, KeyEventArgs e)
    {
        Log.Debug($"{e}");
    }

    private void Window_Resized(object? sender, SizeEventArgs e)
    {
        Log.Debug($"{e}");
    }

    private void Window_Closed(object? sender, EventArgs e)
    {
        Environment.Exit(0);
    }
}