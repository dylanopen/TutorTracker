using Avalonia.Markup.Xaml.Styling;
using Avalonia.Styling;
using Semi.Avalonia.DataGrid;
using Semi.Avalonia.Dock;
using TutorTrackerDatabase;
using TutorTrackerModel;

namespace TutorTracker;

using Avalonia;
using Avalonia.Controls;
using Semi.Avalonia;

class Program
{
    public static void Main(string[] args)
    {
        DatabaseTables.Create();
       
        AppBuilder.Configure<Application>()
            .UsePlatformDetect()
            .Start(AppMain, args);
    }

    static void AppMain(Application app, string[] args)
    {
        app.Styles.Add(new SemiTheme());
        app.Styles.Add(new DataGridSemiTheme());
        app.Styles.Add(new DockSemiTheme());
        app.RequestedThemeVariant = ThemeVariant.Dark;

        var grid = new DataGrid();
        
        var window = new Window
        {
            Title = "Tutor Tracker: organise tutoring sessions",
            Width = 1280,
            Height = 720,
            Content = new MainView()
        };

        window.Show();
        app.Run(window);
    }
}