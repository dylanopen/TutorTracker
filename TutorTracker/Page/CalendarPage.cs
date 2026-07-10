using Avalonia.Layout;
using Avalonia.Controls;
using TutorTrackerModel;
using TutorTrackerControl;

namespace TutorTracker.Calendar;

public class CalendarPage : MainPage
{
    public CalendarPage()
    {
        StackPanel sessionView = new StackPanel
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
            CalendarDayPanel dayPanel = new CalendarDayPanel(date, sessionsForDay);
            dayPanel.SessionClicked += (sender, e) => OpenPage?.Invoke(sender, new EditSessionPage(e));
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
                new EditSessionPanel(new Session
                {
                    Client = IModel<Client>.Everything().FirstOrDefault() ?? new Client
                    {
                        FirstName = "Add a client before adding a session!",
                        LastName = "",
                        Phone = "",
                        Address = "",
                        Year = 0,
                    },
                    StartTime = DateTime.Today.AddDays(7).AddHours(18),
                    Duration = new TimeSpan(1, 0, 0),
                }),
            }
        };
    }
}
