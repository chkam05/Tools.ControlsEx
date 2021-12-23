using System;
using System.Windows.Controls;


namespace chkam05.DotNetTools.ExtendedControls.Utilities
{
    public class NumericTextValidator
    {

        //  VARIABLES

        public string CorrectText { get; private set; } = "";
        public bool FloatingPointValue { get; set; } = false;


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> NumericTextValidator class constructor. </summary>
        public NumericTextValidator()
        {
            //
        }

        #endregion CLASS METHODS

        #region VALIDATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Validate if text is numeric text. </summary>
        /// <param name="value"> Text to validate. </param>
        /// <returns> True - text is numeric; False - otherwise. </returns>
        public bool Validate(string value)
        {
            if (string.IsNullOrEmpty(value))
                return true;

            if (FloatingPointValue)
            {
                if (double.TryParse($"0{value}0", out double _))
                {
                    CorrectText = value;
                    return true;
                }
            }
            else
            {
                if (int.TryParse(value, out int _))
                {
                    CorrectText = value;
                    return true;
                }
            }

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Validate if text in textbox is numeric and correct it. </summary>
        /// <param name="textBox"> Textbox. </param>
        /// <returns> True - new text is correct numeric text; False - otherwise. </returns>
        public bool ValidateOnTextBox(TextBox textBox)
        {
            string text = textBox.Text;
            int length = text.Length;
            int carret = textBox.SelectionStart;

            bool isValid = Validate(text);

            if (!isValid)
            {
                int diffTextLength = Math.Max(0, length - CorrectText.Length);

                textBox.Text = CorrectText;
                textBox.SelectionStart = Math.Max(0, Math.Min(carret - diffTextLength, CorrectText.Length));
                return false;
            }
            else
            {
                CorrectText = text;
                return true;
            }
        }

        #endregion VALIDATION METHODS

    }
}
