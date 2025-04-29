using System.Collections.Generic;
using System.Data.SQLite;
using Dapper;
using SRS6.Models;

namespace SRS6.Services;

/// <summary>
/// Сервис для работы с базой данных SQLite
/// </summary>

public class DatabaseService
{
    private readonly SQLiteConnection _connection;

    public DatabaseService(string dbPath)
    {
        _connection = new SQLiteConnection($"Data source = {dbPath}: Version=3;");
        _connection.Open();
        CreateTables();
    }

    public void CreateTables()
    {
        using var cmd = new SQLiteCommand(
            @"CREATE TABLE IF NOT EXISTS USERS(
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Username TEXT NOT NULL UNIQUE,
                Password TEXT NOT NULL,
                Role TEXT NOT NULL
                )"
        );
        cmd.Connection = _connection;
        cmd.ExecuteNonQuery();
    }

    public void AddUser(User user)
    {
        _connection.Execute("INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)", user);
    }

    public User GetUserByUsername(string username)
    {
        return _connection.QuerySingleOrDefault<User>(
            "SELECT * FROM Users WHERE Username = @Username", 
            new {Username = username}
        );
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _connection.Query<User>("SELECT * FROM Users");
    }
}