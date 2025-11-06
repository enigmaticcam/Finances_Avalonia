namespace Finances_Avalonia.ViewModels.Account;

using Finances_Avalonia.Data;
using ReactiveUI;

public class AccountViewModel : PageViewModel
{
    public AccountViewModel()
    {
        PageName = enumApplicationPageNames.Account;
    }

    private bool _showInactive = true;
    public bool ShowInactive
    {
        get => _showInactive;
        set => this.RaiseAndSetIfChanged(ref _showInactive, value);
    }
}
