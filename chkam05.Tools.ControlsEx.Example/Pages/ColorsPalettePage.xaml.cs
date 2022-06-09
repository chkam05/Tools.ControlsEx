using chkam05.Tools.ControlsEx.Example.Data.Config;
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

namespace chkam05.Tools.ControlsEx.Example.Pages
{
    public partial class ColorsPalettePage : Page, INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private Brush _selectedColorBrush = new SolidColorBrush(System.Windows.Media.Colors.Transparent);
        private string _selectedColorCode = "#00000000";
        private string _selectedColorName = "Transparent";

        public Configuration Configuration { get; private set; }


        //  GETTERS & SETTERS

        public Brush SelectedColorBrush
        {
            get => _selectedColorBrush;
            set
            {
                _selectedColorBrush = value;
                OnPropertyChanged(nameof(SelectedColorBrush));
            }
        }

        public string SelectedColorCode
        {
            get => _selectedColorCode;
            set
            {
                _selectedColorCode = value;
                OnPropertyChanged(nameof(SelectedColorCode));
            }
        }

        public string SelectedColorName
        {
            get => _selectedColorName;
            set
            {
                _selectedColorName = value;
                OnPropertyChanged(nameof(SelectedColorName));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ColorsPalettePage class constructor. </summary>
        public ColorsPalettePage()
        {
            //  Initialize data containers.
            Configuration = Configuration.Instance;

            //  Initialize interface components.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing color in Colors palette. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Colors Palette Selection Changed Event Arguments. </param>
        private void ColorsPaletteEx_ColorSelectionChanged(object sender, Events.ColorsPaletteSelectionChangedEventArgs e)
        {
            if (e?.SelectedColorItem != null)
            {
                SelectedColorBrush = new SolidColorBrush(e.SelectedColorItem.Color);
                SelectedColorCode = $"({e.SelectedColorItem.ColorCode})";
                SelectedColorName = e.SelectedColorItem.Name;
            }
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

    }
}
