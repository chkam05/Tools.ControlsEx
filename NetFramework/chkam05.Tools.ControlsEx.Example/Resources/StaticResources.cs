using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Example.Resources
{
    public static class StaticResources
    {

        //  CONST

        public const string LIB_FILE_PATH = "chkam05.Tools.ControlsEx.dll";

        public const string ASSEMBLY_TYPE_NAME_CLASS = "Class Library";
        public const string ASSEMBLY_TYPE_NAME_CLI_APP = "Console Application";
        public const string ASSEMBLY_TYPE_NAME_WIN_APP = "Windows Application";
        public const string ASSEMBLY_TYPE_REF_FORMS_NAME = "System.Windows.Forms";
        public const string ASSEMBLY_TYPE_REF_WPF_NAME = "PresentationCore";

        public const string SETTINGS_FILE_NAME = "Settings.json";

        public static readonly Encoding SETTINGS_FILE_ENCODING = Encoding.UTF8;
    }
}
