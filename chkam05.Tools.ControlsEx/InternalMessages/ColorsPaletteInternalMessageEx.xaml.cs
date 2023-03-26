using chkam05.Tools.ControlsEx.Colors;
using chkam05.Tools.ControlsEx.Events;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

namespace chkam05.Tools.ControlsEx.InternalMessages
{
    public partial class ColorsPaletteInternalMessageEx : BaseColorSelectorInternalMessageEx
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty AllowTransparentProperty = DependencyProperty.Register(
            nameof(AllowTransparent),
            typeof(bool),
            typeof(ColorsPaletteInternalMessageEx),
            new PropertyMetadata(false));

        public static readonly DependencyProperty ColorsHistoryProperty = DependencyProperty.Register(
            nameof(ColorsHistory),
            typeof(ObservableCollection<ColorPaletteItem>),
            typeof(ColorsPaletteInternalMessageEx),
            new PropertyMetadata(new ObservableCollection<ColorPaletteItem>()));

        public static readonly DependencyProperty ColorsHistoryEnabledProperty = DependencyProperty.Register(
            nameof(ColorsHistoryEnabled),
            typeof(bool),
            typeof(ColorsPaletteInternalMessageEx),
            new PropertyMetadata(true));

        public static readonly DependencyProperty ColorsHistoryCountProperty = DependencyProperty.Register(
            nameof(ColorsHistoryCount),
            typeof(int),
            typeof(ColorsPaletteInternalMessageEx),
            new PropertyMetadata(5));

        public static readonly DependencyProperty ColorsHistoryTitleProperty = DependencyProperty.Register(
            nameof(ColorsHistoryTitle),
            typeof(string),
            typeof(ColorsPaletteInternalMessageEx),
            new PropertyMetadata("Recently used colors:"));

        public static readonly DependencyProperty ColorsPaletteTitleProperty = DependencyProperty.Register(
            nameof(ColorsPaletteTitle),
            typeof(string),
            typeof(ColorsPaletteInternalMessageEx),
            new PropertyMetadata("Colors palette:"));


        //  VARIABLES

        public bool AllowTransparent
        {
            get => (bool)GetValue(AllowTransparentProperty);
            set
            {
                SetValue(AllowTransparentProperty, value);
                OnPropertyChanged(nameof(AllowTransparent));
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
                SetValue(ColorsHistoryCountProperty, value);
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

        public string ColorsPaletteTitle
        {
            get => (string)GetValue(ColorsPaletteTitleProperty);
            set
            {
                SetValue(ColorsPaletteTitleProperty, value);
                OnPropertyChanged(nameof(ColorsPaletteTitle));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ColorsPaletteInternalMessageEx class constructor. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        /// <param name="title"> Message title. </param>
        /// <param name="icon"> Message header icon kind. </param>
        public ColorsPaletteInternalMessageEx(InternalMessagesExContainer parentContainer, string title = "Select color",
            PackIconKind icon = PackIconKind.Palette) : base(parentContainer)
        {
            ColorsHistory = new ObservableCollection<ColorPaletteItem>()
            {
                ColorsPaletteItems.Blue,
                ColorsPaletteItems.Red,
                ColorsPaletteItems.GoldYellow,
                ColorsPaletteItems.Green,
                ColorsPaletteItems.DarkGray
            };

            Title = title;
            IconKind = icon;

            //  Initialize interface components.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region MESSAGE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing color selection in colors palette. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Colors Palette Selection Changed Event Args. </param>
        private void OnColorSelectionChanged(object sender, ColorsPaletteSelectionChangedEventArgs e)
        {
            if (e.SelectedColorItem != null)
            {
                SelectedColor = e.SelectedColorItem.Color;
                SelectedColorCode = e.SelectedColorItem.ColorCode;
                SelectedColorName = e.SelectedColorItem.Name;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading message. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed event arguments. </param>
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (ColorsHistory.Any() && SelectedColor != ColorsHistory.First().Color)
                ColorsHistory.Insert(0, new ColorPaletteItem(SelectedColor, SelectedColorName));
        }

        #endregion MESSAGE METHODS

    }
}
