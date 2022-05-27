using chkam05.Tools.ControlsEx.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Utilities
{
    internal class TextBoxExValidator
    {

        //  VARIABLES

        private TextBoxConversionType _conversionType = TextBoxConversionType.Text;
        private string _correctValue;
        private string _previousText;


        //  GETTERS & SETTERS

        public TextBoxConversionType ConversionType
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
        /// <summary> TextBoxValidator class constructor. </summary>
        public TextBoxExValidator()
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
                case TextBoxConversionType.Bool:
                    return TryConvertBool(value, out resultValue, editMode);

                case TextBoxConversionType.Byte:
                    return TryConvertByte(value, out resultValue, editMode);

                case TextBoxConversionType.Char:
                    return TryConvertChar(value, out resultValue, editMode);

                case TextBoxConversionType.Decimal:
                    return TryConvertDecimal(value, out resultValue, editMode);

                case TextBoxConversionType.Double:
                    return TryConvertDouble(value, out resultValue, editMode);

                case TextBoxConversionType.Float:
                    return TryConvertFloat(value, out resultValue, editMode);

                case TextBoxConversionType.Int:
                    return TryConvertInt(value, out resultValue, editMode);

                case TextBoxConversionType.Long:
                    return TryConvertLong(value, out resultValue, editMode);

                case TextBoxConversionType.Short:
                    return TryConvertShort(value, out resultValue, editMode);

                case TextBoxConversionType.UInt:
                    return TryConvertUInt(value, out resultValue, editMode);

                case TextBoxConversionType.UShort:
                    return TryConvertUShort(value, out resultValue, editMode);

                case TextBoxConversionType.DateTime:
                    return TryConvertDateTime(value, out resultValue, editMode);

                case TextBoxConversionType.TimeSpan:
                    return TryConvertTimeSpan(value, out resultValue, editMode);

                case TextBoxConversionType.Text:
                default:
                    return TryConvertString(value, out resultValue, editMode);
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
        private bool TryConvertString(string value, out string resultValue, bool editMode = false)
        {
            if (editMode && string.IsNullOrEmpty(value))
            {
                resultValue = value;
                return true;
            }

            resultValue = value != null ? value : PreviousCorrectValue;
            return value != null;
        }

        //  --------------------------------------------------------------------------------
        private bool TryConvertBool(string value, out string resultValue, bool editMode = false)
        {
            if (editMode && string.IsNullOrEmpty(value))
            {
                resultValue = value;
                return true;
            }

            if (editMode && !string.IsNullOrEmpty(value))
            {
                if (!value.ToLower().Any(c => !(new List<char> { 'f', 'a', 'l', 's', 'e', 't', 'r', 'u' }).Contains(c)))
                {
                    resultValue = value;
                    return true;
                }
            }

            bool canConvert = bool.TryParse(value.ToLower(), out bool _);
            resultValue = canConvert ? value : PreviousCorrectValue;
            return canConvert;
        }

        //  --------------------------------------------------------------------------------
        private bool TryConvertByte(string value, out string resultValue, bool editMode = false)
        {
            if (editMode && string.IsNullOrEmpty(value))
            {
                resultValue = value;
                return true;
            }

            bool canConvert = byte.TryParse(value, out byte _);
            resultValue = canConvert ? value : PreviousCorrectValue;
            return canConvert;
        }

        //  --------------------------------------------------------------------------------
        private bool TryConvertChar(string value, out string resultValue, bool editMode = false)
        {
            if (editMode && string.IsNullOrEmpty(value))
            {
                resultValue = value;
                return true;
            }

            bool canConvert = value.Length == 1;
            resultValue = canConvert ? value : PreviousCorrectValue;
            return canConvert;
        }

        //  --------------------------------------------------------------------------------
        private bool TryConvertDecimal(string value, out string resultValue, bool editMode = false)
        {
            if (editMode && (string.IsNullOrEmpty(value) || value == "-"))
            {
                resultValue = value;
                return true;
            }

            bool canConvert = decimal.TryParse(value, out decimal _);
            resultValue = canConvert ? value : PreviousCorrectValue;
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
        private bool TryConvertFloat(string value, out string resultValue, bool editMode = false)
        {
            if (editMode && (string.IsNullOrEmpty(value) || value == "-" || value == "," || value == "-,"))
            {
                resultValue = value;
                return true;
            }

            if (editMode && !string.IsNullOrEmpty(value) && value.Length > 1)
            {
                if (value.Last() == ',' && float.TryParse(value.Substring(0, value.Length - 2), out float _))
                {
                    resultValue = value;
                    return true;
                }

                if (value.First() == ',' && float.TryParse(value.Substring(1, value.Length - 1), out float _))
                {
                    resultValue = value;
                    return true;
                }
            }

            bool canConvert = float.TryParse(value.ToLower(), out float _);
            resultValue = canConvert ? value : PreviousCorrectValue;
            return canConvert;
        }

        //  --------------------------------------------------------------------------------
        private bool TryConvertInt(string value, out string resultValue, bool editMode = false)
        {
            if (editMode && (string.IsNullOrEmpty(value) || value == "-"))
            {
                resultValue = value;
                return true;
            }

            bool canConvert = int.TryParse(value, out int _);
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

        //  --------------------------------------------------------------------------------
        private bool TryConvertShort(string value, out string resultValue, bool editMode = false)
        {
            if (editMode && (string.IsNullOrEmpty(value) || value == "-"))
            {
                resultValue = value;
                return true;
            }

            bool canConvert = short.TryParse(value, out short _);
            resultValue = canConvert ? value : PreviousCorrectValue;
            return canConvert;
        }

        //  --------------------------------------------------------------------------------
        private bool TryConvertUInt(string value, out string resultValue, bool editMode = false)
        {
            if (editMode && string.IsNullOrEmpty(value))
            {
                resultValue = value;
                return true;
            }

            bool canConvert = uint.TryParse(value, out uint _);
            resultValue = canConvert ? value : PreviousCorrectValue;
            return canConvert;
        }

        //  --------------------------------------------------------------------------------
        private bool TryConvertUShort(string value, out string resultValue, bool editMode = false)
        {
            if (editMode && string.IsNullOrEmpty(value))
            {
                resultValue = value;
                return true;
            }

            bool canConvert = ushort.TryParse(value, out ushort _);
            resultValue = canConvert ? value : PreviousCorrectValue;
            return canConvert;
        }

        //  --------------------------------------------------------------------------------
        private bool TryConvertDateTime(string value, out string resultValue, bool editMode = false)
        {
            if (editMode && string.IsNullOrEmpty(value))
            {
                resultValue = value;
                return true;
            }

            if (editMode && !string.IsNullOrEmpty(value) && value.Length > 0)
            {
                foreach (string dtPart in value.Split(new string[] { "-", ".", "/", ":", " " }, StringSplitOptions.RemoveEmptyEntries))
                {
                    bool partConvert = int.TryParse(dtPart.Trim(), out int _);

                    if (partConvert == false)
                    {
                        resultValue = PreviousCorrectValue;
                        return false;
                    }
                }

                resultValue = value;
                return true;
            }

            bool canConvert = DateTime.TryParse(value, out DateTime _);
            resultValue = canConvert ? value : PreviousCorrectValue;
            return canConvert;
        }

        //  --------------------------------------------------------------------------------
        private bool TryConvertTimeSpan(string value, out string resultValue, bool editMode = false)
        {
            if (editMode && string.IsNullOrEmpty(value))
            {
                resultValue = value;
                return true;
            }

            if (editMode && !string.IsNullOrEmpty(value) && value.Length > 1)
            {
                foreach (string dtPart in value.Split(new string[] { ".", ":" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    bool partConvert = int.TryParse(dtPart.Trim(), out int _);

                    if (partConvert == false)
                    {
                        resultValue = PreviousCorrectValue;
                        return false;
                    }
                }

                resultValue = value;
                return true;
            }

            bool canConvert = TimeSpan.TryParse(value, out TimeSpan _);
            resultValue = canConvert ? value : PreviousCorrectValue;
            return canConvert;
        }

        #endregion CONVERSION METHODS

        #region SET METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Set conversion type. </summary>
        /// <param name="type"> Conversion type. </param>
        /// <param name="defaultValue"> Current or default value starting point. </param>
        public void SetConversionType(TextBoxConversionType type, string defaultValue = null)
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
                case TextBoxConversionType.Bool:
                    PreviousCorrectValue = ((bool)false).ToString();
                    break;

                case TextBoxConversionType.Byte:
                    PreviousCorrectValue = ((byte)0).ToString();
                    break;

                case TextBoxConversionType.Char:
                    PreviousCorrectValue = 'A'.ToString();
                    break;

                case TextBoxConversionType.Decimal:
                    PreviousCorrectValue = 0m.ToString();
                    break;

                case TextBoxConversionType.Double:
                    PreviousCorrectValue = 0d.ToString();
                    break;

                case TextBoxConversionType.Float:
                    PreviousCorrectValue = 0f.ToString();
                    break;

                case TextBoxConversionType.Int:
                    PreviousCorrectValue = 0.ToString();
                    break;

                case TextBoxConversionType.Long:
                    PreviousCorrectValue = 0L.ToString();
                    break;

                case TextBoxConversionType.Short:
                    PreviousCorrectValue = 0.ToString();
                    break;

                case TextBoxConversionType.UInt:
                    PreviousCorrectValue = 0U.ToString();
                    break;

                case TextBoxConversionType.UShort:
                    PreviousCorrectValue = 0.ToString();
                    break;

                case TextBoxConversionType.DateTime:
                    PreviousCorrectValue = DateTime.Now.ToString(@"dd.MM.yyyy HH:mm:ss");
                    break;

                case TextBoxConversionType.TimeSpan:
                    PreviousCorrectValue = new TimeSpan(0).ToString(@"hh\:mm\:ss\.fff");
                    break;

                case TextBoxConversionType.Text:
                default:
                    PreviousCorrectValue = string.Empty;
                    break;
            }
        }

        #endregion SETUP METHODS

    }
}
