namespace TutorTracker.Page;

using Avalonia.Controls;
using Avalonia.Layout;

public class SettingsPage : MainPage
{
    public SettingsPage()
    {
        Content = new TextBlock
        {
            Text = "Settings",
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center
        };
    }
}
