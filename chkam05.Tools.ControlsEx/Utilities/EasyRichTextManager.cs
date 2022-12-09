using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace chkam05.Tools.ControlsEx.Utilities
{
    public class EasyRichTextManager
    {

        //  VARIABLES

        public RichTextBox RichTextBox { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> EasyRichTextManager class constructor. </summary>
        /// <param name="richTextBox"> RichTextBox component. </param>
        public EasyRichTextManager(RichTextBox richTextBox)
        {
            RichTextBox = richTextBox;
        }

        #endregion CLASS METHODS

    }
}
