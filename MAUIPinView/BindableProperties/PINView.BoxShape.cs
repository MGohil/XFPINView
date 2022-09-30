using MAUIPinView.Helpers;

namespace MAUIPinView;

public partial class PINView
{
    /// <summary>
    /// Gets or Sets the Shape of the PIN Box from BoxShapeType enum:
    /// 
    ///     Circle,
    ///     RoundCorner
    ///     Squere
    ///     
    /// </summary>
    public BoxShapeType BoxShape
    {
        get => (BoxShapeType)GetValue(BoxShapeProperty);
        set => SetValue(BoxShapeProperty, value);
    }

    public static readonly BindableProperty BoxShapeProperty =
       BindableProperty.Create(
           nameof(BoxShape),
           typeof(BoxShapeType),
           typeof(PINView),
            BoxShapeType.Circle,
           defaultBindingMode: BindingMode.OneWay,
           propertyChanged: BoxShapePropertyChanged);

    private static void BoxShapePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = ((PINView)bindable);

        foreach (var x in control.PINBoxContainer.Children)
        {
            var boxTemplate = (BoxTemplate)x;
            boxTemplate.SetRadius((BoxShapeType)newValue);
        }
    }
}
