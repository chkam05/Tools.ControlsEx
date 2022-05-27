using chkam05.Tools.ControlsEx.Static;
using MaterialDesignThemes.Wpf;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace chkam05.Tools.ControlsEx
{
    public class MenuItemEx : MenuItem, INotifyPropertyChanged
    {

        //  CONST

        protected readonly static double CHECK_MARK_HEIGHT = 22d;
        protected readonly static double CHECK_MARK_WIDTH = 22d;
        protected readonly static double ICON_HEIGHT = 16d;
        protected readonly static double ICON_WIDTH = 16d;


        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty CheckMarkColorBrushProperty = DependencyProperty.Register(
            nameof(CheckMarkColorBrush),
            typeof(Brush),
            typeof(MenuItemEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty IconColorBrushProperty = DependencyProperty.Register(
            nameof(IconColorBrush),
            typeof(Brush),
            typeof(MenuItemEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty MouseOverBackgroundProperty = DependencyProperty.Register(
            nameof(MouseOverBackground),
            typeof(Brush),
            typeof(MenuItemEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty MouseOverBorderBrushProperty = DependencyProperty.Register(
            nameof(MouseOverBorderBrush),
            typeof(Brush),
            typeof(MenuItemEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty MouseOverForegroundProperty = DependencyProperty.Register(
            nameof(MouseOverForeground),
            typeof(Brush),
            typeof(MenuItemEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        #endregion Appearance Colors Properties

        #region CheckBox Properties

        public static readonly DependencyProperty CheckBoxStyleProperty = DependencyProperty.Register(
            nameof(CheckBoxStyle),
            typeof(CheckBoxStyle),
            typeof(MenuItemEx),
            new PropertyMetadata(CheckBoxStyle.Mixed));

        public static readonly DependencyProperty CheckMarkHeightProperty = DependencyProperty.Register(
            nameof(CheckMarkHeight),
            typeof(double),
            typeof(MenuItemEx),
            new PropertyMetadata(CHECK_MARK_HEIGHT));

        public static readonly DependencyProperty CheckMarkMarginProperty = DependencyProperty.Register(
            nameof(CheckMarkMargin),
            typeof(Thickness),
            typeof(MenuItemEx),
            new PropertyMetadata(new Thickness(-1, 0, 0, 0)));

        public static readonly DependencyProperty CheckMarkMaxHeightProperty = DependencyProperty.Register(
            nameof(CheckMarkMaxHeight),
            typeof(double),
            typeof(MenuItemEx),
            new PropertyMetadata(double.NaN));

        public static readonly DependencyProperty CheckMarkMaxWidthProperty = DependencyProperty.Register(
            nameof(CheckMarkMaxWidth),
            typeof(double),
            typeof(MenuItemEx),
            new PropertyMetadata(double.NaN));

        public static readonly DependencyProperty CheckMarkMinHeightProperty = DependencyProperty.Register(
            nameof(CheckMarkMinHeight),
            typeof(double),
            typeof(MenuItemEx),
            new PropertyMetadata(0d));

        public static readonly DependencyProperty CheckMarkMinWidthProperty = DependencyProperty.Register(
            nameof(CheckMarkMinWidth),
            typeof(double),
            typeof(MenuItemEx),
            new PropertyMetadata(0d));

        public static readonly DependencyProperty CheckMarkWidthProperty = DependencyProperty.Register(
            nameof(CheckMarkWidth),
            typeof(double),
            typeof(MenuItemEx),
            new PropertyMetadata(CHECK_MARK_WIDTH));

        #endregion CheckBox Properties

        #region Icon Properties

        public static readonly DependencyProperty IconHeightProperty = DependencyProperty.Register(
            nameof(IconHeight),
            typeof(double),
            typeof(MenuItemEx),
            new PropertyMetadata(ICON_HEIGHT));

        public static readonly DependencyProperty IconKindProperty = DependencyProperty.Register(
            nameof(IconKind),
            typeof(PackIconKind),
            typeof(MenuItemEx),
            new PropertyMetadata(StaticResources.DEFAULT_ICON_KIND));

        public static readonly DependencyProperty IconMarginProperty = DependencyProperty.Register(
            nameof(IconMargin),
            typeof(Thickness),
            typeof(MenuItemEx),
            new PropertyMetadata(new Thickness(0)));

        public static readonly DependencyProperty IconMaxHeightProperty = DependencyProperty.Register(
            nameof(IconMaxHeight),
            typeof(double),
            typeof(MenuItemEx),
            new PropertyMetadata(double.NaN));

        public static readonly DependencyProperty IconMaxWidthProperty = DependencyProperty.Register(
            nameof(IconMaxWidth),
            typeof(double),
            typeof(MenuItemEx),
            new PropertyMetadata(double.NaN));

        public static readonly DependencyProperty IconMinHeightProperty = DependencyProperty.Register(
            nameof(IconMinHeight),
            typeof(double),
            typeof(MenuItemEx),
            new PropertyMetadata(0d));

        public static readonly DependencyProperty IconMinWidthProperty = DependencyProperty.Register(
            nameof(IconMinWidth),
            typeof(double),
            typeof(MenuItemEx),
            new PropertyMetadata(0d));

        public static readonly DependencyProperty IconWidthProperty = DependencyProperty.Register(
            nameof(IconWidth),
            typeof(double),
            typeof(MenuItemEx),
            new PropertyMetadata(ICON_WIDTH));

        #endregion Icon Properties

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(MenuItemEx),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  GETTERS & SETTERS

        #region Appearance Colors

        public Brush CheckMarkColorBrush
        {
            get => (Brush)GetValue(CheckMarkColorBrushProperty);
            set
            {
                SetValue(CheckMarkColorBrushProperty, value);
                OnPropertyChanged(nameof(CheckMarkColorBrush));
            }
        }

        public Brush IconColorBrush
        {
            get => (Brush)GetValue(IconColorBrushProperty);
            set
            {
                SetValue(IconColorBrushProperty, value);
                OnPropertyChanged(nameof(IconColorBrush));
            }
        }

        public Brush MouseOverBackground
        {
            get => (Brush)GetValue(MouseOverBackgroundProperty);
            set
            {
                SetValue(MouseOverBackgroundProperty, value);
                OnPropertyChanged(nameof(MouseOverBackground));
            }
        }

        public Brush MouseOverBorderBrush
        {
            get => (Brush)GetValue(MouseOverBorderBrushProperty);
            set
            {
                SetValue(MouseOverBorderBrushProperty, value);
                OnPropertyChanged(nameof(MouseOverBorderBrush));
            }
        }

        public Brush MouseOverForeground
        {
            get => (Brush)GetValue(MouseOverForegroundProperty);
            set
            {
                SetValue(MouseOverForegroundProperty, value);
                OnPropertyChanged(nameof(MouseOverForeground));
            }
        }

        #endregion Appearance Colors

        #region CheckBox

        public CheckBoxStyle CheckBoxStyle
        {
            get => (CheckBoxStyle)GetValue(CheckBoxStyleProperty);
            set
            {
                SetValue(CheckBoxStyleProperty, value);
                OnPropertyChanged(nameof(CheckBoxStyle));
            }
        }

        public double CheckMarkHeight
        {
            get => (double)GetValue(CheckMarkHeightProperty);
            set
            {
                SetValue(CheckMarkHeightProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(CheckMarkHeight));
            }
        }

        public Thickness CheckMarkMargin
        {
            get => (Thickness)GetValue(CheckMarkMarginProperty);
            set
            {
                SetValue(CheckMarkMarginProperty, value);
                OnPropertyChanged(nameof(CheckMarkMargin));
            }
        }

        public double CheckMarkMaxHeight
        {
            get => (double)GetValue(CheckMarkMaxHeightProperty);
            set
            {
                SetValue(CheckMarkMaxHeightProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(CheckMarkMaxHeight));
            }
        }

        public double CheckMarkMaxWidth
        {
            get => (double)GetValue(CheckMarkMaxWidthProperty);
            set
            {
                SetValue(CheckMarkMaxWidthProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(CheckMarkMaxWidth));
            }
        }

        public double CheckMarkMinHeight
        {
            get => (double)GetValue(CheckMarkMinHeightProperty);
            set
            {
                SetValue(CheckMarkMinHeightProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(CheckMarkMinHeight));
            }
        }

        public double CheckMarkMinWidth
        {
            get => (double)GetValue(CheckMarkMinWidthProperty);
            set
            {
                SetValue(CheckMarkMinWidthProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(CheckMarkMinWidth));
            }
        }

        public double CheckMarkWidth
        {
            get => (double)GetValue(CheckMarkWidthProperty);
            set
            {
                SetValue(CheckMarkWidthProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(CheckMarkWidth));
            }
        }

        #endregion CheckBox

        #region Icon

        public double IconHeight
        {
            get => (double)GetValue(IconHeightProperty);
            set
            {
                SetValue(IconHeightProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(IconHeight));
            }
        }

        public PackIconKind IconKind
        {
            get => (PackIconKind)GetValue(IconKindProperty);
            set
            {
                SetValue(IconKindProperty, value);
                OnPropertyChanged(nameof(IconKindProperty));
            }
        }

        public Thickness IconMargin
        {
            get => (Thickness)GetValue(IconMarginProperty);
            set
            {
                SetValue(IconMarginProperty, value);
                OnPropertyChanged(nameof(IconMargin));
            }
        }

        public double IconMaxHeight
        {
            get => (double)GetValue(IconMaxHeightProperty);
            set
            {
                SetValue(IconMaxHeightProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(IconMaxHeight));
            }
        }

        public double IconMaxWidth
        {
            get => (double)GetValue(IconMaxWidthProperty);
            set
            {
                SetValue(IconMaxWidthProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(IconMaxWidth));
            }
        }

        public double IconMinHeight
        {
            get => (double)GetValue(IconMinHeightProperty);
            set
            {
                SetValue(IconMinHeightProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(IconMinHeight));
            }
        }

        public double IconMinWidth
        {
            get => (double)GetValue(IconMinWidthProperty);
            set
            {
                SetValue(IconMinWidthProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(IconMinWidth));
            }
        }

        public double IconWidth
        {
            get => (double)GetValue(IconWidthProperty);
            set
            {
                SetValue(IconWidthProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(IconWidth));
            }
        }

        #endregion Icon

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set
            {
                SetValue(CornerRadiusProperty, value);
                OnPropertyChanged(nameof(CornerRadius));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Static MenuItemEx class constructor. </summary>
        static MenuItemEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuItemEx),
                new FrameworkPropertyMetadata(typeof(MenuItemEx)));
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
