using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Events
{
    public class InternalMessageHideEventArgs
    {

        //  VARIABLES

        public bool IsHidden { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> InternalMessageHideEventArgs class constructor. </summary>
        /// <param name="isHidden"> Is message hidden. </param>
        public InternalMessageHideEventArgs(bool isHidden) : base()
        {
            IsHidden = isHidden;
        }

        #endregion CLASS METHODS

    }
}
