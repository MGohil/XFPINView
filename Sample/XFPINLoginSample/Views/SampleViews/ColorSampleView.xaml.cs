using Xamarin.Forms;

namespace XFPINLoginSample.Views.SampleViews
{
    public partial class ColorSampleView : ContentView
    {
        public ColorSampleView()
        {
            InitializeComponent();
            pinView1.PINValue = "12345";
            pinView2.PINValue = "12345";
            pinView3.PINValue = "12345";
        }
    }
}
