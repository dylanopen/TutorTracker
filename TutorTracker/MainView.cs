namespace TutorTracker;

using Avalonia.Layout;
using Avalonia.Controls;

public class MainView : UserControl
{
    private readonly ContentControl _contentHost;

    public MainView()
    {
        _contentHost = new ContentControl
        {
            Content = new CalendarPage()
        };

        var commandBar = new StackPanel
        {
            Orientation = Orientation.Horizontal,
            HorizontalAlignment = HorizontalAlignment.Stretch
        };

        var homeButton = new Button
        {
            Content = "Calendar",
            HorizontalAlignment = HorizontalAlignment.Stretch
        };

        var aboutButton = new Button
        {
            Content = "Notes",
            HorizontalAlignment = HorizontalAlignment.Stretch
        };

        var settingsButton = new Button
        {
            Content = "Settings",
            HorizontalAlignment = HorizontalAlignment.Stretch
        };

        homeButton.Click += (_, _) => _contentHost.Content = new CalendarPage();
        settingsButton.Click += (_, _) => _contentHost.Content = new SettingsPage();
        aboutButton.Click += (_, _) => _contentHost.Content = new NotesPage();

        commandBar.Children.Add(homeButton);
        commandBar.Children.Add(aboutButton);
        commandBar.Children.Add(settingsButton);

        DockPanel.SetDock(commandBar, Dock.Bottom);

        Content = new DockPanel
        {
            Children =
            {
                commandBar,
                _contentHost
            }
        };
    }
}

