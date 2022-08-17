using MaterialDesignThemes.Wpf;
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

namespace chkam05.Tools.ControlsEx.InternalMessages
{
    public partial class OpenFileInternalMessageEx : BaseFilesSelectorInternalMessageEx
    {

        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> OpenFileInternalMessageEx class constructor. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        /// <param name="title"> Message title. </param>
        /// <param name="icon"> Message header icon kind. </param>
        public OpenFileInternalMessageEx(InternalMessagesExContainer parentContainer, string title = "Select file",
            PackIconKind icon = PackIconKind.FolderOpen) : base(parentContainer)
        {
            Title = title;
            IconKind = icon;

            //  Initialize interface components.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region MESSAGE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading message. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed event arguments. </param>
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            //
        }

        #endregion MESSAGE METHODS

    }
}
