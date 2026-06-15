using Avalonia.Layout;
using Avalonia.Controls;
using Avalonia.Media;
using TutorTrackerModel;

namespace TutorTracker;

public class ClientsPage : UserControl
{
    public ClientsPage()
    {
        List<Client> clients = IModel<Client>.Everything();
        
        DataGrid studentGrid = new DataGrid
        {
            ItemsSource = clients,
            AutoGenerateColumns = true,
            HorizontalAlignment = HorizontalAlignment.Stretch,
            VerticalAlignment = VerticalAlignment.Stretch,
        };
        studentGrid.RowEditEnded += (sender, e) =>
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                Client client = (Client)(e.Row.DataContext ?? throw new Exception("Selected client's row data is null"));
                Models.Save(client);
            }
        };
        studentGrid.KeyDown += (sender, e) =>
        {
            if (e.Key == Avalonia.Input.Key.Delete)
            {
                if (studentGrid.SelectedItem is Client client)
                {
                    Models.Delete(client);
                    clients.Remove(client);
                    studentGrid.ItemsSource = null;
                    studentGrid.ItemsSource = clients;
                }
            }
        };

        Button addStudentButton = new()
        {
            Content = "Add New Client",
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Bottom,
        };
        addStudentButton.Click += (_, _) =>
        {
            Client newClient = new Client
            {
                FirstName = "First Name",
                LastName = "Last Name",
                Phone = "Phone Number",
                Address = "Address",
                Year = 0
            };
            Models.Save(newClient);
            clients.Add(newClient);
            studentGrid.ItemsSource = null;
            studentGrid.ItemsSource = clients;
        };
        
        Content = new StackPanel
        {
            Children =
            {
                new TextBlock
                {
                    Text = "Clients",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                },
                studentGrid,
                addStudentButton,
            }
        };
    }

}