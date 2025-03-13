using chkam05.Tools.ControlsEx.Example.Resources;
using chkam05.Tools.ControlsEx.Example.Utilities;
using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Example.Data
{
    public class InfoPageDataContext : BaseViewModel
    {

        //  VARIABLES

        private AssemblyInfoContext appAssemblyInfo;
        private AssemblyInfoContext libAssemblyInfo;


        //  GETTERS & SETTERS

        public AssemblyInfoContext AppAssemblyInfo
        {
            get => appAssemblyInfo;
            set => UpdateProperty(ref appAssemblyInfo, value);
        }

        public AssemblyInfoContext LibAssemblyInfo
        {
            get => libAssemblyInfo;
            set => UpdateProperty(ref libAssemblyInfo, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> InfoPageDataContext class constructor. </summary>
        public InfoPageDataContext()
        {
            AppAssemblyInfo = new AssemblyInfoContext(new AssemblyInfo());
            LibAssemblyInfo = new AssemblyInfoContext(new AssemblyInfo(StaticResources.LIB_FILE_PATH));
        }

        #endregion CONSTRUCTORS

    }
}
