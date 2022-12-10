using chkam05.Tools.ControlsEx.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace chkam05.Tools.ControlsEx.Events
{
    public class FontStyleChangedEventArgs : EventArgs
    {

        //  VARIABLES

        public FontStyle FontStyle { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> FontStyleChangedEventArgs class constructor. </summary>
        /// <param name="fontStyle"> Selected font style. </param>
        public FontStyleChangedEventArgs(FontStyle fontStyle) : base()
        {
            FontStyle = fontStyle;
        }

        #endregion CLASS METHODS

    }
}
