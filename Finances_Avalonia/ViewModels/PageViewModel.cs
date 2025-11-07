using Finances_Avalonia.Data;
using ReactiveUI;

namespace Finances_Avalonia.ViewModels;

public abstract class PageViewModel : ViewModelBase
{
    public PageViewModel()
    {
        _pageName = PageNameAbstract;
    }

    protected abstract enumApplicationPageNames PageNameAbstract { get; }
    public enumApplicationPageNames _pageName;
    public enumApplicationPageNames PageName
    {
        get => _pageName;
        set => this.RaiseAndSetIfChanged(ref _pageName, value);
    }
}
