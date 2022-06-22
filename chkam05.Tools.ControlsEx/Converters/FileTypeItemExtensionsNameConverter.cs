using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace chkam05.Tools.ControlsEx.Converters
{
    internal class FileTypeItemExtensionsNameConverter : IValueConverter
    {

        //  METHODS

        //  --------------------------------------------------------------------------------
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var extensions = value as string[];

            if (extensions != null && extensions.Any())
                return $"({string.Join(", ", extensions)})";
            return "(*.*)";
        }

        //  --------------------------------------------------------------------------------
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string data = value as string;

            if (!string.IsNullOrEmpty(data))
            {
                return data.Substring(1, data.Length - 2)
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }

            return new string[0];
        }

    }
}
