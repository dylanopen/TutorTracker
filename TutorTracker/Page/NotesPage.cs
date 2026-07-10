namespace TutorTracker.Page;

using Avalonia.Controls;
using Avalonia.Layout;

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
