using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace XFPINView
{
    public partial class PINView
    {
        /// <summary>
        /// Gets or Sets the PIN value.
        /// </summary>
        public string PINValue
        {
            get => (string)GetValue(PINValueProperty);
            set => SetValue(PINValueProperty, value);
        }

        public static readonly BindableProperty PINValueProperty =
           BindableProperty.Create(
               nameof(PINValue),
               typeof(string),
               typeof(PINView),
               string.Empty,
               defaultBindingMode: BindingMode.TwoWay,
               propertyChanged: PINValuePropertyChanged);

        private static async void PINValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            try
            {
                var control = (PINView)bindable;
                var boxes = control.PINBoxContainer.Children;

                string pin = Convert.ToString(newValue);
                ((PINView)bindable).hiddenTextEntry.Text = pin;

                int length = pin.Length;

                if (!control.IsPassword)
                {
                    string oldPin = Convert.ToString(oldValue);
                    int oldLength = oldPin.Length;

                    if (length > oldLength && length >= 1)
                    {
                        (boxes[length - 1] as BoxTemplate).CharLabel.Text = pin.ToCharArray()[length - 1].ToString();
                    }
                    else if (length < oldLength)
                    {
                        (boxes[length] as BoxTemplate).CharLabel.Text = "";
                    }
                }

                for (int i = 0; i < control.PINLength; i++)
                {
                    var boxTemplate = (BoxTemplate)boxes[i];

                    var previousVisibility = boxTemplate.Dot.IsVisible;
                    if (i < length)
                    {
                        boxTemplate.Dot.IsVisible = true;
                        if (previousVisibility == false)
                        {
                            await boxTemplate.GrowAnimation();
                        }
                    }
                    else
                    {
                        if (previousVisibility == true)
                        {
                            await boxTemplate.ShrinkAnimation();
                        }
                        boxTemplate.Dot.IsVisible = false;
                        boxTemplate.CharLabel.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
