using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XFPINLoginSample.Views.SampleViews
{
    public partial class PINInputTypeSampleView : ContentView
    {
        public PINInputTypeSampleView()
        {
            InitializeComponent();
            pinView1.PINValue = "12345";
            pinView2.PINValue = "ABCDE";
        }
    }
}
