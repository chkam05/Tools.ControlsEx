using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Example.Data.Config;
using chkam05.Tools.ControlsEx.Utilities;
using System;
using System.Collections.Generic;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TextDataFormat = chkam05.Tools.ControlsEx.Data.TextDataFormat;


namespace chkam05.Tools.ControlsEx.Example.Pages
{
    public partial class FontAndRichTextBoxPage : Page, INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private Color _selectedFontBackground = System.Windows.Media.Colors.Transparent;
        private Color _selectedFontColor = System.Windows.Media.Colors.Black;
        private FontFamilyInfo _selectedFontFamily = FontUtilities.DefaultFont;
        private double _selectedFontSize = 11.0;
        private bool _selectedFontStrike = false;
        private FontStyle _selectedFontStyle = FontStyles.Normal;
        private bool _selectedFontUnderline = false;
        private FontWeight _selectedFontWeight = FontWeights.Normal;
        private TextAlignment _selectedTextAlignment = TextAlignment.Left;
        private string _selectedTextDataFormat = TextDataFormat.Text;

        public Configuration Configuration { get; private set; }


        //  GETTERS & SETTERS

        public Color SelectedFontBackground
        {
            get => _selectedFontBackground;
            set
            {
                _selectedFontBackground = value;
                OnPropertyChanged(nameof(SelectedFontBackground));
            }
        }

        public Color SelectedFontColor
        {
            get => _selectedFontColor;
            set
            {
                _selectedFontColor = value;
                OnPropertyChanged(nameof(SelectedFontColor));
            }
        }

        public FontFamilyInfo SelectedFontFamily
        {
            get => _selectedFontFamily;
            set
            {
                _selectedFontFamily = value;
                OnPropertyChanged(nameof(SelectedFontFamily));
            }
        }

        public double SelectedFontSize
        {
            get => _selectedFontSize;
            set
            {
                _selectedFontSize = value;
                OnPropertyChanged(nameof(SelectedFontSize));
            }
        }

        public bool SelectedFontStrike
        {
            get => _selectedFontStrike;
            set
            {
                _selectedFontStrike = value;
                OnPropertyChanged(nameof(SelectedFontStrike));
            }
        }

        public FontStyle SelectedFontStyle
        {
            get => _selectedFontStyle;
            set
            {
                _selectedFontStyle = value;
                OnPropertyChanged(nameof(SelectedFontStyle));
            }
        }

        public bool SelectedFontUnderline
        {
            get => _selectedFontUnderline;
            set
            {
                _selectedFontUnderline = value;
                OnPropertyChanged(nameof(SelectedFontUnderline));
            }
        }

        public FontWeight SelectedFontWeight
        {
            get => _selectedFontWeight;
            set
            {
                _selectedFontWeight = value;
                OnPropertyChanged(nameof(SelectedFontWeight));
            }
        }

        public TextAlignment SelectedTextAlignment
        {
            get => _selectedTextAlignment;
            set
            {
                _selectedTextAlignment = value;
                OnPropertyChanged(nameof(SelectedTextAlignment));
            }
        }

        public string SelectedTextDataFormat
        {
            get => _selectedTextDataFormat;
            set
            {
                _selectedTextDataFormat = value;
                OnPropertyChanged(nameof(SelectedTextDataFormat));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> FontAndRichTextBoxPage class constructor. </summary>
        public FontAndRichTextBoxPage()
        {
            //  Initialize data containers.
            Configuration = Configuration.Instance;

            //  Initialize interface components.
            InitializeComponent();
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
