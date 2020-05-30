using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

                string newPIN = Convert.ToString(newValue);
                string oldPIN = Convert.ToString(oldValue);

                control.hiddenTextEntry.Text = newPIN;
                var pinBoxArray = control.PINBoxContainer.Children.Select(x => x as BoxTemplate).ToArray();

                int newPINLength = newPIN.Length;
                int oldPINLength = oldPIN.Length;

                if (newPINLength > oldPINLength && newPINLength >= 1)
                {
                    _ = pinBoxArray[newPINLength - 1].SetValueWithAnimation(newPIN.ToCharArray()[newPINLength - 1]);
                }
                else if (newPINLength < oldPINLength)
                {
                    // If Cleared PIN programatically
                    if (newPINLength == 0 && oldPINLength == control.PINLength)
                    {
                        for (int i = control.PINLength - 1; i >= 0; i--)
                        {
                            // When all PINS are cleared at once, wait for some time (50 ms) to show clear animation from right to left
                            // This delay is half then set inside the animation method to clear values a bit faster
                            _ = pinBoxArray[i].ClearValueWithAnimation();
                            await Task.Delay(50);
                        }
                    }
                    else
                    {
                        await pinBoxArray[newPINLength].ClearValueWithAnimation();
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
