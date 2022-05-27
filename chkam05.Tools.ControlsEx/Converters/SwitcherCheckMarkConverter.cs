using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace chkam05.Tools.ControlsEx.Converters
{
    internal class SwitcherCheckMarkConverter : IMultiValueConverter
    {

        //  METHODS

        //  --------------------------------------------------------------------------------
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var isChecked = (bool)values[0];
            var isOutline = (bool)values[1];

            return isChecked
                ? isOutline
                    ? PackIconKind.ToggleSwitchOutline
                    : PackIconKind.ToggleSwitch
                : isOutline
                    ? PackIconKind.ToggleSwitchOffOutline
                    : PackIconKind.ToggleSwitchOff;
        }

        //  --------------------------------------------------------------------------------
        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            var packIconKind = (PackIconKind)value;
            var isChecked = false;
            var isOutline = false;

            switch (packIconKind)
            {
                case PackIconKind.ToggleSwitchOutline:
                    isChecked = true;
                    isOutline = true;
                    break;

                case PackIconKind.ToggleSwitch:
                    isChecked = false;
                    isOutline = true;
                    break;

                case PackIconKind.ToggleSwitchOffOutline:
                    isChecked = true;
                    isOutline = false;
                    break;

                case PackIconKind.ToggleSwitchOff:
                    isChecked = false;
                    isOutline = false;
                    break;
            }

            return new object[] { isChecked, isOutline };
        }

    }
}
