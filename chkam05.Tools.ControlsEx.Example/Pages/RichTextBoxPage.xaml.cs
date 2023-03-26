using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Events;
using chkam05.Tools.ControlsEx.Example.Data.Config;
using chkam05.Tools.ControlsEx.Example.ExtendedControls;
using chkam05.Tools.ControlsEx.Example.Windows;
using chkam05.Tools.ControlsEx.InternalMessages;
using chkam05.Tools.ControlsEx.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace chkam05.Tools.ControlsEx.Example.Pages
{
    public partial class RichTextBoxPage : Page, INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private MainWindow _mainWindow;

        private ObservableCollection<FontFamilyInfo> _fontsCollection;
        private ObservableCollection<FontStyle> _fontStylesCollection;
        private ObservableCollection<FontWeight> _fontWeightsCollection;
        private ObservableCollection<TextAlignment> _textAlignmentsCollection;

        private bool _editorLock = false;
        private EasyRichTextManager _easyTextManager;
        private FontFamilyInfo _editorFontFamilyInfo = FontUtilities.DefaultFont;
        private double _editorFontSizeMax = 72d;
        private double _editorFontSizeMin = 7d;

        private EasyRichParagraphProperties _paragraphProperties = new EasyRichParagraphProperties();
        private EasyRichTextFormatting _textFormatting = new EasyRichTextFormatting();

        public Configuration Configuration { get; private set; }


        //  GETTERS & SETTERS

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

        public EasyRichTextManager EasyTextManager
        {
            get => _easyTextManager;
            set
            {
                _easyTextManager = value;
                OnPropertyChanged(nameof(EasyTextManager));
            }
        }

        public EasyRichParagraphProperties ParagraphProperties
        {
            get => _paragraphProperties;
            set
            {
                _paragraphProperties = value;
                _paragraphProperties.PropertyChanged += OnParagraphPropertyChanged;
                OnPropertyChanged(nameof(ParagraphProperties));

                if (!_editorLock)
                    EasyTextManager.SetSelectedParagraphProperties(value);
            }
        }

        public EasyRichTextFormatting TextFormatting
        {
            get => _textFormatting;
            set
            {
                _textFormatting = value;
                _textFormatting.PropertyChanged += OnTextFormattingPropertyChanged;
                OnPropertyChanged(nameof(TextFormatting));

                if (!_editorLock)
                    EasyTextManager.SetSelectedTextFormatting(value);
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
                    EasyTextManager.SetSelectedTextFontFamily(value.FontFamily);
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> RichTextBoxPage class constructor. </summary>
        public RichTextBoxPage()
        {
            //  Initialize values.
            _mainWindow = ((App)Application.Current).MainWindow as MainWindow;

            //  Initialize data containers.
            Configuration = Configuration.Instance;
            EasyTextManager = new EasyRichTextManager();
            EasyTextManager.SelectionChanged += EasyRichTextManagerSelectionChanged;

            //  Setup data.
            SetupData();

            //  Initialize interface components.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing selection in RichTextBox. </summary>
        /// <param name="sender"> Object from which event has been invoked. </param>
        /// <param name="e"> EasyRichText Selection Changed Event Arguments. </param>
        private void EasyRichTextManagerSelectionChanged(object sender, EasyRichTextSelectionChangedEventArgs e)
        {
            var paragraphProps = e.ParagraphProperties;
            var formatting = e.TextFormatting;

            _editorLock = true;

            TextFormatting = formatting;
            ParagraphProperties = paragraphProps;

            EditorFontFamilyInfo = FontUtilities.FindFontByName(
                FontUtilities.SystemFonts, formatting.FontFamily.FamilyNames.FirstOrDefault().Value);

            _editorLock = false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking font background color ButtonEx. </summary>
        /// <param name="sender"> Object from which event has been invoked. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void FontBackgroundButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var internalMessages = _mainWindow.InternalMessages;
            var message = new ColorsPaletteInternalMessageEx(internalMessages);

            message.AllowTransparent = true;
            message.OnClose += (s, ec) =>
            {
                if (ec.Result == InternalMessageResult.Ok)
                {
                    if (!_editorLock)
                        TextFormatting.FontBackground = new SolidColorBrush(ec.Color);
                }
            };

            UpdateInternalMessageAppearance(message);
            internalMessages.ShowMessage(message);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking font color ButtonEx. </summary>
        /// <param name="sender"> Object from which event has been invoked. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void FontColorButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var internalMessages = _mainWindow.InternalMessages;
            var message = new ColorsPaletteInternalMessageEx(internalMessages);

            message.OnClose += (s, ec) =>
            {
                if (ec.Result == InternalMessageResult.Ok)
                {
                    if (!_editorLock)
                        TextFormatting.FontColor = new SolidColorBrush(ec.Color);
                }
            };

            UpdateInternalMessageAppearance(message);
            internalMessages.ShowMessage(message);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking paragraph ButtonEx. </summary>
        /// <param name="sender"> Object from which event has been invoked. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void ParagraphFormattingButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var internalMessages = _mainWindow.InternalMessages;
            var message = new ParagraphPropertiesInternalMessageEx(internalMessages, ParagraphProperties);

            message.OnClose += (s, ec) =>
            {
                if (ec.Result == InternalMessageResult.Ok)
                    ParagraphProperties = message.EasyRichParagraphProperties;
            };

            internalMessages.ShowMessage(message);
        }

        #endregion INTERACTION METHODS

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

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after updating any paragraph property. </summary>
        /// <param name="sender"> Object from which event has been invoked. </param>
        /// <param name="e"> Property Changed Event Arguments. </param>
        protected void OnParagraphPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!_editorLock)
                EasyTextManager.SetSelectedParagraphProperties(ParagraphProperties);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after updating any text formatting property. </summary>
        /// <param name="sender"> Object from which event has been invoked. </param>
        /// <param name="e"> Property Changed Event Arguments. </param>
        protected void OnTextFormattingPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!_editorLock)
                EasyTextManager.SetSelectedTextFormatting(TextFormatting);
        }

        #endregion NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        #region PAGE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked during page loading. </summary>
        /// <param name="sender"> Object from which event has been invoked. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //
        }

        #endregion PAGE METHODS

        #region SETUP METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Setup example data. </summary>
        private void SetupData()
        {
            FontsCollection = new ObservableCollection<FontFamilyInfo>(FontUtilities.SystemFonts);
            FontStylesCollection = new ObservableCollection<FontStyle>(FontUtilities.GetStyles());
            FontWeightsCollection = new ObservableCollection<FontWeight>(FontUtilities.GetWeights());
            TextAlignmentsCollection = new ObservableCollection<TextAlignment>(FontUtilities.GetTextAlignments());
        }

        #endregion SETUP METHODS

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

        #endregion UPDATE METHODS

    }
}
