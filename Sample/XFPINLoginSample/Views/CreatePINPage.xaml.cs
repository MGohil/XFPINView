﻿using Xamarin.Forms;

namespace XFPINLoginSample.Views
{
    public partial class CreatePINPage : ContentPage
    {
        public CreatePINPage()
        {
            InitializeComponent();

            // When First PIN box series entry completed, move focus to the next set of PIN entry boxes,
            // so, user can continue entring PIN.
            newPINView.PINEntryCompleted += delegate { confirmPINView.FocusBox(); };
        }
    }
}
