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
    public class ContrastSolidColorBrushConverter : IValueConverter
    {

        //  METHODS

        //  --------------------------------------------------------------------------------
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SolidColorBrush brush)
                return new SolidColorBrush(ColorsUtilities.FoundFontColorContrastingWithBackground(brush.Color));

            if (value is Color color)
                return new SolidColorBrush(ColorsUtilities.FoundFontColorContrastingWithBackground(color));

            return System.Windows.Media.Colors.Black;
        }

        //  --------------------------------------------------------------------------------
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
