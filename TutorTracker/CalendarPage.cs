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
            Children =
            {
                new TextBlock
                {
                    Text = "Calendar",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                },
            }
        };
        List<Client> clients = IModel<Client>.Everything();
        foreach (Client client in clients)
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