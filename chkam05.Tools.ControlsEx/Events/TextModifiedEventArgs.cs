using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Events
{
    public class TextModifiedEventArgs : EventArgs
    {

        //  VARIABLES

        public string NewText { get; private set; }
        public string OldText { get; private set; }
        public bool UserModified { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> TextModifiedEventArgs class constructor. </summary>
        /// <param name="newText"> New text. </param>
        /// <param name="oldText"> Old text. </param>
        /// <param name="userModified"> Modification made by user. </param>
        public TextModifiedEventArgs(string newText, string oldText, bool userModified) : base()
        {
            NewText = newText;
            OldText = oldText;
            UserModified = userModified;
        }

        #endregion CLASS METHODS

    }
}
