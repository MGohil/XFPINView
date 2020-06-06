using Xamarin.Forms.Platform.UWP;

namespace XFPINLoginSample.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new XFPINLoginSample.App());

            var appView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            appView.TitleBar.BackgroundColor = ((Xamarin.Forms.Color)XFPINLoginSample.App.Current.Resources["PrimaryColor"]).ToWindowsColor();
            appView.TitleBar.ButtonBackgroundColor = ((Xamarin.Forms.Color)XFPINLoginSample.App.Current.Resources["PrimaryColor"]).ToWindowsColor();
            appView.TitleBar.ForegroundColor = ((Xamarin.Forms.Color)XFPINLoginSample.App.Current.Resources["PrimaryTintColor"]).ToWindowsColor();
            appView.TitleBar.ButtonForegroundColor = ((Xamarin.Forms.Color)XFPINLoginSample.App.Current.Resources["PrimaryTintColor"]).ToWindowsColor();
        }
    }
}
