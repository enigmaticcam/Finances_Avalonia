using Finances_Avalonia.Data;

namespace Finances_Avalonia.ViewModels;

public class HomePageViewModel : PageViewModel
{
    public HomePageViewModel()
    {
        PageName = enumApplicationPageNames.Home;
    }
    public string Test { get; set; } = "Home Test string";
}
