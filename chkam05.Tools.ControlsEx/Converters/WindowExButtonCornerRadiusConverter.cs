using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace chkam05.Tools.ControlsEx.Converters
{
    internal class WindowExButtonCornerRadiusConverter : IValueConverter
    {

        //  CONST

        public const string TopLeft = "TopLeft";
        public const string TopRight = "TopRight";
        public const string BottomRight = "BottomRight";
        public const string BottomLeft = "BottomLeft";


        //  METHODS

        //  --------------------------------------------------------------------------------
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cornerRadius = (CornerRadius)value;
            var side = parameter.ToString();

            switch (side)
            {
                case TopLeft:
                    return new CornerRadius(cornerRadius.TopLeft, 0, 0, 0);

                case BottomRight:
                    return new CornerRadius(0, 0, cornerRadius.BottomRight, 0);

                case BottomLeft:
                    return new CornerRadius(0, 0, 0, cornerRadius.BottomLeft);

                case TopRight:
                default:
                    return new CornerRadius(0, cornerRadius.TopRight, 0, 0);
            }
        }

        //  --------------------------------------------------------------------------------
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
