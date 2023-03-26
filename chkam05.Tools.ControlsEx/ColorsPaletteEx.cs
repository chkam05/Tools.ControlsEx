using chkam05.Tools.ControlsEx.Colors;
using chkam05.Tools.ControlsEx.Static;
using chkam05.Tools.ControlsEx.Utilities;
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
using System.Windows.Media;
using static chkam05.Tools.ControlsEx.Events.Delegates;

namespace chkam05.Tools.ControlsEx
{
    public class ColorsPaletteEx : Control, INotifyPropertyChanged
    {

        //  CONST

        public static readonly int MAX_COLORS_HISTORY_COUNT = 10;


        //  DEPENDENCY PROPERTIES

        #region Item Appearance Properties

        public static readonly DependencyProperty ColorItemMouseOverBackgroundProperty = DependencyProperty.Register(
            nameof(ColorItemMouseOverBackground),
            typeof(Brush),
            typeof(ColorsPaletteEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty ColorItemMouseOverBorderBrushProperty = DependencyProperty.Register(
            nameof(ColorItemMouseOverBorderBrush),
            typeof(Brush),
            typeof(ColorsPaletteEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty ColorItemSelectedBackgroundProperty = DependencyProperty.Register(
            nameof(ColorItemSelectedBackground),
            typeof(Brush),
            typeof(ColorsPaletteEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_SELECTED)));

        public static readonly DependencyProperty ColorItemSelectedBorderBrushProperty = DependencyProperty.Register(
            nameof(ColorItemSelectedBorderBrush),
            typeof(Brush),
            typeof(ColorsPaletteEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_SELECTED)));

        public static readonly DependencyProperty ColorItemSelectedInactiveBackgroundProperty = DependencyProperty.Register(
            nameof(ColorItemSelectedInactiveBackground),
            typeof(Brush),
            typeof(ColorsPaletteEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_SELECTED_INACTIVE)));

        public static readonly DependencyProperty ColorItemSelectedInactiveBorderBrushProperty = DependencyProperty.Register(
            nameof(ColorItemSelectedInactiveBorderBrush),
            typeof(Brush),
            typeof(ColorsPaletteEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_SELECTED_INACTIVE)));

        #endregion Item Appearance Properties

        #region Item Properties

        public static readonly DependencyProperty ColorItemCornerRadiusProperty = DependencyProperty.Register(
            nameof(ColorItemCornerRadius),
            typeof(CornerRadius),
            typeof(ColorsPaletteEx),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));

        public static readonly DependencyProperty ColorItemHeightProperty = DependencyProperty.Register(
            nameof(ColorItemHeight),
            typeof(double),
            typeof(ColorsPaletteEx),
            new PropertyMetadata(48d));

        public static readonly DependencyProperty ColorItemKeepSelectedProperty = DependencyProperty.Register(
            nameof(ColorItemKeepSelected),
            typeof(bool),
            typeof(ColorsPaletteEx),
            new PropertyMetadata(false));

        public static readonly DependencyProperty ColorItemMarginProperty = DependencyProperty.Register(
            nameof(ColorItemMargin),
            typeof(Thickness),
            typeof(ColorsPaletteEx),
            new PropertyMetadata(new Thickness(1)));

        public static readonly DependencyProperty ColorItemPaddingProperty = DependencyProperty.Register(
            nameof(ColorItemPadding),
            typeof(Thickness),
            typeof(ColorsPaletteEx),
            new PropertyMetadata(new Thickness(1)));

        public static readonly DependencyProperty ColorItemWidthProperty = DependencyProperty.Register(
            nameof(ColorItemWidth),
            typeof(double),
            typeof(ColorsPaletteEx),
            new PropertyMetadata(48d));

        #endregion Item Properties

