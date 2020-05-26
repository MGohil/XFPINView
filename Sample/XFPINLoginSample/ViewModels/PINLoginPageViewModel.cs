using System.Threading.Tasks;
using Plugin.Settings;
using Xamarin.Forms;
using XFPINLoginSample.Views;

namespace XFPINLoginSample.ViewModels
{
    public class PINLoginPageViewModel : BaseViewModel
    {
        public PINLoginPageViewModel()
        {
            Title = "PIN Login";
            PINEntryCompletedCommand = new Command<string>(PINEntryCompletedCommandExecute);
        }

        string pin;
        public string PIN
        {
            get { return pin; }
            set { SetProperty(ref pin, value); }
        }

        public Command<string> PINEntryCompletedCommand { get; set; }
        private async void PINEntryCompletedCommandExecute(string pin)
        {
            // Here you will fetch saved value from your preferred local storage, where you saved the PIN,
            // And match the user's entry with it
            var existingSavedPIN = CrossSettings.Current.GetValueOrDefault("PIN", string.Empty);
            if (string.IsNullOrWhiteSpace(existingSavedPIN))
            {
                await Application.Current.MainPage.DisplayAlert("Message", "You have not yet created new PIN. Click OK to create new PIN", "OK");
                await Application.Current.MainPage.Navigation.PushAsync(new CreatePINPage());
            }
            else
            {
                // Check if entered PIN matches saved PIN
                if (PIN != existingSavedPIN)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Your entered a wrong PIN", "OK");
                    PIN = string.Empty;
                    return;
                }

                //await Application.Current.MainPage.DisplayAlert("Message", $"PIN Entered {pin}", "OK");

                _ = Task.Run(async () =>
                {
                    // Have some delay before you navigate, otherwise, the last PIN won't be displayed and navigation will be invoked.
                    await Task.Delay(200);

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Application.Current.MainPage.Navigation.PushAsync(new DashboardPage());
                    });
                });
            }
        }
    }
}
