using Finances_Avalonia.ViewModels.Account;
using ReactiveUI;
using System.Windows.Input;

namespace Finances_Avalonia.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
        CurrentPage = _homePage;
        GoAccounts = ReactiveCommand.Create(
            () => CurrentPage = _accountPage
        );
        GoHome = ReactiveCommand.Create(
            () => CurrentPage = _homePage
        );
        ExpandSideMenu = ReactiveCommand.Create(
            () => SideMenuExpanded = !SideMenuExpanded
        );
        //this.WhenAnyValue(x => x.HomePageIsActive)
        //    .Subscribe(x => notify)
    }

    private const string ButtonActiveClass = "active";
    public string Greeting => "Welcome to Avalonia!";
    private readonly AccountViewModel _accountPage = new();
    private readonly HomePageViewModel _homePage = new();

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

    public bool HomePageIsActive => _currentPage == _homePage;
    public bool AccountPageIsActive => _currentPage == _accountPage;

    public ICommand GoAccounts { get; }
    public ICommand GoHome { get; }
    public ICommand ExpandSideMenu { get; }
}
