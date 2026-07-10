using Avalonia.Controls;
using TutorTrackerModel;

namespace TutorTracker;

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