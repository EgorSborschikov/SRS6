using Avalonia.Controls;
using Avalonia.Interactivity;
using SRS6.Services;
using SRS6.ViewModels;

namespace SRS6.View.Pages.Login;

/// <summary>
/// Логика взаимодействия с LoginPage
/// </summary>

public partial class LoginPage : UserControl
{
    public LoginPage()
    {
        InitializeComponent();
        DataContext = new LoginPageViewModel(new UserService(new DatabaseService()));
    }

    private void LoginBtn_Click(object? sender, RoutedEventArgs e)
    {
        var viewModel = DataContext as LoginPageViewModel;
        viewModel?.Login();
    }
}