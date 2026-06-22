namespace TutorTrackerControl;

using TutorTrackerModel;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Interactivity;

public class CalendarSessionPanel : Button
{
    public Session Session { get; private set; }
    public EventHandler<Session>? SessionClicked;

    public CalendarSessionPanel(Session session)
    {
        this.Session = session;

        Random random = new Random(session.Client.GetHashCode());
        this.Background = new SolidColorBrush(CalendarColour.GetColourForClient(session.Client.Id));
        this.MinWidth = 100;
        string StudentName = session.Client.FirstName;
        this.Click += (sender, e) => SessionClicked?.Invoke(sender, Session);
        
        this.Content = new StackPanel
        {
            Children = {
                new TextBlock
                {
                    Text = $"{session.StartTime.ToShortTimeString()} - {session.StartTime.Add(session.Duration).ToShortTimeString()}",
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                    VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
                },
                new TextBlock
                {
                    Text = StudentName,
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                    VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
                },
            },
        };
    }

    public void ButtonClicked(object? sender, RoutedEventArgs e)
    {
        SessionClicked?.Invoke(this, Session);
    }
}
