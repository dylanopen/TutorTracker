using Microsoft.Data.Sqlite;
using TutorTrackerDatabase;

namespace TutorTrackerModel;

public interface IModel<T> where T : IModel<T>
{
    public static abstract T ParseNextRow(SqliteDataReader reader);
    
    public static T Load(SqliteDataReader reader)
    {
        if (!reader.HasRows) throw new Exception($"No rows found for query, table '{GetTableName()}'.");
        return T.ParseNextRow(reader);
    }
    
    public static List<T> LoadAll(SqliteDataReader reader)
    {
        List<T> list = new List<T>();
        while (reader.Read())
        {
            list.Add(T.ParseNextRow(reader));
        }
        return list;
    }
    
    public static T FromId(int id)
    {
        using var conn = new DbConnection();
        // We are only using our own class name and integers, so no escaping needed
        using var reader = conn.Query($"SELECT * FROM {GetTableName()} WHERE id = {id}");
        return Load(reader);
    }
    
    public static List<T> FromIdAll(String sql)
    {
        using var conn = new DbConnection();
        using var reader = conn.Query(sql);
        return LoadAll(reader);
    }
    
    public static List<T> Everything()
    {
        using var conn = new DbConnection();
        using var reader = conn.Query($"SELECT * FROM {GetTableName()}");
        return LoadAll(reader);
    }

    public static List<T> LoadAll(String sql)
    {
        using var conn = new DbConnection();
        using var reader = conn.Query(sql);
        return LoadAll(reader);
    }

    public static T Load(String sql)
    {
        using var conn = new DbConnection();
        using var reader = conn.Query(sql);
        if (!reader.HasRows) throw new Exception($"No rows found for query '{sql}', table '{GetTableName()}'.");
        return Load(reader);
    }
    
    public static List<T> LoadAll(String sql, params object[] args)
    {
        using var conn = new DbConnection();
        using var reader = conn.Query(sql, args);
        return LoadAll(reader);
    }
    
    public static T Load(String sql, params object[] args)
    {
        using var conn = new DbConnection();
        using var reader = conn.Query(sql, args);
        if (!reader.HasRows) throw new Exception($"No rows found for query '{sql}', table '{GetTableName()}'.");
        return Load(reader);
    }

    public static string? GetTableName()
    {
        return StringTools.ToSnakeCase(typeof(T).Name);
    }
}