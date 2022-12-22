using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Events;
using chkam05.Tools.ControlsEx.Example.Data.Config;
using chkam05.Tools.ControlsEx.Utilities;
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

        private bool _fontFormatGridAnimationStarted = false;
        private Thickness _fontFormatGridMargin;

        private ObservableCollection<FontFamilyInfo> _fontsCollection;
        private ObservableCollection<FontStyle> _fontStylesCollection;
        private ObservableCollection<FontWeight> _fontWeightsCollection;
        private ObservableCollection<TextAlignment> _textAlignmentsCollection;

        private bool _editorLock = false;
        private EasyRichTextManager _easyTextManager;
        private FontFamilyInfo _editorFontFamilyInfo = FontUtilities.DefaultFont;
        private double _editorFontSizeMax = 72d;
        private double _editorFontSizeMin = 7d;
        private double _editorFontSize = 12d;
        private FontStyle _editorFontStyle = FontStyles.Normal;
        private FontWeight _editorFontWeight = FontWeights.Bold;
        private TextAlignment _editorTextAlignment = TextAlignment.Left;
        private bool _editorTextDecorBaseline = false;
        private int _editorTextDecorBaselineType = 0;
        private bool _editorTextDecorOverLine = false;
        private int _editorTextDecorOverLineType = 0;
        private bool _editorTextDecorStrikethrough = false;
        private int _editorTextDecorStrikethroughType = 0;
        private bool _editorTextDecorUnderline = false;
        private int _editorTextDecorUnderlineType = 0;

        public Configuration Configuration { get; private set; }


        //  GETTERS & SETTERS

        public Thickness FontFormatGridMargin
        {
            get => _fontFormatGridMargin;
            set
            {
                _fontFormatGridMargin = value;
                OnPropertyChanged(nameof(FontFormatGridMargin));
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

        public EasyRichTextManager EasyTextManager
        {
            get => _easyTextManager;
            set
            {
                _easyTextManager = value;
                OnPropertyChanged(nameof(EasyTextManager));
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

        public double EditorFontSize
        {
            get => _editorFontSize;
            set
            {
                _editorFontSize = Math.Min(Math.Max(value, _editorFontSizeMin), _editorFontSizeMax);
                OnPropertyChanged(nameof(EditorFontSize));

                if (!_editorLock)
                    EasyTextManager.SetSelectedTextFontSize(value);
            }
        }

        public FontStyle EditorFontStyle
        {
            get => _editorFontStyle;
            set
            {
                _editorFontStyle = value;
                OnPropertyChanged(nameof(EditorFontStyle));

                if (!_editorLock)
                    EasyTextManager.SetSelectedTextFontStyle(value);
            }
        }

        public FontWeight EditorFontWeight
        {
            get => _editorFontWeight;
            set
            {
                _editorFontWeight = value;
                OnPropertyChanged(nameof(EditorFontWeight));

                if (!_editorLock)
                    EasyTextManager.SetSelectedTextFontWeight(value);
            }
        }

        public TextAlignment EditorTextAlignment
        {
            get => _editorTextAlignment;
            set
            {
                _editorTextAlignment = value;
                OnPropertyChanged(nameof(EditorTextAlignment));

                if (!_editorLock)
                    EasyTextManager.SetSelectedTextAlignment(value);
            }
        }

        public bool EditorTextDecorBaseline
        {
            get => _editorTextDecorBaseline;
            set
            {
                _editorTextDecorBaseline = value;
                OnPropertyChanged(nameof(EditorTextDecorBaseline));

                if (!_editorLock)
                    EasyTextManager.SetSelectedTextBaseline(value);
            }
        }

        public bool EditorTextDecorOverLine
        {
            get => _editorTextDecorOverLine;
            set
            {
                _editorTextDecorOverLine = value;
                OnPropertyChanged(nameof(EditorTextDecorOverLine));

                if (!_editorLock)
                    EasyTextManager.SetSelectedTextOverLine(value);
            }
        }

        public bool EditorTextDecorStrikethrough
        {
            get => _editorTextDecorStrikethrough;
            set
            {
                _editorTextDecorStrikethrough = value;
                OnPropertyChanged(nameof(EditorTextDecorStrikethrough));

                if (!_editorLock)
                    EasyTextManager.SetSelectedTextStrikethrough(value);
            }
        }

        public bool EditorTextDecorUnderline
        {
            get => _editorTextDecorUnderline;
            set
            {
                _editorTextDecorUnderline = value;
                OnPropertyChanged(nameof(EditorTextDecorUnderline));

                if (!_editorLock)
                    EasyTextManager.SetSelectedTextUnderline(value);
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> RichTextBoxPage class constructor. </summary>
        public RichTextBoxPage()
        {
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

        #region ANIMATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Run show hide FontFormatGrid storyboard. </summary>
        private void RunShowHideFormattingGridStoryboard()
        {
            if (!_fontFormatGridAnimationStarted)
            {
                FontFormatGridMargin = FontFormatGridMargin.Right >= 0.0
                    ? new Thickness(0, 0, -fontFormatGrid.ActualWidth, 0)
                    : new Thickness(0);

                Storyboard storyboard = Resources["ShowHideFormattingGrid"] as Storyboard;
                storyboard?.Begin();
                _fontFormatGridAnimationStarted = true;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after finishing FontFormatGrid storyboard animation. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Event Arguments. </param>
        private void ShowHideFormattingGridStoryboard_Completed(object sender, EventArgs e)
        {
            _fontFormatGridAnimationStarted = false;
        }

        #endregion ANIMATION METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking font format button. </summary>
        /// <param name="sender"> Object from which event has been invoked. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void FontFormatButtonEx_Click(object sender, RoutedEventArgs e)
        {
            RunShowHideFormattingGridStoryboard();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing selection in RichTextBox. </summary>
        /// <param name="sender"> Object from which event has been invoked. </param>
        /// <param name="e"> EasyRichText Selection Changed Event Arguments. </param>
        private void EasyRichTextManagerSelectionChanged(object sender, EasyRichTextSelectionChangedEventArgs e)
        {
            var formatting = e.Formatting;

            _editorLock = true;

            EditorFontFamilyInfo = FontUtilities.FindFontByName(
                FontUtilities.SystemFonts, formatting.FontFamily.FamilyNames.FirstOrDefault().Value);
            EditorFontSize = Math.Min(Math.Max(EditorFontSizeMin, formatting.FontSize), EditorFontSizeMax);
            EditorFontStyle = formatting.FontStyle;
            EditorFontWeight = formatting.FontWeight;
            EditorTextAlignment = formatting.TextAlignment;

            EditorTextDecorBaseline = formatting.TextDecorationBaseline;
            EditorTextDecorOverLine = formatting.TextDecorationOverLine;
            EditorTextDecorStrikethrough = formatting.TextDecorationStrikethrough;
            EditorTextDecorUnderline = formatting.TextDecorationUnderline;

            _editorLock = false;
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

    }
}
