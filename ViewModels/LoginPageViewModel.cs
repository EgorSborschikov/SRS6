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
            var user = _userService.LoginUser(Username, Password);

            var adminWindow = new AdminWindow();
            var tutorWindow = new TutorWindow();

            /*
             * if(user.Role == "Admin"){
             *      adminWindow.Show();
             * } else {
             *      tutorWindow.Show();
             * }
             */
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }
}