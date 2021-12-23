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

namespace chkam05.DotNetTools.ExtendedControlsExample.Windows
{
    public partial class MainWindow : Window
    {

        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> MainWindow class constructor. </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Open context menu left clicking on button. </summary>
        /// <param name="sender"> Object that invoked an event. </param>
        /// <param name="e"> Routed event arguemnts. </param>
        private void ButtonContextMenuOpen(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                var button = (Button)sender;

                if (button.ContextMenu != null)
                    button.ContextMenu.IsOpen = true;
            }
        }

        #endregion INTERACTION METHODS

    }
}
