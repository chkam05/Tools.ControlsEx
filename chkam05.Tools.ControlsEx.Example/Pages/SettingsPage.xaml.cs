using chkam05.Tools.ControlsEx.Colors;
using chkam05.Tools.ControlsEx.Example.Data.Config;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace chkam05.Tools.ControlsEx.Example.Pages
{
    public partial class SettingsPage : Page, INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private ObservableCollection<ColorPaletteItem> _themeColors;

        public Configuration Configuration { get; private set; }


        //  GETTERS & SETTERS

        public ObservableCollection<ColorPaletteItem> ThemeColors
        {
            get => _themeColors;
            set
            {
                _themeColors = value;
                OnPropertyChanged(nameof(ThemeColors));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SettingsPage class constructor. </summary>
        public SettingsPage()
        {
            //  Initialize data containers.
            Configuration = Configuration.Instance;

            ThemeColors = new ObservableCollection<ColorPaletteItem>()
            {
                new ColorPaletteItem(System.Windows.Media.Colors.Black, "Dark"),
                new ColorPaletteItem(System.Windows.Media.Colors.White, "Light"),
            };

            //  Initialize interface components.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing color in Colors palette. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Colors Palette Selection Changed Event Arguments. </param>
        private void AccentColorsPaletteEx_ColorSelectionChanged(object sender, Events.ColorsPaletteSelectionChangedEventArgs e)
        {
            if (e?.SelectedColorItem != null)
            {
                Configuration.AccentColor = e.SelectedColorItem.Color;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing color in Colors palette. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Colors Palette Selection Changed Event Arguments. </param>
        private void ThemeColorsPaletteEx_ColorSelectionChanged(object sender, Events.ColorsPaletteSelectionChangedEventArgs e)
        {
            if (e?.SelectedColorItem != null)
            {
                Configuration.ThemeColor = e.SelectedColorItem.Color;
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
