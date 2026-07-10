using Microsoft.Data.Sqlite;
using TutorTrackerDatabase;

namespace TutorTracker.Database;

public interface IModel<T> where T : IModel<T>
{
    public int Id { get; set; }
    
    public static abstract T ParseNextRow(SqliteDataReader reader);
    
    public static T Load(SqliteDataReader reader)
    {
        if (!reader.HasRows) throw new Exception($"No rows found for query, table '{GetTableName()}'.");
        reader.Read();
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
        return Load($"SELECT * FROM {GetTableName()} WHERE id = @id", ("id", id));
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
    
    public static List<T> LoadAll(String sql, (string, object)[] args)
    {
        using var conn = new DbConnection();
        using var reader = conn.Query(sql, args);
        return LoadAll(reader);
    }
    
    public static T Load(String sql, params (string, object)[] args)
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

    public (string, object)[] ToMap();

    public void Insert()
    {
        using var conn = new DbConnection();
        var map = ToMap();
        var columns = String.Join(", ", map.Select(m => m.Item1));
        var values = String.Join(", ", map.Select(m => $"@{m.Item1}"));
        var sql = $"INSERT INTO {GetTableName()} ({columns}) VALUES ({values}) RETURNING id";
        using var reader = conn.Query(sql, map);
        if (!reader.HasRows) throw new Exception($"No rows returned for insert query '{sql}', table '{GetTableName()}'.");
        reader.Read();
        Id = reader.GetInt32(0);
    }
    
    public void Update()
    {
        using var conn = new DbConnection();
        var map = ToMap();
        var set = String.Join(", ", map.Select(m => $"{m.Item1} = @{m.Item1}"));
        var sql = $"UPDATE {GetTableName()} SET {set} WHERE id = @id";
        conn.Update(sql, map.Append(("id", Id)).ToArray());
    }
    
    public void Save()
    {
        if (Id == 0)
        {
            Insert();
        }
        else
        {
            Update();
        }
    }
    
    public void Delete()
    {
        using var conn = new DbConnection();
        var sql = $"DELETE FROM {GetTableName()} WHERE id = @id";
        conn.Update(sql, new (string, object)[] { ("id", Id) });
    }
}
