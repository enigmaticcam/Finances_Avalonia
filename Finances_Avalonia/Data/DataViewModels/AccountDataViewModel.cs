using Finances_Avalonia.ViewModels;
using ReactiveUI;

namespace Finances_Avalonia.Data.DataViewModels;

public class AccountDataViewModel : ViewModelBase
{
    public AccountDataViewModel(int accountId, string accountName, decimal accountLimit, bool isActive, bool needsAdjust)
    {
        _accountId = accountId;
        _accountName = accountName;
        _accountLimit = accountLimit;
        _isActive = isActive;
        _needsAdjust = needsAdjust;
    }

    private int _accountId;
    public int AccountId
    {
        get => _accountId;
        set => this.RaiseAndSetIfChanged(ref _accountId, value);
    }

    private string _accountName;
    public string AccountName
    {
        get => _accountName;
        set => this.RaiseAndSetIfChanged(ref _accountName, value);
    }

    private decimal _accountLimit;
    public decimal AccountLimit
    {
        get => _accountLimit;
        set => this.RaiseAndSetIfChanged(ref _accountLimit, value);
    }

    private bool _isActive;
    public bool IsActive
    {
        get => _isActive;
        set => this.RaiseAndSetIfChanged(ref _isActive, value);
    }

    private bool _needsAdjust;
    public bool NeedsAdjust
    {
        get => _needsAdjust;
        set => this.RaiseAndSetIfChanged(ref _needsAdjust, value);
    }
}