        public static readonly DependencyProperty AllowTransparentProperty = DependencyProperty.Register(
            nameof(AllowTransparent),
            typeof(bool),
            typeof(ColorsPaletteEx),
            new PropertyMetadata(false, new PropertyChangedCallback(OnAllowTransparentPropertyChanged)));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ColorsPaletteEx),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));

        public static readonly DependencyProperty ColorsProperty = DependencyProperty.Register(
            nameof(Colors),
            typeof(ObservableCollection<ColorPaletteItem>),
            typeof(ColorsPaletteEx),
            new PropertyMetadata(new ObservableCollection<ColorPaletteItem>()));

        public static readonly DependencyProperty ColorsHistoryProperty = DependencyProperty.Register(
            nameof(ColorsHistory),
            typeof(ObservableCollection<ColorPaletteItem>),
            typeof(ColorsPaletteEx),
            new PropertyMetadata(new ObservableCollection<ColorPaletteItem>()));

        public static readonly DependencyProperty ColorsHistoryEnabledProperty = DependencyProperty.Register(
            nameof(ColorsHistoryEnabled),
            typeof(bool),
            typeof(ColorsPaletteEx),
            new PropertyMetadata(true));

        public static readonly DependencyProperty ColorsHistoryCountProperty = DependencyProperty.Register(
            nameof(ColorsHistoryCount),
            typeof(int),
            typeof(ColorsPaletteEx),
            new PropertyMetadata(5));

        public static readonly DependencyProperty ColorsHistoryTitleProperty = DependencyProperty.Register(
            nameof(ColorsHistoryTitle),
            typeof(string),
            typeof(ColorsPaletteEx),
            new PropertyMetadata("Recently used colors:"));

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(ColorsPaletteEx),
            new PropertyMetadata("Colors palette:"));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;
        public event ColorsPalleteSelectionChanged ColorSelectionChanged;


        //  VARIABLES

        private ColorPaletteItem _selectedColorItem;


        //  GETTERS & SETTERS

        #region Item Appearance

        public Brush ColorItemMouseOverBackground
        {
            get => (Brush)GetValue(ColorItemMouseOverBackgroundProperty);
            set
            {
                SetValue(ColorItemMouseOverBackgroundProperty, value);
                OnPropertyChanged(nameof(ColorItemMouseOverBackground));
            }
        }

        public Brush ColorItemMouseOverBorderBrush
        {
            get => (Brush)GetValue(ColorItemMouseOverBorderBrushProperty);
            set
            {
                SetValue(ColorItemMouseOverBorderBrushProperty, value);
                OnPropertyChanged(nameof(ColorItemMouseOverBorderBrush));
            }
        }

        public Brush ColorItemSelectedBackground
        {
            get => (Brush)GetValue(ColorItemSelectedBackgroundProperty);
            set
            {
                SetValue(ColorItemSelectedBackgroundProperty, value);
                OnPropertyChanged(nameof(ColorItemSelectedBackground));
            }
        }

        public Brush ColorItemSelectedBorderBrush
        {
            get => (Brush)GetValue(ColorItemSelectedBorderBrushProperty);
            set
            {
                SetValue(ColorItemSelectedBorderBrushProperty, value);
                OnPropertyChanged(nameof(ColorItemSelectedBorderBrush));
            }
        }

        public Brush ColorItemSelectedInactiveBackground
        {
            get => (Brush)GetValue(ColorItemSelectedInactiveBackgroundProperty);
            set
            {
                SetValue(ColorItemSelectedInactiveBackgroundProperty, value);
                OnPropertyChanged(nameof(ColorItemSelectedInactiveBackground));
            }
        }

        public Brush ColorItemSelectedInactiveBorderBrush
        {
            get => (Brush)GetValue(ColorItemSelectedInactiveBorderBrushProperty);
            set
            {
                SetValue(ColorItemSelectedInactiveBorderBrushProperty, value);
                OnPropertyChanged(nameof(ColorItemSelectedInactiveBorderBrush));
            }
        }

        #endregion Item Appearance

        #region Item

        public CornerRadius ColorItemCornerRadius
        {
            get => (CornerRadius)GetValue(ColorItemCornerRadiusProperty);
            set
            {
                SetValue(ColorItemCornerRadiusProperty, value);
                OnPropertyChanged(nameof(ColorItemCornerRadius));
            }
        }

        public double ColorItemHeight
        {
            get => (double)GetValue(ColorItemHeightProperty);
            set
            {
                SetValue(ColorItemHeightProperty, value);
                OnPropertyChanged(nameof(ColorItemHeight));
            }
        }

        public bool ColorItemKeepSelected
        {
            get => (bool)GetValue(ColorItemKeepSelectedProperty);
            set
            {
                SetValue(ColorItemKeepSelectedProperty, value);
                OnPropertyChanged(nameof(ColorItemKeepSelected));
            }
        }

        public Thickness ColorItemMargin
        {
            get => (Thickness)GetValue(ColorItemMarginProperty);
            set
            {
                SetValue(ColorItemMarginProperty, value);
                OnPropertyChanged(nameof(ColorItemMargin));
            }
        }

        public Thickness ColorItemPadding
        {
            get => (Thickness)GetValue(ColorItemPaddingProperty);
            set
            {
                SetValue(ColorItemPaddingProperty, value);
                OnPropertyChanged(nameof(ColorItemPadding));
            }
        }

        public double ColorItemWidth
        {
            get => (double)GetValue(ColorItemWidthProperty);
            set
            {
                SetValue(ColorItemWidthProperty, value);
                OnPropertyChanged(nameof(ColorItemWidth));
            }
        }

        #endregion Item

        public bool AllowTransparent
        {
            get => (bool)GetValue(AllowTransparentProperty);
            set
            {
                SetValue(AllowTransparentProperty, value);
                OnPropertyChanged(nameof(AllowTransparent));
            }
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set
            {
                SetValue(CornerRadiusProperty, value);
                OnPropertyChanged(nameof(CornerRadius));
            }
        }

        public ObservableCollection<ColorPaletteItem> Colors
        {
            get => (ObservableCollection<ColorPaletteItem>)GetValue(ColorsProperty);
            set
            {
                value.CollectionChanged += OnCollectionChanged<ColorPaletteItem>;
                SetValue(ColorsProperty, value);
                OnPropertyChanged(nameof(Colors));
            }
        }

        public ObservableCollection<ColorPaletteItem> ColorsHistory
        {
            get => (ObservableCollection<ColorPaletteItem>)GetValue(ColorsHistoryProperty);
            set
            {
                var items = value?.ToList() ?? new List<ColorPaletteItem>();
                var observableCollection = new ObservableCollection<ColorPaletteItem>(
                    items.GetRange(0, Math.Min(items.Count, ColorsHistoryCount)));
                observableCollection.CollectionChanged += OnCollectionChanged<ColorPaletteItem>;
                SetValue(ColorsHistoryProperty, observableCollection);
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
                SetValue(ColorsHistoryCountProperty, Math.Min(Math.Max(value, 1), MAX_COLORS_HISTORY_COUNT));
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

        public ColorPaletteItem SelectedColorItem
        {
            get
            {
                if (_selectedColorItem == null)
                    _selectedColorItem = ColorsHistory.FirstOrDefault();

                return _selectedColorItem;
            }
            set
            {
                _selectedColorItem = value;
                OnPropertyChanged(nameof(SelectedColorItem));
            }
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set
            {
                SetValue(TitleProperty, value);
                OnPropertyChanged(nameof(Title));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ColorsPaletteEx class constructor. </summary>
        public ColorsPaletteEx()
        {
            UpdateColorsList();
            ColorsHistory = new ObservableCollection<ColorPaletteItem>()
            {
                ColorsPaletteItems.Blue,
                ColorsPaletteItems.Red,
                ColorsPaletteItems.GoldYellow,
                ColorsPaletteItems.Green,
                ColorsPaletteItems.DarkGray
            };
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static ColorsPaletteEx class constructor. </summary>
        static ColorsPaletteEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorsPaletteEx),
                new FrameworkPropertyMetadata(typeof(ColorsPaletteEx)));
        }

        #endregion CLASS METHODS

        #region DATA MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after selecting item in color palette items list view. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Selection Changed Event Arguments. </param>
        protected void OnColorPaletteItemSelected(object sender, SelectionChangedEventArgs e)
        {
            var listView = (ListViewEx)sender;
            var currentHashCode = listView.GetHashCode();
            var historyHashCode = this.GetListView("historyColorsListView").GetHashCode();
            var hashCode = this.GetListView("colorsListView").GetHashCode();
            var selectedItem = listView.SelectedItem;

            if (selectedItem != null)
            {
                var colorPaletteItem = selectedItem as ColorPaletteItem;

                if (colorPaletteItem != null && (currentHashCode == historyHashCode || currentHashCode == hashCode))
                {
                    AddColorToHistory(colorPaletteItem);
                    SelectedColorItem = colorPaletteItem;

                    var eventArgs = new Events.ColorsPaletteSelectionChangedEventArgs(colorPaletteItem);
                    ColorSelectionChanged?.Invoke(this, eventArgs);
                }

                if (!ColorItemKeepSelected)
                {
                    listView.SelectedIndex = -1;
                    listView.SelectedItem = null;
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Add color to Colors palette. </summary>
        /// <param name="colorPaletteItem"> ColorPaletteItem to add. </param>
        public void AddColor(ColorPaletteItem colorPaletteItem)
        {
            if (colorPaletteItem != null
                    && colorPaletteItem.Color != System.Windows.Media.Colors.Transparent
                    && !Colors.Any(c => c == colorPaletteItem))
            {
                Colors.Add(colorPaletteItem);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Add color to Colors history. </summary>
        /// <param name="colorPaletteItem"> ColorPaletteItem to add. </param>
        public void AddColorToHistory(ColorPaletteItem colorPaletteItem)
        {
            if (colorPaletteItem != null)
            {
                if (ColorsHistory.Any(c => c == colorPaletteItem))
                {
                    var currentColors = ColorsHistory.Where(c => c == colorPaletteItem).ToList();
                    foreach (var color in currentColors)
                        ColorsHistory.Remove(color);
                }

                if (ColorsHistory.Count >= ColorsHistoryCount)
                    while (ColorsHistory.Count >= ColorsHistoryCount)
                        ColorsHistory.RemoveAt(ColorsHistory.Count - 1);

                ColorsHistory.Insert(0, colorPaletteItem);
            };
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Insert color to Colors palette at specified index. </summary>
        /// <param name="colorPaletteItem"> ColorPaletteItem to add. </param>
        /// <param name="index"> Index of place where Color palette item will be placed. </param>
        public void InsertColor(ColorPaletteItem colorPaletteItem, int index = 0)
        {
            if (colorPaletteItem != null
                    && colorPaletteItem.Color != System.Windows.Media.Colors.Transparent
                    && !Colors.Any(c => c == colorPaletteItem) 
                    && index >= 0 && index < Colors.Count)
            {
                ColorsHistory.Insert(index, colorPaletteItem);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Insert color to Colors history at specified index. </summary>
        /// <param name="colorPaletteItem"> ColorPaletteItem to add. </param>
        /// <param name="index"> Index of place where Color palette item will be placed. </param>
        public void InsertColorToHistory(ColorPaletteItem colorPaletteItem, int index = 0)
        {
            if (colorPaletteItem != null
                    && colorPaletteItem.Color != System.Windows.Media.Colors.Transparent 
                    && index >= 0 && index < ColorsHistoryCount)
            {
                if (ColorsHistory.Any(c => c == colorPaletteItem))
                {
                    var currentColors = ColorsHistory.Where(c => c == colorPaletteItem).ToList();
                    foreach (var color in currentColors)
                        ColorsHistory.Remove(color);
                }

                if (ColorsHistory.Count >= ColorsHistoryCount)
                    while (ColorsHistory.Count >= ColorsHistoryCount)
                        ColorsHistory.RemoveAt(ColorsHistory.Count - 1);

                ColorsHistory.Insert(Math.Min(Math.Max(index, 0), ColorsHistory.Count - 1), colorPaletteItem);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Remove color from Colors palette. </summary>
        /// <param name="colorPaletteItem"> ColorPaletteItem to remove. </param>
        public void RemoveColor(ColorPaletteItem colorPaletteItem)
        {
            if (colorPaletteItem != null && Colors.Any(c => c == colorPaletteItem))
            {
                var currentColors = Colors.Where(c => c == colorPaletteItem).ToList();
                foreach (var color in currentColors)
                    Colors.Remove(color);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Remove color from Colors history. </summary>
        /// <param name="colorPaletteItem"> ColorPaletteItem to remove. </param>
        public void RemoveColorFromHistory(ColorPaletteItem colorPaletteItem)
        {
            if (colorPaletteItem != null && ColorsHistory.Any(c => c == colorPaletteItem))
            {
                var currentColors = ColorsHistory.Where(c => c == colorPaletteItem).ToList();
                foreach (var color in currentColors)
                    ColorsHistory.Remove(color);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Remove color from Color palette with specified index. </summary>
        /// <param name="index"> Index of item to remove. </param>
        public void RemoveColorAt(int index)
        {
            if (index >= 0 && index < Colors.Count)
                Colors.RemoveAt(index);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Remove color from Color history with specified index. </summary>
        /// <param name="index"> Index of item to remove. </param>
        public void RemoveColorFromHistoryAt(int index)
        {
            if (index >= 0 && index < ColorsHistoryCount)
                ColorsHistory.RemoveAt(Math.Min(Math.Max(index, 0), ColorsHistory.Count - 1));
        }

        #endregion DATA MANAGEMENT METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after updating allow transparency property. </summary>
        /// <param name="o"> Dependency object. </param>
        /// <param name="e"> Dependency Property Changed Event Arguments. </param>
        protected static void OnAllowTransparentPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var instance = o as ColorsPaletteEx;
            instance.UpdateColorsList();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing lyrics collection. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Notify Collection Changed Event Arguments. </param>
        protected void OnCollectionChanged<T>(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (T item in e.OldItems)
                    if (item is INotifyPropertyChanged)
                        ((INotifyPropertyChanged)item).PropertyChanged -= (s, e1)
                            => OnCollectionItemChanged<T>(s, e1);
            }

            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (T item in e.NewItems)
                    if (item is INotifyPropertyChanged)
                        ((INotifyPropertyChanged)item).PropertyChanged += (s, e1)
                            => OnCollectionItemChanged<T>(s, e1);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after chaning any value in lyrics in lyrics collection. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Property Changed Event Arguments. </param>
        protected void OnCollectionItemChanged<T>(object sender, PropertyChangedEventArgs e)
        {
            //
        }

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

        #region TEMPLATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> When overridden in a derived class,cis invoked whenever 
        /// application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            //  Apply Template
            base.OnApplyTemplate();

            ApplySelectMethod(GetListView("colorsListView"), OnColorPaletteItemSelected);
            ApplySelectMethod(GetListView("historyColorsListView"), OnColorPaletteItemSelected);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get ListViewEx from ContentTemplate. </summary>
        /// <param name="listViewName"> ListViewEx name. </param>
        /// <returns> ListViewEx or null. </returns>
        protected ListViewEx GetListView(string listViewName)
        {
            return this.Template.FindName(listViewName, this) as ListViewEx;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Apply SelectionChanged method on ListViewEx. </summary>
        /// <param name="listViewEx"> ListViewEx. </param>
        /// <param name="eventHandler"> SelectionChanged method. </param>
        protected void ApplySelectMethod(ListViewEx listViewEx, SelectionChangedEventHandler eventHandler)
        {
            if (listViewEx != null)
                listViewEx.SelectionChanged += eventHandler;
        }

        #endregion TEMPLATE METHODS

        #region UPDATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Update colors list. </summary>
        private void UpdateColorsList()
        {
            var colors = new List<ColorPaletteItem>(ColorsPaletteItems.Colors);

            if (AllowTransparent)
                colors.Insert(0, ColorsPaletteItems.Transparent);

            Colors = new ObservableCollection<ColorPaletteItem>(colors);
        }

        #endregion UPDATE METHODS

    }
}
