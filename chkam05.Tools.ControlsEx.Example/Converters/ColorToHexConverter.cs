using chkam05.Tools.ControlsEx.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Example.Converters
{
    public class ColorToHexConverter : IValueConverter
    {

        //  METHODS

        //  --------------------------------------------------------------------------------
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color color = (Color)value;

            return ColorsUtilities.ColorToHex(color);
        }

        //  --------------------------------------------------------------------------------
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string colorHex = value as string;

            if (!string.IsNullOrEmpty(colorHex))
                return ColorsUtilities.ColorFromHex((string)colorHex);

            return System.Windows.Media.Colors.Transparent;
        }

    }
}
