using System;
using SRS6.Services;

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
    
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string ErrorMessage { get; set; }

    public void Register()
    {
        try
        {
            _userService.RegisterUser(Username, Password, Role);
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }
}