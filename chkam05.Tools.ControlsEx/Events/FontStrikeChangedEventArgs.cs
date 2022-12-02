using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Events
{
    public class FontStrikeChangedEventArgs : EventArgs
    {

        //  VARIABLES

        public bool Strike { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> FontStrikeChangedEventArgs class constructor. </summary>
        /// <param name="strike"> Selected font strike. </param>
        public FontStrikeChangedEventArgs(bool strike) : base()
        {
            Strike = strike;
        }

        #endregion CLASS METHODS

    }
}
