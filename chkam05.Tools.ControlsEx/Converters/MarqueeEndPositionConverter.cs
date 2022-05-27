using chkam05.Tools.ControlsEx.Static;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace chkam05.Tools.ControlsEx.Converters
{
    internal class MarqueeEndPositionConverter : IMultiValueConverter
    {

        //  --------------------------------------------------------------------------------
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var startPosition = (MarqueeTextAnimationPlace)values[0];
            var canvasWidth = (double)values[1];
            var textWidth = (double)values[2];
            var waitForText = (bool)values[3];

            switch (startPosition)
            {
                case MarqueeTextAnimationPlace.LeftOutside:
                    return -textWidth;

                case MarqueeTextAnimationPlace.LeftInside:
                    return waitForText && IsTextTooLong(canvasWidth, textWidth)
                        ? -(textWidth - canvasWidth)
                        : 0;

                case MarqueeTextAnimationPlace.RightInside:
                    return waitForText && IsTextTooLong(canvasWidth, textWidth)
                        ? 0
                        : canvasWidth - textWidth;

                case MarqueeTextAnimationPlace.RightOutside:
                default:
                    return canvasWidth;
            }
        }

        //  --------------------------------------------------------------------------------
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        //  --------------------------------------------------------------------------------
        private bool IsTextTooLong(double canvasWidth, double textWidth)
        {
            return textWidth >= canvasWidth;
        }

    }
}
