using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Events;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Windows.Media.Ocr;


namespace chkam05.Tools.ControlsEx.Utilities
{
    public class EasyRichTextManager : IDisposable
    {

        //  EVENTS

        public event EventHandler<EasyRichTextSelectionChangedEventArgs> SelectionChanged;


        //  VARIABLES

        private bool _focused = false;
        private bool _nonSelectionInitializing = false;
        private bool _textChanged = false;
        private bool _textSelected = false;
        private TextRange _tempSelectedText = null;

        public RichTextBox RichTextBox { get; private set; }


        //  GETTERS & SETTERS

        public TextRange SelectedText
        {
            get
            {
                try
                {
                    return new TextRange(RichTextBox.Selection.Start, RichTextBox.Selection.End);
                }
                catch
                {
                    return _tempSelectedText;
                }
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> EasyRichTextManager class constructor. </summary>
        public EasyRichTextManager()
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> EasyRichTextManager class constructor. </summary>
        /// <param name="richTextBox"> RichTextBox component. </param>
        public EasyRichTextManager(RichTextBox richTextBox)
        {
            Setup(richTextBox);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked during object destroying process. </summary>
        public void Dispose()
        {
            RichTextBox.GotFocus -= OnRichTextBoxGotFocus;
            RichTextBox.LostFocus -= OnRichTextBoxLostFocus;
            RichTextBox.SelectionChanged -= OnRichTextBoxSelectionChanged;
        }

        #endregion CLASS METHODS

        #region RICHTEXTBOX INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after focusing RichTextBox. </summary>
        /// <param name="sender"> Object which from event has been invoked. </param>
        /// <param name="e"> Routed Event Args. </param>
        protected void OnRichTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            _focused = true;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after RichTextBox lost focus. </summary>
        /// <param name="sender"> Object which from event has been invoked. </param>
        /// <param name="e"> Routed Event Args. </param>
        protected void OnRichTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            _focused = false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after text selection chaged in RichTextBox. </summary>
        /// <param name="sender"> Object which from event has been invoked. </param>
        /// <param name="e"> Routed Event Args. </param>
        protected void OnRichTextBoxSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (_focused)
            {
                if (_textChanged)
                {
                    _textChanged = false;
                }
                else
                {
                    _textSelected = !RichTextBox.Selection.IsEmpty;

                    var paragraphProperties = GetSelectedParagraphProperties();
                    var textFormatting = GetSelectedTextFormatting();
                    var eventArgs = new EasyRichTextSelectionChangedEventArgs(
                        paragraphProperties, textFormatting, SelectedText);

                    SelectionChanged?.Invoke(this, eventArgs);
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing text in RichTextBox. </summary>
        /// <param name="sender"> Object which from event has been invoked. </param>
        /// <param name="e"> Text Changed Event Args. </param>
        protected void OnRichTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            if (_focused)
            {
                _textChanged = true;
                _textSelected = false;
            }
        }

        #endregion RICHTEXTBOX INTERACTION METHODS

        #region SELECTED PARAGRAPH GET PROPERTIES METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Get selected paragraph properties. </summary>
        /// <returns> EasyRichParagraphProperties object. </returns>
        public EasyRichParagraphProperties GetSelectedParagraphProperties()
        {
            return new EasyRichParagraphProperties()
            {
                Background = GetSelectedParagraphBackground(),
                BorderBrush = GetSelectedParagraphBorderBrush(),
                BorderThickness = GetSelectedParagraphBorderThickness(),
                BreakColumnBefore = GetSelectedParagraphBreakColumnBefore(),
                BreakPageBefore = GetSelectedParagraphBreakPageBefore(),
                FlowDirection = GetSelectedParagraphFlowDirection(),
                Foreground = GetSelectedParagraphForeground(),
                IsHyphenationEnabled = GetSelectedParagraphIsHyphenationEnabled(),
                KeepTogether = GetSelectedParagraphKeepTogether(),
                KeepWithNext = GetSelectedParagraphKeepWithNext(),
                LineHeight = GetSelectedParagraphLineHeight(),
                LineStackingStrategy = GetSelectedParagraphLineStackingStrategy(),
                Margin = GetSelectedParagraphMargin(),
                Padding = GetSelectedParagraphPadding(),
                TextIndent = GetSelectedParagraphTextIndent(),

                //  Font
                FontFamily = GetSelectedParagraphFontFamily(),
                FontSize = GetSelectedParagraphFontSize(),
                FontStyle = GetSelectedParagraphFontStyle(),
                FontWeight = GetSelectedParagraphFontWeight(),

                //  Text decorations
                TextAlignment = GetSelectedParagraphTextAlignment(),
                TextDecorationBaseline = GetSelectedParagraphBaseline(),
                TextDecorationOverLine = GetSelectedParagraphTextOverLine(),
                TextDecorationStrikethrough = GetSelectedParagraphTextStrikethrough(),
                TextDecorationUnderline = GetSelectedParagraphTextUnderline(),

                //  Typography
                TypographyAnnotationAlternates = GetSelectedParagraphTypographyAnnotationAlternates(),
                TypographyCapitals = GetSelectedParagraphTypographyCapitals(),
                TypographyCapitalSpacing = GetSelectedParagraphTypographyCapitalSpacing(),
                TypographyCaseSensitiveForms = GetSelectedParagraphTypographyCaseSensitiveForms(),
                TypographyContextualAlternates = GetSelectedParagraphTypographyContextualAlternates(),
                TypographyContextualLigatures = GetSelectedParagraphTypographyContextualLigatures(),
                TypographyContextualSwashes = GetSelectedParagraphTypographyContextualSwashes(),
                TypographyDiscretionaryLigatures = GetSelectedParagraphTypographyDiscretionaryLigatures(),
                TypographyEastAsianExpertForms = GetSelectedParagraphTypographyEastAsianExpertForms(),
                TypographyEastAsianLanguage = GetSelectedParagraphTypographyEastAsianLanguage(),
                TypographyEastAsianWidths = GetSelectedParagraphTypographyEastAsianWidths(),
                TypographyFraction = GetSelectedParagraphTypographyFraction(),
                TypographyHistoricalForms = GetSelectedParagraphTypographyHistoricalForms(),
                TypographyHistoricalLigatures = GetSelectedParagraphTypographyHistoricalLigatures(),
                TypographyKerning = GetSelectedParagraphTypographyKerning(),
                TypographyMathematicalGreek = GetSelectedParagraphTypographyMathematicalGreek(),
                TypographyNumeralAlignment = GetSelectedParagraphTypographyNumeralAlignment(),
                TypographyNumeralStyle = GetSelectedParagraphTypographyNumeralStyle(),
                TypographySlashedZero = GetSelectedParagraphTypographySlashedZero(),
                TypographyStandardLigatures = GetSelectedParagraphTypographyStandardLigatures(),
                TypographyStandardSwashes = GetSelectedParagraphTypographyStandardSwashes(),
                TypographyStylisticAlternates = GetSelectedParagraphTypographyStylisticAlternates(),
                TypographyStylisticSet1 = GetSelectedParagraphTypographyStylisticSet(1),
                TypographyStylisticSet2 = GetSelectedParagraphTypographyStylisticSet(2),
                TypographyStylisticSet3 = GetSelectedParagraphTypographyStylisticSet(3),
                TypographyStylisticSet4 = GetSelectedParagraphTypographyStylisticSet(4),
                TypographyStylisticSet5 = GetSelectedParagraphTypographyStylisticSet(5),
                TypographyStylisticSet6 = GetSelectedParagraphTypographyStylisticSet(6),
                TypographyStylisticSet7 = GetSelectedParagraphTypographyStylisticSet(7),
                TypographyStylisticSet8 = GetSelectedParagraphTypographyStylisticSet(8),
                TypographyStylisticSet9 = GetSelectedParagraphTypographyStylisticSet(9),
                TypographyStylisticSet10 = GetSelectedParagraphTypographyStylisticSet(10),
                TypographyStylisticSet11 = GetSelectedParagraphTypographyStylisticSet(11),
                TypographyStylisticSet12 = GetSelectedParagraphTypographyStylisticSet(12),
                TypographyStylisticSet13 = GetSelectedParagraphTypographyStylisticSet(13),
                TypographyStylisticSet14 = GetSelectedParagraphTypographyStylisticSet(14),
                TypographyStylisticSet15 = GetSelectedParagraphTypographyStylisticSet(15),
                TypographyStylisticSet16 = GetSelectedParagraphTypographyStylisticSet(16),
                TypographyStylisticSet17 = GetSelectedParagraphTypographyStylisticSet(17),
                TypographyStylisticSet18 = GetSelectedParagraphTypographyStylisticSet(18),
                TypographyStylisticSet19 = GetSelectedParagraphTypographyStylisticSet(19),
                TypographyStylisticSet20 = GetSelectedParagraphTypographyStylisticSet(20),
                TypographyVariants = GetSelectedParagraphTypographyVariants(),
            };
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get background color brush of selected text paragraph or for current position. </summary>
        /// <returns> Selected paragraph background color. </returns>
        public Brush GetSelectedParagraphBackground()
        {
            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                return paragraph.Background;

            return null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get border brush of selected text paragraph or for current position. </summary>
        /// <returns> Selected paragraph border brush. </returns>
        public Brush GetSelectedParagraphBorderBrush()
        {
            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                return paragraph.BorderBrush;

            return null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get border thickness of selected text paragraph or for current position. </summary>
        /// <returns> Selected paragraph border thickness. </returns>
        public Thickness GetSelectedParagraphBorderThickness()
        {
            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                return paragraph.BorderThickness;

            return new Thickness(0);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get break column before value of selected text paragraph or for current position. </summary>
        /// <returns> Selected paragraph break column before value. </returns>
        public bool GetSelectedParagraphBreakColumnBefore()
        {
            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                return paragraph.BreakColumnBefore;

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get break page before value of selected text paragraph or for current position. </summary>
        /// <returns> Selected paragraph break page before value. </returns>
        public bool GetSelectedParagraphBreakPageBefore()
        {
            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                return paragraph.BreakPageBefore;

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get flow direction value of selected text paragraph or for current position. </summary>
        /// <returns> Selected paragraph flow direction value. </returns>
        public FlowDirection GetSelectedParagraphFlowDirection()
        {
            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                return paragraph.FlowDirection;

            return FlowDirection.LeftToRight;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get foreground color brush of selected text paragraph or for current position. </summary>
        /// <returns> Selected paragraph foreground color. </returns>
        public Brush GetSelectedParagraphForeground()
        {
            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                return paragraph.Foreground;

            return null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get is hyphenation enabled value (auto words split) of selected text paragraph or for current position. </summary>
        /// <returns> Selected paragraph is hyphenation enabled value. </returns>
        public bool GetSelectedParagraphIsHyphenationEnabled()
        {
            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                return paragraph.IsHyphenationEnabled;

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get keep together value (No pages or column breaks) of selected text paragraph or for current position. </summary>
        /// <returns> Selected paragraph keep together value. </returns>
        public bool GetSelectedParagraphKeepTogether()
        {
            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                return paragraph.KeepTogether;

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get keep with next value (Keep with next paragraph) of selected text paragraph or for current position. </summary>
        /// <returns> Selected paragraph keep with next value. </returns>
        public bool GetSelectedParagraphKeepWithNext()
        {
            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                return paragraph.KeepWithNext;

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get line height value of selected text paragraph or for current position. </summary>
        /// <returns> Selected paragraph line height value. </returns>
        public double GetSelectedParagraphLineHeight()
        {
            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                return paragraph.LineHeight;

            return double.NaN;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get line stacking strategy value of selected text paragraph or for current position. </summary>
        /// <returns> Selected paragraph line stacking strategy value. </returns>
        public LineStackingStrategy GetSelectedParagraphLineStackingStrategy()
        {
            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                return paragraph.LineStackingStrategy;

            return LineStackingStrategy.MaxHeight;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get margin value of selected text paragraph or for current position. </summary>
        /// <returns> Selected paragraph margin value. </returns>
        public Thickness GetSelectedParagraphMargin()
        {
            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                return paragraph.Margin;

            return new Thickness(double.NaN);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get padding value of selected text paragraph or for current position. </summary>
        /// <returns> Selected paragraph padding value. </returns>
        public Thickness GetSelectedParagraphPadding()
        {
            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                return paragraph.Padding;

            return new Thickness(0);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get text indent value of selected text paragraph or for current position. </summary>
        /// <returns> Selected paragraph text indent value. </returns>
        public double GetSelectedParagraphTextIndent()
        {
            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                return paragraph.TextIndent;

            return 0;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get font family of selected text paragraph or for current position. </summary>
        /// <returns> Selected paragraph text font family. </returns>
        public FontFamily GetSelectedParagraphFontFamily()
        {
            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                return paragraph.FontFamily;

            return new FontFamily("Segoe UI");
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get font size of selected text paragraph or for current position. </summary>
        /// <returns> Selected paragraph text font size. </returns>
        public double GetSelectedParagraphFontSize()
        {
            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                return paragraph.FontSize;

            return 12d;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get font style of selected text paragraph or for current position. </summary>
        /// <returns> Selected paragraph text font style. </returns>
        public FontStyle GetSelectedParagraphFontStyle()
        {
            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                return paragraph.FontStyle;

            return FontStyles.Normal;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get font weight of selected text paragraph or for current position. </summary>
        /// <returns> Selected paragraph text font weight. </returns>
        public FontWeight GetSelectedParagraphFontWeight()
        {
            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                return paragraph.FontWeight;

            return FontWeights.Normal;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get alignment of selected text paragraph or for current position. </summary>
        /// <returns> Selected paragraph text alignment. </returns>
        public TextAlignment GetSelectedParagraphTextAlignment()
        {
            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                return paragraph.TextAlignment;

            return TextAlignment.Left;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get text baseline decoration of current selected text paragraph or for current position. </summary>
        /// <returns> Selected paragraph text baseline decoration enabled. </returns>
        public bool GetSelectedParagraphBaseline()
        {
            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                return TextDecorationsHelper.HasDecroation(paragraph.TextDecorations, TextDecorationLocation.Baseline);

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get text overline decoration of current selected text paragraph or for current position. </summary>
        /// <returns> Selected paragraph text overline decoration enabled. </returns>
        public bool GetSelectedParagraphTextOverLine()
        {
            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                return TextDecorationsHelper.HasDecroation(paragraph.TextDecorations, TextDecorationLocation.OverLine);

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get text strikethrough decoration of current selected text paragraph or for current position. </summary>
        /// <returns> Selected paragraph text strikethrough decoration enabled. </returns>
        public bool GetSelectedParagraphTextStrikethrough()
        {
            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                return TextDecorationsHelper.HasDecroation(paragraph.TextDecorations, TextDecorationLocation.Strikethrough);

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get text underline decoration of current selected text paragraph or for current position. </summary>
        /// <returns> Selected paragraph text underline decoration enabled. </returns>
        public bool GetSelectedParagraphTextUnderline()
        {
            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                return TextDecorationsHelper.HasDecroation(paragraph.TextDecorations, TextDecorationLocation.Underline);

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get annotation alternates typography value of selected text paragraph or for current position </summary>
        /// <returns> Selected paragraph annotation alternates typography value. </returns>
        public int GetSelectedParagraphTypographyAnnotationAlternates()
        {
            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                return typology.AnnotationAlternates;

            return 0;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get capitals typography value of selected text paragraph or for current position </summary>
        /// <returns> Selected paragraph capitals typography value. </returns>
        public FontCapitals GetSelectedParagraphTypographyCapitals()
        {
            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                return typology.Capitals;

            return FontCapitals.Normal;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get capital spacing typography value of selected text paragraph or for current position </summary>
        /// <returns> Selected paragraph capital spacing typography value. </returns>
        public bool GetSelectedParagraphTypographyCapitalSpacing()
        {
            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                return typology.CapitalSpacing;

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get case sensitive forms typography value of selected text paragraph or for current position </summary>
        /// <returns> Selected paragraph case sensitive forms typography value. </returns>
        public bool GetSelectedParagraphTypographyCaseSensitiveForms()
        {
            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                return typology.CaseSensitiveForms;

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get contextual alternates typography value of selected text paragraph or for current position </summary>
        /// <returns> Selected paragraph contextual alternates typography value. </returns>
        public bool GetSelectedParagraphTypographyContextualAlternates()
        {
            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                return typology.ContextualAlternates;

            return true;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get contextual ligatures typography value of selected text paragraph or for current position </summary>
        /// <returns> Selected paragraph contextual ligatures typography value. </returns>
        public bool GetSelectedParagraphTypographyContextualLigatures()
        {
            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                return typology.ContextualLigatures;

            return true;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get contextual swashes typography value of selected text paragraph or for current position </summary>
        /// <returns> Selected paragraph contextual swashes typography value. </returns>
        public int GetSelectedParagraphTypographyContextualSwashes()
        {
            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                return typology.ContextualSwashes;

            return 0;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get discretionary ligatures typography value of selected text paragraph or for current position </summary>
        /// <returns> Selected paragraph discretionary ligatures typography value. </returns>
        public bool GetSelectedParagraphTypographyDiscretionaryLigatures()
        {
            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                return typology.DiscretionaryLigatures;

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get east asian expert forms typography value of selected text paragraph or for current position </summary>
        /// <returns> Selected paragraph east asian expert forms typography value. </returns>
        public bool GetSelectedParagraphTypographyEastAsianExpertForms()
        {
            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                return typology.EastAsianExpertForms;

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get east asian language typography value of selected text paragraph or for current position </summary>
        /// <returns> Selected paragraph east asian language typography value. </returns>
        public FontEastAsianLanguage GetSelectedParagraphTypographyEastAsianLanguage()
        {
            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                return typology.EastAsianLanguage;

            return FontEastAsianLanguage.Normal;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get east asian widths typography value of selected text paragraph or for current position </summary>
        /// <returns> Selected paragraph east asian widths typography value. </returns>
        public FontEastAsianWidths GetSelectedParagraphTypographyEastAsianWidths()
        {
            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                return typology.EastAsianWidths;

            return FontEastAsianWidths.Normal;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get fraction typography value of selected text paragraph or for current position </summary>
        /// <returns> Selected paragraph fraction typography value. </returns>
        public FontFraction GetSelectedParagraphTypographyFraction()
        {
            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                return typology.Fraction;

            return FontFraction.Normal;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get historical forms typography value of selected text paragraph or for current position </summary>
        /// <returns> Selected paragraph historical forms typography value. </returns>
        public bool GetSelectedParagraphTypographyHistoricalForms()
        {
            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                return typology.HistoricalForms;

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get historical ligatures typography value of selected text paragraph or for current position </summary>
        /// <returns> Selected paragraph historical ligatures typography value. </returns>
        public bool GetSelectedParagraphTypographyHistoricalLigatures()
        {
            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                return typology.HistoricalLigatures;

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get kerning typography value of selected text paragraph or for current position </summary>
        /// <returns> Selected paragraph kerning typography value. </returns>
        public bool GetSelectedParagraphTypographyKerning()
        {
            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                return typology.Kerning;

            return true;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get mathematical greek typography value of selected text paragraph or for current position </summary>
        /// <returns> Selected paragraph mathematical greek typography value. </returns>
        public bool GetSelectedParagraphTypographyMathematicalGreek()
        {
            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                return typology.MathematicalGreek;

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get numeral alignment typography value of selected text paragraph or for current position </summary>
        /// <returns> Selected paragraph numeral alignment typography value. </returns>
        public FontNumeralAlignment GetSelectedParagraphTypographyNumeralAlignment()
        {
            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                return typology.NumeralAlignment;

            return FontNumeralAlignment.Normal;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get numeral style typography value of selected text paragraph or for current position </summary>
        /// <returns> Selected paragraph numeral style typography value. </returns>
        public FontNumeralStyle GetSelectedParagraphTypographyNumeralStyle()
        {
            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                return typology.NumeralStyle;

            return FontNumeralStyle.Normal;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get slashed zero typography value of selected text paragraph or for current position </summary>
        /// <returns> Selected paragraph slashed zero typography value. </returns>
        public bool GetSelectedParagraphTypographySlashedZero()
        {
            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                return typology.SlashedZero;

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get standard ligatures typography value of selected text paragraph or for current position </summary>
        /// <returns> Selected paragraph standard ligatures typography value. </returns>
        public bool GetSelectedParagraphTypographyStandardLigatures()
        {
            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                return typology.StandardLigatures;

            return true;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get standard swashes typography value of selected text paragraph or for current position </summary>
        /// <returns> Selected paragraph standard swashes typography value. </returns>
        public int GetSelectedParagraphTypographyStandardSwashes()
        {
            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                return typology.StandardSwashes;

            return 0;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get stylistic alternates typography value of selected text paragraph or for current position </summary>
        /// <returns> Selected paragraph stylistic alternates typography value. </returns>
        public int GetSelectedParagraphTypographyStylisticAlternates()
        {
            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                return typology.StylisticAlternates;

            return 0;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get stylistic set typography value of selected text paragraph or for current position </summary>
        /// <param name="setIndex"> Stylistic set index. </param>
        /// <returns> Selected paragraph stylistic set typography value. </returns>
        public bool GetSelectedParagraphTypographyStylisticSet(int setIndex)
        {
            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
            {
                switch (setIndex)
                {
                    case 1:
                        return typology.StylisticSet1;
                    case 2:
                        return typology.StylisticSet2;
                    case 3:
                        return typology.StylisticSet3;
                    case 4:
                        return typology.StylisticSet4;
                    case 5:
                        return typology.StylisticSet5;
                    case 6:
                        return typology.StylisticSet6;
                    case 7:
                        return typology.StylisticSet7;
                    case 8:
                        return typology.StylisticSet8;
                    case 9:
                        return typology.StylisticSet9;
                    case 10:
                        return typology.StylisticSet10;
                    case 11:
                        return typology.StylisticSet11;
                    case 12:
                        return typology.StylisticSet12;
                    case 13:
                        return typology.StylisticSet13;
                    case 14:
                        return typology.StylisticSet14;
                    case 15:
                        return typology.StylisticSet15;
                    case 16:
                        return typology.StylisticSet16;
                    case 17:
                        return typology.StylisticSet17;
                    case 18:
                        return typology.StylisticSet18;
                    case 19:
                        return typology.StylisticSet19;
                    case 20:
                        return typology.StylisticSet20;
                    default:
                        return false;
                }
            }

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get variants typography value of selected text paragraph or for current position </summary>
        /// <returns> Selected paragraph variants typography value. </returns>
        public FontVariants GetSelectedParagraphTypographyVariants()
        {
            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                return typology.Variants;

            return FontVariants.Normal;
        }

        #endregion SELECTED PARAGRAPH GET PROPERTIES METHODS

        #region SELECTED PARAGRAPH SET PROPERTIES METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Set selected paragraph properties. </summary>
        /// <param name="paragraphProperties"> EasyRichParagraphProperties object. </param>
        public void SetSelectedParagraphProperties(EasyRichParagraphProperties paragraphProperties)
        {
            if (paragraphProperties != null)
            {
                SetSelectedParagraphBackground(paragraphProperties.Background);
                SettSelectedParagraphBorderBrush(paragraphProperties.BorderBrush);
                SetSelectedParagraphBorderThickness(paragraphProperties.BorderThickness);
                SetSelectedParagraphBreakColumnBefore(paragraphProperties.BreakColumnBefore);
                SetSelectedParagraphBreakPageBefore(paragraphProperties.BreakPageBefore);
                SetSelectedParagraphFlowDirection(paragraphProperties.FlowDirection);
                SetSelectedParagraphForeground(paragraphProperties.Foreground);
                SetSelectedParagraphIsHyphenationEnabled(paragraphProperties.IsHyphenationEnabled);
                SetSelectedParagraphKeepTogether(paragraphProperties.KeepTogether);
                SetSelectedParagraphKeepWithNext(paragraphProperties.KeepWithNext);
                SetSelectedParagraphLineHeight(paragraphProperties.LineHeight);
                SetSelectedParagraphLineStackingStrategy(paragraphProperties.LineStackingStrategy);
                SetSelectedParagraphMargin(paragraphProperties.Margin);
                SetSelectedParagraphPadding(paragraphProperties.Padding);
                SetSelectedParagraphTextIndent(paragraphProperties.TextIndent);

                //  Font
                SetSelectedParagraphFontFamily(paragraphProperties.FontFamily);
                SetSelectedParagraphFontSize(paragraphProperties.FontSize);
                SetSelectedParagraphFontStyle(paragraphProperties.FontStyle);
                SetSelectedParagraphFontWeight(paragraphProperties.FontWeight);
                SetSelectedParagraphTextAlignment(paragraphProperties.TextAlignment);

                //  Text decorations
                SetSelectedParagraphBaseline(paragraphProperties.TextDecorationBaseline);
                SetSelectedParagraphTextOverLine(paragraphProperties.TextDecorationOverLine);
                SetSelectedParagraphTextStrikethrough(paragraphProperties.TextDecorationStrikethrough);
                SetSelectedParagraphTextUnderline(paragraphProperties.TextDecorationUnderline);

                //  Typography
                SetSelectedParagraphTypographyAnnotationAlternates(paragraphProperties.TypographyAnnotationAlternates);
                SetSelectedParagraphTypographyCapitals(paragraphProperties.TypographyCapitals);
                SetSelectedParagraphTypographyCapitalSpacing(paragraphProperties.TypographyCapitalSpacing);
                SetSelectedParagraphTypographyCaseSensitiveForms(paragraphProperties.TypographyCaseSensitiveForms);
                SetSelectedParagraphTypographyContextualAlternates(paragraphProperties.TypographyContextualAlternates);
                SetSelectedParagraphTypographyContextualLigatures(paragraphProperties.TypographyContextualLigatures);
                SetSelectedParagraphTypographyContextualSwashes(paragraphProperties.TypographyContextualSwashes);
                SetSelectedParagraphTypographyDiscretionaryLigatures(paragraphProperties.TypographyDiscretionaryLigatures);
                SetSelectedParagraphTypographyEastAsianExpertForms(paragraphProperties.TypographyEastAsianExpertForms);
                SetSelectedParagraphTypographyEastAsianLanguage(paragraphProperties.TypographyEastAsianLanguage);
                SetSelectedParagraphTypographyEastAsianWidths(paragraphProperties.TypographyEastAsianWidths);
                SetSelectedParagraphTypographyFraction(paragraphProperties.TypographyFraction);
                SetSelectedParagraphTypographyHistoricalForms(paragraphProperties.TypographyHistoricalForms);
                SetSelectedParagraphTypographyHistoricalLigatures(paragraphProperties.TypographyHistoricalLigatures);
                SetSelectedParagraphTypographyKerning(paragraphProperties.TypographyKerning);
                SetSelectedParagraphTypographyMathematicalGreek(paragraphProperties.TypographyMathematicalGreek);
                SetSelectedParagraphTypographyNumeralAlignment(paragraphProperties.TypographyNumeralAlignment);
                SetSelectedParagraphTypographyNumeralStyle(paragraphProperties.TypographyNumeralStyle);
                SetSelectedParagraphTypographySlashedZero(paragraphProperties.TypographySlashedZero);
                SetSelectedParagraphTypographyStandardLigatures(paragraphProperties.TypographyStandardLigatures);
                SetSelectedParagraphTypographyStandardSwashes(paragraphProperties.TypographyStandardSwashes);
                SetSelectedParagraphTypographyStylisticAlternates(paragraphProperties.TypographyStylisticAlternates);
                SetSelectedParagraphTypographyStylisticSet(1, paragraphProperties.TypographyStylisticSet1);
                SetSelectedParagraphTypographyStylisticSet(2, paragraphProperties.TypographyStylisticSet2);
                SetSelectedParagraphTypographyStylisticSet(3, paragraphProperties.TypographyStylisticSet3);
                SetSelectedParagraphTypographyStylisticSet(4, paragraphProperties.TypographyStylisticSet4);
                SetSelectedParagraphTypographyStylisticSet(5, paragraphProperties.TypographyStylisticSet5);
                SetSelectedParagraphTypographyStylisticSet(6, paragraphProperties.TypographyStylisticSet6);
                SetSelectedParagraphTypographyStylisticSet(7, paragraphProperties.TypographyStylisticSet7);
                SetSelectedParagraphTypographyStylisticSet(8, paragraphProperties.TypographyStylisticSet8);
                SetSelectedParagraphTypographyStylisticSet(9, paragraphProperties.TypographyStylisticSet9);
                SetSelectedParagraphTypographyStylisticSet(10, paragraphProperties.TypographyStylisticSet10);
                SetSelectedParagraphTypographyStylisticSet(11, paragraphProperties.TypographyStylisticSet11);
                SetSelectedParagraphTypographyStylisticSet(12, paragraphProperties.TypographyStylisticSet12);
                SetSelectedParagraphTypographyStylisticSet(13, paragraphProperties.TypographyStylisticSet13);
                SetSelectedParagraphTypographyStylisticSet(14, paragraphProperties.TypographyStylisticSet14);
                SetSelectedParagraphTypographyStylisticSet(15, paragraphProperties.TypographyStylisticSet15);
                SetSelectedParagraphTypographyStylisticSet(16, paragraphProperties.TypographyStylisticSet16);
                SetSelectedParagraphTypographyStylisticSet(17, paragraphProperties.TypographyStylisticSet17);
                SetSelectedParagraphTypographyStylisticSet(18, paragraphProperties.TypographyStylisticSet18);
                SetSelectedParagraphTypographyStylisticSet(19, paragraphProperties.TypographyStylisticSet19);
                SetSelectedParagraphTypographyStylisticSet(20, paragraphProperties.TypographyStylisticSet20);
                SetSelectedParagraphTypographyVariants(paragraphProperties.TypographyVariants);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set background color brush of selected text paragraph or for current position. </summary>
        /// <param name="colorBrush"> Background color. </param>
        public void SetSelectedParagraphBackground(Brush colorBrush)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                paragraph.Background = colorBrush;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set border brush of selected text paragraph or for current position. </summary>
        /// <param name="colorBrush"> Border color. </param>
        public void SettSelectedParagraphBorderBrush(Brush colorBrush)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                paragraph.Background = colorBrush;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set border thickness of selected text paragraph or for current position. </summary>
        /// <param name="thickness"> Border thickness. </param>
        public void SetSelectedParagraphBorderThickness(Thickness thickness)
        {
            if (thickness != null)
            {
                if (!_textSelected)
                    InitForNoSelectionUpdate();

                var paragraph = GetSelectedTextParagraph();

                if (paragraph != null)
                    paragraph.BorderThickness = thickness;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set break column before value of selected text paragraph or for current position. </summary>
        /// <param name="breakColumnBefore"> Break column before value. </param>
        public void SetSelectedParagraphBreakColumnBefore(bool breakColumnBefore)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                paragraph.BreakColumnBefore = breakColumnBefore;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set break page before value of selected text paragraph or for current position. </summary>
        /// <param name="breakPageBefore"> Break page before value. </param>
        public void SetSelectedParagraphBreakPageBefore(bool breakPageBefore)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                paragraph.BreakColumnBefore = breakPageBefore;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set flow direction value of selected text paragraph or for current position. </summary>
        /// <param name="flowDirection"> Flow direction value. </param>
        public void SetSelectedParagraphFlowDirection(FlowDirection flowDirection)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                paragraph.FlowDirection = flowDirection;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set foreground color brush of selected text paragraph or for current position. </summary
        /// <param name="colorBrush"> Foreground color. </param>
        public void SetSelectedParagraphForeground(Brush colorBrush)
        {
            if (colorBrush != null)
            {
                if (!_textSelected)
                    InitForNoSelectionUpdate();

                var paragraph = GetSelectedTextParagraph();

                if (paragraph != null)
                    paragraph.Foreground = colorBrush;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set is hyphenation enabled value (auto words split) of selected text paragraph or for current position. </summary>
        /// <param name="isHyphenationEnabled"> Is hyphenation enabled value. </param>
        public void SetSelectedParagraphIsHyphenationEnabled(bool isHyphenationEnabled)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                paragraph.IsHyphenationEnabled = isHyphenationEnabled;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set keep together value (No pages or column breaks) of selected text paragraph or for current position. </summary>
        /// <param name="keepTogether"> eep together value. </param>
        public void SetSelectedParagraphKeepTogether(bool keepTogether)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                paragraph.KeepTogether = keepTogether;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set keep with next value (Keep with next paragraph) of selected text paragraph or for current position. </summary>
        /// <param name="keepWithNext"> eep with next value. </param>
        public void SetSelectedParagraphKeepWithNext(bool keepWithNext)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                paragraph.KeepWithNext = keepWithNext;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set line height value of selected text paragraph or for current position. </summary>
        /// <param name="lineHeight"> Line height value. </param>
        public void SetSelectedParagraphLineHeight(double lineHeight)
        {
            if (lineHeight > -1)
            {
                if (!_textSelected)
                    InitForNoSelectionUpdate();

                var paragraph = GetSelectedTextParagraph();

                if (paragraph != null)
                    paragraph.LineHeight = lineHeight;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set line stacking strategy value of selected text paragraph or for current position. </summary>
        /// <param name="lineStackingStrategy"> Line stacking strategy value. </param>
        public void SetSelectedParagraphLineStackingStrategy(LineStackingStrategy lineStackingStrategy)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                paragraph.LineStackingStrategy = lineStackingStrategy;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set margin value of selected text paragraph or for current position. </summary>
        /// <param name="margin"> Margin value. </param>
        public void SetSelectedParagraphMargin(Thickness margin)
        {
            if (margin != null)
            {
                if (!_textSelected)
                    InitForNoSelectionUpdate();

                var paragraph = GetSelectedTextParagraph();

                if (paragraph != null)
                    paragraph.Margin = margin;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set padding value of selected text paragraph or for current position. </summary>
        /// <param name="padding"> Padding value. </param>
        public void SetSelectedParagraphPadding(Thickness padding)
        {
            if (padding != null)
            {
                if (!_textSelected)
                    InitForNoSelectionUpdate();

                var paragraph = GetSelectedTextParagraph();

                if (paragraph != null)
                    paragraph.Padding = padding;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set text indent value of selected text paragraph or for current position. </summary>
        /// <param name="textIndent"> Text indent value. </param>
        public void SetSelectedParagraphTextIndent(double textIndent)
        {
            if (textIndent > -1)
            {
                if (!_textSelected)
                    InitForNoSelectionUpdate();

                var paragraph = GetSelectedTextParagraph();

                if (paragraph != null)
                    paragraph.TextIndent = textIndent;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set font family of selected text paragraph or for current position. </summary>
        /// <param name="fontFamily"> Text font family. </param>
        public void SetSelectedParagraphFontFamily(FontFamily fontFamily)
        {
            if (fontFamily != null)
            {
                if (!_textSelected)
                    InitForNoSelectionUpdate();

                var paragraph = GetSelectedTextParagraph();

                if (paragraph != null)
                    paragraph.FontFamily = fontFamily;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set font size of selected text paragraph or for current position. </summary>
        /// <param name="fontSize"> Text font size. </param>
        public void SetSelectedParagraphFontSize(double fontSize)
        {
            if (fontSize > -1)
            {
                if (!_textSelected)
                    InitForNoSelectionUpdate();

                var paragraph = GetSelectedTextParagraph();

                if (paragraph != null)
                    paragraph.FontSize = fontSize;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set font style of selected text paragraph or for current position. </summary>
        /// <param name="fontStyle"> Text font style. </param>
        public void SetSelectedParagraphFontStyle(FontStyle fontStyle)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                paragraph.FontStyle = fontStyle;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set font weight of selected text paragraph or for current position. </summary>
        /// <param name="fontWeight"> Text font weight. </param>
        public void SetSelectedParagraphFontWeight(FontWeight fontWeight)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                paragraph.FontWeight = fontWeight;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set alignment of selected text paragraph or for current position. </summary>
        /// <param name="textAlignment"> Text alignment. </param>
        public void SetSelectedParagraphTextAlignment(TextAlignment textAlignment)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
                paragraph.TextAlignment = textAlignment;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set text baseline decoration of current selected text paragraph or for current position. </summary>
        /// <param name="baseline"> Text baseline decoration enabled. </param>
        public void SetSelectedParagraphBaseline(bool baseline)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
            {
                if (baseline)
                    TextDecorationsHelper.AddDecoration(paragraph.TextDecorations, TextDecorationLocation.Baseline);
                else
                    TextDecorationsHelper.RemoveDecoration(paragraph.TextDecorations, TextDecorationLocation.Baseline);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set text overline decoration of current selected text paragraph or for current position. </summary>
        /// <param name="overLine"> Text overline decoration enabled. </param>
        public void SetSelectedParagraphTextOverLine(bool overLine)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
            {
                if (overLine)
                    TextDecorationsHelper.AddDecoration(paragraph.TextDecorations, TextDecorationLocation.OverLine);
                else
                    TextDecorationsHelper.RemoveDecoration(paragraph.TextDecorations, TextDecorationLocation.OverLine);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set text strikethrough decoration of current selected text paragraph or for current position. </summary>
        /// <param name="strikethrough"> Text strikethrough decoration enabled. </param>
        public void SetSelectedParagraphTextStrikethrough(bool strikethrough)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
            {
                if (strikethrough)
                    TextDecorationsHelper.AddDecoration(paragraph.TextDecorations, TextDecorationLocation.Strikethrough);
                else
                    TextDecorationsHelper.RemoveDecoration(paragraph.TextDecorations, TextDecorationLocation.Strikethrough);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set text underline decoration of current selected text paragraph or for current position. </summary>
        /// <param name="underline"> Text underline decoration enabled. </param>
        public void SetSelectedParagraphTextUnderline(bool underline)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var paragraph = GetSelectedTextParagraph();

            if (paragraph != null)
            {
                if (underline)
                    TextDecorationsHelper.AddDecoration(paragraph.TextDecorations, TextDecorationLocation.Underline);
                else
                    TextDecorationsHelper.RemoveDecoration(paragraph.TextDecorations, TextDecorationLocation.Underline);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set annotation alternates typography value of selected text paragraph or for current position </summary>
        /// <param name="annotationAlternates"> Annotation alternates typography value. </param>
        public void SetSelectedParagraphTypographyAnnotationAlternates(int annotationAlternates)
        {
            if (annotationAlternates > -1)
            {
                if (!_textSelected)
                    InitForNoSelectionUpdate();

                var typology = GetSelectedTextParagraphTypography();

                if (typology != null)
                    typology.AnnotationAlternates = annotationAlternates;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set capitals typography value of selected text paragraph or for current position </summary>
        /// <param name="fontCapitals"> Font capitals typography value. </param>
        public void SetSelectedParagraphTypographyCapitals(FontCapitals fontCapitals)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                typology.Capitals = fontCapitals;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set capital spacing typography value of selected text paragraph or for current position </summary>
        /// <param name="capitalSpacing"> Capital spacing typography value. </param>
        public void SetSelectedParagraphTypographyCapitalSpacing(bool capitalSpacing)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                typology.CapitalSpacing = capitalSpacing;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set case sensitive forms typography value of selected text paragraph or for current position </summary>
        /// <param name="caseSensitiveForms"> Case sensitive forms typography value. </param>
        public void SetSelectedParagraphTypographyCaseSensitiveForms(bool caseSensitiveForms)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                typology.CaseSensitiveForms = caseSensitiveForms;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set contextual alternates typography value of selected text paragraph or for current position </summary>
        /// <param name="contextualAlternates"> Contextual alternates typography value. </param>
        public void SetSelectedParagraphTypographyContextualAlternates(bool contextualAlternates)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                typology.ContextualAlternates = contextualAlternates;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set contextual ligatures typography value of selected text paragraph or for current position </summary>
        /// <param name="contextualLigatures"> Contextual ligatures typography value. </param>
        public void SetSelectedParagraphTypographyContextualLigatures(bool contextualLigatures)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                typology.ContextualLigatures = contextualLigatures;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set contextual swashes typography value of selected text paragraph or for current position </summary>
        /// <param name="contextualSwashes"> Contextual swashes typography value. </param>
        public void SetSelectedParagraphTypographyContextualSwashes(int contextualSwashes)
        {
            if (contextualSwashes > -1)
            {
                if (!_textSelected)
                    InitForNoSelectionUpdate();

                var typology = GetSelectedTextParagraphTypography();

                if (typology != null)
                    typology.ContextualSwashes = contextualSwashes;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set discretionary ligatures typography value of selected text paragraph or for current position </summary>
        /// <param name="discretionaryLigatures"> Discretionary ligatures typography value. </param>
        public void SetSelectedParagraphTypographyDiscretionaryLigatures(bool discretionaryLigatures)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                typology.DiscretionaryLigatures = discretionaryLigatures;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set east asian expert forms typography value of selected text paragraph or for current position </summary>
        /// <param name="eastAsianExpertForms"> East asian expert forms typography value. </param>
        public void SetSelectedParagraphTypographyEastAsianExpertForms(bool eastAsianExpertForms)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                typology.EastAsianExpertForms = eastAsianExpertForms;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set east asian language typography value of selected text paragraph or for current position </summary>
        /// <param name="fontEastAsianLanguage"> Font east asian language typography value. </param>
        public void SetSelectedParagraphTypographyEastAsianLanguage(FontEastAsianLanguage fontEastAsianLanguage)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                typology.EastAsianLanguage = fontEastAsianLanguage;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set east asian widths typography value of selected text paragraph or for current position </summary>
        /// <param name="fontEastAsianWidths"> Font east asian widths typography value. </param>
        public void SetSelectedParagraphTypographyEastAsianWidths(FontEastAsianWidths fontEastAsianWidths)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                typology.EastAsianWidths = fontEastAsianWidths;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set fraction typography value of selected text paragraph or for current position </summary>
        /// <param name="fontFraction"> Font fraction typography value. </param>
        public void SetSelectedParagraphTypographyFraction(FontFraction fontFraction)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                typology.Fraction = fontFraction;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set historical forms typography value of selected text paragraph or for current position </summary>
        /// <param name="historicalForms"> Historical forms typography value. </param>
        public void SetSelectedParagraphTypographyHistoricalForms(bool historicalForms)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                typology.HistoricalForms = historicalForms;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set historical ligatures typography value of selected text paragraph or for current position </summary>
        /// <param name="historicalLigatures"> Historical ligatures typography value. </param>
        public void SetSelectedParagraphTypographyHistoricalLigatures(bool historicalLigatures)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                typology.HistoricalLigatures = historicalLigatures;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set kerning typography value of selected text paragraph or for current position </summary>
        /// <param name="kerning"> Kerning typography value. </param>
        public void SetSelectedParagraphTypographyKerning(bool kerning)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                typology.Kerning = kerning;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set mathematical greek typography value of selected text paragraph or for current position </summary>
        /// <param name="mathematicalGreek"> Mathematical greek typography value. </param>
        public void SetSelectedParagraphTypographyMathematicalGreek(bool mathematicalGreek)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                typology.MathematicalGreek = mathematicalGreek;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set numeral alignment typography value of selected text paragraph or for current position </summary>
        /// <param name="fontNumeralAlignment"> Font numeral alignment typography value. </param>
        public void SetSelectedParagraphTypographyNumeralAlignment(FontNumeralAlignment fontNumeralAlignment)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                typology.NumeralAlignment = fontNumeralAlignment;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set numeral style typography value of selected text paragraph or for current position </summary>
        /// <param name="fontNumeralStyle"> Font numeral style typography value. </param>
        public void SetSelectedParagraphTypographyNumeralStyle(FontNumeralStyle fontNumeralStyle)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                typology.NumeralStyle = fontNumeralStyle;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set slashed zero typography value of selected text paragraph or for current position </summary>
        /// <param name="slashedZero"> Slashed zero typography value. </param>
        public void SetSelectedParagraphTypographySlashedZero(bool slashedZero)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                typology.SlashedZero = slashedZero;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set standard ligatures typography value of selected text paragraph or for current position </summary>
        /// <param name="standardLigatures"> Standard ligatures typography value. </param>
        public void SetSelectedParagraphTypographyStandardLigatures(bool standardLigatures)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                typology.StandardLigatures = standardLigatures;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set standard swashes typography value of selected text paragraph or for current position </summary>
        /// <param name="standardSwashes"> Standard swashes typography value. </param>
        public void SetSelectedParagraphTypographyStandardSwashes(int standardSwashes)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                typology.StandardSwashes = standardSwashes;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set stylistic alternates typography value of selected text paragraph or for current position </summary>
        /// <param name="stylisticAlternates"> Stylistic alternates typography value. </param>
        public void SetSelectedParagraphTypographyStylisticAlternates(int stylisticAlternates)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                typology.StylisticAlternates = stylisticAlternates;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set stylistic set typography value of selected text paragraph or for current position </summary>
        /// <param name="setIndex"> Stylistic set index. </param>
        /// <param name="value"> Stylistic set value. </param>
        public void SetSelectedParagraphTypographyStylisticSet(int setIndex, bool value)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
            {
                switch (setIndex)
                {
                    case 1:
                        typology.StylisticSet1 = value;
                        break;
                    case 2:
                        typology.StylisticSet2 = value;
                        break;
                    case 3:
                        typology.StylisticSet3 = value;
                        break;
                    case 4:
                        typology.StylisticSet4 = value;
                        break;
                    case 5:
                        typology.StylisticSet5 = value;
                        break;
                    case 6:
                        typology.StylisticSet6 = value;
                        break;
                    case 7:
                        typology.StylisticSet7 = value;
                        break;
                    case 8:
                        typology.StylisticSet8 = value;
                        break;
                    case 9:
                        typology.StylisticSet9 = value;
                        break;
                    case 10:
                        typology.StylisticSet10 = value;
                        break;
                    case 11:
                        typology.StylisticSet11 = value;
                        break;
                    case 12:
                        typology.StylisticSet12 = value;
                        break;
                    case 13:
                        typology.StylisticSet13 = value;
                        break;
                    case 14:
                        typology.StylisticSet14 = value;
                        break;
                    case 15:
                        typology.StylisticSet15 = value;
                        break;
                    case 16:
                        typology.StylisticSet16 = value;
                        break;
                    case 17:
                        typology.StylisticSet17 = value;
                        break;
                    case 18:
                        typology.StylisticSet18 = value;
                        break;
                    case 19:
                        typology.StylisticSet19 = value;
                        break;
                    case 20:
                        typology.StylisticSet20 = value;
                        break;
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set variants typography value of selected text paragraph or for current position </summary>
        /// <param name="fontVariants"> Font variants typography value. </param>
        public void SetSelectedParagraphTypographyVariants(FontVariants fontVariants)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var typology = GetSelectedTextParagraphTypography();

            if (typology != null)
                typology.Variants = fontVariants;
        }

        #endregion SELECTED PARAGRAPH SET PROPERTIES METHODS

        #region SELECTED TEXT GET PROPERTIES METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Get selected text formatting. </summary>
        /// <returns> EasyTichTextFormatting object. </returns>
        public EasyRichTextFormatting GetSelectedTextFormatting()
        {
            return new EasyRichTextFormatting()
            {
                FontBackground = GetSelectedTextFontBackground(),
                FontColor = GetSelectedTextFontColor(),
                FontSize = GetSelectedTextFontSize(),
                FontFamily = GetSelectedTextFontFamily(),
                FontStyle = GetSelectedTextFontStyle(),
                FontWeight = GetSelectedTextFontWeight(),
                TextAlignment = GetSelectedTextAlignment(),

                //  Text decorations
                TextDecorationBaseline = GetSelectedTextBaseline(),
                TextDecorationOverLine = GetSelectedTextOverLine(),
                TextDecorationStrikethrough = GetSelectedTextStrikethrough(),
                TextDecorationUnderline = GetSelectedTextUnderline(),
            };
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get background color brush of selected text or for current position. </summary>
        /// <returns> Selected text font background color. </returns>
        public Brush GetSelectedTextFontBackground()
        {
            var property = TextElement.BackgroundProperty;
            object propertyValue = SelectedText.GetPropertyValue(property);

            if (IsPropertySet(propertyValue))
                return (Brush)propertyValue;

            return null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get foreground color brush of selected text or for current position. </summary>
        /// <returns> Selected text font color. </returns>
        public Brush GetSelectedTextFontColor()
        {
            var property = TextElement.ForegroundProperty;
            object propertyValue = SelectedText.GetPropertyValue(property);

            if (IsPropertySet(propertyValue))
                return (Brush)propertyValue;

            return new SolidColorBrush(System.Windows.Media.Colors.Black);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get font family of selected text or for current position. </summary>
        /// <returns> Selected text font family. </returns>
        public FontFamily GetSelectedTextFontFamily()
        {
            var property = TextElement.FontFamilyProperty;
            object propertyValue = SelectedText.GetPropertyValue(property);

            if (IsPropertySet(propertyValue))
                return (FontFamily)propertyValue;

            return new FontFamily("Segoe UI");
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get font size of selected text or for current position. </summary>
        /// <returns> Selected text font size. </returns>
        public double GetSelectedTextFontSize()
        {
            var property = TextElement.FontSizeProperty;
            object propertyValue = SelectedText.GetPropertyValue(property);

            if (IsPropertySet(propertyValue))
                return (double)propertyValue;

            return 12d;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get font style of selected text or for current position. </summary>
        /// <returns> Selected text font style. </returns>
        public FontStyle GetSelectedTextFontStyle()
        {
            var property = TextElement.FontStyleProperty;
            object propertyValue = RichTextBox.Selection.GetPropertyValue(property);

            if (IsPropertySet(propertyValue))
                return (FontStyle)propertyValue;

            return FontStyles.Normal;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get font weight of selected text or for current position. </summary>
        /// <returns> Selected text font weight. </returns>
        public FontWeight GetSelectedTextFontWeight()
        {
            var property = TextElement.FontWeightProperty;
            object propertyValue = RichTextBox.Selection.GetPropertyValue(property);

            if (IsPropertySet(propertyValue))
                return (FontWeight)propertyValue;

            return FontWeights.Normal;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get alignment of selected text or for current position. </summary>
        /// <returns> Selected text alignment. </returns>
        public TextAlignment GetSelectedTextAlignment()
        {
            var property = Paragraph.TextAlignmentProperty;
            object propertyValue = RichTextBox.Selection.GetPropertyValue(property);

            if (IsPropertySet(propertyValue))
                return (TextAlignment)propertyValue;

            return TextAlignment.Left;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get text baseline decoration of current selected text or for current position. </summary>
        /// <returns> Selected text baseline decoration enabled. </returns>
        public bool GetSelectedTextBaseline()
        {
            return TextDecorationsHelper.HasDecroation(SelectedText, TextDecorationLocation.Baseline);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get text overline decoration of current selected text or for current position. </summary>
        /// <returns> Selected text overline decoration enabled. </returns>
        public bool GetSelectedTextOverLine()
        {
            return TextDecorationsHelper.HasDecroation(SelectedText, TextDecorationLocation.OverLine);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get text strikethrough decoration of current selected text or for current position. </summary>
        /// <returns> Selected text strikethrough decoration enabled. </returns>
        public bool GetSelectedTextStrikethrough()
        {
            return TextDecorationsHelper.HasDecroation(SelectedText, TextDecorationLocation.Strikethrough);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get text underline decoration of current selected text or for current position. </summary>
        /// <returns> Selected text underline decoration enabled. </returns>
        public bool GetSelectedTextUnderline()
        {
            return TextDecorationsHelper.HasDecroation(SelectedText, TextDecorationLocation.Underline);
        }

        #endregion SELECTED TEXT GET PROPERTIES METHODS

        #region SELECTED TEXT SET PROPERTIES METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Set selected text formatting. </summary>
        /// <param name="formatting"> EasyTichTextFormatting object. </param>
        public void SetSelectedTextFormatting(EasyRichTextFormatting formatting)
        {
            if (formatting != null)
            {
                SetSelectedTextFontBackground(formatting.FontBackground);
                SetSelectedTextFontColor(formatting.FontColor);
                SetSelectedTextFontFamily(formatting.FontFamily);
                SetSelectedTextFontSize(formatting.FontSize);
                SetSelectedTextFontStyle(formatting.FontStyle);
                SetSelectedTextFontWeight(formatting.FontWeight);
                SetSelectedTextAlignment(formatting.TextAlignment);
                SetSelectedTextBaseline(formatting.TextDecorationBaseline);
                SetSelectedTextOverLine(formatting.TextDecorationOverLine);
                SetSelectedTextStrikethrough(formatting.TextDecorationStrikethrough);
                SetSelectedTextUnderline(formatting.TextDecorationUnderline);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set background color brush of selected text or for current position. </summary>
        /// <param name="colorBrush"> Background color brush. </param>
        public void SetSelectedTextFontBackground(Brush colorBrush)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var property = TextElement.BackgroundProperty;
            var selectedText = SelectedText;

            if (selectedText != null)
                selectedText.ApplyPropertyValue(property, colorBrush);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set foreground color brush of selected text or for current position. </summary>
        /// <param name="colorBrush"> Foreground color brush. </param>
        public void SetSelectedTextFontColor(Brush colorBrush)
        {
            if (colorBrush != null)
            {
                if (!_textSelected)
                    InitForNoSelectionUpdate();

                var property = TextElement.ForegroundProperty;
                var selectedText = SelectedText;

                if (selectedText != null)
                    selectedText.ApplyPropertyValue(property, colorBrush);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set font family to selected text or for current position. </summary>
        /// <param name="fontFamily"> Font family. </param>
        public void SetSelectedTextFontFamily(FontFamily fontFamily)
        {
            if (fontFamily != null)
            {
                if (!_textSelected)
                    InitForNoSelectionUpdate();

                var property = TextElement.FontFamilyProperty;
                var selectedText = SelectedText;

                if (selectedText != null)
                    selectedText.ApplyPropertyValue(property, fontFamily);

                RichTextBox.Focus();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set font size to selected text or for current position. </summary>
        /// <param name="fontSize"> Font size. </param>
        public void SetSelectedTextFontSize(double fontSize)
        {
            if (fontSize > 0)
            {
                if (!_textSelected)
                    InitForNoSelectionUpdate();

                var property = TextElement.FontSizeProperty;
                var selectedText = SelectedText;

                if (selectedText != null)
                    selectedText.ApplyPropertyValue(property, fontSize);

                RichTextBox.Focus();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set font style to selected text or for current position. </summary>
        /// <param name="fontStyle"> Font style. </param>
        public void SetSelectedTextFontStyle(FontStyle fontStyle)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var property = TextElement.FontStyleProperty;
            var selectedText = SelectedText;

            if (selectedText != null)
                selectedText.ApplyPropertyValue(property, fontStyle);

            RichTextBox.Focus();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set font weight to selected text or for current position. </summary>
        /// <param name="fontWeight"> Font weight. </param>
        public void SetSelectedTextFontWeight(FontWeight fontWeight)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var property = TextElement.FontWeightProperty;
            var selectedText = SelectedText;

            if (selectedText != null)
                selectedText.ApplyPropertyValue(property, fontWeight);

            RichTextBox.Focus();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set alignment of selected text or for current position. </summary>
        /// <param name="textAlignment"> Text alignment. </param>
        public void SetSelectedTextAlignment(TextAlignment textAlignment)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var property = Paragraph.TextAlignmentProperty;
            var selectedText = SelectedText;

            if (selectedText != null)
                selectedText.ApplyPropertyValue(property, textAlignment);

            RichTextBox.Focus();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set baseline text decoration to selected text or for current position. </summary>
        /// <param name="baseline"> Baseline text decoration enabled. </param>
        public void SetSelectedTextBaseline(bool baseline)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            if (baseline)
                TextDecorationsHelper.AddDecoration(SelectedText, TextDecorationLocation.Baseline);
            else
                TextDecorationsHelper.RemoveDecoration(SelectedText, TextDecorationLocation.Baseline);

            RichTextBox.Focus();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set overLine text decoration to selected text or for current position. </summary>
        /// <param name="overLine"> OverLine text decoration enabled. </param>
        public void SetSelectedTextOverLine(bool overLine)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            if (overLine)
                TextDecorationsHelper.AddDecoration(SelectedText, TextDecorationLocation.OverLine);
            else
                TextDecorationsHelper.RemoveDecoration(SelectedText, TextDecorationLocation.OverLine);

            RichTextBox.Focus();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set strikethrough text decoration to selected text or for current position. </summary>
        /// <param name="strike"> Strikethrough text decoration enabled. </param>
        public void SetSelectedTextStrikethrough(bool strike)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            if (strike)
                TextDecorationsHelper.AddDecoration(SelectedText, TextDecorationLocation.Strikethrough);
            else
                TextDecorationsHelper.RemoveDecoration(SelectedText, TextDecorationLocation.Strikethrough);

            RichTextBox.Focus();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set underline text decoration to selected text or for current position. </summary>
        /// <param name="underline"> Underline text decoration enabled. </param>
        public void SetSelectedTextUnderline(bool underline)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            if (underline)
                TextDecorationsHelper.AddDecoration(SelectedText, TextDecorationLocation.Underline);
            else
                TextDecorationsHelper.RemoveDecoration(SelectedText, TextDecorationLocation.Underline);

            RichTextBox.Focus();
        }

        #endregion SELECTED TEXT SET PROPERTIES METHODS

        #region SETUP METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Setup with RichTextBox component. </summary>
        /// <param name="richTextBox"> RichTextBox component. </param>
        internal void Setup(RichTextBox richTextBox)
        {
            if (RichTextBox != null)
            {
                RichTextBox.GotFocus -= OnRichTextBoxGotFocus;
                RichTextBox.LostFocus -= OnRichTextBoxLostFocus;
                RichTextBox.SelectionChanged -= OnRichTextBoxSelectionChanged;
            }

            RichTextBox = richTextBox;
            RichTextBox.GotFocus += OnRichTextBoxGotFocus;
            RichTextBox.LostFocus += OnRichTextBoxLostFocus;
            RichTextBox.SelectionChanged += OnRichTextBoxSelectionChanged;
        }

        #endregion SETUP METHODS

        #region UTILITY METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Get selected text paragraph. </summary>
        /// <returns> Selected text paragraph. </returns>
        protected Paragraph GetSelectedTextParagraph()
        {
            return SelectedText.Start.Paragraph;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get selected text paragraph typography. </summary>
        /// <returns> Selected text paragraph typography. </returns>
        protected Typography GetSelectedTextParagraphTypography()
        {
            return SelectedText.Start.Paragraph?.Typography;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get text selection from current position. </summary>
        /// <param name="caretPosition"> Caret position. </param>
        /// <param name="backward"> Offset backward. </param>
        /// <param name="forward"> Offset forward. </param>
        /// <returns> Selected text range. </returns>
        protected TextRange GetTextSelectionFromCurrentPosition(TextPointer caretPosition, int backward, int forward)
        {
            TextPointer startPosition = caretPosition.GetPositionAtOffset(backward, LogicalDirection.Backward);
            TextPointer endPosition = caretPosition.GetPositionAtOffset(forward, LogicalDirection.Forward);

            if (startPosition != null && endPosition != null)
            {
                TextRange selectedText = new TextRange(startPosition, endPosition);

                if (selectedText != null && !selectedText.IsEmpty)
                    return selectedText;
            }

            return null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Check if dependency property has set value, is not null or unset. </summary>
        /// <param name="property"> Dependency property. </param>
        /// <returns> True = value is set, False - otherwise. </returns>
        protected bool IsPropertySet(object property)
        {
            return property != null && property != DependencyProperty.UnsetValue;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Prepare RichTextBox for font update when text is no selected. </summary>
        private void InitForNoSelectionUpdate()
        {
            if (!_textSelected && !_nonSelectionInitializing)
            {
                _nonSelectionInitializing = true;

                TextPointer caretPosition = RichTextBox.CaretPosition;
                TextRange selectedText = GetTextSelectionFromCurrentPosition(caretPosition, 0, 0)
                    ?? GetTextSelectionFromCurrentPosition(caretPosition, 0, 1)
                    ?? GetTextSelectionFromCurrentPosition(caretPosition, -1, 0);

                if (selectedText == null)
                {
                    var insertText = " ";

                    RichTextBox.CaretPosition.InsertTextInRun(insertText);
                    RichTextBox.CaretPosition = caretPosition.GetPositionAtOffset(insertText.Length);
                    RichTextBox.Selection.Select(caretPosition, RichTextBox.CaretPosition);
                }
                else
                    _tempSelectedText = selectedText;

                _textSelected = true;
                _nonSelectionInitializing = false;
            }
        }

        #endregion UTILITY METHODS

    }
}
