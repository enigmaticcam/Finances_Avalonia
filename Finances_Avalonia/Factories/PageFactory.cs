using Finances_Avalonia.Data;
using Finances_Avalonia.ViewModels;
using System;

namespace Finances_Avalonia.Factories;

public class PageFactory(Func<enumApplicationPageNames, PageViewModel> factory)
{

    public PageViewModel GetPageViewModel(enumApplicationPageNames pageName) => factory.Invoke(pageName);
}
