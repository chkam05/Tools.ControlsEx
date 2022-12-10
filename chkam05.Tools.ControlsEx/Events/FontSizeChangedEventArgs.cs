using chkam05.Tools.ControlsEx.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Events
{
    public class FontSizeChangedEventArgs : EventArgs
    {

        //  VARIABLES

        public double FontSize { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> FontSizeChangedEventArgs class constructor. </summary>
        /// <param name="fontSize"> Selected font size. </param>
        public FontSizeChangedEventArgs(double fontSize) : base()
        {
            FontSize = fontSize;
        }

        #endregion CLASS METHODS

    }
}
