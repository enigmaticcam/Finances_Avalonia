using Finances_Avalonia.Data;

namespace Finances_Avalonia.ViewModels;

public class HomePageViewModel : PageViewModel
{
    public string Test { get; set; } = "Home Test string";
    protected override enumApplicationPageNames PageNameAbstract => enumApplicationPageNames.Home;
}
