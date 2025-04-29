using Avalonia.Controls;
using Avalonia.Interactivity;
using SRS6.Services;
using SRS6.ViewModels;

namespace SRS6.View.Pages.AddUsers;

public partial class AddUsersPage : UserControl
{
    public AddUsersPage()
    {
        InitializeComponent();
        DataContext = new AddUsersPageViewModel(new UserService(new DatabaseService()));
    }

    private void AddNewUserBtn_Click(object? sender, RoutedEventArgs e)
    {
        var viewModel = DataContext as AddUsersPageViewModel;
        viewModel?.AddNewUser();
    }
}