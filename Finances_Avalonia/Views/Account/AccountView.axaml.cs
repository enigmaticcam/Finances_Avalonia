using Avalonia.Markup.Xaml;
using Finances_Avalonia.ViewModels.Account;
using ReactiveUI;

namespace Finances_Avalonia;

public partial class AccountView : ReactiveUI.Avalonia.ReactiveUserControl<AccountViewModel>
{
    public AccountView()
    {
        InitializeComponent();
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}