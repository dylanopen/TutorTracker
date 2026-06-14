using Avalonia.Controls;
using Avalonia.Layout;

namespace TutorTracker;

public class NotesPage : UserControl
{
    public NotesPage()
    {
        Content = new TextBlock
        {
            Text = "Notes",
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center
        };
    }
}