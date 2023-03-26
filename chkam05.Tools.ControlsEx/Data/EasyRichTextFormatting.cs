using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Data
{
    public class EasyRichTextFormatting : INotifyPropertyChanged, ICloneable
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        #region Decorations properties

        private bool _textDecorationBaseline = false;
        private bool _textDecorationOverLine = false;
        private bool _textDecorationStrikethrough = false;
        private bool _textDecorationUnderline = false;

        #endregion Decorations properties

        private Brush _fontBackground = null;
        private Brush _fontColor = new SolidColorBrush(System.Windows.Media.Colors.Black);
        private FontFamily _fontFamily = new FontFamily("Segoe UI");
        private double _fontSize = 12d;
        private FontStyle _fontStyle = FontStyles.Normal;
        private FontWeight _fontWeight = FontWeights.Normal;
        private TextAlignment _textAlignment = TextAlignment.Left;


        //  GETTERS & SETTERS

        #region Decorations

        public bool TextDecorationBaseline
        {
            get => _textDecorationBaseline;
            set
            {
                _textDecorationBaseline = value;
                OnPropertyChanged(nameof(TextDecorationBaseline));
            }
        }

        public bool TextDecorationOverLine
        {
            get => _textDecorationOverLine;
            set
            {
                _textDecorationOverLine = value;
                OnPropertyChanged(nameof(TextDecorationOverLine));
            }
        }

        public bool TextDecorationStrikethrough
        {
            get => _textDecorationStrikethrough;
            set
            {
                _textDecorationStrikethrough = value;
                OnPropertyChanged(nameof(TextDecorationStrikethrough));
            }
        }

        public bool TextDecorationUnderline
        {
            get => _textDecorationUnderline;
            set
            {
                _textDecorationUnderline = value;
                OnPropertyChanged(nameof(TextDecorationUnderline));
            }
        }

        #endregion Decorations

        public Brush FontBackground
        {
            get => _fontBackground;
            set
            {
                _fontBackground = value;
                OnPropertyChanged(nameof(FontBackground));
            }
        }

        public Brush FontColor
        {
            get => _fontColor;
            set
            {
                _fontColor = value;
                OnPropertyChanged(nameof(FontColor));
            }
        }

        public FontFamily FontFamily
        {
            get => _fontFamily;
            set
            {
                _fontFamily = value ?? new FontFamily("Segoe UI");
                OnPropertyChanged(nameof(FontFamily));
            }
        }

        public double FontSize
        {
            get => _fontSize;
            set
            {
                _fontSize = Math.Max(0, value);
                OnPropertyChanged(nameof(FontSize));
            }
        }

        public FontStyle FontStyle
        {
            get => _fontStyle;
            set
            {
                _fontStyle = value;
                OnPropertyChanged(nameof(FontStyle));
            }
        }

        public FontWeight FontWeight
        {
            get => _fontWeight;
            set
            {
                _fontWeight = value;
                OnPropertyChanged(nameof(FontWeight));
            }
        }

        public TextAlignment TextAlignment
        {
            get => _textAlignment;
            set
            {
                _textAlignment = value;
                OnPropertyChanged(nameof(TextAlignment));
            }
        }

        
        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> EasyRichTextFormatting class constructor. </summary>
        public EasyRichTextFormatting()
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Creates a new object that is a copy of the current instance. </summary>
        /// <returns> A new object that is a copy of this instance. </returns>
        public object Clone()
        {
            return new EasyRichTextFormatting()
            {
                FontBackground = this.FontBackground,
                FontColor = this.FontColor,
                FontFamily = this.FontFamily,
                FontSize = this.FontSize,
                FontStyle = this.FontStyle,
                FontWeight = this.FontWeight,
                TextAlignment = this.TextAlignment,
                TextDecorationBaseline = this.TextDecorationBaseline,
                TextDecorationOverLine = this.TextDecorationOverLine,
                TextDecorationStrikethrough = this.TextDecorationStrikethrough,
                TextDecorationUnderline = this.TextDecorationUnderline,
            };
        }

        #endregion CLASS METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method for invoking PropertyChangedEventHandler external method. </summary>
        /// <param name="propertyName"> Changed property name. </param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion NOTIFY PROPERTIES CHANGED INTERFACE METHODS

    }
}
