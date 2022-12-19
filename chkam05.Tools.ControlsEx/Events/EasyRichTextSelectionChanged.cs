using chkam05.Tools.ControlsEx.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace chkam05.Tools.ControlsEx.Events
{
    public class EasyRichTextSelectionChangedEventArgs : EventArgs
    {

        //  VARIABLES

        public EasyRichTextFormatting Formatting { get; private set; }
        public TextRange SelectedText { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> EasyRichTextSelectionChangedEventArgs class constructor. </summary>
        /// <param name="formatting"> Selected text formatting. </param>
        /// <param name="selectedText"> Selected text range. </param>
        public EasyRichTextSelectionChangedEventArgs(EasyRichTextFormatting formatting, TextRange selectedText) : base()
        {
            Formatting = formatting;
            SelectedText = selectedText;
        }

        #endregion CLASS METHODS

    }
}
