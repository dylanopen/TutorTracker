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
            Content = new ClientsPage()
        };

        var commandBar = new StackPanel
        {
            Orientation = Orientation.Horizontal,
            HorizontalAlignment = HorizontalAlignment.Stretch
        };

        var clientsButton = new Button
        {
            Content = "Clients",
            HorizontalAlignment = HorizontalAlignment.Stretch
        };

        var calendarButton = new Button
        {
            Content = "Calendar",
            HorizontalAlignment = HorizontalAlignment.Stretch
        };

        var notesButton = new Button
        {
            Content = "Notes",
            HorizontalAlignment = HorizontalAlignment.Stretch
        };

        var settingsButton = new Button
        {
            Content = "Settings",
            HorizontalAlignment = HorizontalAlignment.Stretch
        };

        clientsButton.Click += (_, _) => _contentHost.Content = new ClientsPage();
        calendarButton.Click += (_, _) => _contentHost.Content = new CalendarPage();
        settingsButton.Click += (_, _) => _contentHost.Content = new SettingsPage();
        notesButton.Click += (_, _) => _contentHost.Content = new NotesPage();

        commandBar.Children.Add(clientsButton);
        commandBar.Children.Add(calendarButton);
        commandBar.Children.Add(notesButton);
        commandBar.Children.Add(settingsButton);

        DockPanel.SetDock(commandBar, Dock.Bottom);

        Content = new DockPanel
        {
            Children =
            {
                commandBar,
                _contentHost,
            }
        };
    }
}

