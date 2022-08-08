using chkam05.Tools.ControlsEx.Colors;
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

namespace chkam05.Tools.ControlsEx.InternalMessages
{
    public partial class PaletteColorInternalMessageEx : BaseColorInternalMessageEx
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty ColorsProperty = DependencyProperty.Register(
            nameof(Colors),
            typeof(ObservableCollection<ColorPaletteItem>),
            typeof(PaletteColorInternalMessageEx),
            new PropertyMetadata(new ObservableCollection<ColorPaletteItem>()));

        public static readonly DependencyProperty ColorsHistoryProperty = DependencyProperty.Register(
            nameof(ColorsHistory),
            typeof(ObservableCollection<ColorPaletteItem>),
            typeof(PaletteColorInternalMessageEx),
            new PropertyMetadata(new ObservableCollection<ColorPaletteItem>()));

        public static readonly DependencyProperty ColorsHistoryEnabledProperty = DependencyProperty.Register(
            nameof(ColorsHistoryEnabled),
            typeof(bool),
            typeof(PaletteColorInternalMessageEx),
            new PropertyMetadata(true));

        public static readonly DependencyProperty ColorsHistoryCountProperty = DependencyProperty.Register(
            nameof(ColorsHistoryCount),
            typeof(int),
            typeof(PaletteColorInternalMessageEx),
            new PropertyMetadata(5));

        public static readonly DependencyProperty ColorsHistoryTitleProperty = DependencyProperty.Register(
            nameof(ColorsHistoryTitle),
            typeof(string),
            typeof(PaletteColorInternalMessageEx),
            new PropertyMetadata("Recently used colors:"));

        public static readonly DependencyProperty ColorsTitleProperty = DependencyProperty.Register(
            nameof(ColorsTitle),
            typeof(string),
            typeof(PaletteColorInternalMessageEx),
            new PropertyMetadata("Colors palette:"));


        //  GETTERS & SETTERS

        public ObservableCollection<ColorPaletteItem> Colors
        {
            get => (ObservableCollection<ColorPaletteItem>)GetValue(ColorsProperty);
            set
            {
                SetValue(ColorsProperty, value);
                OnPropertyChanged(nameof(Colors));
            }
        }

        public ObservableCollection<ColorPaletteItem> ColorsHistory
        {
            get => (ObservableCollection<ColorPaletteItem>)GetValue(ColorsHistoryProperty);
            set
            {
                SetValue(ColorsHistoryProperty, value);
                OnPropertyChanged(nameof(ColorsHistory));
            }
        }

        public bool ColorsHistoryEnabled
        {
            get => (bool)GetValue(ColorsHistoryEnabledProperty);
            set
            {
                SetValue(ColorsHistoryEnabledProperty, value);
                OnPropertyChanged(nameof(ColorsHistoryEnabled));
            }
        }

        public int ColorsHistoryCount
        {
            get => (int)GetValue(ColorsHistoryCountProperty);
            set
            {
                SetValue(ColorsHistoryCountProperty, Math.Min(Math.Max(value, 1), ColorsPaletteEx.MAX_COLORS_HISTORY_COUNT));
                OnPropertyChanged(nameof(ColorsHistoryCount));
            }
        }

        public string ColorsHistoryTitle
        {
            get => (string)GetValue(ColorsHistoryTitleProperty);
            set
            {
                SetValue(ColorsHistoryTitleProperty, value);
                OnPropertyChanged(nameof(ColorsHistoryTitle));
            }
        }

        public string ColorsTitle
        {
            get => (string)GetValue(ColorsTitleProperty);
            set
            {
                SetValue(ColorsTitleProperty, value);
                OnPropertyChanged(nameof(ColorsTitle));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> PaletteColorInternalMessageEx class constructor. </summary>
        public PaletteColorInternalMessageEx() : base()
        {
            Colors = new ObservableCollection<ColorPaletteItem>(ColorsPaletteItems.Colors);
            ColorsHistory = new ObservableCollection<ColorPaletteItem>()
            {
                ColorsPaletteItems.Blue,
                ColorsPaletteItems.Red,
                ColorsPaletteItems.GoldYellow,
                ColorsPaletteItems.Green,
                ColorsPaletteItems.DarkGray
            };
            SelectedColor = ColorsHistory[0];

            //  Initialize interface components.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after selecting color. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Colors Palette Selection Changed Event Arguments. </param>
        private void ColorsPaletteEx_ColorSelectionChanged(object sender, Events.ColorsPaletteSelectionChangedEventArgs e)
        {
            SelectedColor = e.SelectedColorItem;
        }

        #endregion INTERACTION METHODS
    }
}
