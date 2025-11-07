using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Finances_Avalonia.Data;
using Finances_Avalonia.Factories;
using Finances_Avalonia.ViewModels;
using Finances_Avalonia.ViewModels.Account;
using Finances_Avalonia.ViewModels.Options;
using Finances_Avalonia.Views;
using Microsoft.Extensions.DependencyInjection;
using System;

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
