using Xamarin.Forms;

namespace XFPINLoginSample.Views
{
    public partial class ChangePINPage : ContentPage
    {
        public ChangePINPage()
        {
            InitializeComponent();
            existingPINEntryControl.PINEntryCompleted += delegate { newPINEntryControl.FocusBox(); };
            newPINEntryControl.PINEntryCompleted += delegate { confirmPINEntryControl.FocusBox(); };
        }
    }
}
