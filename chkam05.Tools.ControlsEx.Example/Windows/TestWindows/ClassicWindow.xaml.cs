using chkam05.Tools.ControlsEx.Example.Data.Config;
using chkam05.Tools.ControlsEx.WindowsEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace chkam05.Tools.ControlsEx.Example.Windows.TestWindows
{
    public partial class ClassicWindow : WindowEx
    {

        //  VARIABLES

        public Configuration Configuration { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ClassicWindow class constructor inherited from WindowsEx. </summary>
        public ClassicWindow()
        {
            //  Initialize data containers.
            Configuration = Configuration.Instance;

            //  Initialize interface components.
            InitializeComponent();
        }

        #endregion CLASS METHODS

    }
}
