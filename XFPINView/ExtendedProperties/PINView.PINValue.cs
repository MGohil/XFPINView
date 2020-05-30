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

                int newPINLength = newPIN.Length;
                int oldPINLength = oldPIN.Length;

                // If no any chars entered, return from here
                if (newPINLength == 0 && oldPINLength == 0)
                {
                    return;
                }

                char[] newPINChars = newPIN.ToCharArray();

                control.hiddenTextEntry.Text = newPIN;
                var pinBoxArray = control.PINBoxContainer.Children.Select(x => x as BoxTemplate).ToArray();

                // Check old and new PIN's equal length to detect if new PIN is set programatically with equal length old PIN
                //    Example: PIN = "12345" and then again set PIN = "98765"

                // If new PIN Length > old PIN Length means user is entering the value

                // TODO 1 : If Programatically set PIN = "12345", then PIN = "456", Last 2 chars should be deleted/removed

                // TODO 2 : IF Programatically set PIN = "12345", now manually delete last 2 chars by delete key,
                //     and again if we set PIN = "45678", some chars are left blank
                if (newPINLength == oldPINLength || (newPINLength > oldPINLength && newPINLength >= 1))
                {
                    // If Set value programatically
                    if ((oldPINLength == 0 || newPINLength == oldPINLength) && newPINLength == control.PINLength)
                    {
                        for (int i = 0; i < control.PINLength; i++)
                        {
                            _ = pinBoxArray[i].SetValueWithAnimation(newPINChars[i]);
                            await Task.Delay(50);
                        }
                    }
                    else
                    {
                        _ = pinBoxArray[newPINLength - 1].SetValueWithAnimation(newPINChars[newPINLength - 1]);
                    }
                }

                // If new PIN Length < old PIN Length means user is clearing/deleting the value by backspace or delete
                else if (newPINLength < oldPINLength)
                {
                    // If all charecters of PIN are Cleared programatically
                    //     Example : PIN = string.Empty
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
