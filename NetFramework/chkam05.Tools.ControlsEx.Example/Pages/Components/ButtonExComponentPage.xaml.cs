using chkam05.Tools.ControlsEx.Example.Data.Components;
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

namespace chkam05.Tools.ControlsEx.Example.Pages.Components
{
    public partial class ButtonExComponentPage : Page
    {

        //  VARIABLES

        public ButtonExComponentDataContext ButtonExComponentDataContext
        {
            get => this.DataContext as ButtonExComponentDataContext;
            set => this.DataContext = value;
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ButtonExComponentPage class constructor. </summary>
        public ButtonExComponentPage()
        {
            DataContext = new ButtonExComponentDataContext();

            InitializeComponent();
        }

        #endregion CONSTRUCTORS

    }
}
