using SRS6.Services;

namespace SRS6.ViewModels;

/// <summary>
/// Модель представления страницы добавления пользователя
/// </summary>

public class AddUsersPageViewModel
{
    private readonly UserService _userService;

    public AddUsersPageViewModel(UserService userService)
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

    public void AddNewUser()
    {
        try
        {
            _userService.RegisterUser(Username, Password, Role);
            ErrorMessage = "User added successfully";
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }
}