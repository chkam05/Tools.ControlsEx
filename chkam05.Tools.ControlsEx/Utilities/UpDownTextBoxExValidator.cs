using chkam05.Tools.ControlsEx.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Utilities
{
    [Obsolete("Old component class used in UpDownTextBoxEx, please use UpDownDoubleTextBoxEx and UpDownLongTextBoxEx instead.")]
    internal class UpDownTextBoxExValidator
    {

        //  VARIABLES

        private UpDownTextBoxConversionType _conversionType = UpDownTextBoxConversionType.Decimal;
        private string _correctValue;
        private string _previousText;


        //  GETTERS & SETTERS

        public UpDownTextBoxConversionType ConversionType
        {
            get => _conversionType;
            set
            {
                SetConversionType(value);
            }
        }

        public string PreviousCorrectValue
        {
            get => _correctValue;
            private set
            {
                _previousText = _correctValue;
                _correctValue = value;
            }
        }

        public string PreviousText
        {
            get => _previousText;
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> UpDownTextBoxValidator class constructor. </summary>
        public UpDownTextBoxExValidator()
        {
            //  Initialize default value.
            InitializeDefaultValue();
        }

        #endregion CLASS METHODS

        #region CONVERSION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Check if string conversion to speicifed type value is possible. </summary>
        /// <param name="value"> Value to convert. </param>
        /// <param name="resultValue"> Converted value output or previous value if conversion failed. </param>
        /// <param name="editMode"> Conversion in edit mode - allows to leave not full filled value. </param>
        /// <returns> True - conversion is possible; False - otherwise. </returns>
        public bool CanConvertValue(string value, out string resultValue, bool editMode = false)
        {
            switch (ConversionType)
            {
                case UpDownTextBoxConversionType.FloatingPoint:
                    return TryConvertDouble(value, out resultValue, editMode);

                case UpDownTextBoxConversionType.Decimal:
                default:
                    return TryConvertLong(value, out resultValue, editMode);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Try convert string value to specified type value. </summary>
        /// <param name="value"> Value to convert. </param>
        /// <param name="resultValue"> Converted value output or previous value if conversion failed. </param>
        /// <returns> True - value converted; False - otherwise. </returns>
        public bool TryConvertValue(string value, out string resultValue)
        {
            bool canConvert = CanConvertValue(value, out resultValue, false);

            if (canConvert)
                PreviousCorrectValue = resultValue;

            return canConvert;
        }

        //  --------------------------------------------------------------------------------
        private bool TryConvertDouble(string value, out string resultValue, bool editMode = false)
        {
            if (editMode && (string.IsNullOrEmpty(value) || value == "-" || value == "," || value == "-,"))
            {
                resultValue = value;
                return true;
            }

            if (editMode && !string.IsNullOrEmpty(value) && value.Length > 1)
            {
                if (value.Last() == ',' && double.TryParse(value.Substring(0, value.Length - 2), out double _))
                {
                    resultValue = value;
                    return true;
                }

                if (value.First() == ',' && double.TryParse(value.Substring(1, value.Length - 1), out double _))
                {
                    resultValue = value;
                    return true;
                }
            }

            bool canConvert = double.TryParse(value.ToLower(), out double _);
            resultValue = canConvert ? value : PreviousCorrectValue;
            return canConvert;
        }

        //  --------------------------------------------------------------------------------
        private bool TryConvertLong(string value, out string resultValue, bool editMode = false)
        {
            if (editMode && (string.IsNullOrEmpty(value) || value == "-"))
            {
                resultValue = value;
                return true;
            }

            bool canConvert = long.TryParse(value, out long _);
            resultValue = canConvert ? value : PreviousCorrectValue;
            return canConvert;
        }

        #endregion CONVERSION METHODS

        #region SET METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Set conversion type. </summary>
        /// <param name="type"> Conversion type. </param>
        /// <param name="defaultValue"> Current or default value starting point. </param>
        public void SetConversionType(UpDownTextBoxConversionType type, string defaultValue = null)
        {
            string correctValue = string.Empty;

            _conversionType = type;

            if (defaultValue == null || !TryConvertValue(defaultValue, out correctValue))
                InitializeDefaultValue();
            else
                PreviousCorrectValue = correctValue;
        }

        #endregion SET METHODS

        #region SETUP METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Setup default values. </summary>
        private void InitializeDefaultValue()
        {
            switch (ConversionType)
            {
                case UpDownTextBoxConversionType.FloatingPoint:
                    PreviousCorrectValue = 0d.ToString();
                    break;

                case UpDownTextBoxConversionType.Decimal:
                default:
                    PreviousCorrectValue = 0L.ToString();
                    break;
            }
        }

        #endregion SETUP METHODS

    }
}
