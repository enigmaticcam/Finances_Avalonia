using Finances_Avalonia.Data;
using Finances_Avalonia.Factories;
using ReactiveUI;
using System.Reactive.Linq;
using System.Windows.Input;

namespace Finances_Avalonia.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel(PageFactory pageFactory)
    {
        GoAccounts = ReactiveCommand.Create(
            () => CurrentPage = pageFactory.GetPageViewModel(enumApplicationPageNames.Account)
        );
        GoHome = ReactiveCommand.Create(
            () => CurrentPage = pageFactory.GetPageViewModel(enumApplicationPageNames.Home)
        );
        ExpandSideMenu = ReactiveCommand.Create(
            () => SideMenuExpanded = !SideMenuExpanded
        );
        _homePageIsActive = this.WhenAnyValue(x => x.CurrentPage)
            .Select(x => x?.PageName == enumApplicationPageNames.Home)
            .ToProperty(this, x => x.HomePageIsActive, scheduler: RxApp.MainThreadScheduler);
        _accountPageIsActive = this.WhenAnyValue(x => x.CurrentPage)
            .Select(x => x?.PageName == enumApplicationPageNames.Account)
            .ToProperty(this, x => x.AccountPageIsActive, scheduler: RxApp.MainThreadScheduler);
        _pageFactory = pageFactory;

        GoHome.Execute(null);
    }

    private PageFactory _pageFactory;
    private const string ButtonActiveClass = "active";
    public string Greeting => "Welcome to Avalonia!";

    private PageViewModel? _currentPage;
    public PageViewModel? CurrentPage
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
