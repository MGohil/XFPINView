using Xamarin.Forms;
using XFPINView.Helpers;

namespace XFPINLoginSample.Views
{
    public partial class PINSamplesPage : ContentPage
    {
        public PINSamplesPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, string.Empty);
        }

        void PINView_PINEntryCompleted(System.Object sender, PINCompletedEventArgs e)
        {
            Application.Current.MainPage.DisplayAlert("Message", $"PIN Entered {e.PIN}", "OK");
        }
    }
}
