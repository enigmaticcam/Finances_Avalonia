using Finances_Avalonia.ViewModels.Account;
using ReactiveUI;
using System.Reactive;

namespace Finances_Avalonia.ViewModels;

public class MainViewModel : ReactiveObject, IScreen
{
    public MainViewModel()
    {
        GoAccounts = ReactiveCommand.CreateFromObservable(
            () => Router.Navigate.Execute(new AccountViewModel(this))
        );
    }
    public string Greeting => "Welcome to Avalonia!";

    public RoutingState Router => new RoutingState();

    public ReactiveCommand<Unit, IRoutableViewModel> GoAccounts { get; }
    public bool Test { get; set; } = true;
}
