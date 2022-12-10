using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace chkam05.Tools.ControlsEx.Converters.Fonts
{
    internal class ItalicCheckedConverter : IValueConverter
    {

        //  VARIABLES

        private static readonly Dictionary<FontStyle, bool> _mapping = new Dictionary<FontStyle, bool>()
        {
            { FontStyles.Normal, false },
            { FontStyles.Italic, true },
            { FontStyles.Oblique, false },
        };


        //  METHODS

        //  --------------------------------------------------------------------------------
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var style = (FontStyle)value;
            return _mapping[style];
        }

        //  --------------------------------------------------------------------------------
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? FontStyles.Italic : FontStyles.Normal;
        }

    }
}
