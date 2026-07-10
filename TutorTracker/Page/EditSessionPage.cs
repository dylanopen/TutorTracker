using TutorTracker.Model;

namespace TutorTracker.Page;

using Avalonia.Controls;

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