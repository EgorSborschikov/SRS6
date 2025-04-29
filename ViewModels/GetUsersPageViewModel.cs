// GetUsersPageViewModel.cs
using System.Collections.ObjectModel;
using SRS6.Models;
using SRS6.Services;

namespace SRS6.ViewModels;

public class GetUsersPageViewModel
{
    private readonly UserService _userService;

    public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();

    public GetUsersPageViewModel(UserService userService)
    {
        _userService = userService;
        
        // Загрузка данных из базы
        foreach (var user in _userService.GetAllUsers())
        {
            Users.Add(user);
        }
    }
}