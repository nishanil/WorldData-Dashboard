using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace WorldData.WinPhone
{
    public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;
         
            global::Xamarin.Forms.Forms.Init();
            Infragistics.XF.Initializers.Barcodes.Init();
            Infragistics.XF.Initializers.Charts.Init();
            Infragistics.XF.Initializers.Gauges.Init();
            Infragistics.XF.Initializers.Grids.Init();
            LoadApplication(new WorldData.App());
        }
    }
}
