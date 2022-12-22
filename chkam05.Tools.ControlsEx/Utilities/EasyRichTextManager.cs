using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

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

        public RichTextBox RichTextBox { get; private set; }


        //  GETTERS & SETTERS

        public TextRange SelectedText
        {
            get => new TextRange(RichTextBox.Selection.Start, RichTextBox.Selection.End);
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

        #region DECORATIONS MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Add decoration to text decoration collection. </summary>
        /// <param name="collection"> Decoration collection. </param>
        /// <param name="decoration"> Decoration to add. </param>
        protected void AddDecoration(TextDecorationCollection collection, TextDecoration decoration)
        {
            if (collection == null && !collection.Any())
                return;

            if (!IsDecorationApplied(collection, decoration))
                collection.Add(decoration);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Check if decoration is applied in text decoration collection. </summary>
        /// <param name="collection"> Decoration collection. </param>
        /// <param name="decoration"> Decoration. </param>
        /// <returns> True - decoration is applied; False - otherwise. </returns>
        protected bool IsDecorationApplied(TextDecorationCollection collection, TextDecoration decoration)
        {
            if (collection == null && !collection.Any())
                return false;

            return collection.Any(d => d.Equals(decoration));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Remove decoration from text decoration collection. </summary>
        /// <param name="collection"> Decoration collection. </param>
        /// <param name="decoration"> Decoration to remove. </param>
        protected void RemoveDecoration(TextDecorationCollection collection, TextDecoration decoration)
        {
            if (collection == null && !collection.Any())
                return;

            if (IsDecorationApplied(collection, decoration))
                collection.Remove(decoration);
        }

        #endregion DECORATIONS MANAGEMENT METHODS

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

                    var formatting = GetSelectedTextFormatting();
                    var eventArgs = new EasyRichTextSelectionChangedEventArgs(formatting, SelectedText);
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

        #region SELECTED TEXT PROPERTIES MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Get selected text formatting. </summary>
        /// <returns> EasyTichTextFormatting object. </returns>
        public EasyRichTextFormatting GetSelectedTextFormatting()
        {
            //object textDecorationsProperty = SelectedText.GetPropertyValue(Inline.TextDecorationsProperty);

            Brush fontBackground = GetSelectedTextFontBackground();
            Brush fontColor = GetSelectedTextFontColor();
            FontFamily fontFamily = GetSelectedTextFontFamily();
            double fontSize = GetSelectedTextFontSize();
            FontStyle fontStyle = GetSelectedTextFontStyle();
            FontWeight fontWeight = GetSelectedTextFontWeight();
            TextAlignment textAlignment = GetSelectedTextAlignment();

            var textDecorBaseLine = GetSelectedTextBaseline();
            var textDecorOverLine = GetSelectedTextOverLine();
            var textDecorStrikethrough = GetSelectedTextStrikethrough();
            var textDecorUnderline = GetSelectedTextUnderline();

            return new EasyRichTextFormatting()
            {
                FontBackground = fontBackground,
                FontColor = fontColor,
                FontSize = fontSize,
                FontFamily = fontFamily,
                FontStyle = fontStyle,
                FontWeight = fontWeight,
                TextAlignment = textAlignment,

                TextDecorationBaseline = textDecorBaseLine,
                TextDecorationOverLine = textDecorOverLine,
                TextDecorationStrikethrough = textDecorStrikethrough,
                TextDecorationUnderline = textDecorUnderline,
            };
        }

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
            var property = Inline.TextDecorationsProperty;
            var propertyValue = SelectedText.GetPropertyValue(property);

            if (IsPropertySet(propertyValue))
            {
                var textDecorations = propertyValue as TextDecorationCollection;
                return IsDecorationApplied(textDecorations, TextDecorations.Baseline[0]);
            }

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get text overline decoration of current selected text or for current position. </summary>
        /// <returns> Selected text overline decoration enabled. </returns>
        public bool GetSelectedTextOverLine()
        {
            var property = Inline.TextDecorationsProperty;
            var propertyValue = SelectedText.GetPropertyValue(property);

            if (IsPropertySet(propertyValue))
            {
                var textDecorations = propertyValue as TextDecorationCollection;
                return IsDecorationApplied(textDecorations, TextDecorations.OverLine[0]);
            }

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get text strikethrough decoration of current selected text or for current position. </summary>
        /// <returns> Selected text strikethrough decoration enabled. </returns>
        public bool GetSelectedTextStrikethrough()
        {
            var property = Inline.TextDecorationsProperty;
            var propertyValue = SelectedText.GetPropertyValue(property);

            if (IsPropertySet(propertyValue))
            {
                var textDecorations = propertyValue as TextDecorationCollection;
                return IsDecorationApplied(textDecorations, TextDecorations.Strikethrough[0]);
            }

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get text underline decoration of current selected text or for current position. </summary>
        /// <returns> Selected text underline decoration enabled. </returns>
        public bool GetSelectedTextUnderline()
        {
            var property = Inline.TextDecorationsProperty;
            var propertyValue = SelectedText.GetPropertyValue(property);

            if (IsPropertySet(propertyValue))
            {
                var textDecorations = propertyValue as TextDecorationCollection;
                return IsDecorationApplied(textDecorations, TextDecorations.Underline[0]);
            }

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set background color brush of selected text or for current position. </summary>
        /// <param name="colorBrush"> Background color brush. </param>
        public void SetSelectedTextFontBackground(Brush colorBrush)
        {
            if (colorBrush != null)
            {
                if (!_textSelected)
                    InitForNoSelectionUpdate();

                var property = TextElement.BackgroundProperty;
                var selectedText = SelectedText;

                if (selectedText != null)
                    selectedText.ApplyPropertyValue(property, colorBrush);
            }
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

            var property = Inline.TextDecorationsProperty;
            var selectedText = SelectedText;

            if (selectedText != null)
            {
                var textDecorations = (TextDecorationCollection)selectedText.GetPropertyValue(property);
                bool requiredUpdate = false;

                if (textDecorations != null)
                {
                    var isDecorationApplied = IsDecorationApplied(textDecorations, TextDecorations.Baseline[0]);

                    if (baseline && !isDecorationApplied)
                    {
                        AddDecoration(textDecorations, TextDecorations.Baseline[0]);
                        requiredUpdate = true;
                    }
                    else if (!baseline && isDecorationApplied)
                    {
                        RemoveDecoration(textDecorations, TextDecorations.Baseline[0]);
                        requiredUpdate = true;
                    }
                }
                else
                {
                    textDecorations = baseline
                        ? new TextDecorationCollection() { TextDecorations.Baseline[0] }
                        : null;
                    requiredUpdate = true;
                }

                if (requiredUpdate)
                    selectedText.ApplyPropertyValue(property, textDecorations);
            }

            RichTextBox.Focus();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set overLine text decoration to selected text or for current position. </summary>
        /// <param name="overLine"> OverLine text decoration enabled. </param>
        public void SetSelectedTextOverLine(bool overLine)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var property = Inline.TextDecorationsProperty;
            var selectedText = SelectedText;

            if (selectedText != null)
            {
                var textDecorations = (TextDecorationCollection)selectedText.GetPropertyValue(property);
                bool requiredUpdate = false;

                if (textDecorations != null)
                {
                    var isDecorationApplied = IsDecorationApplied(textDecorations, TextDecorations.OverLine[0]);

                    if (overLine && !isDecorationApplied)
                    {
                        AddDecoration(textDecorations, TextDecorations.OverLine[0]);
                        requiredUpdate = true;
                    }
                    else if (!overLine && isDecorationApplied)
                    {
                        RemoveDecoration(textDecorations, TextDecorations.OverLine[0]);
                        requiredUpdate = true;
                    }
                }
                else
                {
                    textDecorations = overLine
                        ? new TextDecorationCollection() { TextDecorations.OverLine[0] }
                        : null;
                    requiredUpdate = true;
                }

                if (requiredUpdate)
                    selectedText.ApplyPropertyValue(property, textDecorations);
            }

            RichTextBox.Focus();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set strikethrough text decoration to selected text or for current position. </summary>
        /// <param name="strike"> Strikethrough text decoration enabled. </param>
        public void SetSelectedTextStrikethrough(bool strike)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var property = Inline.TextDecorationsProperty;
            var selectedText = SelectedText;

            if (selectedText != null)
            {
                var textDecorations = (TextDecorationCollection)selectedText.GetPropertyValue(property);
                bool requiredUpdate = false;

                if (textDecorations != null)
                {
                    var isDecorationApplied = IsDecorationApplied(textDecorations, TextDecorations.Strikethrough[0]);

                    if (strike && !isDecorationApplied)
                    {
                        AddDecoration(textDecorations, TextDecorations.Strikethrough[0]);
                        requiredUpdate = true;
                    }
                    else if (!strike && isDecorationApplied)
                    {
                        RemoveDecoration(textDecorations, TextDecorations.Strikethrough[0]);
                        requiredUpdate = true;
                    }
                }
                else
                {
                    textDecorations = strike
                        ? new TextDecorationCollection() { TextDecorations.Strikethrough[0] }
                        : null;
                    requiredUpdate = true;
                }

                if (requiredUpdate)
                    selectedText.ApplyPropertyValue(property, textDecorations);
            }   

            RichTextBox.Focus();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set underline text decoration to selected text or for current position. </summary>
        /// <param name="underline"> Underline text decoration enabled. </param>
        public void SetSelectedTextUnderline(bool underline)
        {
            if (!_textSelected)
                InitForNoSelectionUpdate();

            var property = Inline.TextDecorationsProperty;
            var selectedText = SelectedText;

            if (selectedText != null)
            {
                var textDecorations = (TextDecorationCollection)selectedText.GetPropertyValue(property);
                bool requiredUpdate = false;

                if (textDecorations != null)
                {
                    var isDecorationApplied = IsDecorationApplied(textDecorations, TextDecorations.Underline[0]);

                    if (underline && !isDecorationApplied)
                    {
                        AddDecoration(textDecorations, TextDecorations.Underline[0]);
                        requiredUpdate = true;
                    }
                    else if (!underline && isDecorationApplied)
                    {
                        RemoveDecoration(textDecorations, TextDecorations.Underline[0]);
                        requiredUpdate = true;
                    }
                }
                else
                {
                    textDecorations = underline
                        ? new TextDecorationCollection() { TextDecorations.Underline[0] }
                        : null;
                    requiredUpdate = true;
                }

                if (requiredUpdate)
                    selectedText.ApplyPropertyValue(property, textDecorations);
            }

            RichTextBox.Focus();
        }

        #endregion SELECTED TEXT PROPERTIES MANAGEMENT METHODS

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
        /// <summary> Check if dependency property has set value, is not null or unset. </summary>
        /// <param name="property"> Dependency property. </param>
        /// <returns> True = value is set, False - otherwise. </returns>
        protected bool IsPropertySet(object property)
        {
            return property != null && property != DependencyProperty.UnsetValue;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Prepare RichTextBox for font update when text is no selected. </summary>
        internal void InitForNoSelectionUpdate()
        {
            if (!_textSelected && !_nonSelectionInitializing)
            {
                _nonSelectionInitializing = true;

                var caretPosition = RichTextBox.CaretPosition;
                var insertText = " ";

                RichTextBox.CaretPosition.InsertTextInRun(insertText);
                RichTextBox.CaretPosition = caretPosition.GetPositionAtOffset(insertText.Length);
                RichTextBox.Selection.Select(caretPosition, RichTextBox.CaretPosition);

                _textSelected = true;
                _nonSelectionInitializing = false;
            }
        }

        #endregion UTILITY METHODS

    }
}
