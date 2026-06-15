using Microsoft.Data.Sqlite;

namespace TutorTrackerDatabase;

public class DatabaseTables
{
    public static void Create()
    {
        String[] tables = new[]
        {
            "client (id integer primary key autoincrement, first_name text, last_name text, phone text, address text)",
        };
        using var conn = new DbConnection();
        foreach (String table in tables)
        {
            conn.Update($"CREATE TABLE IF NOT EXISTS {table}");
        }
    }
}