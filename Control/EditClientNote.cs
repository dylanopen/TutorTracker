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
    private Button _saveButton;

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

        _saveButton = new Button()
        {
            Content = "Save",
            HorizontalAlignment = HorizontalAlignment.Left,
        };
        _saveButton.Click += (sender, args) => Save();

        if (clientNoteOption == null)
        {
            _textTextBox.Text = "";
        }
        
        Children.Add(_clientSelect);
        Children.Add(_textTextBox);
        Children.Add(_saveButton);
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
        ClientNote note = new ClientNote()
        {
            Client = _clientSelect.Client,
            Text = _textTextBox.Text,
        };
        ClientNote? existingNote = IModel<ClientNote>.Load("select * from client_note where client = @client",
            ("client", note.Client.Id));
        if (existingNote != null) note.Id =  existingNote.Id;
        return note;
    }

    public void PlaceholdInputs(ClientNote clientNote)
    {
        _clientSelect.Client = clientNote.Client;
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