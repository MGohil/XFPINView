using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XFPINLoginSample.Views.SampleViews
{
    public partial class BoxSpacingSampleView : ContentView
    {
        public BoxSpacingSampleView()
        {
            InitializeComponent();
            pinView1.PINValue = "12345";
            pinView2.PINValue = "12345";
            pinView3.PINValue = "12345";
        }
    }
}
