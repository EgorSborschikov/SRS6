using Avalonia.Controls;
using Avalonia.Interactivity;
using SRS6.Services;
using SRS6.View.Pages.Login;
using SRS6.View.Pages.Register;
using SRS6.ViewModels;

namespace SRS6.View.Windows.Main;

/// <summary>
/// Логика взаимодействия с MainWindow
/// </summary>

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OpenRegisterPageBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var registerPage = new RegisterPage{
            DataContext = new RegisterPageViewModel(new UserService(new DatabaseService()))
        };
        PageContent.Content = registerPage;
    }

    private void OpenLoginPageBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var loginPage = new LoginPage
        {
            DataContext = new LoginPageViewModel(new UserService(new DatabaseService()))
        };
        // Устанавливаем содержимое PageContent
        PageContent.Content = loginPage;
    }
}