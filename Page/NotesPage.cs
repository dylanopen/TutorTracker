using TutorTracker.Control;
using TutorTracker.Database;
using TutorTracker.Model;

namespace TutorTracker.Page;

using Avalonia.Controls;
using Avalonia.Layout;

public class NotesPage : MainPage
{
    private ClientSelect _clientSelect;
    private ClientNoteDisplay? _clientNoteDisplay;
    private StackPanel _clientNotePanel;
    
    public NotesPage()
    {
        _clientSelect = new ClientSelect();
        _clientSelect.ClientChanged += (sender, client) => UpdateClientNoteDisplay();
        
        _clientNotePanel = new StackPanel();

        StackPanel panel = new StackPanel()
        {
            Children =
            {
                new TextBlock()
                {
                    Text = "Notes"
                },
                _clientSelect,
                _clientNotePanel,
            }
        };
        
        Content = panel;
        
        UpdateClientNoteDisplay();
    }

    private void UpdateClientNoteDisplay()
    {
        int clientId = _clientSelect.Client.Id;
        if (clientId == 0)
        {
            _clientNoteDisplay = null;
        }
        else
        {
            ClientNote? note = IModel<ClientNote>.Load("select * from client_note where client = @client",
                [("client", clientId)]);
            if (note != null)
            {
                _clientNoteDisplay = new ClientNoteDisplay(note);
                _clientNoteDisplay.EditClientNote += OpenClientNoteEditor;
            }
            else
            {
                OpenClientNoteEditor(null, new ClientNote()
                {
                    Client = _clientSelect.Client,
                    Text = "",
                });
                return;
            }
        }
        
        _clientNotePanel.Children.Clear();
        if (_clientNoteDisplay != null)
        {
            _clientNotePanel.Children.Add(_clientNoteDisplay);
        }
    }
    
    private void OpenClientNoteEditor(object sender, ClientNote note)
    {
        EditClientNote editClientNote = new EditClientNote(note);
        _clientNotePanel.Children.Clear();
        _clientNotePanel.Children.Add(editClientNote);
        editClientNote.NoteSaved += (sender, clientNote) => UpdateClientNoteDisplay();
    }
}