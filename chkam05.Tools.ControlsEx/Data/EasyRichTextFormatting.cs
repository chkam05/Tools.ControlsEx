using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Data
{
    public class EasyRichTextFormatting
    {

        //  VARIABLES

        public Brush FontBackground { get; set; } = null;
        public Brush FontColor { get; set; } = null;
        public FontFamily FontFamily { get; set; } = null;
        public double FontSize { get; set; } = 0;
        public FontStyle FontStyle { get; set; } = FontStyles.Normal;
        public FontWeight FontWeight { get; set; } = FontWeights.Normal;
        public TextAlignment TextAlignment { get; set; } = TextAlignment.Left;

        public bool TextDecorationBaseline { get; set; } = false;
        public bool TextDecorationOverLine { get; set; } = false;
        public bool TextDecorationStrikethrough { get; set; } = false;
        public bool TextDecorationUnderline { get; set; } = false;


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> EasyRichTextFormatting class constructor. </summary>
        public EasyRichTextFormatting()
        {
            //
        }

        #endregion CLASS METHODS

    }
}
