using Finances_Avalonia.Data;
using Finances_Avalonia.Factories;
using ReactiveUI;
using System.Reactive.Linq;
using System.Windows.Input;

namespace Finances_Avalonia.ViewModels;

public class MainViewModel : ViewModelBase
{
    /// <summary>
    /// Design-time only constructor
    /// </summary>
    public MainViewModel()
    {
        CurrentPage = new HomePageViewModel();
    }

    public MainViewModel(PageFactory pageFactory)
    {
        GoAccounts = ReactiveCommand.Create(
            () => CurrentPage = pageFactory.GetPageViewModel(enumApplicationPageNames.Account)
        );
        GoHome = ReactiveCommand.Create(
            () => CurrentPage = pageFactory.GetPageViewModel(enumApplicationPageNames.Home)
        );
        GoOptions = ReactiveCommand.Create(
            () => CurrentPage = pageFactory.GetPageViewModel(enumApplicationPageNames.Options)
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
        _optionsPageIsActive = this.WhenAnyValue(x => x.CurrentPage)
            .Select(x => x?.PageName == enumApplicationPageNames.Options)
            .ToProperty(this, x => x.OptionsPageIsActive, scheduler: RxApp.MainThreadScheduler);

        GoHome.Execute(null);
    }

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

    private ObservableAsPropertyHelper<bool> _optionsPageIsActive;
    public bool OptionsPageIsActive => _optionsPageIsActive.Value;

    public ICommand GoAccounts { get; }
    public ICommand GoHome { get; }
    public ICommand GoOptions { get; }
    public ICommand ExpandSideMenu { get; }
}
