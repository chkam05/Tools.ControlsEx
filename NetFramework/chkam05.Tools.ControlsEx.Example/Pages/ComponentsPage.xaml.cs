using chkam05.Tools.ControlsEx.Data.Collections;
using chkam05.Tools.ControlsEx.Example.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace chkam05.Tools.ControlsEx.Example.Pages
{
    public partial class ComponentsPage : Page
    {

        //  VARIABLES

        public ComponentsPageDataContext ComponentsPageDataContext
        {
            get => base.DataContext as ComponentsPageDataContext;
            set => base.DataContext = value;
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ComponentsPage class constructor. </summary>
        /// <param name="navigationService"> FrameEx Pages navigation service. </param>
        public ComponentsPage(IFrameNavigationServiceEx<Page> navigationService)
        {
            DataContext = new ComponentsPageDataContext(navigationService);

            InitializeComponent();
        }

        #endregion CONSTRUCTORS

    }
}
