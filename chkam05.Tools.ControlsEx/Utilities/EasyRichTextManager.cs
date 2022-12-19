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

            return new EasyRichTextFormatting()
            {
                FontBackground = fontBackground,
                FontColor = fontColor,
                FontSize = fontSize,
                FontFamily = fontFamily,
                FontStyle = fontStyle,
                FontWeight = fontWeight,
                TextAlignment = textAlignment,
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
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get background color brush of selected text or for current position. </summary>
        /// <returns> Selected text font background color. </returns>
        public Brush GetSelectedTextFontBackground()
        {
            object propertyValue = SelectedText.GetPropertyValue(TextElement.BackgroundProperty);

            if (IsPropertySet(propertyValue))
                return (Brush)propertyValue;

            return null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get foreground color brush of selected text or for current position. </summary>
        /// <returns> Selected text font color. </returns>
        public Brush GetSelectedTextFontColor()
        {
            object propertyValue = SelectedText.GetPropertyValue(TextElement.ForegroundProperty);

            if (IsPropertySet(propertyValue))
                return (Brush)propertyValue;

            return new SolidColorBrush(System.Windows.Media.Colors.Black);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get font family of selected text or for current position. </summary>
        /// <returns> Selected text font family. </returns>
        public FontFamily GetSelectedTextFontFamily()
        {
            object propertyValue = SelectedText.GetPropertyValue(TextElement.FontFamilyProperty);

            if (IsPropertySet(propertyValue))
                return (FontFamily)propertyValue;

            return new FontFamily("Segoe UI");
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get font size of selected text or for current position. </summary>
        /// <returns> Selected text font size. </returns>
        public double GetSelectedTextFontSize()
        {
            object propertyValue = SelectedText.GetPropertyValue(TextElement.FontSizeProperty);

            if (IsPropertySet(propertyValue))
                return (double)propertyValue;

            return 12d;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get font style of selected text or for current position. </summary>
        /// <returns> Selected text font style. </returns>
        public FontStyle GetSelectedTextFontStyle()
        {
            object propertyValue = RichTextBox.Selection.GetPropertyValue(TextElement.FontStyleProperty);

            if (IsPropertySet(propertyValue))
                return (FontStyle)propertyValue;

            return FontStyles.Normal;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get font weight of selected text or for current position. </summary>
        /// <returns> Selected text font weight. </returns>
        public FontWeight GetSelectedTextFontWeight()
        {
            object propertyValue = RichTextBox.Selection.GetPropertyValue(TextElement.FontWeightProperty);

            if (IsPropertySet(propertyValue))
                return (FontWeight)propertyValue;

            return FontWeights.Normal;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get alignment of selected text or for current position. </summary>
        /// <returns> Selected text alignment. </returns>
        public TextAlignment GetSelectedTextAlignment()
        {
            object propertyValue = RichTextBox.Selection.GetPropertyValue(Paragraph.TextAlignmentProperty);

            if (IsPropertySet(propertyValue))
                return (TextAlignment)propertyValue;

            return TextAlignment.Left;
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
