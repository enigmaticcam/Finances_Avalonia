using Finances_Avalonia.Data;
using ReactiveUI;

namespace Finances_Avalonia.ViewModels;

public class PageViewModel : ViewModelBase
{
    public enumApplicationPageNames _pageName;
    public enumApplicationPageNames PageName
    {
        get => _pageName;
        set => this.RaiseAndSetIfChanged(ref _pageName, value);
    }
}
