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
    internal class BoldCheckedConverter : IValueConverter
    {

        //  VARIABLES

        private static readonly Dictionary<FontWeight, bool> _mapping = new Dictionary<FontWeight, bool>()
        {
            { FontWeights.Normal, false },
            { FontWeights.ExtraLight, false },
            { FontWeights.Light, false },
            { FontWeights.Medium, false },
            { FontWeights.Thin, false },

            { FontWeights.Black, true },
            { FontWeights.Bold, true },
            { FontWeights.ExtraBlack, true },
            { FontWeights.ExtraBold, true },
            { FontWeights.SemiBold, true },
        };


        //  METHODS

        //  --------------------------------------------------------------------------------
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var weight = (FontWeight)value;
            return _mapping[weight];
        }

        //  --------------------------------------------------------------------------------
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? FontWeights.Bold : FontWeights.Normal;
        }

    }
}
