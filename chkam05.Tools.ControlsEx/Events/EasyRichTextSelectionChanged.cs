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

        public EasyRichParagraphProperties ParagraphProperties { get; private set; }
        public EasyRichTextFormatting TextFormatting { get; private set; }
        public TextRange SelectedText { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> EasyRichTextSelectionChangedEventArgs class constructor. </summary>
        /// <param name="paragraphProperties"> Paragraph properties. </param>
        /// <param name="textFormatting"> Text formatting. </param>
        /// <param name="selectedText"> Selected text range. </param>
        public EasyRichTextSelectionChangedEventArgs(EasyRichParagraphProperties paragraphProperties,
            EasyRichTextFormatting textFormatting, TextRange selectedText) : base()
        {
            ParagraphProperties = paragraphProperties;
            TextFormatting = textFormatting;
            SelectedText = selectedText;
        }

        #endregion CLASS METHODS

    }
}
