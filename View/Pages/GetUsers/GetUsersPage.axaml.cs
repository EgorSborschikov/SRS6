using Avalonia.Controls;
using SRS6.Services;
using SRS6.ViewModels;

namespace SRS6.View.Pages.GetUsers;

/// <summary>
/// Логика взаимодействия с GetUsersPage
/// </summary>

public partial class GetUsersPage : UserControl
{
    public GetUsersPage()
    {
        InitializeComponent();
        DataContext = new GetUsersPageViewModel(new UserService(new DatabaseService()));
    }
}