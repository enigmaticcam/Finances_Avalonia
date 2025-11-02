using Finances_Avalonia.ViewModels.Account;
using Finances_Avalonia.Views.Account;
using ReactiveUI;
using System;

namespace Finances_Avalonia.Services;

public class AppViewLocator : IViewLocator
{
    public IViewFor? ResolveView<T>(T? viewModel, string? contract = null) => viewModel switch
    {
        AccountViewModel context => new AccountView { DataContext = context },
        _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
    };
}
