namespace TutorTracker.Page;

using Avalonia.Controls;
using TutorTrackerModel;

public class EditSessionPage : MainPage
{ 
    public EditSessionPage(Session session)
    {
        Content = new StackPanel()
        {
            Children =
            {
                new TextBlock()
                {
                    Text = "Add/edit session",
                },
                new EditSessionPage(session),
            }
        };
    }
}