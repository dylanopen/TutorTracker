using Avalonia.Controls;
using Avalonia.Layout;

namespace TutorTracker;

public class NotesPage : MainPage
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
