﻿using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace XFPINView
{
    public partial class PINView
    {
        /// <summary>
        /// Gets or Sets the Color of the PIN Boxes.
        /// Generally the Color of the Border and Dot inside Box
        /// </summary>
        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public static readonly BindableProperty ColorProperty =
          BindableProperty.Create(
              nameof(Color),
              typeof(Color),
              typeof(PINView),
              Color.Accent,
              defaultBindingMode: BindingMode.OneWay,
              propertyChanged: ColorPropertyChanged);

        private static void ColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (PINView)bindable;

            control.PINBoxContainer.Children.ForEach(x =>
            {
                var boxTemplate = (BoxTemplate)x;
                boxTemplate.SetColor(color: (Color)newValue, boxBorderColor: control.BoxBorderColor);
            });
        }
    }
}
