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
        ExpandSideMenu = ReactiveCommand.Create(
            () => SideMenuExpanded = !SideMenuExpanded
        );
    }

    public string Greeting => "Welcome to Avalonia!";
    private ViewModelBase? _currentPage;
    public ViewModelBase? CurrentPage
    {
        get => _currentPage;
        set => this.RaiseAndSetIfChanged(ref _currentPage, value);
    }

    private bool _sideMenuExpanded = true;
    public bool SideMenuExpanded
    {
        get => _sideMenuExpanded;
        set => this.RaiseAndSetIfChanged(ref _sideMenuExpanded, value);
    }

    public ICommand GoAccounts { get; }
    public ICommand ExpandSideMenu { get; }
}
