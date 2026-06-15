using Avalonia.Layout;
using Avalonia.Controls;
using Avalonia.Media;
using TutorTrackerModel;

namespace TutorTracker;

public class ClientsPage : UserControl
{
    public ClientsPage()
    {
        StackPanel panel = new StackPanel
        {
            Children =
            {
                new TextBlock
                {
                    Text = "Clients",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                },
            }
        };
        List<Client> clients = IModel<Client>.Everything();
        
        panel.Children.Add(new DataGrid
        {
            ItemsSource = clients,
            AutoGenerateColumns = true,
            HorizontalAlignment = HorizontalAlignment.Stretch,
            VerticalAlignment = VerticalAlignment.Stretch,
        });

        Content = panel;
    }

}