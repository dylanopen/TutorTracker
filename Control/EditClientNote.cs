using Avalonia.Layout;
using Avalonia.Media;
using TutorTracker.Database;
using TutorTracker.Model;

namespace TutorTracker.Control;

using Avalonia.Controls;

public class EditClientNote : StackPanel
{
    public ClientNote ClientNote
    {
        get { return ParseInputs(); }
        set { PlaceholdInputs(value); }
    }

    public EventHandler<ClientNote>? NoteSaved;

    private ClientSelect _clientSelect;
    private TextBox _textTextBox;

    public EditClientNote(ClientNote? clientNoteOption)
    {
        ClientNote clientNote = clientNoteOption ?? ClientNote.Placeholder;
        
        string text = clientNote.Text;
        
        _clientSelect = new ClientSelect(true);
        if (clientNoteOption != null)
            _clientSelect.Client = clientNote.Client;
        _clientSelect.ClientChanged += (sender, newClient) => ChangeClient(newClient);

        _textTextBox = new TextBox()
        {
            Text = text,
            AcceptsReturn = true,
            MinWidth = 400,
            Height = 200,
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalContentAlignment = VerticalAlignment.Top,
            HorizontalContentAlignment = HorizontalAlignment.Left,
            TextWrapping = TextWrapping.Wrap,
        };

        if (clientNoteOption == null)
        {
            _textTextBox.Text = "";
        }
        
        Children.Add(_clientSelect);
        Children.Add(_textTextBox);
    }

    private void ChangeClient(Client newClient)
    {
        try
        {
            PlaceholdInputs(IModel<ClientNote>.Load("select * from client_note where client = @client", ("client", newClient.Id)));
        }
        catch (Exception)
        {
            PlaceholdInputs(ClientNote.Placeholder);
        }
    }

    public ClientNote ParseInputs()
    {
        return new ClientNote()
        {
            Client = _clientSelect.Client,
            Text = _textTextBox.Text,
        };
    }

    public void PlaceholdInputs(ClientNote clientNote)
    {
        _textTextBox.Text = clientNote.Text;
    }

    public void PlaceholdInputs()
    {
        PlaceholdInputs(ClientNote.Placeholder);
    }

    public void Save()
    {
        ClientNote clientNote = ParseInputs();
        Models.Save(clientNote);
        NoteSaved?.Invoke(this, clientNote);
    }
}