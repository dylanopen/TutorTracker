namespace TutorTrackerControl;

using Avalonia.Controls;

using TutorTrackerModel;

public class AddSessionPanel : StackPanel
{
    public AddSessionPanel()
    {
        var clientComboBox = new ComboBox
        {
            ItemsSource = IModel<Client>.Everything(),
            DisplayMemberBinding = new Avalonia.Data.Binding("FirstName"),
            SelectedIndex = 0,
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Left,
            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Top,
        };
        var datePicker = new DatePicker
        {
            SelectedDate = DateTime.Today.AddDays(7),
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Left,
            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Top,
        };
        var startTimePicker = new TimePicker
        {
            SelectedTime = new TimeSpan(18, 0, 0),
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Left,
            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Top,
        };
        var durationTextBox = new TextBox
        {
            Text = "1:00",
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Left,
            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Top,
        };
        var addSessionButton = new Button
        {
            Content = "Add Session",
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Left,
            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Top,
        };

        addSessionButton.Click += (sender, e) =>
        {
            var client = (Client)clientComboBox.SelectedItem;
            var startTime = (datePicker.SelectedDate ?? DateTime.Today).Add(startTimePicker.SelectedTime ?? new TimeSpan(18, 0, 0));
            var durationParts = durationTextBox.Text.Split(':');
            var duration = new TimeSpan(int.Parse(durationParts[0]), int.Parse(durationParts[1]), 0);
            var newSession = new Session
            {
                Client = client,
                StartTime = startTime.DateTime,
                Duration = duration,
            };
            Models.Save(newSession);
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
    }
}
