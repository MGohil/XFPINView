using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace XFPINView
{
    public partial class PINEntryControl
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
               typeof(PINEntryControl),
               string.Empty,
               defaultBindingMode: BindingMode.TwoWay,
               propertyChanged: PINValuePropertyChanged);

        private static async void PINValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            try
            {
                var control = (PINEntryControl)bindable;
                var boxes = control.PINBoxContainer.Children;

                string pin = Convert.ToString(newValue);
                ((PINEntryControl)bindable).hiddenTextEntry.Text = pin;

                int length = pin.Length;

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
