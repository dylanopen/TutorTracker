using Microsoft.Data.Sqlite;
using TutorTracker.Database;

namespace TutorTracker.Model;

public class Session : IModel<Session>
{
    public int Id { get; set; }
    public required Client Client { get; set; }
    public required DateTime StartTime { get; set; }
    public required TimeSpan Duration { get; set; }

    public static Session ParseNextRow(SqliteDataReader reader)
    {
        return new Session
        {
            Id = reader.GetInt32(0),
            Client = IModel<Client>.FromId(reader.GetInt32(1)),
            StartTime = DateTimeOffset.FromUnixTimeSeconds(reader.GetInt64(2)).DateTime,
            Duration = TimeSpan.FromSeconds(reader.GetInt32(3)),
        };
    }

    public (string, object)[] ToMap()
    {
        return
        [
            ("client", Client.Id),
            ("start_time", new DateTimeOffset(StartTime).ToUnixTimeSeconds()),
            ("duration", (int)Duration.TotalSeconds)
        ];
    }

    public static readonly Session Placeholder = new Session
    {
        Client = IModel<Client>.Everything().First(),
        StartTime = DateTime.Today.AddDays(7).AddHours(18),
        Duration = new TimeSpan(1, 0, 0),
    };
}
