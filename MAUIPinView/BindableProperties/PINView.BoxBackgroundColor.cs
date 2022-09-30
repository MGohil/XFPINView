﻿namespace MAUIPinView;

public partial class PINView
{
    /// <summary>
    /// Gets or Sets the Background color of the PIN Box.
    /// </summary>
    public Color BoxBackgroundColor
    {
        get => (Color)GetValue(BoxBackgroundColorProperty);
        set => SetValue(BoxBackgroundColorProperty, value);
    }

    public static readonly BindableProperty BoxBackgroundColorProperty =
      BindableProperty.Create(
          nameof(BoxBackgroundColor),
          typeof(Color),
          typeof(PINView),
          Colors.Transparent,
          defaultBindingMode: BindingMode.OneWay,
          propertyChanged: BoxBackgroundColorPropertyChanged);

    private static void BoxBackgroundColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        foreach (var x in ((PINView)bindable).PINBoxContainer.Children )
        {
            var boxTemplate = (BoxTemplate)x;
            boxTemplate.Box.BackgroundColor = (Color)newValue;
        }

    }
}
