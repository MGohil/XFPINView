using Xamarin.Forms;
using XFPINLoginSample.Views;

namespace XFPINLoginSample
{
    public partial class App : Application
    {
        public static int PINLength = 5;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
