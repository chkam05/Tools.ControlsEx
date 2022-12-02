using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Data
{
    public static class TextDataFormat
    {

        public static readonly string Rtf = System.Windows.DataFormats.Rtf;
        public static readonly string Text = System.Windows.DataFormats.Text;
        public static readonly string XamlPackage = System.Windows.DataFormats.XamlPackage;

        public static readonly List<string> ListData = new List<string>()
        {
            Rtf,
            Text,
            XamlPackage
        };

    }
}
