using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace chkam05.Tools.ControlsEx.Events
{
    public class FontUnderlineChangedEventArgs : EventArgs
    {

        //  VARIABLES

        public bool Underline { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> FontUnderlineChangedEventArgs class constructor. </summary>
        /// <param name="underline"> Selected font underline. </param>
        public FontUnderlineChangedEventArgs(bool underline) : base()
        {
            Underline = underline;
        }

        #endregion CLASS METHODS

    }
}
