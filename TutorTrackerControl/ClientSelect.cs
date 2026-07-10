namespace TutorTrackerControl;

using Avalonia.Controls;

using TutorTrackerModel;

public class ClientSelect : StackPanel
{
    private ComboBox _combo;
    
    public EventHandler<Client>? ClientChanged;
    
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
        _combo.SelectionChanged += (sender, e) => ClientChanged?.Invoke(sender, ParseInput());
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