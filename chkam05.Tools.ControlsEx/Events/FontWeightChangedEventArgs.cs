using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace chkam05.Tools.ControlsEx.Events
{
    public class FontWeightChangedEventArgs : EventArgs
    {

        //  VARIABLES

        public FontWeight FontWeight { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> FontWeightChangedEventArgs class constructor. </summary>
        /// <param name="fontWeight"> Selected font weight. </param>
        public FontWeightChangedEventArgs(FontWeight fontWeight) : base()
        {
            FontWeight = fontWeight;
        }

        #endregion CLASS METHODS

    }
}
