using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Events
{
    public class FontBackgroundChangedRequestEventArgs : EventArgs
    {

        //  VARIABLES

        public Color CurrentBackground { get; private set; }
        public bool ChangeRequested { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> FontBackgroundChangedRequestEventArgs class constructor. </summary>
        /// <param name="currentBackground"> Current font background. </param>
        /// <param name="requested"> Change requested. </param>
        public FontBackgroundChangedRequestEventArgs(Color currentBackground, bool requested) : base()
        {
            CurrentBackground = currentBackground;
            ChangeRequested = requested;
        }

        #endregion CLASS METHODS

    }
}
