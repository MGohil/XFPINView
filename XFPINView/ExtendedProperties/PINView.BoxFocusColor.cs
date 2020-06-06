﻿using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace XFPINView
{
    public partial class PINView
    {
        /// <summary>
        /// Gets or Sets the FocusIndicatorColor of the PIN Boxes.
        /// </summary>
        public Color BoxFocusColor
        {
            get => (Color)GetValue(BoxFocusColorProperty);
            set => SetValue(BoxFocusColorProperty, value);
        }

        public static readonly BindableProperty BoxFocusColorProperty =
          BindableProperty.Create(
              nameof(BoxFocusColor),
              typeof(Color),
              typeof(PINView),
              Color.Black,
              defaultBindingMode: BindingMode.OneWay,
              propertyChanged: BoxFocusColorPropertyChanged);

        private static void BoxFocusColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((PINView)bindable).PINBoxContainer.Children.ForEach(x =>
            {
                var boxTemplate = (BoxTemplate)x;
                boxTemplate.BoxFocusColor = (Color)newValue;
            });
        }
    }
}
