using chkam05.Tools.ControlsEx.Static;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace chkam05.Tools.ControlsEx
{
    public class MenuEx : Menu, INotifyPropertyChanged
    {

        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty SubMenuBackgroundProperty = DependencyProperty.Register(
            nameof(SubMenuBackground),
            typeof(Brush),
            typeof(MenuEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_COLOR)));

        public static readonly DependencyProperty SubMenuBorderBrushProperty = DependencyProperty.Register(
            nameof(SubMenuBorderBrush),
            typeof(Brush),
            typeof(MenuEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        #endregion Appearance Colors Properties

        public static readonly DependencyProperty SubMenuBorderThicknessProperty = DependencyProperty.Register(
            nameof(SubMenuBorderThickness),
            typeof(Thickness),
            typeof(MenuEx),
            new PropertyMetadata(new Thickness(1)));

        public static readonly DependencyProperty SubMenuCornerRadiusProperty = DependencyProperty.Register(
            nameof(SubMenuCornerRadius),
            typeof(CornerRadius),
            typeof(MenuEx),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));

        public static readonly DependencyProperty SubMenuPaddingProperty = DependencyProperty.Register(
            nameof(SubMenuPadding),
            typeof(Thickness),
            typeof(MenuEx),
            new PropertyMetadata(new Thickness(2, 1, 2, 1)));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  GETTERS & SETTERS

        #region Appearance Colors

        public Brush SubMenuBackground
        {
            get => (Brush)GetValue(SubMenuBackgroundProperty);
            set
            {
                SetValue(SubMenuBackgroundProperty, value);
                OnPropertyChanged(nameof(SubMenuBackground));
            }
        }

        public Brush SubMenuBorderBrush
        {
            get => (Brush)GetValue(SubMenuBorderBrushProperty);
            set
            {
                SetValue(SubMenuBorderBrushProperty, value);
                OnPropertyChanged(nameof(SubMenuBorderBrush));
            }
        }

        #endregion Appearance Colors

        public Thickness SubMenuBorderThickness
        {
            get => (Thickness)GetValue(SubMenuBorderThicknessProperty);
            set
            {
                SetValue(SubMenuBorderThicknessProperty, value);
                OnPropertyChanged(nameof(SubMenuBorderThickness));
            }
        }

        public CornerRadius SubMenuCornerRadius
        {
            get => (CornerRadius)GetValue(SubMenuCornerRadiusProperty);
            set
            {
                SetValue(SubMenuCornerRadiusProperty, value);
                OnPropertyChanged(nameof(SubMenuCornerRadius));
            }
        }

        public Thickness SubMenuPadding
        {
            get => (Thickness)GetValue(SubMenuPaddingProperty);
            set
            {
                SetValue(SubMenuPaddingProperty, value);
                OnPropertyChanged(nameof(SubMenuPadding));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Static ContextMenuEx class constructor. </summary>
        static MenuEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuEx),
                new FrameworkPropertyMetadata(typeof(MenuEx)));
        }

        #endregion CLASS METHODS

        #region ITEMS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Creates and returns new MenuItemEx container. </summary>
        /// <returns> A new MenuItemEx control. </returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new MenuItemEx();
        }

        #endregion ITEMS METHODS

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
