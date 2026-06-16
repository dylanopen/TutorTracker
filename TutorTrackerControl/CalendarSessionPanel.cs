namespace TutorTrackerControl;

using TutorTrackerModel;
using Avalonia.Controls;
using Avalonia.Media;

public class CalendarSessionPanel : StackPanel
{
    public CalendarSessionPanel(Session session)
    {
        Random random = new Random(session.Client.GetHashCode());
        this.Background = new SolidColorBrush(CalendarColour.GetColourForClient(session.Client.Id));
        this.MinWidth = 100;
        this.Children.Add(new TextBlock
        {
            Text = $"{session.StartTime.ToShortTimeString()} - {session.StartTime.Add(session.Duration).ToShortTimeString()}",
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
        });
        string StudentName = session.Client.FirstName;
        this.Children.Add(new TextBlock
        {
            Text = StudentName,
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
        });
    }
}
