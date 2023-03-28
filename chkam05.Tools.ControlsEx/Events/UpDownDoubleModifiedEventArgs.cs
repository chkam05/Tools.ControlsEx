using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Events
{
    public class UpDownDoubleModifiedEventArgs : EventArgs
    {

        //  VARIABLES

        public double NewValue { get; private set; }
        public double OldValue { get; private set; }
        public bool UserModified { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> UpDownDoubleModifiedEventArgs class constructor. </summary>
        /// <param name="newValue"> New value. </param>
        /// <param name="oldValue"> Old value. </param>
        /// <param name="userModified"> Modification made by user. </param>
        public UpDownDoubleModifiedEventArgs(double newValue, double oldValue, bool userModified) : base()
        {
            NewValue = newValue;
            OldValue = oldValue;
            UserModified = userModified;
        }

        #endregion CLASS METHODS

    }
}
