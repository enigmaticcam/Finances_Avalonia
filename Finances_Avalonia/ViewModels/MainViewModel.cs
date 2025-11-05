using Finances_Avalonia.ViewModels.Account;
using ReactiveUI;
using System.Reactive.Linq;
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
        _homePageIsActive = this.WhenAnyValue(x => x.CurrentPage)
            .Select(x => x == _homePage)
            .ToProperty(this, x => x.HomePageIsActive, scheduler: RxApp.MainThreadScheduler);
        _accountPageIsActive = this.WhenAnyValue(x => x.CurrentPage)
            .Select(x => x == _accountPage)
            .ToProperty(this, x => x.AccountPageIsActive, scheduler: RxApp.MainThreadScheduler);
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

    private ObservableAsPropertyHelper<bool> _homePageIsActive;
    public bool HomePageIsActive => _homePageIsActive.Value;

    private ObservableAsPropertyHelper<bool> _accountPageIsActive;
    public bool AccountPageIsActive => _accountPageIsActive.Value;

    public ICommand GoAccounts { get; }
    public ICommand GoHome { get; }
    public ICommand ExpandSideMenu { get; }
}
