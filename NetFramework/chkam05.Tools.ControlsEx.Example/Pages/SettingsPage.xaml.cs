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
    public partial class SettingsPage : Page
    {

        //  VARIABLES

        public SettingsPageDataContext SettingsPageDataContext
        {
            get => base.DataContext as SettingsPageDataContext;
            set => base.DataContext = value;
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> SettingsPage class constructor. </summary>
        public SettingsPage()
        {
            DataContext = new SettingsPageDataContext();

            InitializeComponent();
        }

        #endregion CONSTRUCTORS

    }
}
