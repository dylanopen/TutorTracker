using Microsoft.Data.Sqlite;

namespace TutorTrackerDatabase;

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
        foreach (object arg in args)
        {
            command.Parameters.Add(new SqliteParameter { Value = arg });
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