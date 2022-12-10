using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace chkam05.Tools.ControlsEx.Events
{
    public class TextAlignmentChangedEventArgs : EventArgs
    {

        //  VARIABLES

        public TextAlignment TextAlignment { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> TextAlignmentChangedEventArgs class constructor. </summary>
        /// <param name="textAlignment"> Selected text alignment. </param>
        public TextAlignmentChangedEventArgs(TextAlignment textAlignment) : base()
        {
            TextAlignment = textAlignment;
        }

        #endregion CLASS METHODS

    }
}
