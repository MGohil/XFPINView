using System;
using Xamarin.Forms;
using XFPINLoginSample.Views;

namespace XFPINLoginSample.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            GoToPINLoginPageCommand = new Command(GoToPINLoginPageCommandExecute);
            GoToCreatePINPageCommand = new Command(GoToCreatePINPageCommandExecute);
            GoToChangePINPageCommand = new Command(GoToChangePINPageCommandExecute);
        }

        public Command GoToPINLoginPageCommand { get; set; }
        private void GoToPINLoginPageCommandExecute()
        {
            Application.Current.MainPage.Navigation.PushAsync(new PINLoginPage());
        }

        public Command GoToCreatePINPageCommand { get; set; }
        private void GoToCreatePINPageCommandExecute()
        {
            Application.Current.MainPage.Navigation.PushAsync(new CreatePINPage());
        }

        public Command GoToChangePINPageCommand { get; set; }
        private void GoToChangePINPageCommandExecute()
        {
            Application.Current.MainPage.Navigation.PushAsync(new ChangePINPage());
        }
    }
}
