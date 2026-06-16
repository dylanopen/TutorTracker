using Avalonia.Layout;
using Avalonia.Controls;
using TutorTrackerModel;
using TutorTrackerControl;

namespace TutorTracker;

public class CalendarPage : UserControl
{
    public CalendarPage()
    {
        var sessionView = new StackPanel
        {
            Orientation = Orientation.Horizontal,
            HorizontalAlignment = HorizontalAlignment.Stretch,
            VerticalAlignment = VerticalAlignment.Stretch,
            Spacing = 6,
        };

        for (int i = 0; i < 7; i++)
        {
            DateTime date = DateTime.Today.AddDays(i);
            List<Session> sessionsForDay = IModel<Session>.LoadAll("select * from Session where start_time >= @start and start_time < @end", [
                ( "start", UnixTime.ToUnixTime(DateTime.Today.AddDays(i))),
                ( "end", UnixTime.ToUnixTime(DateTime.Today.AddDays(i + 1)))
            ]);
            var dayPanel = new CalendarDayPanel(date, sessionsForDay);
            sessionView.Children.Add(dayPanel);
        }

        Content = new StackPanel
        {
            Children =
            {
                new TextBlock
                {
                    Text = "Calendar",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                },
                sessionView,
                new TextBlock
                {
                    Text = "Add New Session",
                    FontSize = 20,
                    HorizontalAlignment = HorizontalAlignment.Left,
                },
                new AddSessionPanel(),
            }
        };
    }
}
