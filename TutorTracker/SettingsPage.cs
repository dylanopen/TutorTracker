using Avalonia.Controls;
using Avalonia.Layout;

namespace TutorTracker;

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
