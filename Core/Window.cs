namespace Toolbox.Core;

public class Window
{
    // TODO: Generate random handle/id
    public string Name { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;

    public Window(string name, string title)
    {
#if VERBOSE
        Log.Write($"Window '{name}' Created");
#endif
        Name = name;
        Title = title;

        SFML.Graphics.RenderWindow window = new(new SFML.Window.VideoMode(800, 600), title);

        window.Display();
        window.Closed += Window_Closed;

        while (true)
        {
            window.DispatchEvents();
        }
    }

    private void Window_Closed(object? sender, EventArgs e)
    {
        Environment.Exit(0);
    }
}
