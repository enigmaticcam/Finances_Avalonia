using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Metadata;
using Finances_Avalonia.Commands.Account;
using Finances_Avalonia.Commands.BalanceWindowAccount;
using Finances_Avalonia.Commands.Options;
using Finances_Avalonia.Data;
using Finances_Avalonia.Factories;
using Finances_Avalonia.Services;
using Finances_Avalonia.Services.Entities;
using Finances_Avalonia.Services.Entities.States;
using Finances_Avalonia.ViewModels;
using Finances_Avalonia.ViewModels.Account;
using Finances_Avalonia.ViewModels.Options;
using Finances_Avalonia.Views;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: XmlnsDefinition("https://github.com/avaloniaui", "Finances_Avalonia.Controls")]

namespace Finances_Avalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var collection = new ServiceCollection();
        collection.AddHttpClient<IClient, Client>(options =>
        {
            options.BaseAddress = new("http://localhost");
        });
        collection.AddSingleton<IAccountGet, AccountGet>();
        collection.AddSingleton<IAccountState, AccountState>();
        collection.AddSingleton<IBalanceWindowAccountGet, BalanceWindowAccountGet>();
        collection.AddSingleton<IBalanceWindowAccountState, BalanceWindowAccountState>();
        collection.AddSingleton<ICacheChange, CacheChange>();
        collection.AddSingleton<IClearCollection, ClearCollection>();
        collection.AddSingleton<IOptionsRefreshCache, OptionsRefreshCache>();
        collection.AddSingleton<IServiceWrapper, ServiceWrapper>();

        collection.AddTransient<AccountViewModel>();
        collection.AddTransient<HomePageViewModel>();
        collection.AddTransient<MainViewModel>();
        collection.AddTransient<OptionsViewModel>();

        collection.AddSingleton<Func<enumApplicationPageNames, PageViewModel>>(x => name => name switch
        {
            enumApplicationPageNames.Account => x.GetRequiredService<AccountViewModel>(),
            enumApplicationPageNames.Home => x.GetRequiredService<HomePageViewModel>(),
            enumApplicationPageNames.Options => x.GetRequiredService<OptionsViewModel>(),
            _ => throw new NotImplementedException($"{name.ToString()} not implemented")
        });

        collection.AddSingleton<PageFactory>();

        var services = collection.BuildServiceProvider();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = services.GetRequiredService<MainViewModel>()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = services.GetRequiredService<MainViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
