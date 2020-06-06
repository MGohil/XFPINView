using Xamarin.Forms;

namespace XFPINLoginSample.Views.SampleViews
{
    public partial class ColorSampleView : ContentView
    {
        public ColorSampleView()
        {
            InitializeComponent();
            pinViewSquere.PINValue = "12345";
            pinViewCircle.PINValue = "12345";
            pinViewRoundCorner.PINValue = "12345";
        }
    }
}
