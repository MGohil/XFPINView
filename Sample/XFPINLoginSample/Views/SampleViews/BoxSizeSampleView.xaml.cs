using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XFPINLoginSample.Views.SampleViews
{
    public partial class BoxSizeSampleView : ContentView
    {
        public BoxSizeSampleView()
        {
            InitializeComponent();
            pinView1.PINValue = "123";
            pinView2.PINValue = "123";
            pinView3.PINValue = "123";
        }
    }
}
