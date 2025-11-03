using Finances_Avalonia.ViewModels.Account;
using ReactiveUI;
using System.Windows.Input;

namespace Finances_Avalonia.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
        GoAccounts = ReactiveCommand.Create(
            () => CurrentPage = new AccountViewModel()
        );
    }
    public string Greeting => "Welcome to Avalonia!";
    private ViewModelBase? _currentPage;
    public ViewModelBase? CurrentPage
    {
        get => _currentPage;
        set => this.RaiseAndSetIfChanged(ref _currentPage, value);
    }

    public ICommand GoAccounts { get; }
}
