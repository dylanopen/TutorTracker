using Microsoft.Data.Sqlite;
using TutorTracker.Database;

namespace TutorTracker.Model;

public class SessionNote : IModel<SessionNote>
{
    public int Id { get; set; }
    public required Session Session { get; set; }
    public required string Text { get; set; }

    public static SessionNote ParseNextRow(SqliteDataReader reader)
    {
        return new SessionNote()
        {
            Id = reader.GetInt32(0),
            Session = IModel<Session>.FromId(reader.GetInt32(1)),
            Text = reader.GetString(2),
        };
    }

    public (string, object)[] ToMap()
    {
        return [
            ("client", Session.Id),
            ("text", Text),
        ];
    }
    
    public static SessionNote Placeholder = new SessionNote
    {
        Session = Session.Placeholder,
        Text = "This session doesn't have a note yet: start typing one!",
    };
}