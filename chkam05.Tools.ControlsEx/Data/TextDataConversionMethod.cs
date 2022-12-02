using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Data
{
    public static class TextDataConversionMethod
    {

        public static readonly string Base64 = "base64";
        public static readonly string PlainText = "plainText";

        public static readonly List<string> ListData = new List<string>()
        {
            Base64,
            PlainText
        };

        public static string FromDataFormat(string dataFormat)
        {
            if (TextDataFormat.ListData.Contains(dataFormat))
            {
                if (dataFormat == TextDataFormat.Rtf)
                    return Base64;

                if (dataFormat == TextDataFormat.Text)
                    return PlainText;

                if (dataFormat == TextDataFormat.XamlPackage)
                    return Base64;
            }

            return PlainText;
        }

    }
}
