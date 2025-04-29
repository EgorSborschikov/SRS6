using Avalonia.Controls;
using Avalonia.Interactivity;
using SRS6.Services;
using SRS6.View.Pages.AddUsers;
using SRS6.View.Pages.GetUsers;
using SRS6.ViewModels;

namespace SRS6.View.Windows.Admin;

/// <summary>
/// Логика взаимодействия с AdminWindow
/// </summary>

public partial class AdminWindow : Window
{
    public AdminWindow()
    {
        InitializeComponent();
    }

    private void OpenGetUsersPageBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var getUsersPage = new GetUsersPage{
            DataContext = new GetUsersPageViewModel(new UserService(new DatabaseService()))
        };
        PageContent.Content = getUsersPage;
    }

    private void OpenAddUsersPageBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var addUsersPage = new AddUsersPage{
            DataContext = new AddUsersPageViewModel(new UserService(new DatabaseService()))
        };
        PageContent.Content = addUsersPage;
    }
}