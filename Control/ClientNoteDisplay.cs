using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using TutorTracker.Model;

namespace TutorTracker.Control;

public class ClientNoteDisplay : StackPanel
{
    public readonly ClientNote Note;
    public EventHandler<ClientNote>? EditClientNote;
    
    private Button _editButton;
    private Label _clientInfoLabel;
    private TextBlock _textBlock;
    
    public ClientNoteDisplay(ClientNote note)
    {
        Note = note;
        Orientation = Orientation.Vertical;
        HorizontalAlignment = HorizontalAlignment.Left;
        MaxWidth = 300;
        Background = new SolidColorBrush(Color.FromUInt32(0xff222428));

        _clientInfoLabel = new Label()
        {
            Content = Note.Client.FirstName,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Stretch,
            Padding = new Thickness(7, 0),
        };

        _editButton = new Button()
        {
            Content = "Edit",
            HorizontalAlignment = HorizontalAlignment.Right,
            VerticalAlignment = VerticalAlignment.Center,
            Padding = new Thickness(7, 0)
        };

        _textBlock = new TextBlock()
        {
            Text = Note.Text,
            Foreground = Brushes.White,
            TextWrapping = TextWrapping.Wrap,
            Padding = new Thickness(8),
        };

        Children.Add(new StackPanel()
        {
            Orientation = Orientation.Horizontal,
            Children =
            {
                _clientInfoLabel,
                _editButton,
            },
        });
        
        Children.Add(new Separator()
        {
            Margin = new Thickness(0, 5, 0, 5),
            Background = Brushes.Gray,
            Height = 1,
        });
        
        Children.Add(_textBlock);
        
        _editButton.Click += (sender, args) => EditClientNote?.Invoke(this, Note);
    }
}