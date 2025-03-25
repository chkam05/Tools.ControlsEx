using chkam05.Tools.ControlsEx.Data.Enums;
using chkam05.Tools.ControlsEx.Data.Theme;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace chkam05.Tools.ControlsEx.Example.Converters
{
    public class ThemeTypeNameConverter : IValueConverter
    {

        //  CONST

        private static readonly Dictionary<ThemeType, string> themeTypeNames = new Dictionary<ThemeType, string>()
        {
            { ThemeType.Dark, "Dark" },
            { ThemeType.Light, "Light" },
            { ThemeType.System, "System" },
        };


        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Converts ThemeType value to name. </summary>
        /// <param name="value"> The ThemeType value produced by the binding source. </param>
        /// <param name="targetType"> The type of the binding target property. </param>
        /// <param name="parameter"> The converter parameter to use. </param>
        /// <param name="culture"> The culture to use in converter. </param>
        /// <returns> A converted name value. If the methods returns null, the vaild null value is used. </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ThemeType themeType)
                return themeTypeNames[themeType];

            return string.Empty;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Converts a value. </summary>
        /// <param name="value"> The value that is produced by the binding target. </param>
        /// <param name="targetType"> The type to convert to. </param>
        /// <param name="parameter"> The converter parameter to use. </param>
        /// <param name="culture"> The culture to use in the converter. </param>
        /// <returns> A converted value. If the method returns null, the valid null value is used. </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
