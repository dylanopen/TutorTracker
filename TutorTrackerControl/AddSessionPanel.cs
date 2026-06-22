namespace TutorTrackerControl;

using Avalonia.Controls;

using TutorTrackerModel;

public class AddSessionPanel : StackPanel
{
    public AddSessionPanel()
    {
        ComboBox clientComboBox = new ComboBox
        {
            ItemsSource = IModel<Client>.Everything(),
            DisplayMemberBinding = new Avalonia.Data.Binding("FirstName"),
            SelectedIndex = 0,
        };
        DatePicker datePicker = new DatePicker
        {
            SelectedDate = DateTime.Today.AddDays(7),
        };
        TimePicker startTimePicker = new TimePicker
        {
            SelectedTime = new TimeSpan(18, 0, 0),
        };
        TextBox durationTextBox = new TextBox
        {
            Text = "1:00",
        };
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
            Client client = (Client)clientComboBox.SelectedItem;
            DateTimeOffset startTime = (datePicker.SelectedDate ?? DateTime.Today).Add(startTimePicker.SelectedTime ?? new TimeSpan(18, 0, 0));
            string[] durationParts = durationTextBox.Text.Split(':');
            TimeSpan duration = new TimeSpan(int.Parse(durationParts[0]), int.Parse(durationParts[1]), 0);
            Session newSession = new Session
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
