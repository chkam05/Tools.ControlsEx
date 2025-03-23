using chkam05.Tools.ControlsEx.Data.Collections;
using chkam05.Tools.ControlsEx.Data.Enums;
using chkam05.Tools.ControlsEx.Data.Events;
using chkam05.Tools.ControlsEx.Resources;
using chkam05.Tools.ControlsEx.Utilities;
using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using static MaterialDesignThemes.Wpf.Theme;

namespace chkam05.Tools.ControlsEx
{
    public class HamburgerMenuEx : Control
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty CollapseOnSelectProperty = DependencyProperty.Register(
            nameof(CollapseOnSelect),
            typeof(bool),
            typeof(HamburgerMenuEx),
            new PropertyMetadata(false));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(HamburgerMenuEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty EnableExpandCollapseAnimationProperty = DependencyProperty.Register(
            nameof(EnableExpandCollapseAnimation),
            typeof(bool),
            typeof(HamburgerMenuEx),
            new PropertyMetadata(true));

        public static readonly DependencyProperty ExpandOnHoverProperty = DependencyProperty.Register(
            nameof(ExpandOnHover),
            typeof(bool),
            typeof(HamburgerMenuEx),
            new PropertyMetadata(true));

        public static readonly DependencyProperty ForegroundInactiveProperty = DependencyProperty.Register(
            nameof(ForegroundInactive),
            typeof(Brush),
            typeof(HamburgerMenuEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DarkInactive)));

        public static readonly DependencyProperty IconHeightProperty = DependencyProperty.Register(
            nameof(IconHeight),
            typeof(double),
            typeof(HamburgerMenuEx),
            new PropertyMetadata(24d));

        public static readonly DependencyProperty IconMarginProperty = DependencyProperty.Register(
            nameof(IconMargin),
            typeof(Thickness),
            typeof(HamburgerMenuEx),
            new PropertyMetadata(new Thickness(4)));

        public static readonly DependencyProperty IconWidthProperty = DependencyProperty.Register(
            nameof(IconWidth),
            typeof(double),
            typeof(HamburgerMenuEx),
            new PropertyMetadata(24d));

