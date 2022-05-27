using chkam05.Tools.ControlsEx.Static;
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
    internal class CheckBoxStyleCheckMarkConverter : IValueConverter
    {

        //  CONST

        public static readonly Dictionary<CheckBoxStyle, PackIconKind> BlankMapping = new Dictionary<CheckBoxStyle, PackIconKind>()
        {
            { CheckBoxStyle.Bordered, PackIconKind.CheckBoxOutlineBlank },
            { CheckBoxStyle.CircleBordered, PackIconKind.CheckboxBlankCircleOutline },
            { CheckBoxStyle.CircleFilled, PackIconKind.CheckboxBlankCircle },
            { CheckBoxStyle.Filled, PackIconKind.CheckboxBlank },
            { CheckBoxStyle.Mixed, PackIconKind.CheckboxBlank },
            { CheckBoxStyle.MixedCircle, PackIconKind.CheckboxBlankCircle },
            { CheckBoxStyle.MixedCircleReverse, PackIconKind.CheckboxBlankCircleOutline },
            { CheckBoxStyle.MixedReverse, PackIconKind.CheckBoxOutlineBlank }
        };

        public static readonly Dictionary<CheckBoxStyle, PackIconKind> CheckedMapping = new Dictionary<CheckBoxStyle, PackIconKind>()
        {
            { CheckBoxStyle.Bordered, PackIconKind.CheckboxOutline },
            { CheckBoxStyle.CircleBordered, PackIconKind.CheckboxMarkedCircleOutline },
            { CheckBoxStyle.CircleFilled, PackIconKind.CheckboxMarkedCircle },
            { CheckBoxStyle.Filled, PackIconKind.CheckboxMarked },
            { CheckBoxStyle.Mixed, PackIconKind.CheckboxOutline },
            { CheckBoxStyle.MixedCircle, PackIconKind.CheckboxMarkedCircleOutline },
            { CheckBoxStyle.MixedCircleReverse, PackIconKind.CheckboxMarkedCircle },
            { CheckBoxStyle.MixedReverse, PackIconKind.CheckboxMarked }
        };


        //  METHODS

        //  --------------------------------------------------------------------------------
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var checkBoxStyle = (CheckBoxStyle)value;
            bool isChecked = false;
            bool.TryParse($"{parameter}", out isChecked);

            return isChecked ? CheckedMapping[checkBoxStyle] : BlankMapping[checkBoxStyle];
        }

        //  --------------------------------------------------------------------------------
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var packIconKind = (PackIconKind)value;

            if (CheckedMapping.Any(kvp => kvp.Value == packIconKind))
                return true;

            return false;
        }

    }
}
