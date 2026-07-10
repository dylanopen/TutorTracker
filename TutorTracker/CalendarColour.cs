using Avalonia.Media;

public class CalendarColour
{
    static Color[] colours = new Color[] // dark mode (so dark background), but still vibrant colours
    {
        Color.FromRgb(191, 127, 0),
        Color.FromRgb(191, 31, 0),
        Color.FromRgb(31, 0, 191),
        Color.FromRgb(0, 31, 191),
        Color.FromRgb(191, 191, 0),
        Color.FromRgb(127, 191, 0),
        Color.FromRgb(31, 191, 0),
        Color.FromRgb(127, 0, 191),
        Color.FromRgb(191, 0, 127),
        Color.FromRgb(0, 191, 127),
        Color.FromRgb(0, 191, 31),
        Color.FromRgb(0, 191, 191),
        Color.FromRgb(0, 127, 191),
        Color.FromRgb(191, 0, 31),
    };

    public static Color GetColourForClient(int clientId)
    {
        return colours[clientId % colours.Length];
    }
}
