using ReactiveUI;

namespace Finances_Avalonia.ViewModels.Account;

public class AccountViewModel : ReactiveObject, IRoutableViewModel
{
    public AccountViewModel(IScreen screen)
    {
        HostScreen = screen;
    }
    public string? UrlPathSegment => "AccountMain";

    public IScreen HostScreen { get; }
}
