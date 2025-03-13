using chkam05.Tools.ControlsEx.Example.Utilities;
using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Example.Data
{
    public class AssemblyInfoContext : BaseViewModel
    {

        //  VARIABLES

        private string title;
        private string description;
        private string company;
        private string product;
        private string copyright;
        private string trademark;
        private string version;
        private string fileVersion;
        private string guid;
        private string language;
        private string name;
        private string @namespace;
        private string targetFramework;
        private string outputType;


        //  GETTERS & SETTERS

        public string Title
        {
            get => title;
            set => UpdateProperty(ref title, value);
        }

        public string Description
        {
            get => description;
            set => UpdateProperty(ref description, value);
        }

        public string Company
        {
            get => company;
            set => UpdateProperty(ref company, value);
        }

        public string Product
        {
            get => product;
            set => UpdateProperty(ref product, value);
        }

        public string Copyright
        {
            get => copyright;
            set => UpdateProperty(ref copyright, value);
        }

        public string Trademark
        {
            get => trademark;
            set => UpdateProperty(ref trademark, value);
        }

        public string Version
        {
            get => version;
            set => UpdateProperty(ref version, value);
        }

        public string FileVersion
        {
            get => fileVersion;
            set => UpdateProperty(ref fileVersion, value);
        }

        public string Guid
        {
            get => guid;
            set => UpdateProperty(ref guid, value);
        }

        public string Language
        {
            get => language;
            set => UpdateProperty(ref language, value);
        }

        public string Name
        {
            get => name;
            set => UpdateProperty(ref name, value);
        }

        public string Namespace
        {
            get => @namespace;
            set => UpdateProperty(ref @namespace, value);
        }

        public string TargetFramework
        {
            get => targetFramework;
            set => UpdateProperty(ref targetFramework, value);
        }

        public string OutputType
        {
            get => outputType;
            set => UpdateProperty(ref outputType, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> AppInfoContext class constructor. </summary>
        /// <param name="assemblyInfo"> Assembly info getter. </param>
        public AssemblyInfoContext(AssemblyInfo assemblyInfo)
        {
            Title = assemblyInfo.GetTitle();
            Description = assemblyInfo.GetDescription();
            Company = assemblyInfo.GetCompany();
            Product = assemblyInfo.GetProduct();
            Copyright = assemblyInfo.GetCopyright();
            Trademark = assemblyInfo.GetTrademark();
            Version = assemblyInfo.GetVersion();
            FileVersion = assemblyInfo.GetFileVersion();
            Guid = assemblyInfo.GetGuid();
            Language = assemblyInfo.GetLanguage();
            Name = assemblyInfo.GetName();
            Namespace = assemblyInfo.GetNamespace();
            TargetFramework = assemblyInfo.GetTargetFramework();
            OutputType = assemblyInfo.GetOutputType();
        }

        #endregion CONSTRUCTORS

    }
}
