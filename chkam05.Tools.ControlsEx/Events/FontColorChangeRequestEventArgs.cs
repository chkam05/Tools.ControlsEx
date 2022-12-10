using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Events
{
    public class FontColorChangeRequestEventArgs : EventArgs
    {

        //  VARIABLES

        public Color CurrentColor { get; private set; }
        public bool ChangeRequested { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> FontColorChangeRequestEventArgs class constructor. </summary>
        /// <param name="currentColor"> Current font color. </param>
        /// <param name="requested"> Change requested. </param>
        public FontColorChangeRequestEventArgs(Color currentColor, bool requested) : base()
        {
            CurrentColor = currentColor;
            ChangeRequested = requested;
        }

        #endregion CLASS METHODS

    }
}
