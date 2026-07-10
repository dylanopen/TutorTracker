using TutorTracker.Page;

namespace TutorTracker.App;

using Avalonia.Layout;
using Avalonia.Controls;

public class MainView : UserControl
{
    private ContentControl currentPage = new ContentControl
    {
        HorizontalAlignment = HorizontalAlignment.Stretch,
        VerticalAlignment = VerticalAlignment.Stretch
    };

    public MainView()
    {
        StackPanel commandBar = new StackPanel
        {
            Orientation = Orientation.Horizontal,
            HorizontalAlignment = HorizontalAlignment.Stretch
        };

        var pages = new List<(string, Func<UserControl>)>
        {
            ("Clients", () => CreatePage(new ClientsPage())),
            ("Calendar", () => CreatePage(new CalendarPage())),
            ("Notes", () => CreatePage(new NotesPage())),
            ("Settings", () => CreatePage(new SettingsPage()))
        };

        foreach ((string name, Func<UserControl> pageFactory) in pages)
        {
            var button = new Button
            {
                Content = name,
                HorizontalAlignment = HorizontalAlignment.Stretch
            };
            button.Click += (_, _) => currentPage.Content = pageFactory();
            commandBar.Children.Add(button);
        }

        DockPanel.SetDock(commandBar, Dock.Bottom);
        SetCurrentPage(CreatePage(new CalendarPage()));

        Content = new DockPanel
        {
            Children =
            {
                commandBar,
                currentPage,
            }
        };
    }

    MainPage CreatePage(MainPage page)
    {
        page.OpenPage += (sender, newPage) => SetCurrentPage(newPage);
        return page;
    }

    void SetCurrentPage(MainPage newPage)
    {
        currentPage.Content = newPage;
    }
}

