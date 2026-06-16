using Avalonia.Layout;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using TutorTrackerModel;

namespace TutorTracker;

public class ClientsPage : UserControl
{
    List<Client> clients;
    DataGrid studentGrid;

    public ClientsPage()
    {
        clients = IModel<Client>.Everything();

        studentGrid = new DataGrid
        {
            ItemsSource = clients,
            AutoGenerateColumns = true,
            HorizontalAlignment = HorizontalAlignment.Stretch,
            VerticalAlignment = VerticalAlignment.Stretch,
        };

        Button addStudentButton = new()
        {
            Content = "Add New Client",
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Bottom,
        };
        addStudentButton.Click += AddStudentButtonClick;

        // Begin event handlers
        studentGrid.RowEditEnded += (sender, e) =>
        {
            if (e.EditAction == DataGridEditAction.Commit) CommitCurrentRowChanges(sender, e);
        };
        studentGrid.KeyDown += (sender, e) =>
        {
            if (e.Key == Avalonia.Input.Key.Delete) DeleteCurrentRow(sender, e);
        };
        // End event handlers

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

    private void AddStudentButtonClick(object? sender, RoutedEventArgs e) 
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
    }

    private void DeleteCurrentRow(object? sender, KeyEventArgs e)
    {
        if (studentGrid.SelectedItem is Client client)
        {
            Models.Delete(client);
            clients.Remove(client);
            studentGrid.ItemsSource = null;
            studentGrid.ItemsSource = clients;
        }
    }

    private void CommitCurrentRowChanges(object? sender, DataGridRowEditEndedEventArgs e)
    {
        Client client = (Client)(e.Row.DataContext ?? throw new Exception("Selected client's row data is null"));
        Models.Save(client);
    }
}
