using Xamarin.Forms;

namespace XFPINLoginSample.Views.SampleViews
{
    public partial class BoxShapeSampleView : ContentView
    {
        public BoxShapeSampleView()
        {
            InitializeComponent();
            pinViewSquere.PINValue = "123";
            pinViewCircle.PINValue = "123";
            pinViewRoundCorner.PINValue = "123";
        }
    }
}
