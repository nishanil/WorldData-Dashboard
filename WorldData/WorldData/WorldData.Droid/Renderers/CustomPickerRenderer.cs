using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WorldData.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using TextAlignment = Android.Views.TextAlignment;

[assembly: ExportRenderer(typeof(Picker), typeof(CustomPickerRenderer))]

namespace WorldData.Droid.Renderers
{
    public class CustomPickerRenderer :  PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            
            Control.SetTextColor(Color.White.ToAndroid());
            Control.SetHintTextColor(Color.White.ToAndroid());
            Control.TextAlignment = TextAlignment.Center;
            Control.SetElegantTextHeight(true);
            Control.TextSize = 10;
            Control.SetPadding(2,2,2,2);
            Control.Gravity = GravityFlags.Center;
            Control.Background = null;

        }
    }
}