using chkam05.Tools.ControlsEx.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Events
{
    public class FontChangedEventArgs : EventArgs
    {

        //  VARIABLES

        public FontFamilyInfo FontFamilyInfo { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> FontChangedEventArgs class constructor. </summary>
        /// <param name="fontFamilyInfo"> Selected font family info. </param>
        public FontChangedEventArgs(FontFamilyInfo fontFamilyInfo) : base()
        {
            FontFamilyInfo = fontFamilyInfo;
        }

        #endregion CLASS METHODS

    }
}
