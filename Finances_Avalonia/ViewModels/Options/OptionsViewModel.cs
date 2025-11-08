using Finances_Avalonia.Commands.Options;
using Finances_Avalonia.Data;
using Finances_Avalonia.Services;
using ReactiveUI;
using System.Reactive;

namespace Finances_Avalonia.ViewModels.Options;

public class OptionsViewModel : PageViewModel
{
    private readonly IOptionsRefreshCache _optionsRefreshCache;

    /// <summary>
    /// Design-time only constructor
    /// </summary>
    public OptionsViewModel() { }

    public OptionsViewModel(IOptionsRefreshCache optionsRefreshCache)
    {
        _optionsRefreshCache = optionsRefreshCache;
        RefreshCacheCommand = ReactiveCommand.CreateFromTask(_optionsRefreshCache.Perform);
        _isExecuting = RefreshCacheCommand.IsExecuting.ToProperty(this, x => x.IsExecuting);
    }

    protected override enumApplicationPageNames PageNameAbstract => enumApplicationPageNames.Options;

    private ObservableAsPropertyHelper<bool> _isExecuting;
    public bool IsExecuting => _isExecuting.Value;

    public ReactiveCommand<Unit, APIResult> RefreshCacheCommand { get; }
}
