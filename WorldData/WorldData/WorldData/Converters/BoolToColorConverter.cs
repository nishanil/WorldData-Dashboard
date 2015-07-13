using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WorldData
{
    public class BoolToColorConverter : IValueConverter
    {
        public BoolToColorConverter()
        {
            FalseColor = Theme.ErrorColor;
            TrueColor = Theme.PrimaryColor;
        }

        /// <summary> Gets or sets TrueColor </summary>
        public Color TrueColor { get; set; }
        /// <summary> Gets or sets FalseColor </summary>
        public Color FalseColor { get; set; }

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) throw new Exception("Cannot convert null value to a Color");

            var isTrue = value.ToString().ToLower() == "true";
            return isTrue ? TrueColor : FalseColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
