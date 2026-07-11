using Microsoft.Data.Sqlite;
using TutorTracker.Database;

namespace TutorTracker.Model;

public class ClientNote : IModel<ClientNote>
{
    public int Id { get; set; }
    public required Client Client { get; set; }
    public required string Text { get; set; }

    public static ClientNote ParseNextRow(SqliteDataReader reader)
    {
        return new ClientNote()
        {
            Id = reader.GetInt32(0),
            Client = IModel<Client>.FromId(reader.GetInt32(1)),
            Text = reader.GetString(2),
        };
    }

    public (string, object)[] ToMap()
    {
        return [
            ("client", Client.Id),
            ("text", Text),
        ];
    }
    
    public static ClientNote Placeholder = new ClientNote
    {
        Client = Client.SelectPlaceholder,
        Text = "This client doesn't have a note yet: start typing one!",
    };
}