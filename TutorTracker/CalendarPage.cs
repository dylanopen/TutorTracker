namespace TutorTrackerCalendar;

using Avalonia.Layout;
using Avalonia.Controls;

public class CalendarPage : UserControl
{
        public CalendarPage()
        {
            Content = new TextBlock
            {
                Text = "Calendar",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
        }

}