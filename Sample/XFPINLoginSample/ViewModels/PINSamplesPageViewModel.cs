using Xamarin.Forms;

namespace XFPINLoginSample.ViewModels
{
    public class PINSamplesPageViewModel : BaseViewModel
    {
        public PINSamplesPageViewModel()
        {
            Title = "PIN Samples";
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
            await Application.Current.MainPage.DisplayAlert("Message", "PINEntryCompletedCommand Invoked", "OK");
        }
    }
}
