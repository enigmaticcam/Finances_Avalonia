using Avalonia;
using Avalonia.Controls;

namespace Finances_Avalonia.Controls;

public class IconButton : Button
{


    /// <summary>
    /// IconImage StyledProperty definition
    /// </summary>
    public static readonly StyledProperty<string> IconImageProperty =
        AvaloniaProperty.Register<IconButton, string>(nameof(IconImage));

    /// <summary>
    /// Gets or sets the IconImage property. This StyledProperty
    /// indicates ....
    /// </summary>
    public string IconImage
    {
        get => this.GetValue(IconImageProperty);
        set => SetValue(IconImageProperty, value);
    }


}