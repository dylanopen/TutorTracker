using Microsoft.Data.Sqlite;

namespace TutorTrackerModel;

public class Client : IModel<Client>
{
    // client (id integer primary key autoincrement, first_name text, last_name text, phone text, address text)
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Phone { get; set; }
    public required string Address { get; set; }

    public static Client ParseNextRow(SqliteDataReader reader)
    {
        
        return new Client
        {
            Id = reader.GetInt32(0),
            FirstName = reader.GetString(1),
            LastName = reader.GetString(2),
            Phone = reader.GetString(3),
            Address = reader.GetString(4)
        };
    }
}