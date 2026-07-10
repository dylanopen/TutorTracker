namespace TutorTrackerControl;

using Avalonia.Controls;

using TutorTrackerModel;

public class ClientSelect : StackPanel
{
    private ComboBox _combo;
    
    public Client Client
    {
        get { return ParseInput(); }
        set { PlaceholdInput(value); }
    }

    public ClientSelect()
    {
        _combo = new ComboBox()
        {
            ItemsSource = IModel<Client>.Everything(),
            DisplayMemberBinding = new Avalonia.Data.Binding("FirstName"),
        };
        Children.Add(_combo);
    }

    Client ParseInput()
    {
        return (Client)_combo.SelectedValue;
    }

    void PlaceholdInput(Client client)
    {
        _combo.SelectedValue = client;
    }
}