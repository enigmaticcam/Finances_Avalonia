using Avalonia.Markup.Xaml;
using Finances_Avalonia.ViewModels;
using ReactiveUI;

namespace Finances_Avalonia.Views;

public partial class MainWindow : ReactiveUI.Avalonia.ReactiveWindow<MainViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}
