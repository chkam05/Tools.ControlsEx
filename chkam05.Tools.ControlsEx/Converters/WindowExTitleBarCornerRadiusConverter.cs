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
    internal class WindowExTitleBarCornerRadiusConverter : IMultiValueConverter
    {

        //  CONST

        public const string LeftSide = "Left";
        public const string TopSide = "Top";
        public const string RightSide = "Right";
        public const string BottomSide = "Bottom";


        //  METHODS

        //  --------------------------------------------------------------------------------
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var cornerRadius = (CornerRadius)values[0];
            int radiusShift = (int)values[1];
            var side = parameter.ToString();

            switch (side)
            {
                case LeftSide:
                    return new CornerRadius(cornerRadius.TopLeft - radiusShift, 0, 0, cornerRadius.BottomLeft - radiusShift);

                case RightSide:
                    return new CornerRadius(0, cornerRadius.TopRight - radiusShift, cornerRadius.BottomRight - radiusShift, 0);

                case BottomSide:
                    return new CornerRadius(0, 0, cornerRadius.BottomRight - radiusShift, cornerRadius.BottomLeft - radiusShift);

                case TopSide:
                default:
                    return new CornerRadius(cornerRadius.TopLeft - radiusShift, cornerRadius.TopRight - radiusShift, 0, 0);
            }
        }

        //  --------------------------------------------------------------------------------
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
