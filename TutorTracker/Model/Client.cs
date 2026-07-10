using Microsoft.Data.Sqlite;

namespace TutorTracker.Model;

public class Client : IModel<Client>
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Phone { get; set; }
    public required string Address { get; set; }
    public required int Year { get; set; }

    public static Client ParseNextRow(SqliteDataReader reader)
    {
        Client client = new Client
        {
            Id = reader.GetInt32(0),
            FirstName = reader.GetString(1),
            LastName = reader.GetString(2),
            Phone = reader.GetString(3),
            Address = reader.GetString(4),
            Year = reader.GetInt32(5)
        };

        return client;
    }

    public (string, object)[] ToMap()
    {
        return
        [
            ("first_name", FirstName),
            ("last_name", LastName),
            ("phone", Phone),
            ("address", Address),
            ("year", Year)
        ];
    }

    public static Client Placeholder = new Client
    {
        FirstName = "First Name",
        LastName = "Last Name",
        Phone = "Phone",
        Address = "Address",
        Year = 0,
    };
}