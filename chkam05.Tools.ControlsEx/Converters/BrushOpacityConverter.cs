using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Converters
{
    internal class BrushOpacityConverter : IMultiValueConverter
    {

        //  --------------------------------------------------------------------------------
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var brush = (Brush)values[0];
            double opacity = (double)values[1];

            var resultBrush = brush.Clone();
            resultBrush.Opacity = opacity;
            return resultBrush;
        }

        //  --------------------------------------------------------------------------------
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
