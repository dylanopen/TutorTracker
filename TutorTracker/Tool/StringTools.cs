namespace TutorTracker.Tool;

using System.Text;

public static class StringTools
{
    // Adapted from https://stackoverflow.com/a/63055977
    // Posted by littlerufe, modified by community. See post 'Timeline' for change history
    // Retrieved 2026-06-14, License - CC BY-SA 4.0
    public static string? ToSnakeCase(string str)
    {
        return string.Join("_", string.Concat(string.Join("_", str.Split(new char[] {},
                    StringSplitOptions.RemoveEmptyEntries))
                .Select(c => char.IsUpper(c)
                    ? $"_{c}".ToLower()
                    : $"{c}"))
            .Split(new[] {'_'}, StringSplitOptions.RemoveEmptyEntries));
    }
}