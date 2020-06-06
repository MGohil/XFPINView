using Xamarin.Forms;

namespace XFPINLoginSample.Views.SampleViews
{
    public partial class BoxBackgroundColorSampleView : ContentView
    {
        public BoxBackgroundColorSampleView()
        {
            InitializeComponent();
            pinView1.PINValue = "123";
            pinView2.PINValue = "123";
            pinView3.PINValue = "123";
        }
    }
}
