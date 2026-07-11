using TutorTracker.Database;
using TutorTracker.Model;

namespace TutorTracker.Control;

using Avalonia.Controls;

public class ClientSelect : StackPanel
{
    private readonly ComboBox _combo;
    
    public EventHandler<Client>? ClientChanged;
    
    public Client Client
    {
        get { return ParseInput(); }
        set { PlaceholdInput(value); }
    }

    public ClientSelect(bool allowWildcard)
    {
        List<Client> clients = new List<Client>();
        if (allowWildcard)
        {
            Client placeholder = Client.Placeholder;
            placeholder.FirstName = "All Clients";
            clients.Add(placeholder);
        }
        clients.AddRange(IModel<Client>.Everything());
        
        _combo = new ComboBox()
        {
            ItemsSource = clients,
            DisplayMemberBinding = new Avalonia.Data.Binding("FirstName"),
            SelectedIndex = 0,
        };
        _combo.SelectionChanged += (sender, e) => ClientChanged?.Invoke(sender, ParseInput());
        Children.Add(_combo);
    }

    public ClientSelect() : this(false) {}

    private Client ParseInput()
    {
        return (Client)_combo.SelectedValue;
    }

    void PlaceholdInput(Client client)
    {
        foreach (var item in _combo.Items)
        {
            if (item is Client c && c.Id == client.Id)
            {
                int index = _combo.Items.Cast<Client>().ToList().IndexOf(c);
                _combo.SelectedIndex = index;
                return;
            }
        }
    }
}