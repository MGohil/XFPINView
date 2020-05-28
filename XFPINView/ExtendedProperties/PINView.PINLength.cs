﻿using Xamarin.Forms;
using XFPINView.Helpers;

namespace XFPINView
{
    public partial class PINView
    {
        /// <summary>
        /// Gets or Sets the Length of the PIN.
        /// The number of PIN boxes will be layed out based on this Property.
        /// </summary>
        public int PINLength
        {
            get => (int)GetValue(PINLengthProperty);
            set => SetValue(PINLengthProperty, value);
        }

        public static readonly BindableProperty PINLengthProperty =
          BindableProperty.Create(
              nameof(PINLength),
              typeof(int),
              typeof(PINView),
              Constants.DefaultPINLength,
              defaultBindingMode: BindingMode.OneWay,
              propertyChanged: PINLengthPropertyChanged);

        private static void PINLengthPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((int)newValue <= 0)
            {
                return;
            }

           ((PINView)bindable).CreateControl();
        }
    }
}
