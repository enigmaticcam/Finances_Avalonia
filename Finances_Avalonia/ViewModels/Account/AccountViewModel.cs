namespace Finances_Avalonia.ViewModels.Account;
using ReactiveUI;

public class AccountViewModel : ViewModelBase
{

    private bool _showInactive = true;
    public bool ShowInactive
    {
        get => _showInactive;
        set => this.RaiseAndSetIfChanged(ref _showInactive, value);
    }
}
