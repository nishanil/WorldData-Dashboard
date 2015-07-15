using System.ComponentModel;
using Android.Widget;
using Java.Lang;
using WorldData.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Button = Android.Widget.Button;
using View = Android.Views.View;
using Options = WorldData.Options;

[assembly: ExportRenderer(typeof(Options), typeof(OptionsRenderer))]

namespace WorldData.Droid.Renderers
{

    public class OptionsRenderer : ViewRenderer<Options, Button>
    {

        public void OnClick()
        {
            PopupMenu menu = new PopupMenu(Context, Control);
            foreach (var item in Element.Items)
            {
                menu.Menu.Add(new String(item));
            }

            menu.MenuItemClick += (s, e) =>
            {
                var itemTitle = e.Item.TitleFormatted;
                Element.SelectedIndex = Element.Items.IndexOf(itemTitle.ToString());
            };

            menu.Show();

        }


        protected override void OnElementChanged(ElementChangedEventArgs<Options> e)
        {
            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    var button = new Button(Context)
                    {
                        Focusable = false,
                        Clickable = true,
                        Tag = this,
                        //TODO: Fix this with a TitleProperty in Options
                        Text = "Frequency",
                    };
                    button.SetOnClickListener(OptionsListener.Instance);
                    SetNativeControl(button);
                }
            }
            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == Options.SelectedIndexProperty.PropertyName)
                UpdateOptionsMenu();
        }

        private void UpdateOptionsMenu()
        {
            Control.Text = Element.Items[Element.SelectedIndex];
        }

        class OptionsListener : Object, IOnClickListener
        {
            public static readonly OptionsListener Instance = new OptionsListener();

            public void OnClick(View v)
            {
                var options = v.Tag as OptionsRenderer;

                if (options != null) options.OnClick();
            }
        }
    }
}