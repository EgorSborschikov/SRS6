using System;
using System.Collections.Generic;
using SRS6.Services;
using SRS6.View.Windows.Admin;
using SRS6.View.Windows.Tutor;

namespace SRS6.ViewModels;

/// <summary>
/// Модель представления страницы регистрации
/// </summary>

public class RegisterPageViewModel
{
    private readonly UserService _userService;

    public RegisterPageViewModel(UserService userService)
    {
        _userService = userService;
    }
    
    public List<string> RolesList { get; } = new List<string> 
    { 
        "Администратор", 
        "Преподаватель" 
    };
    
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string ErrorMessage { get; set; }

    public void Register()
    {
        try
        {
            Console.WriteLine("Registration started...");
            
            Console.WriteLine($"Role selected: {Role}");
            _userService.RegisterUser(Username, Password, Role);
            Console.WriteLine("Registration finished successfully");

            if (Role == "Администратор")
            {
                Console.WriteLine("Open admin window");
                var adminWindow = new AdminWindow();
                adminWindow.Show();
            } else if (Role == "Преподаватель")
            {
                Console.WriteLine("Open tutor window");
                var tutorWindow = new TutorWindow();
                tutorWindow.Show();
            }
            else
            {
                ErrorMessage = "Invalid credentials";
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
            Console.WriteLine("Error:" + ex.Message);
        }
    }
}