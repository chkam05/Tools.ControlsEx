using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Data
{
    public class EasyRichParagraphProperties : INotifyPropertyChanged, ICloneable
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        #region Text properties

        private FontFamily _fontFamily = new FontFamily("Segoe UI");
        private double _fontSize = 12d;
        private FontStyle _fontStyle = FontStyles.Normal;
        private FontWeight _fontWeight = FontWeights.Normal;
        private TextAlignment _textAlignment = TextAlignment.Left;

        #endregion Text properties

        #region Text decorations properties

        private bool _textDecorationBaseline = false;
        private bool _textDecorationOverLine = false;
        private bool _textDecorationStrikethrough = false;
        private bool _textDecorationUnderline = false;

        #endregion Text decorations properties

        #region Typography properties

        private int _typographyAnnotationAlternates = 0;
        private FontCapitals _typographyCapitals = FontCapitals.Normal;
        private bool _typographyCapitalSpacing = false;
        private bool _typographyCaseSensitiveForms = false;
        private bool _typographyContextualAlternates = true;
        private bool _typographyContextualLigatures = true;
        private int _typographyContextualSwashes = 0;
        private bool _typographyDiscretionaryLigatures = false;
        private bool _typographyEastAsianExpertForms = false;
        private FontEastAsianLanguage _typographyEastAsianLanguage = FontEastAsianLanguage.Normal;
        private FontEastAsianWidths _typographyEastAsianWidths = FontEastAsianWidths.Normal;
        private FontFraction _typographyFraction = FontFraction.Normal;
        private bool _typographyHistoricalForms = false;
        private bool _typographyHistoricalLigatures = false;
        private bool _typographyKerning = true;
        private bool _typographyMathematicalGreek = false;
        private FontNumeralAlignment _typographyNumeralAlignment = FontNumeralAlignment.Normal;
        private FontNumeralStyle _typographyNumeralStyle = FontNumeralStyle.Normal;
        private bool _typographySlashedZero = false;
        private bool _typographyStandardLigatures = true;
        private int _typographyStandardSwashes = 0;
        private int _typographyStylisticAlternates = 0;
        private bool _typographyStylisticSet1 = false;
        private bool _typographyStylisticSet2 = false;
        private bool _typographyStylisticSet3 = false;
        private bool _typographyStylisticSet4 = false;
        private bool _typographyStylisticSet5 = false;
        private bool _typographyStylisticSet6 = false;
        private bool _typographyStylisticSet7 = false;
        private bool _typographyStylisticSet8 = false;
        private bool _typographyStylisticSet9 = false;
        private bool _typographyStylisticSet10 = false;
        private bool _typographyStylisticSet11 = false;
        private bool _typographyStylisticSet12 = false;
        private bool _typographyStylisticSet13 = false;
        private bool _typographyStylisticSet14 = false;
        private bool _typographyStylisticSet15 = false;
        private bool _typographyStylisticSet16 = false;
        private bool _typographyStylisticSet17 = false;
        private bool _typographyStylisticSet18 = false;
        private bool _typographyStylisticSet19 = false;
        private bool _typographyStylisticSet20 = false;
        private FontVariants _typographyVariants = FontVariants.Normal;

        #endregion Typography properties

        private Brush _background = null;
        private Brush _borderBrush = null;
        private Thickness _borderThickness = new Thickness(0);
        private bool _breakColumnBefore = false;
        private bool _breakPageBefore = false;
        private FlowDirection _flowDirection = FlowDirection.LeftToRight;
        private Brush _foreground = new SolidColorBrush(System.Windows.Media.Colors.Black);
        private bool _isHyphenationEnabled = false;
        private bool _keepTogether = false;
        private bool _keepWithNext = false;
        private double _lineHeight = double.NaN;
        private LineStackingStrategy _lineStackingStrategy = LineStackingStrategy.MaxHeight;
        private Thickness _margin = new Thickness(double.NaN);
        private Thickness _padding = new Thickness(0);
        private double _textIndent = 0;


        //  GETTERS & SETTERS

        #region Text

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

        #endregion Text

        #region Text decorations

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

        #endregion Text decorations

        #region Typography

        public int TypographyAnnotationAlternates
        {
            get => _typographyAnnotationAlternates;
            set
            {
                _typographyAnnotationAlternates = value;
                OnPropertyChanged(nameof(TypographyAnnotationAlternates));
            }
        }

        public FontCapitals TypographyCapitals
        {
            get => _typographyCapitals;
            set
            {
                _typographyCapitals = value;
                OnPropertyChanged(nameof(TypographyCapitals));
            }
        }

        public bool TypographyCapitalSpacing
        {
            get => _typographyCapitalSpacing;
            set
            {
                _typographyCapitalSpacing = value;
                OnPropertyChanged(nameof(TypographyCapitalSpacing));
            }
        }

        public bool TypographyCaseSensitiveForms
        {
            get => _typographyCaseSensitiveForms;
            set
            {
                _typographyCaseSensitiveForms = value;
                OnPropertyChanged(nameof(TypographyCaseSensitiveForms));
            }
        }

        public bool TypographyContextualAlternates
        {
            get => _typographyContextualAlternates;
            set
            {
                _typographyContextualAlternates = value;
                OnPropertyChanged(nameof(TypographyContextualAlternates));
            }
        }

        public bool TypographyContextualLigatures
        {
            get => _typographyContextualLigatures;
            set
            {
                _typographyContextualLigatures = value;
                OnPropertyChanged(nameof(TypographyContextualLigatures));
            }
        }

        public int TypographyContextualSwashes
        {
            get => _typographyContextualSwashes;
            set
            {
                _typographyContextualSwashes = value;
                OnPropertyChanged(nameof(TypographyContextualSwashes));
            }
        }

        public bool TypographyDiscretionaryLigatures
        {
            get => _typographyDiscretionaryLigatures;
            set
            {
                _typographyDiscretionaryLigatures = value;
                OnPropertyChanged(nameof(TypographyDiscretionaryLigatures));
            }
        }

        public bool TypographyEastAsianExpertForms
        {
            get => _typographyEastAsianExpertForms;
            set
            {
                _typographyEastAsianExpertForms = value;
                OnPropertyChanged(nameof(TypographyEastAsianExpertForms));
            }
        }

        public FontEastAsianLanguage TypographyEastAsianLanguage
        {
            get => _typographyEastAsianLanguage;
            set
            {
                _typographyEastAsianLanguage = value;
                OnPropertyChanged(nameof(TypographyEastAsianLanguage));
            }
        }

        public FontEastAsianWidths TypographyEastAsianWidths
        {
            get => _typographyEastAsianWidths;
            set
            {
                _typographyEastAsianWidths = value;
                OnPropertyChanged(nameof(TypographyEastAsianWidths));
            }
        }

        public FontFraction TypographyFraction
        {
            get => _typographyFraction;
            set
            {
                _typographyFraction = value;
                OnPropertyChanged(nameof(TypographyFraction));
            }
        }

        public bool TypographyHistoricalForms
        {
            get => _typographyHistoricalForms;
            set
            {
                _typographyHistoricalForms = value;
                OnPropertyChanged(nameof(TypographyHistoricalForms));
            }
        }

        public bool TypographyHistoricalLigatures
        {
            get => _typographyHistoricalLigatures;
            set
            {
                _typographyHistoricalLigatures = value;
                OnPropertyChanged(nameof(TypographyHistoricalLigatures));
            }
        }

        public bool TypographyKerning
        {
            get => _typographyKerning;
            set
            {
                _typographyKerning = value;
                OnPropertyChanged(nameof(TypographyKerning));
            }
        }

        public bool TypographyMathematicalGreek
        {
            get => _typographyMathematicalGreek;
            set
            {
                _typographyMathematicalGreek = value;
                OnPropertyChanged(nameof(TypographyMathematicalGreek));
            }
        }

        public FontNumeralAlignment TypographyNumeralAlignment
        {
            get => _typographyNumeralAlignment;
            set
            {
                _typographyNumeralAlignment = value;
                OnPropertyChanged(nameof(TypographyNumeralAlignment));
            }
        }

        public FontNumeralStyle TypographyNumeralStyle
        {
            get => _typographyNumeralStyle;
            set
            {
                _typographyNumeralStyle = value;
                OnPropertyChanged(nameof(TypographyNumeralStyle));
            }
        }

        public bool TypographySlashedZero
        {
            get => _typographySlashedZero;
            set
            {
                _typographySlashedZero = value;
                OnPropertyChanged(nameof(TypographySlashedZero));
            }
        }

        public bool TypographyStandardLigatures
        {
            get => _typographyStandardLigatures;
            set
            {
                _typographyStandardLigatures = value;
                OnPropertyChanged(nameof(TypographyStandardLigatures));
            }
        }

        public int TypographyStandardSwashes
        {
            get => _typographyStandardSwashes;
            set
            {
                _typographyStandardSwashes = value;
                OnPropertyChanged(nameof(TypographyStandardSwashes));
            }
        }

        public int TypographyStylisticAlternates
        {
            get => _typographyStylisticAlternates;
            set
            {
                _typographyStylisticAlternates = value;
                OnPropertyChanged(nameof(TypographyStylisticAlternates));
            }
        }

        public bool TypographyStylisticSet1

        {
            get => _typographyStylisticSet1;
            set
            {
                _typographyStylisticSet1 = value;
                OnPropertyChanged(nameof(TypographyStylisticSet1));
            }
        }

        public bool TypographyStylisticSet2
        {
            get => _typographyStylisticSet2;
            set
            {
                _typographyStylisticSet2 = value;
                OnPropertyChanged(nameof(TypographyStylisticSet2));
            }
        }

        public bool TypographyStylisticSet3
        {
            get => _typographyStylisticSet3;
            set
            {
                _typographyStylisticSet3 = value;
                OnPropertyChanged(nameof(TypographyStylisticSet3));
            }
        }

        public bool TypographyStylisticSet4
        {
            get => _typographyStylisticSet4;
            set
            {
                _typographyStylisticSet4 = value;
                OnPropertyChanged(nameof(TypographyStylisticSet4));
            }
        }

        public bool TypographyStylisticSet5
        {
            get => _typographyStylisticSet5;
            set
            {
                _typographyStylisticSet5 = value;
                OnPropertyChanged(nameof(TypographyStylisticSet5));
            }
        }

        public bool TypographyStylisticSet6
        {
            get => _typographyStylisticSet6;
            set
            {
                _typographyStylisticSet6 = value;
                OnPropertyChanged(nameof(TypographyStylisticSet6));
            }
        }

        public bool TypographyStylisticSet7
        {
            get => _typographyStylisticSet7;
            set
            {
                _typographyStylisticSet7 = value;
                OnPropertyChanged(nameof(TypographyStylisticSet7));
            }
        }

        public bool TypographyStylisticSet8
        {
            get => _typographyStylisticSet8;
            set
            {
                _typographyStylisticSet8 = value;
                OnPropertyChanged(nameof(TypographyStylisticSet8));
            }
        }

        public bool TypographyStylisticSet9
        {
            get => _typographyStylisticSet9;
            set
            {
                _typographyStylisticSet9 = value;
                OnPropertyChanged(nameof(TypographyStylisticSet9));
            }
        }

        public bool TypographyStylisticSet10
        {
            get => _typographyStylisticSet10;
            set
            {
                _typographyStylisticSet10 = value;
                OnPropertyChanged(nameof(TypographyStylisticSet10));
            }
        }

        public bool TypographyStylisticSet11
        {
            get => _typographyStylisticSet11;
            set
            {
                _typographyStylisticSet11 = value;
                OnPropertyChanged(nameof(TypographyStylisticSet11));
            }
        }

        public bool TypographyStylisticSet12
        {
            get => _typographyStylisticSet12;
            set
            {
                _typographyStylisticSet12 = value;
                OnPropertyChanged(nameof(TypographyStylisticSet12));
            }
        }

        public bool TypographyStylisticSet13
        {
            get => _typographyStylisticSet13;
            set
            {
                _typographyStylisticSet13 = value;
                OnPropertyChanged(nameof(TypographyStylisticSet13));
            }
        }

        public bool TypographyStylisticSet14
        {
            get => _typographyStylisticSet14;
            set
            {
                _typographyStylisticSet14 = value;
                OnPropertyChanged(nameof(TypographyStylisticSet14));
            }
        }

        public bool TypographyStylisticSet15
        {
            get => _typographyStylisticSet15;
            set
            {
                _typographyStylisticSet15 = value;
                OnPropertyChanged(nameof(TypographyStylisticSet15));
            }
        }

        public bool TypographyStylisticSet16
        {
            get => _typographyStylisticSet16;
            set
            {
                _typographyStylisticSet16 = value;
                OnPropertyChanged(nameof(TypographyStylisticSet16));
            }
        }

        public bool TypographyStylisticSet17
        {
            get => _typographyStylisticSet17;
            set
            {
                _typographyStylisticSet17 = value;
                OnPropertyChanged(nameof(TypographyStylisticSet17));
            }
        }

        public bool TypographyStylisticSet18
        {
            get => _typographyStylisticSet18;
            set
            {
                _typographyStylisticSet18 = value;
                OnPropertyChanged(nameof(TypographyStylisticSet18));
            }
        }

        public bool TypographyStylisticSet19
        {
            get => _typographyStylisticSet19;
            set
            {
                _typographyStylisticSet19 = value;
                OnPropertyChanged(nameof(TypographyStylisticSet19));
            }
        }

        public bool TypographyStylisticSet20
        {
            get => _typographyStylisticSet20;
            set
            {
                _typographyStylisticSet20 = value;
                OnPropertyChanged(nameof(TypographyStylisticSet20));
            }
        }

        public FontVariants TypographyVariants
        {
            get => _typographyVariants;
            set
            {
                _typographyVariants = value;
                OnPropertyChanged(nameof(TypographyVariants));
            }
        }

        #endregion Typography

        public Brush Background
        {
            get => _background;
            set
            {
                _background = value;
                OnPropertyChanged(nameof(Background));
            }
        }

        public Brush BorderBrush
        {
            get => _borderBrush;
            set
            {
                _borderBrush = value;
                OnPropertyChanged(nameof(BorderBrush));
            }
        }

        public Thickness BorderThickness
        {
            get => _borderThickness;
            set
            {
                _borderThickness = value;
                OnPropertyChanged(nameof(BorderThickness));
            }
        }

        public bool BreakColumnBefore
        {
            get => _breakColumnBefore;
            set
            {
                _breakColumnBefore = value;
                OnPropertyChanged(nameof(BreakColumnBefore));
            }
        }

        public bool BreakPageBefore
        {
            get => _breakPageBefore;
            set
            {
                _breakPageBefore = value;
                OnPropertyChanged(nameof(BreakPageBefore));
            }
        }

        public FlowDirection FlowDirection
        {
            get => _flowDirection;
            set
            {
                _flowDirection = value;
                OnPropertyChanged(nameof(FlowDirection));
            }
        }

        public Brush Foreground
        {
            get => _foreground;
            set
            {
                _foreground = value;
                OnPropertyChanged(nameof(Foreground));
            }
        }

        public bool IsHyphenationEnabled
        {
            get => _isHyphenationEnabled;
            set
            {
                _isHyphenationEnabled = value;
                OnPropertyChanged(nameof(IsHyphenationEnabled));
            }
        }

        public bool KeepTogether
        {
            get => _keepTogether;
            set
            {
                _keepTogether = value;
                OnPropertyChanged(nameof(KeepTogether));
            }
        }

        public bool KeepWithNext
        {
            get => _keepWithNext;
            set
            {
                _keepWithNext = value;
                OnPropertyChanged(nameof(KeepWithNext));
            }
        }

        public double LineHeight
        {
            get => _lineHeight;
            set
            {
                _lineHeight = value;
                OnPropertyChanged(nameof(LineHeight));
            }
        }

        public LineStackingStrategy LineStackingStrategy
        {
            get => _lineStackingStrategy;
            set
            {
                _lineStackingStrategy = value;
                OnPropertyChanged(nameof(LineStackingStrategy));
            }
        }

        public Thickness Margin
        {
            get => _margin;
            set
            {
                _margin = value;
                OnPropertyChanged(nameof(Margin));
            }
        }

        public Thickness Padding
        {
            get => _padding;
            set
            {
                _padding = value;
                OnPropertyChanged(nameof(Padding));
            }
        }

        public double TextIndent
        {
            get => _textIndent;
            set
            {
                _textIndent = value;
                OnPropertyChanged(nameof(TextIndent));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> EasyRichParagraphProperties class constructor. </summary>
        public EasyRichParagraphProperties()
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Creates a new object that is a copy of the current instance. </summary>
        /// <returns> A new object that is a copy of this instance. </returns>
        public object Clone()
        {
            return new EasyRichParagraphProperties()
            {
                Background = this.Background,
                BorderBrush = this.BorderBrush,
                BorderThickness = this.BorderThickness,
                BreakColumnBefore = this.BreakColumnBefore,
                BreakPageBefore = this.BreakPageBefore,
                FlowDirection = this.FlowDirection,
                FontFamily = this.FontFamily,
                FontSize = this.FontSize,
                FontStyle = this.FontStyle,
                FontWeight = this.FontWeight,
                Foreground = this.Foreground,
                IsHyphenationEnabled = this.IsHyphenationEnabled,
                KeepTogether = this.KeepTogether,
                KeepWithNext = this.KeepWithNext,
                LineHeight = this.LineHeight,
                LineStackingStrategy = this.LineStackingStrategy,
                Margin = this.Margin,
                Padding = this.Padding,
                TextAlignment = this.TextAlignment,
                TextDecorationBaseline = this.TextDecorationBaseline,
                TextDecorationOverLine = this.TextDecorationOverLine,
                TextDecorationStrikethrough = this.TextDecorationStrikethrough,
                TextDecorationUnderline = this.TextDecorationUnderline,
                TextIndent = this.TextIndent,
                TypographyAnnotationAlternates = this._typographyAnnotationAlternates,
                TypographyCapitals = this.TypographyCapitals,
                TypographyCapitalSpacing = this.TypographyCapitalSpacing,
                TypographyCaseSensitiveForms = this.TypographyCaseSensitiveForms,
                TypographyContextualAlternates = this.TypographyContextualAlternates,
                TypographyContextualLigatures = this.TypographyContextualLigatures,
                TypographyContextualSwashes = this.TypographyContextualSwashes,
                TypographyDiscretionaryLigatures = this.TypographyDiscretionaryLigatures,
                TypographyEastAsianExpertForms = this.TypographyEastAsianExpertForms,
                TypographyEastAsianLanguage = this.TypographyEastAsianLanguage,
                TypographyEastAsianWidths = this._typographyEastAsianWidths,
                TypographyFraction = this.TypographyFraction,
                TypographyHistoricalForms = this.TypographyHistoricalForms,
                TypographyHistoricalLigatures = this.TypographyHistoricalLigatures,
                TypographyKerning = this.TypographyKerning,
                TypographyMathematicalGreek = this.TypographyMathematicalGreek,
                TypographyNumeralAlignment = this.TypographyNumeralAlignment,
                TypographyNumeralStyle = this.TypographyNumeralStyle,
                TypographySlashedZero = this.TypographySlashedZero,
                TypographyStandardLigatures = this.TypographyStandardLigatures,
                TypographyStandardSwashes = this.TypographyStandardSwashes,
                TypographyStylisticAlternates = this.TypographyStylisticAlternates,
                TypographyStylisticSet1 = this.TypographyStylisticSet1,
                TypographyStylisticSet2 = this.TypographyStylisticSet2,
                TypographyStylisticSet3 = this.TypographyStylisticSet3,
                TypographyStylisticSet4 = this.TypographyStylisticSet4,
                TypographyStylisticSet5 = this.TypographyStylisticSet5,
                TypographyStylisticSet6 = this.TypographyStylisticSet6,
                TypographyStylisticSet7 = this.TypographyStylisticSet7,
                TypographyStylisticSet8 = this.TypographyStylisticSet8,
                TypographyStylisticSet9 = this.TypographyStylisticSet9,
                TypographyStylisticSet10 = this.TypographyStylisticSet10,
                TypographyStylisticSet11 = this.TypographyStylisticSet11,
                TypographyStylisticSet12 = this.TypographyStylisticSet12,
                TypographyStylisticSet13 = this.TypographyStylisticSet13,
                TypographyStylisticSet14 = this.TypographyStylisticSet14,
                TypographyStylisticSet15 = this.TypographyStylisticSet15,
                TypographyStylisticSet16 = this.TypographyStylisticSet16,
                TypographyStylisticSet17 = this.TypographyStylisticSet17,
                TypographyStylisticSet18 = this.TypographyStylisticSet18,
                TypographyStylisticSet19 = this.TypographyStylisticSet19,
                TypographyStylisticSet20 = this.TypographyStylisticSet20,
                TypographyVariants = this.TypographyVariants
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
