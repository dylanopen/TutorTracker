namespace TutorTracker;

using Avalonia;
using Avalonia.Controls;
using Semi.Avalonia;

class Program
{
    public static void Main(string[] args)
    {
        AppBuilder.Configure<Application>()
            .UsePlatformDetect()
            .Start(AppMain, args);
    }

    static void AppMain(Application app, string[] args)
    {
        app.Styles.Add(new SemiTheme());

        var window = new Window
        {
            Title = "Tutor Tracker: organise tutoring sessions",
            Width = 2100,
            Height = 1080,
            Content = new MainView()
        };

        window.Show();
        app.Run(window);
    }
}