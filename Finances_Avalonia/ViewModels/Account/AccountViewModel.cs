namespace Finances_Avalonia.ViewModels.Account;

using Finances_Avalonia.Data;
using Finances_Avalonia.Data.DataViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class AccountViewModel : PageViewModel
{
    /// <summary>
    /// Design-time only constructor
    /// </summary>
    public AccountViewModel() 
    {
        _accounts = new()
        {
            new AccountDataViewModel(1, "Wells Fargo", 0, true, false),
            new AccountDataViewModel(1, "BofA", 1000, true, false),
            new AccountDataViewModel(1, "Chase", 2000, true, false),
            new AccountDataViewModel(1, "Amazon", 3000, true, false)
        };
    }

    private ObservableCollection<AccountDataViewModel> _accounts;
    public IEnumerable<AccountDataViewModel> Accounts => _accounts;

    protected override enumApplicationPageNames PageNameAbstract => enumApplicationPageNames.Account;
}
