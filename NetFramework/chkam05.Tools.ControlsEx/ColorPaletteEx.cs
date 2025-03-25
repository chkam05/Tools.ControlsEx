using chkam05.Tools.ControlsEx.Data.Collections;
using chkam05.Tools.ControlsEx.Data.Events;
using chkam05.Tools.ControlsEx.Resources;
using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace chkam05.Tools.ControlsEx
{
    public class ColorPaletteEx : Control
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundInactiveProperty = DependencyProperty.Register(
            nameof(BackgroundInactive),
            typeof(Brush),
            typeof(ColorPaletteEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty BorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(BorderBrushInactive),
            typeof(Brush),
            typeof(ColorPaletteEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ColorPaletteEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty HorizontalScrollBarVisibilityProperty = DependencyProperty.Register(
            nameof(HorizontalScrollBarVisibility),
            typeof(ScrollBarVisibility),
            typeof(ColorPaletteEx),
            new PropertyMetadata(ScrollBarVisibility.Disabled));

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
            nameof(ItemsSource),
            typeof(ColorPaletteExCollection),
            typeof(ColorPaletteEx),
            new PropertyMetadata(GetDefaultItems()));

        public static readonly DependencyProperty ItemsStyleProperty = DependencyProperty.Register(
            nameof(ItemsStyle),
            typeof(Style),
            typeof(ColorPaletteEx),
            new PropertyMetadata(GetGenericColorPaletteItemExStyle()));

        public static readonly DependencyProperty ScrollViewerStyleProperty = DependencyProperty.Register(
            nameof(ScrollViewerStyle),
            typeof(Style),
            typeof(ColorPaletteEx),
            new PropertyMetadata(GetGenericScrollViewerExStyle()));

        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
            nameof(SelectedItem),
            typeof(ColorPaletteExItem),
            typeof(ColorPaletteEx),
            new PropertyMetadata(null));

        public static readonly DependencyProperty ShowAddItemProperty = DependencyProperty.Register(
            nameof(ShowAddItem),
            typeof(bool),
            typeof(ColorPaletteEx),
            new PropertyMetadata(false, ShowAddItemPropertyChangeCallback));

        public static readonly DependencyProperty VerticalScrollBarVisibilityProperty = DependencyProperty.Register(
            nameof(VerticalScrollBarVisibility),
            typeof(ScrollBarVisibility),
            typeof(ColorPaletteEx),
            new PropertyMetadata(ScrollBarVisibility.Auto));


        //  DELEGATES

        public delegate void ColorPaletteExSelectionChangedEventHandler(object sender, ColorPaletteExSelectionChangedEventArgs e);


        //  EVENTS

        public event ColorPaletteExSelectionChangedEventHandler SelectionChanged;


        //  VARIABLES

        private ListViewEx listViewEx;


        //  GETTERS & SETTERS

        public Brush BackgroundInactive
        {
            get => (Brush)GetValue(BackgroundInactiveProperty);
            set => SetValue(BackgroundInactiveProperty, value);
        }

        public Brush BorderBrushInactive
        {
            get => (Brush)GetValue(BorderBrushInactiveProperty);
            set => SetValue(BorderBrushInactiveProperty, value);
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public ScrollBarVisibility HorizontalScrollBarVisibility
        {
            get => (ScrollBarVisibility)GetValue(HorizontalScrollBarVisibilityProperty);
            set => SetValue(VerticalScrollBarVisibilityProperty, value);
        }

        public ColorPaletteExCollection ItemsSource
        {
            get => (ColorPaletteExCollection)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public Style ItemsStyle
        {
            get => (Style)GetValue(ItemsStyleProperty);
            set => SetValue(ItemsStyleProperty, value);
        }

        public Style ScrollViewerStyle
        {
            get => (Style)GetValue(ScrollViewerStyleProperty);
            set => SetValue(ScrollViewerStyleProperty, value);
        }

        public ColorPaletteExItem SelectedItem
        {
            get => (ColorPaletteExItem)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public bool ShowAddItem
        {
            get => (bool)GetValue(ShowAddItemProperty);
            set => SetValue(ShowAddItemProperty, value);
        }

        public ScrollBarVisibility VerticalScrollBarVisibility
        {
            get => (ScrollBarVisibility)GetValue(VerticalScrollBarVisibilityProperty);
            set => SetValue(VerticalScrollBarVisibilityProperty, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ColorPaletteEx class constructor. </summary>
        static ColorPaletteEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorPaletteEx),
                new FrameworkPropertyMetadata(typeof(ColorPaletteEx)));
        }

        #endregion CONSTRUCTORS

        #region ITEMS

        //  --------------------------------------------------------------------------------
        /// <summary> Creates a default ItemsSource collection. </summary>
        /// <returns> Default ItemsSource collection. </returns>
        private static ColorPaletteExCollection GetDefaultItems()
        {
            return new ColorPaletteExCollection(ColorsResources.GetPaletteColors()
                .Select(cx => new ViewModels.ColorPaletteExItem(cx)));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Manages the selection of elements on the color palette. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Selection changed event arguments. </param>
        private void OnViewExSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listViewEx = sender as ListViewEx;

            if (e.AddedItems.Count > 0)
            {
                var boundObject = e.AddedItems[0];

                if (boundObject is ColorPaletteExItem viewModel)
                {
                    SelectionChanged?.Invoke(this, new ColorPaletteExSelectionChangedEventArgs(SelectedItem, this.IsFocused));

                    if (ShowAddItem && viewModel.IsAddItem)
                        listViewEx.SelectedItem = null;

                    SelectedItem = viewModel;
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Updates the ShowAddItem parameter of the ItemsSource collection. </summary>
        /// <param name="showAddItem"> ShowAddItem parameter. </param>
        private void UpdateItemsSourceWithAddItem(bool showAddItem)
        {
            if (ItemsSource == null)
                ItemsSource = new ColorPaletteExCollection(showAddItem);

            ItemsSource.ShowAddItem = showAddItem;
        }

        #endregion ITEMS

        #region PROPERTIES CHANGED CALLBACKS

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when ShowAddItem property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void ShowAddItemPropertyChangeCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var colorPaletteEx = d as ColorPaletteEx;

            if (colorPaletteEx != null && e.NewValue is bool newValue)
                colorPaletteEx.UpdateItemsSourceWithAddItem(newValue);
        }

        #endregion PROPERTIES CHANGED CALLBACKS

        #region STYLES

        //  --------------------------------------------------------------------------------
        /// <summary> Get generic ColorPaletteItemEx style from resources. </summary>
        /// <returns> ColorPaletteItemEx style. </returns>
        protected static Style GetGenericColorPaletteItemExStyle()
        {
            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/ColorPaletteEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary["ColorPaletteEx.ListViewItemExStyle"] as Style;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get generic ScrollViewerEx style from resources. </summary>
        /// <returns> ScrollViewerEx style. </returns>
        protected static Style GetGenericScrollViewerExStyle()
        {
            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/ScrollViewerEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary["ScrollViewerExStyle"] as Style;
        }

        #endregion STYLES

        #region TEMPLATE

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked whenever application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            listViewEx = GetTemplateChild("listView") as ListViewEx;

            if (listViewEx != null)
                listViewEx.SelectionChanged += OnViewExSelectionChanged;
        }

        #endregion TEMPLATE

    }
}
