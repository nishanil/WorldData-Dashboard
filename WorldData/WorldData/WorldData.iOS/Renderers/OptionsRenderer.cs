using System;
using System.ComponentModel;
using CoreGraphics;
using UIKit;
using WorldData;
using WorldData.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Options), typeof(OptionsRenderer))]

namespace WorldData.iOS.Renderers
{

    public class OptionsRenderer : ViewRenderer<Options, UISegmentedControl>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Options> e)
        {

            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    var segmentedControl = new UISegmentedControl(CGRect.Empty);
                    segmentedControl.ValueChanged += (o, args) =>
                    {
                        var selectedSegmentId = (o as UISegmentedControl).SelectedSegment;
                        e.NewElement.SelectedIndex = (int)selectedSegmentId;
                    };
                    segmentedControl.TintColor = Theme.PrimaryColor.ToUIColor();
                    SetNativeControl(segmentedControl);
                }

                Control.RemoveAllSegments();

                int pos = 0;
                foreach (var item in Element.Items)
                {
                    Control.InsertSegment(item, (int)pos, false);
                    pos++;
                }

            }
            base.OnElementChanged(e);
        }




        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == Options.SelectedIndexProperty.PropertyName)
                UpdateSelectedSegment();
        }

        private void UpdateSelectedSegment()
        {
            Control.SelectedSegment = (int)Element.SelectedIndex;
        }
    }
}