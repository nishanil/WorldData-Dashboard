using UIKit;
using WorldData.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Picker), typeof(CustomPickerRenderer))]
namespace WorldData.iOS.Renderers
{
    public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var textField = Control;
                textField.Font = UIFont.FromName("AvenirNext-Medium", 17f);
                textField.TextAlignment = UITextAlignment.Center;
                textField.TextColor = UIColor.White;
                SetNativeControl(textField);
            }

        }
    }
}