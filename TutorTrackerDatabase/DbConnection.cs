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
    
    public void Update(String sql, object[] args)
    {
        using SqliteCommand command = new SqliteCommand(sql, Conn);
        foreach (object arg in args)
        {
            command.Parameters.Add(new SqliteParameter { Value = arg });
        }
        command.ExecuteNonQuery();
    }

    public SqliteDataReader Query(String sql, object[] args)
    {
        using SqliteCommand command = new SqliteCommand(sql, Conn);
        for (int i = 0; i < args.Length; i++)
        {
            object arg = args[i];
            Console.WriteLine(arg);
            command.Parameters.AddWithValue($"placeholder{i}", arg);
        }
        return command.ExecuteReader();
    }
}