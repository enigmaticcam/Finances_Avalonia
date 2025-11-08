using Finances_Avalonia.ViewModels;
using ReactiveUI;

namespace Finances_Avalonia.Data.DataViewModels;

public class BalanceWindowAccountDataViewModel : ViewModelBase
{
    public BalanceWindowAccountDataViewModel(int balanceWindowAccountId, int balanceWindowId, int accountId, decimal balance)
    {
        _balanceWindowAccountId = balanceWindowAccountId;
        _balanceWindowId = balanceWindowId;
        _accountId = accountId;
        _balance = balance;
    }

    private int _balanceWindowAccountId;
    public int BalanceWindowAccountId
    {
        get => _balanceWindowAccountId;
        set => this.RaiseAndSetIfChanged(ref _balanceWindowAccountId, value);
    }

    private int _balanceWindowId;
    public int BalanceWindowId
    {
        get => _balanceWindowId;
        set => this.RaiseAndSetIfChanged(ref _balanceWindowId, value);
    }

    private int _accountId;
    public int AccountId
    {
        get => _accountId;
        set => this.RaiseAndSetIfChanged(ref _accountId, value);
    }

    private decimal _balance;
    public decimal Balance
    {
        get => _balance;
        set => this.RaiseAndSetIfChanged(ref _balance, value);
    }
}
