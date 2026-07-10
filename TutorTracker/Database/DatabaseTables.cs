namespace TutorTracker.Database;

public class DatabaseTables
{
    public static void Create()
    {
        String[] tables = new[]
        {
            "client (id integer primary key autoincrement, first_name text, last_name text, phone text, address text, year integer)",
            "session (id integer primary key autoincrement, client integer, start_time long, duration integer)",
        };
        using var conn = new DbConnection();
        foreach (String table in tables)
        {
            conn.Update($"CREATE TABLE IF NOT EXISTS {table}");
        }
    }
}
