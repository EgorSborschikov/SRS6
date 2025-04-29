using Avalonia.Controls;
using Avalonia.Interactivity;
using SRS6.Services;
using SRS6.ViewModels;

namespace SRS6.View.Pages.Register;

/// <summary>
/// Логика взаимодействия с RegisterPage
/// </summary>

public partial class RegisterPage : UserControl
{
    public RegisterPage()
    {
        InitializeComponent();
        DataContext = new RegisterPageViewModel(new UserService(new DatabaseService()));
    }

    private void RegisterBtn_Click(object? sender, RoutedEventArgs e)
    {
        var viewModel = DataContext as RegisterPageViewModel;
        viewModel?.Register();
    }
}