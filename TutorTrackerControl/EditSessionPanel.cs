namespace TutorTrackerControl;

using Avalonia.Controls;

using TutorTrackerModel;

public class EditSessionPanel : StackPanel
{
    public Session Session
    {
        get { return ParseInputs(); }
        set { PlaceholdInputs(value); }
    }

    public EditSessionPanel(Session? session)
    {
        ClientSelect clientComboBox = new ClientSelect();
        DatePicker datePicker = new DatePicker();
        TimePicker startTimePicker = new TimePicker();
        TextBox durationTextBox = new TextBox();

        Button addSessionButton = new Button
        {
            Content = "Add Session",
        };

        foreach (Control control in new Control[] { clientComboBox, datePicker, startTimePicker, durationTextBox, addSessionButton })
        {
            control.Margin = new Avalonia.Thickness(3);
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Left;
            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Top;
        }

        addSessionButton.Click += (sender, e) =>
        {
            Models.Save(ParseInputs());
        };

        Orientation = Avalonia.Layout.Orientation.Horizontal;
        HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch;
        VerticalAlignment = Avalonia.Layout.VerticalAlignment.Stretch;
        Spacing = 5;
        Children.AddRange([
            clientComboBox,
            datePicker,
            startTimePicker,
            durationTextBox,
            addSessionButton
        ]);
        
        if (session == null)
            PlaceholdInputs();
        else
            PlaceholdInputs(session);
    }

    public Session ParseInputs()
    {
        Client client = ((ClientSelect)Children[0]).Client;
        DateTimeOffset startTime = ((DatePicker)Children[1]).SelectedDate ?? DateTime.Today;
        TimeSpan startTimeOfDay = ((TimePicker)Children[2]).SelectedTime ?? new TimeSpan(18, 0, 0);
        string[] durationParts = ((TextBox)Children[3]).Text.Split(':');
        if (durationParts.Length != 2) throw new ArgumentException("Invalid duration");
        TimeSpan duration = new TimeSpan(int.Parse(durationParts[0]), int.Parse(durationParts[1]), 0);
        return new Session
        {
            Client = client,
            StartTime = startTime.Date.Add(startTimeOfDay),
            Duration = duration,
        };
    }

    public void PlaceholdInputs(Session session)
    {
        ((ClientSelect)Children[0]).Client = session.Client;
        ((DatePicker)Children[1]).SelectedDate = session.StartTime.Date;
        ((TimePicker)Children[2]).SelectedTime = session.StartTime.TimeOfDay;
        ((TextBox)Children[3]).Text = $"{(int)session.Duration.TotalHours}:{session.Duration.Minutes:D2}";
    }

    public void PlaceholdInputs()
    {
        PlaceholdInputs(new Session
        {
            Client = IModel<Client>.Everything().First(),
            StartTime = DateTime.Today.AddDays(7).AddHours(18),
            Duration = new TimeSpan(1, 0, 0),
        });
    }
}