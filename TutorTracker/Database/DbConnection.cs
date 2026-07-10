namespace TutorTracker.Database;

using Microsoft.Data.Sqlite;

public class DbConnection : IDisposable
{
    public SqliteConnection Conn { get; set; }
    
    public DbConnection()
    {
        Conn = new SqliteConnection("Data Source=tutortracker.db");
        Conn.Open();
    }

    public void Dispose()
    {
        Conn.Close();
        Conn.Dispose();
    }

    public void Update(String sql)
    {
        var command = new SqliteCommand(sql, Conn);
        command.ExecuteNonQuery();
    }
    
    public SqliteDataReader Query(String sql)
    {
        var command = new SqliteCommand(sql, Conn);
        return command.ExecuteReader();
    }
    
    public void Update(String sql, (string, object)[] args)
    {
        using SqliteCommand command = new SqliteCommand(sql, Conn);
        foreach ((string key, object value) in args)
        {
            command.Parameters.AddWithValue(key, value);
        }
        command.ExecuteNonQuery();
    }

    public SqliteDataReader Query(String sql, (string, object)[] args)
    {
        SqliteCommand command = new SqliteCommand(sql, Conn);
        for (int i = 0; i < args.Length; i++)
        {
            string key = args[i].Item1;
            object value = args[i].Item2;
            command.Parameters.AddWithValue(key, value);
        }
        return command.ExecuteReader();
    }
}
