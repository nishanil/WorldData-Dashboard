using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WorldData
{
    public static class Theme
    {
        public static Xamarin.Forms.Color PrimaryColor {
            get { return Xamarin.Forms.Color.FromHex("#22D09B"); }
        }

        //D0021B

        public static Xamarin.Forms.Color ErrorColor
        {
            get { return Xamarin.Forms.Color.FromHex("#D0021B"); }
        }
        public static Xamarin.Forms.Color LightColor
        {
            get { return Xamarin.Forms.Color.FromHex("#E2E2E2"); }
        }

        public static Xamarin.Forms.Color DefaultTextColor
        {
            get { return Xamarin.Forms.Color.FromHex("#002319"); }
        }

        public static string FontFamilyMedium {
            get
            {
                return Device.OnPlatform(iOS: "AvenirNext-Medium", Android: "", WinPhone: "");
            }
        }

        public static string FontFamilyRegular
        {
            get
            {
                return Device.OnPlatform(iOS: "AvenirNext-Regular", Android: "", WinPhone: "");
            }
        }

        public static string FontFamilyUltraLight
        {
            get
            {
                return Device.OnPlatform(iOS: "AvenirNext-UltraLight", Android: "", WinPhone: "");
            }
        }
        //
        public static string FontFamilyItalic
        {
            get
            {
                return Device.OnPlatform(iOS: "AvenirNext-Italic", Android: "", WinPhone: "");
            }
        }

        public static double FontSizeSmall
        {
            get { return Device.GetNamedSize(NamedSize.Small, typeof (Label)); }
        }

        public static double FontSizeMicro
        {
            get { return Device.OnPlatform(iOS: 13, Android: Device.GetNamedSize(NamedSize.Micro, typeof(Label)), WinPhone: Device.GetNamedSize(NamedSize.Micro, typeof(Label))); }

        }

        public static double FontSizeXMicro
        {
            get { return Device.OnPlatform(iOS: 9, Android: Device.GetNamedSize(NamedSize.Micro, typeof(Label)), WinPhone: Device.GetNamedSize(NamedSize.Micro, typeof(Label))); }

        }

        public static double FontSizeMedium
        {
            get { return Device.OnPlatform(iOS: 17, Android: Device.GetNamedSize(NamedSize.Medium, typeof(Label)), WinPhone: Device.GetNamedSize(NamedSize.Medium, typeof(Label))); }

        }

        public static double FontSizeLarge
        {
            get { return Device.OnPlatform(iOS: 24, Android: Device.GetNamedSize(NamedSize.Large, typeof(Label)), WinPhone: Device.GetNamedSize(NamedSize.Large, typeof(Label))); }
        }

        public static double FontSizeExtraLarge
        {
            get { return Device.OnPlatform(iOS: 48, Android: Device.GetNamedSize(NamedSize.Large, typeof(Label)), WinPhone: Device.GetNamedSize(NamedSize.Large, typeof(Label))); }
        }
    }
}
