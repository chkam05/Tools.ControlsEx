using chkam05.Tools.ControlsEx.Colors;
using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Example.Data;
using chkam05.Tools.ControlsEx.Example.Data.Config;
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
        private ObservableCollection<FontFamilyInfo> _fontsCollection;
        private ObservableCollection<FontStyle> _fontStylesCollection;
        private ObservableCollection<FontWeight> _fontWeightsCollection;
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

            //  Setup data.
            SetupData();

            //  Initialize interface.
            InitializeComponent();
            SetupInterfaceAppearance();
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing text background color in Colors palette. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Colors Palette Selection Changed Event Arguments. </param>
        private void FontBackgroundColorsPaletteEx_ColorSelectionChanged(object sender, Events.ColorsPaletteSelectionChangedEventArgs e)
        {
            EasyRichParagraphProperties.Background = new SolidColorBrush(e.SelectedColorItem.Color);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing text color in Colors palette. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Colors Palette Selection Changed Event Arguments. </param>
        private void FontColorsPaletteEx_ColorSelectionChanged(object sender, Events.ColorsPaletteSelectionChangedEventArgs e)
        {
            EasyRichParagraphProperties.Foreground = new SolidColorBrush(e.SelectedColorItem.Color);
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

            FontsCollection = new ObservableCollection<FontFamilyInfo>(FontUtilities.SystemFonts);
            FontStylesCollection = new ObservableCollection<FontStyle>(FontUtilities.GetStyles());
            FontWeightsCollection = new ObservableCollection<FontWeight>(FontUtilities.GetWeights());
            TextAlignmentsCollection = new ObservableCollection<TextAlignment>(FontUtilities.GetTextAlignments());
        }

        #endregion SETUP METHODS

    }
}
