using Avalonia.Controls;
using Avalonia.Layout;

namespace TutorTracker;

public class SettingsPage : UserControl
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