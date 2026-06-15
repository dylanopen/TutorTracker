using Avalonia.Layout;
using Avalonia.Controls;
using TutorTrackerModel;

namespace TutorTracker;

public class CalendarPage : UserControl
{
    public CalendarPage()
    {
        StackPanel panel = new StackPanel
        {
            Children = {
                new TextBlock
                {
                    Text = "Calendar",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                },
            }
        };
        foreach (Client client in IModel<Client>.LoadAll("select * from client where first_name = ?", "Gary"))
        {
            
            panel.Children.Add(new TextBlock
            {
                Text = $"{client.FirstName} {client.LastName} - {client.Phone} - {client.Address}",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
            });
        }

        Content = panel;
    }

}