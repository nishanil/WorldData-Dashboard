using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldData
{
    public static class HelperExtensions
    {
        public static int ToInteger(this string current, int defaultValue = 0)
        {
            int value;
            return int.TryParse(current, out value) ? value : defaultValue;
        }

        public static double ToDouble(this string current, double defaultValue = 0)
        {
            double invariantCultureResult;
            return double.TryParse(current, NumberStyles.Any, CultureInfo.InvariantCulture, out invariantCultureResult)
                ? invariantCultureResult
                : defaultValue;
            
        }
    }
}
