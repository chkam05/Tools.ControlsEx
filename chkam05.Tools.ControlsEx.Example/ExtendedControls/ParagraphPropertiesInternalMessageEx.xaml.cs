using chkam05.Tools.ControlsEx.Colors;
using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Events;
using chkam05.Tools.ControlsEx.Example.Data;
using chkam05.Tools.ControlsEx.Example.Data.Config;
using chkam05.Tools.ControlsEx.Example.Windows;
using chkam05.Tools.ControlsEx.InternalMessages;
using chkam05.Tools.ControlsEx.Utilities;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace chkam05.Tools.ControlsEx.Example.ExtendedControls
{
    public partial class ParagraphPropertiesInternalMessageEx : StandardInternalMessageEx
    {

        //  VARIABLES

        private EasyRichParagraphProperties _paragraphProperties;

        private bool _editorLock = false;

        private ObservableCollection<ColorPaletteItem> _fontBackgroundColorsHistoryCollection;
        private ObservableCollection<ColorPaletteItem> _fontColorsHistoryCollection;
        private ObservableCollection<FlowDirection> _flowDirectionCollection;
        private ObservableCollection<FontCapitals> _fontCapitalsCollection;
        private ObservableCollection<FontEastAsianLanguage> _fontEastAsianLanguageCollection;
        private ObservableCollection<FontEastAsianWidths> _fontEastAsianWidthsCollection;
        private ObservableCollection<FontFraction> _fontFractionCollection;
        private ObservableCollection<FontNumeralAlignment> _fontNumeralAlignmentCollection;
        private ObservableCollection<FontNumeralStyle> _fontNumeralStyleCollection;
        private ObservableCollection<FontVariants> _fontVariantsCollection;
        private ObservableCollection<FontFamilyInfo> _fontsCollection;
        private ObservableCollection<FontStyle> _fontStylesCollection;
        private ObservableCollection<FontWeight> _fontWeightsCollection;
        private ObservableCollection<LineStackingStrategy> _lineStackingStrategyCollection;
        private ObservableCollection<TextAlignment> _textAlignmentsCollection;

        private FontFamilyInfo _editorFontFamilyInfo = FontUtilities.DefaultFont;
        private double _editorFontSizeMax = 72d;
        private double _editorFontSizeMin = 7d;


        //  GETTERS & SETTERS

        public Configuration Configuration { get; private set; }

        public EasyRichParagraphProperties EasyRichParagraphProperties
        {
            get => _paragraphProperties;
            set
            {
                _paragraphProperties = value;
                OnPropertyChanged(nameof(EasyRichParagraphProperties));
            }
        }

        public ObservableCollection<ColorPaletteItem> FontBackgroundColorsHistoryCollection
        {
            get => _fontBackgroundColorsHistoryCollection;
            set
            {
                _fontBackgroundColorsHistoryCollection = value;
                OnPropertyChanged(nameof(FontBackgroundColorsHistoryCollection));
            }
        }

        public ObservableCollection<ColorPaletteItem> FontColorsHistoryCollection
        {
            get => _fontColorsHistoryCollection;
            set
            {
                _fontColorsHistoryCollection = value;
                OnPropertyChanged(nameof(FontColorsHistoryCollection));
            }
        }

        public ObservableCollection<FlowDirection> FlowDirectionCollection
        {
            get => _flowDirectionCollection;
            set
            {
                _flowDirectionCollection = value;
                OnPropertyChanged(nameof(FlowDirectionCollection));
            }
        }

        public ObservableCollection<FontCapitals> FontCapitalsCollection
        {
            get => _fontCapitalsCollection;
            set
            {
                _fontCapitalsCollection = value;
                OnPropertyChanged(nameof(FontCapitalsCollection));
            }
        }

        public ObservableCollection<FontEastAsianLanguage> FontEastAsianLanguageCollection
        {
            get => _fontEastAsianLanguageCollection;
            set
            {
                _fontEastAsianLanguageCollection = value;
                OnPropertyChanged(nameof(FontEastAsianLanguageCollection));
            }
        }

        public ObservableCollection<FontEastAsianWidths> FontEastAsianWidthsCollection
        {
            get => _fontEastAsianWidthsCollection;
            set
            {
                _fontEastAsianWidthsCollection = value;
                OnPropertyChanged(nameof(FontEastAsianWidthsCollection));
            }
        }

        public ObservableCollection<FontFraction> FontFractionCollection
        {
            get => _fontFractionCollection;
            set
            {
                _fontFractionCollection = value;
                OnPropertyChanged(nameof(FontFractionCollection));
            }
        }

        public ObservableCollection<FontNumeralAlignment> FontNumeralAlignmentCollection
        {
            get => _fontNumeralAlignmentCollection;
            set
            {
                _fontNumeralAlignmentCollection = value;
                OnPropertyChanged(nameof(FontNumeralAlignmentCollection));
            }
        }

        public ObservableCollection<FontNumeralStyle> FontNumeralStyleCollection
        {
            get => _fontNumeralStyleCollection;
            set
            {
                _fontNumeralStyleCollection = value;
                OnPropertyChanged(nameof(FontNumeralStyleCollection));
            }
        }

        public ObservableCollection<FontVariants> FontVariantsCollection
        {
            get => _fontVariantsCollection;
            set
            {
                _fontVariantsCollection = value;
                OnPropertyChanged(nameof(FontVariantsCollection));
            }
        }

        public ObservableCollection<FontFamilyInfo> FontsCollection
        {
            get => _fontsCollection;
            set
            {
                _fontsCollection = value;
                OnPropertyChanged(nameof(FontsCollection));
            }
        }

        public ObservableCollection<FontStyle> FontStylesCollection
        {
            get => _fontStylesCollection;
            set
            {
                _fontStylesCollection = value;
                OnPropertyChanged(nameof(FontStylesCollection));
            }
        }

        public ObservableCollection<FontWeight> FontWeightsCollection
        {
            get => _fontWeightsCollection;
            set
            {
                _fontWeightsCollection = value;
                OnPropertyChanged(nameof(FontWeightsCollection));
            }
        }

        public ObservableCollection<LineStackingStrategy> LineStackingStrategyCollection
        {
            get => _lineStackingStrategyCollection;
            set
            {
                _lineStackingStrategyCollection = value;
                OnPropertyChanged(nameof(LineStackingStrategyCollection));
            }
        }

        public ObservableCollection<TextAlignment> TextAlignmentsCollection
        {
            get => _textAlignmentsCollection;
            set
            {
                _textAlignmentsCollection = value;
                OnPropertyChanged(nameof(TextAlignmentsCollection));
            }
        }

        public FontFamilyInfo EditorFontFamilyInfo
        {
            get => _editorFontFamilyInfo;
            set
            {
                _editorFontFamilyInfo = value;
                OnPropertyChanged(nameof(EditorFontFamilyInfo));

                if (!_editorLock)
                    EasyRichParagraphProperties.FontFamily = value.FontFamily;
            }
        }

        public double EditorFontSizeMax
        {
            get => _editorFontSizeMax;
            set
            {
                _editorFontSizeMax = Math.Max(_editorFontSizeMin, value);
                OnPropertyChanged(nameof(EditorFontSizeMax));
            }
        }

        public double EditorFontSizeMin
        {
            get => _editorFontSizeMin;
            set
            {
                _editorFontSizeMin = Math.Min(Math.Max(value, 1d), _editorFontSizeMax);
                OnPropertyChanged(nameof(EditorFontSizeMin));
            }
        }

        #region Thickness values

        //  BorderThickness

        public double EditorBorderThicknessLeft
        {
            get => EasyRichParagraphProperties.BorderThickness.Left;
            set
            {
                EasyRichParagraphProperties.BorderThickness = UpdateThickness(
                    EasyRichParagraphProperties.BorderThickness, left: value);
                OnPropertyChanged(nameof(EditorBorderThicknessLeft));
            }
        }

        public double EditorBorderThicknessTop
        {
            get => EasyRichParagraphProperties.BorderThickness.Top;
            set
            {
                EasyRichParagraphProperties.BorderThickness = UpdateThickness(
                    EasyRichParagraphProperties.BorderThickness, top: value);
                OnPropertyChanged(nameof(EditorBorderThicknessTop));
            }
        }

        public double EditorBorderThicknessRight
        {
            get => EasyRichParagraphProperties.BorderThickness.Right;
            set
            {
                EasyRichParagraphProperties.BorderThickness = UpdateThickness(
                    EasyRichParagraphProperties.BorderThickness, right: value);
                OnPropertyChanged(nameof(EditorBorderThicknessRight));
            }
        }

        public double EditorBorderThicknessBottom
        {
            get => EasyRichParagraphProperties.BorderThickness.Bottom;
            set
            {
                EasyRichParagraphProperties.BorderThickness = UpdateThickness(
                    EasyRichParagraphProperties.BorderThickness, bottom: value);
                OnPropertyChanged(nameof(EditorBorderThicknessBottom));
            }
        }

        //  Margin

        public double EditorMarginLeft
        {
            get => EasyRichParagraphProperties.Margin.Left;
            set
            {
                EasyRichParagraphProperties.Margin = UpdateThickness(
                    EasyRichParagraphProperties.Margin, left: value);
                OnPropertyChanged(nameof(EditorMarginLeft));
            }
        }

        public double EditorMarginTop
        {
            get => EasyRichParagraphProperties.Margin.Top;
            set
            {
                EasyRichParagraphProperties.Margin = UpdateThickness(
                    EasyRichParagraphProperties.Margin, top: value);
                OnPropertyChanged(nameof(EditorMarginTop));
            }
        }

        public double EditorMarginRight
        {
            get => EasyRichParagraphProperties.Margin.Right;
            set
            {
                EasyRichParagraphProperties.Margin = UpdateThickness(
                    EasyRichParagraphProperties.Margin, right: value);
                OnPropertyChanged(nameof(EditorMarginRight));
            }
        }

        public double EditorMarginBottom
        {
            get => EasyRichParagraphProperties.Margin.Bottom;
            set
            {
                EasyRichParagraphProperties.Margin = UpdateThickness(
                    EasyRichParagraphProperties.Margin, bottom: value);
                OnPropertyChanged(nameof(EditorMarginBottom));
            }
        }

        //  Padding

        public double EditorPaddingLeft
        {
            get => EasyRichParagraphProperties.Padding.Left;
            set
            {
                EasyRichParagraphProperties.Padding = UpdateThickness(
                    EasyRichParagraphProperties.Padding, left: value);
                OnPropertyChanged(nameof(EditorPaddingLeft));
            }
        }

        public double EditorPaddingTop
        {
            get => EasyRichParagraphProperties.Padding.Top;
            set
            {
                EasyRichParagraphProperties.Padding = UpdateThickness(
                    EasyRichParagraphProperties.Padding, top: value);
                OnPropertyChanged(nameof(EditorPaddingTop));
            }
        }

        public double EditorPaddingRight
        {
            get => EasyRichParagraphProperties.Padding.Right;
            set
            {
                EasyRichParagraphProperties.Padding = UpdateThickness(
                    EasyRichParagraphProperties.Padding, right: value);
                OnPropertyChanged(nameof(EditorPaddingRight));
            }
        }

        public double EditorPaddingBottom
        {
            get => EasyRichParagraphProperties.Padding.Bottom;
            set
            {
                EasyRichParagraphProperties.Padding = UpdateThickness(
                    EasyRichParagraphProperties.Padding, bottom: value);
                OnPropertyChanged(nameof(EditorPaddingBottom));
            }
        }

        #endregion Thickness values


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ParagraphPropertiesInternalMessageEx class constructor. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        public ParagraphPropertiesInternalMessageEx(InternalMessagesExContainer parentContainer,
            EasyRichParagraphProperties paragraphProperties) : base(parentContainer)
        {
            //  Setup data.
            Configuration = Configuration.Instance;
            EasyRichParagraphProperties = (EasyRichParagraphProperties) paragraphProperties.Clone();

            EditorFontFamilyInfo = FontUtilities.FindFontByName(
                FontUtilities.SystemFonts, EasyRichParagraphProperties.FontFamily.FamilyNames.FirstOrDefault().Value);

            //  Setup data.
            SetupData();

            //  Initialize interface.
            InitializeComponent();
            SetupInterfaceAppearance();
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking background color ButtonEx. </summary>
        /// <param name="sender"> Object from which event has been invoked. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void BackgroundButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var message = new ColorsPaletteInternalMessageEx(_parentContainer);

            message.AllowTransparent = true;

            message.OnClose += (s, ec) =>
            {
                if (ec.Result == InternalMessageResult.Ok)
                {
                    if (!_editorLock)
                        EasyRichParagraphProperties.Background = new SolidColorBrush(ec.Color);
                }
            };

            UpdateInternalMessageAppearance(message);
            _parentContainer.ShowMessage(message);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking border brush color ButtonEx. </summary>
        /// <param name="sender"> Object from which event has been invoked. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void BorderBrushButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var message = new ColorsPaletteInternalMessageEx(_parentContainer);

            message.AllowTransparent = true;

            message.OnClose += (s, ec) =>
            {
                if (ec.Result == InternalMessageResult.Ok)
                {
                    if (!_editorLock)
                        EasyRichParagraphProperties.BorderBrush = new SolidColorBrush(ec.Color);
                }
            };

            UpdateInternalMessageAppearance(message);
            _parentContainer.ShowMessage(message);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking font color ButtonEx. </summary>
        /// <param name="sender"> Object from which event has been invoked. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void FontColorButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var message = new ColorsPaletteInternalMessageEx(_parentContainer);

            message.OnClose += (s, ec) =>
            {
                if (ec.Result == InternalMessageResult.Ok)
                {
                    if (!_editorLock)
                        EasyRichParagraphProperties.Foreground = new SolidColorBrush(ec.Color);
                }
            };

            UpdateInternalMessageAppearance(message);
            _parentContainer.ShowMessage(message);
        }

        #endregion INTERACTION METHODS

        #region SETUP METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Setup interface appearance. </summary>
        private void SetupInterfaceAppearance()
        {
            Background = Configuration.BackgroundColorBrush;
            BorderBrush = Configuration.AccentColorBrush;
            Foreground = Configuration.ForegroundColorBrush;
            BottomBorderBrush = Configuration.AccentColorBrush;
            ButtonBackground = Configuration.AccentColorBrush;
            ButtonBorderBrush = Configuration.AccentColorBrush;
            ButtonForeground = Configuration.AccentForegroundColorBrush;
            ButtonMouseOverBackground = Configuration.AccentMouseOverColorBrush;
            ButtonMouseOverBorderBrush = Configuration.AccentMouseOverColorBrush;
            ButtonMouseOverForeground = Configuration.AccentForegroundColorBrush;
            ButtonPressedBackground = Configuration.AccentPressedColorBrush;
            ButtonPressedBorderBrush = Configuration.AccentPressedColorBrush;
            ButtonPressedForeground = Configuration.AccentForegroundColorBrush;
            HeaderBorderThickness = new Thickness(0);

            Buttons = new InternalMessageButtons[]
            {
                InternalMessageButtons.OkButton,
                InternalMessageButtons.CancelButton
            };
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Setup example data. </summary>
        private void SetupData()
        {
            FontBackgroundColorsHistoryCollection = new ObservableCollection<ColorPaletteItem>()
            {
                new ColorPaletteItem((EasyRichParagraphProperties.Background as SolidColorBrush ?? Brushes.Transparent).Color, null),
                ColorsPaletteItems.Blue,
                ColorsPaletteItems.Red,
                ColorsPaletteItems.GoldYellow,
                ColorsPaletteItems.Green
            };

            FontColorsHistoryCollection = new ObservableCollection<ColorPaletteItem>()
            {
                new ColorPaletteItem(((SolidColorBrush)EasyRichParagraphProperties.Foreground).Color, null),
                ColorsPaletteItems.Blue,
                ColorsPaletteItems.Red,
                ColorsPaletteItems.GoldYellow,
                ColorsPaletteItems.Green
            };

            FlowDirectionCollection = new ObservableCollection<FlowDirection>(GetEnumValues<FlowDirection>());
            FontCapitalsCollection = new ObservableCollection<FontCapitals>(GetEnumValues<FontCapitals>());
            FontEastAsianLanguageCollection = new ObservableCollection<FontEastAsianLanguage>(GetEnumValues<FontEastAsianLanguage>());
            FontEastAsianWidthsCollection = new ObservableCollection<FontEastAsianWidths>(GetEnumValues<FontEastAsianWidths>());
            FontFractionCollection = new ObservableCollection<FontFraction>(GetEnumValues<FontFraction>());
            FontNumeralAlignmentCollection = new ObservableCollection<FontNumeralAlignment>(GetEnumValues<FontNumeralAlignment>());
            FontNumeralStyleCollection = new ObservableCollection<FontNumeralStyle>(GetEnumValues<FontNumeralStyle>());
            FontVariantsCollection = new ObservableCollection<FontVariants>(GetEnumValues<FontVariants>());
            FontsCollection = new ObservableCollection<FontFamilyInfo>(FontUtilities.SystemFonts);
            FontStylesCollection = new ObservableCollection<FontStyle>(FontUtilities.GetStyles());
            FontWeightsCollection = new ObservableCollection<FontWeight>(FontUtilities.GetWeights());
            LineStackingStrategyCollection = new ObservableCollection<LineStackingStrategy>(GetEnumValues<LineStackingStrategy>());
            TextAlignmentsCollection = new ObservableCollection<TextAlignment>(FontUtilities.GetTextAlignments());
        }

        #endregion SETUP METHODS

        #region UTILITY METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Get enum values list. </summary>
        /// <typeparam name="T"> Enum type. </typeparam>
        /// <returns> Enum values list. </returns>
        private List<T> GetEnumValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }

        #endregion UTILITY METHODS

        #region UPDATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Update Internal Message appearance. </summary>
        /// <param name="message"> Internal Message. </param>
        private void UpdateInternalMessageAppearance<T>(BaseInternalMessageEx<T> message) where T : InternalMessageCloseEventArgs
        {
            message.Background = Configuration.BackgroundColorBrush;
            message.BorderBrush = Configuration.AccentColorBrush;
            message.Foreground = Configuration.ForegroundColorBrush;
            message.ButtonBackground = Configuration.AccentColorBrush;
            message.ButtonBorderBrush = Configuration.AccentColorBrush;
            message.ButtonForeground = Configuration.AccentForegroundColorBrush;
            message.ButtonMouseOverBackground = Configuration.AccentMouseOverColorBrush;
            message.ButtonMouseOverBorderBrush = Configuration.AccentMouseOverColorBrush;
            message.ButtonMouseOverForeground = Configuration.AccentForegroundColorBrush;
            message.ButtonPressedBackground = Configuration.AccentPressedColorBrush;
            message.ButtonPressedBorderBrush = Configuration.AccentPressedColorBrush;
            message.ButtonPressedForeground = Configuration.AccentForegroundColorBrush;

            if (message.GetType().IsSubclassOf(typeof(ColorsPickerInternalMessageEx)))
            {
                var pickerMessage = message as ColorsPickerInternalMessageEx;
                pickerMessage.ColorComponentMouseOverBackground = Configuration.AccentMouseOverColorBrush;
                pickerMessage.ColorComponentMouseOverBorderBrush = Configuration.AccentColorBrush;
                pickerMessage.ColorComponentMouseOverForeground = Configuration.AccentForegroundColorBrush;
                pickerMessage.ColorComponentSelectedBackground = Configuration.BackgroundColorBrush;
                pickerMessage.ColorComponentSelectedBorderBrush = Configuration.AccentSelectedColorBrush;
                pickerMessage.ColorComponentSelectedForeground = Configuration.ForegroundColorBrush;
                pickerMessage.ColorComponentSelectedTextBackground = Configuration.AccentSelectedColorBrush;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update thickness value. </summary>
        /// <param name="thickness"> Thickness. </param>
        /// <param name="left"> Left. </param>
        /// <param name="top"> Top. </param>
        /// <param name="right"> Right. </param>
        /// <param name="bottom"> Bottom. </param>
        private Thickness UpdateThickness(Thickness thickness, double? left = null, double? top = null,
            double? right = null, double? bottom = null)
        {
            return new Thickness(
                left.HasValue ? left.Value : thickness.Left,
                top.HasValue ? top.Value : thickness.Top,
                right.HasValue ? right.Value : thickness.Right,
                bottom.HasValue ? bottom.Value : thickness.Bottom);
        }

        #endregion UPDATE METHODS

    }
}
