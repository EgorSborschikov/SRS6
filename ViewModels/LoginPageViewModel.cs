using System;
using SRS6.Services;
using SRS6.View.Windows.Admin;
using SRS6.View.Windows.Tutor;

namespace SRS6.ViewModels;

/// <summary>
/// Модель представления страницы авторизации
/// </summary>

public class LoginPageViewModel
{
    private readonly UserService _userService;

    public LoginPageViewModel(UserService userService)
    {
        _userService = userService;
    }
    
    public string Username { get; set; }
    public string Password { get; set; }
    public string ErrorMessage { get; set; }

    public void Login()
    {
        try
        {
            Console.WriteLine("Authenticating started...");
            
            var user = _userService.LoginUser(Username, Password);
            Console.WriteLine("Logged in successfully!");

            if (user.Role == "Администратор")
            {
                Console.WriteLine("Open admin window");
                var adminWindow = new AdminWindow();
                adminWindow.Show();
            }
            else if (user.Role == "Преподаватель")
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
        }
    }
}