        public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register(
            nameof(IsExpanded),
            typeof(bool),
            typeof(HamburgerMenuEx),
            new PropertyMetadata(true, IsExpandedPropertyChangeCallback));

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
            nameof(ItemsSource),
            typeof(HamburgerMenuExCollection),
            typeof(HamburgerMenuEx),
            new PropertyMetadata(GetDefaultItems(), ItemsSourceChangedCallback));

        public static readonly DependencyProperty ItemsStyleProperty = DependencyProperty.Register(
            nameof(ItemsStyle),
            typeof(Style),
            typeof(HamburgerMenuEx),
            new PropertyMetadata(GetGenericHamburgerMenuItemExStyle()));

        public static readonly DependencyProperty ShowHeaderItemProperty = DependencyProperty.Register(
            nameof(ShowHeaderItem),
            typeof(bool),
            typeof(HamburgerMenuEx),
            new PropertyMetadata(false, ShowHeaderItemPropertyChangeCallback));

        public static readonly DependencyProperty TitleMarginProperty = DependencyProperty.Register(
            nameof(TitleMargin),
            typeof(Thickness),
            typeof(HamburgerMenuEx),
            new PropertyMetadata(new Thickness(4,0,8,0)));


        //  DELEGATES

        public delegate void HamburgerMenuExSelectionChangedEventHandler(object sender, HamburgerMenuExSelectionChangedEventArgs e);


        //  EVENTS

        public event HamburgerMenuExSelectionChangedEventHandler SelectionChanged;


        //  VARIABLES

        private ListViewEx bottomListViewEx;
        private Border separator;
        private ListViewEx topListViewEx;
        
        private bool enableAnimatedResize = false;
        private double expandedWidth = 0;


        //  GETTERS & SETTERS

        public bool CollapseOnSelect
        {
            get => (bool)GetValue(CollapseOnSelectProperty);
            set => SetValue(CollapseOnSelectProperty, value);
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public bool EnableExpandCollapseAnimation
        {
            get => (bool)GetValue(EnableExpandCollapseAnimationProperty);
            set => SetValue(EnableExpandCollapseAnimationProperty, value);
        }

        public bool ExpandOnHover
        {
            get => (bool)GetValue(ExpandOnHoverProperty);
            set => SetValue(ExpandOnHoverProperty, value);
        }

        public Brush ForegroundInactive
        {
            get => (Brush)GetValue(ForegroundInactiveProperty);
            set => SetValue(ForegroundInactiveProperty, value);
        }

        public double IconHeight
        {
            get => (double)GetValue(IconHeightProperty);
            set => SetValue(IconHeightProperty, value);
        }

        public Thickness IconMargin
        {
            get => (Thickness)GetValue(IconMarginProperty);
            set => SetValue(IconMarginProperty, value);
        }

        public double IconWidth
        {
            get => (double) GetValue(IconWidthProperty);
            set => SetValue(IconWidthProperty, value);
        }

        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }

        public HamburgerMenuExCollection ItemsSource
        {
            get => (HamburgerMenuExCollection)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public Style ItemsStyle
        {
            get => (Style)GetValue(ItemsStyleProperty);
            set => SetValue(ItemsStyleProperty, value);
        }

        public bool ShowHeaderItem
        {
            get => (bool)GetValue(ShowHeaderItemProperty);
            set => SetValue(ShowHeaderItemProperty, value);
        }

        public Thickness TitleMargin
        {
            get => (Thickness)GetValue(TitleMarginProperty);
            set => SetValue(TitleMarginProperty, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> HamburgerMenuEx class constructor. </summary>
        static HamburgerMenuEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HamburgerMenuEx),
                new FrameworkPropertyMetadata(typeof(HamburgerMenuEx)));

            WidthProperty.OverrideMetadata(typeof(HamburgerMenuEx),
                new FrameworkPropertyMetadata(
                    default(double),
                    FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender,
                    OnWidthPropertyChangeCallback
                ));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> HamburgerMenuEx class constructor. </summary>
        public HamburgerMenuEx()
        {
            Loaded += OnHamburgerMenuExLoaded;
            MouseEnter += OnHamburgerMenuExMouseEnter;
            MouseLeave += OnHamburgerMenuExMouseLeave;
        }

        #endregion CONSTRUCTORS

        #region ANIMATIONS

        //  --------------------------------------------------------------------------------
        /// <summary> Performs an animated resize. </summary>
        /// <param name="fromWidth"> Initial component size. </param>
        /// <param name="toWidth"> Final component size. </param>
        private void AnimateWidth(double fromWidth, double toWidth)
        {
            var widthAnimation = new DoubleAnimation()
            {
                From = fromWidth,
                To = toWidth,
                Duration = new Duration(TimeSpan.FromMilliseconds(300)),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };

            var storyboard = new Storyboard();
            Storyboard.SetTarget(widthAnimation, this);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(WidthProperty));
            storyboard.Children.Add(widthAnimation);

            storyboard.Begin();
        }

        #endregion ANIMATIONS

        #region COMPONENT

        //  --------------------------------------------------------------------------------
        /// <summary> Collapse component to compact size. </summary>
        private void Collapse()
        {
            if (GetMinWidth() is double minWidth)
            {
                if (Width >= expandedWidth)
                    expandedWidth = Width;
                MinWidth = minWidth;

                if (EnableExpandCollapseAnimation && enableAnimatedResize)
                    AnimateWidth(Width, minWidth);
                else
                    Width = minWidth;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Configures separator and its visibility. </summary>
        private void ConfigureSeparator()
        {
            if (separator != null)
            {
                var showSeparator = ItemsSource.Any(i => i.Position == HamburgerMenuExItemPosition.Top)
                    && ItemsSource.Any(i => i.Position == HamburgerMenuExItemPosition.Bottom);

                separator.Visibility = showSeparator ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Expands the component to full size. </summary>
        private void Expand()
        {
            if (EnableExpandCollapseAnimation && enableAnimatedResize)
                AnimateWidth(Width, expandedWidth);
            else
                Width = expandedWidth;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Calculates the minimum width of a component in Collapsed mode. </summary>
        /// <returns> Minimum component width or null. </returns>
        private double? GetMinWidth()
        {
            try
            {
                FrameworkElement childElement = ObjectUtilities.FindChildByName(this, "packIcon");
                double distance = ObjectUtilities.CalculateTotalDistance(childElement, this).X;
                return (distance * 2) + IconWidth;
            }
            catch
            {
                return null;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Ivoked after loading component. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed event arguments. </param>
        private void OnHamburgerMenuExLoaded(object sender, RoutedEventArgs e)
        {
            if (!IsExpanded)
                Collapse();

            ConfigureSeparator();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after the cursor leaves the component. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Mouse event arguments. </param>
        private void OnHamburgerMenuExMouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (ExpandOnHover && IsExpanded)
                InvokeWithAnimationResizeEnabled(() => IsExpanded = false);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after cursor hovering over a component. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Mouse event arguments. </param>
        private void OnHamburgerMenuExMouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (ExpandOnHover && !IsExpanded)
                InvokeWithAnimationResizeEnabled(() => IsExpanded = true);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Updates the component width taking into account the display mode. </summary>
        /// <param name="newWidth"> New component width. </param>
        private void UpdateWidth(double newWidth)
        {
            if (newWidth < expandedWidth)
                return;

            expandedWidth = newWidth;
        }

        #endregion COMPONENT

        #region ITEMS

        //  --------------------------------------------------------------------------------
        /// <summary> Creates a default ItemsSource collection. </summary>
        /// <returns> Default ItemsSource collection. </returns>
        private static HamburgerMenuExCollection GetDefaultItems()
        {
            return new HamburgerMenuExCollection();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Updates the collection after it has changed. </summary>
        private void OnCollectionUpdate()
        {
            ItemsSource.ShowHeaderItem = ShowHeaderItem;
            ConfigureSeparator();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Manages the selection of elements on the hamburger menu. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Selection changed event arguments. </param>
        private void OnViewExSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listViewEx = sender as ListViewEx;

            if (e.AddedItems.Count > 0)
            {
                var boundObject = e.AddedItems[0];

                if (boundObject is HamburgerMenuExItem viewModel)
                {
                    if (viewModel.ItemType == HamburgerMenuExItemType.Header)
                        InvokeWithAnimationResizeEnabled(() => IsExpanded = !IsExpanded);

                    SelectionChanged?.Invoke(this, new HamburgerMenuExSelectionChangedEventArgs(viewModel));
                    viewModel.Action?.Invoke();

                    listViewEx.SelectedItem = null;

                    if (viewModel.ItemType != HamburgerMenuExItemType.Header && IsExpanded && CollapseOnSelect)
                        InvokeWithAnimationResizeEnabled(() => IsExpanded = false);
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Updates the ShowHeaderItem and ShowBackItem parameters of the ItemsSource collection. </summary>
        /// <param name="showHeaderItem"> ShowHeaderItem parameter. </param>
        /// <param name="showHeaderItem"> ShowBackItem parameter. </param>
        private void UpdateItemsSourceWithStaticItems(bool? showHeaderItem = null)
        {
            if (ItemsSource == null)
            {
                ItemsSource = new HamburgerMenuExCollection(showHeaderItem ?? true);
            }
            else
            {
                ItemsSource.ShowHeaderItem = showHeaderItem ?? ItemsSource.ShowHeaderItem;
            }
        }

        #endregion ITEMS

        #region PROPERTIES CHANGED CALLBACKS

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when IsExpanded property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void IsExpandedPropertyChangeCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var hamburgerMenuEx = d as HamburgerMenuEx;

            if (hamburgerMenuEx != null && e.NewValue is bool newValue)
            {
                if (newValue)
                    hamburgerMenuEx.Expand();
                else
                    hamburgerMenuEx.Collapse();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when ItemsSource property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void ItemsSourceChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var hamburgerMenuEx = d as HamburgerMenuEx;

            if (hamburgerMenuEx != null)
            {
                if (e.NewValue is HamburgerMenuExCollection collection)
                    hamburgerMenuEx.OnCollectionUpdate();
                else
                    hamburgerMenuEx.ItemsSource = new HamburgerMenuExCollection();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when ShowHeaderItem property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void ShowHeaderItemPropertyChangeCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var hamburgerMenuEx = d as HamburgerMenuEx;

            if (hamburgerMenuEx != null && e.NewValue is bool newValue)
                hamburgerMenuEx.UpdateItemsSourceWithStaticItems(showHeaderItem: newValue);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when Width property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void OnWidthPropertyChangeCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var hamburgerMenuEx = d as HamburgerMenuEx;

            if (hamburgerMenuEx != null && e.NewValue is double newValue)
                hamburgerMenuEx.UpdateWidth(newValue);
        }

        #endregion PROPERTIES CHANGED CALLBACKS

        #region STYLES

        //  --------------------------------------------------------------------------------
        /// <summary> Get generic ColorPaletteItemEx style from resources. </summary>
        /// <returns> ColorPaletteItemEx style. </returns>
        protected static Style GetGenericHamburgerMenuItemExStyle()
        {
            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/HamburgerMenuEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary["HamburgerMenuEx.ListViewItemExStyle"] as Style;
        }

        #endregion STYLES

        #region TEMPLATE

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked whenever application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            bottomListViewEx = GetTemplateChild("bottomListView") as ListViewEx;
            separator = GetTemplateChild("separator") as Border;
            topListViewEx = GetTemplateChild("topListView") as ListViewEx;

            if (topListViewEx != null)
                topListViewEx.SelectionChanged += OnViewExSelectionChanged;

            if (bottomListViewEx != null)
                bottomListViewEx.SelectionChanged += OnViewExSelectionChanged;
        }

        #endregion TEMPLATE

        #region UTILITIES

        //  --------------------------------------------------------------------------------
        /// <summary> Invokes an action in the enabled animated resize mode. </summary>
        /// <param name="action"> The action that will be invoked. </param>
        private void InvokeWithAnimationResizeEnabled(Action action)
        {
            enableAnimatedResize = true;
            action?.Invoke();
            enableAnimatedResize = false;
        }

        #endregion UTILITIES

    }
}
