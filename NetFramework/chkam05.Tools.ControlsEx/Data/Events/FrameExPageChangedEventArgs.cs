using chkam05.Tools.ControlsEx.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace chkam05.Tools.ControlsEx.Data.Events
{
    public class FrameExPageChangedEventArgs : EventArgs
    {

        //  VARIABLES

        public Page Page { get; private set; }
        public FrameExPageAction Action { get; private set; }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> FrameExPageChangedEventArgs class constructor. </summary>
        /// <param name="page"> Loaded or Unloaded page. </param>
        /// <param name="action"> Action. </param>
        public FrameExPageChangedEventArgs(Page page, FrameExPageAction action) : base()
        {
            this.Page = page;
            this.Action = action;
        }

        #endregion CONSTRUCTORS

    }
}
