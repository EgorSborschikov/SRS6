using System;
using System.Collections.Generic;
using SRS6.Models;

namespace SRS6.Services;

/// <summary>
/// Сервис для управления пользователями
/// </summary>

public class UserService
{
    private readonly DatabaseService _databaseService;

    public UserService(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public void RegisterUser(string username, string password, string role)
    {
        if (string.IsNullOrEmpty(username) 
            || string.IsNullOrEmpty(password) 
            || string.IsNullOrEmpty(role))
        {
            throw new ArgumentException("All fields are required");
        }

        var user = _databaseService.GetUserByUsername(username);
        if (user != null)
        {
            throw new InvalidOperationException("Username already exists");
        }

        var newUser = new User
        {
            Username = username,
            Password = password,
            Role = role
        };
        _databaseService.AddUser(newUser);
    }

    public User LoginUser(string username, string password)
    {
        var user = _databaseService.GetUserByUsername(username);
        if (user == null || user.Password != password)
        {
            throw new InvalidOperationException("Invalid username or password");
        }
        return user;
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _databaseService.GetAllUsers();
    }
}