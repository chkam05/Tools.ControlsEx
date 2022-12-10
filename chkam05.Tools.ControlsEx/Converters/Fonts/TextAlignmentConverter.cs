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
    internal class TextAlignmentConverter : IValueConverter
    {

        //  CONST

        public const string PARAM_LEFT = "left";
        public const string PARAM_CENTER = "center";
        public const string PARAM_RIGHT = "right";
        public const string PARAM_JUSTIFY = "justify";


        //  METHODS

        //  --------------------------------------------------------------------------------
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var alignment = (TextAlignment)value;
            var param = ((string)parameter).ToLower();

            switch (alignment)
            {
                case TextAlignment.Left:
                    return param == PARAM_LEFT ? true : false;

                case TextAlignment.Center:
                    return param == PARAM_CENTER ? true : false;

                case TextAlignment.Right:
                    return param == PARAM_RIGHT ? true : false;

                case TextAlignment.Justify:
                    return param == PARAM_JUSTIFY ? true : false;
            }

            return false;
        }

        //  --------------------------------------------------------------------------------
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isChecked = (bool)value;
            var param = (string)parameter;

            if (isChecked)
            {
                switch (param)
                {
                    case PARAM_LEFT:
                        return TextAlignment.Left;

                    case PARAM_CENTER:
                        return TextAlignment.Center;

                    case PARAM_RIGHT:
                        return TextAlignment.Right;

                    case PARAM_JUSTIFY:
                        return TextAlignment.Justify;
                }
            }

            return null;
        }

    }
}
