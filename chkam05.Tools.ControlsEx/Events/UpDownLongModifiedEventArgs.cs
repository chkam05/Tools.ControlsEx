using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Events
{
    public class UpDownLongModifiedEventArgs : EventArgs
    {

        //  VARIABLES

        public long NewValue { get; private set; }
        public long OldValue { get; private set; }
        public bool UserModified { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> UpDownLongModifiedEventArgs class constructor. </summary>
        /// <param name="newValue"> New value. </param>
        /// <param name="oldValue"> Old value. </param>
        /// <param name="userModified"> Modification made by user. </param>
        public UpDownLongModifiedEventArgs(long newValue, long oldValue, bool userModified) : base()
        {
            NewValue = newValue;
            OldValue = oldValue;
            UserModified = userModified;
        }

        #endregion CLASS METHODS

    }
}
