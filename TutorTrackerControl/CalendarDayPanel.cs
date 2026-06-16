namespace TutorTrackerControl;

using TutorTrackerModel;
using Avalonia.Controls;

public class CalendarDayPanel : StackPanel
{
    public CalendarDayPanel(DateTime date, List<Session> sessions)
    {
        this.Orientation = Avalonia.Layout.Orientation.Vertical;
        this.Spacing = 6;
        this.MinWidth = 100;
        this.Children.Add(new TextBlock
        {
            Text = date.ToString("ddd dd/MM"),
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
        });
        foreach (Session session in sessions)
        {
            this.Children.Add(new CalendarSessionPanel(session));
        }
    }
}
