using chkam05.Tools.ControlsEx.Static;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace chkam05.Tools.ControlsEx
{
    public class ScrollViewerEx : ScrollViewer, INotifyPropertyChanged
    {

        //  CONST

        protected readonly static double SCROLLBAR_HORIZONTAL_HEIGHT = 16d;
        protected readonly static double SCROLLBAR_VERTICAL_WIDTH = 16d;

        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty ScrollBarBackgroundProperty = DependencyProperty.Register(
            nameof(ScrollBarBackground),
            typeof(Brush),
            typeof(ScrollViewerEx),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty ScrollBarThumbBackgroundProperty = DependencyProperty.Register(
            nameof(ScrollBarThumbBackground),
            typeof(Brush),
            typeof(ScrollViewerEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty ScrollBarThumbBorderBrushProperty = DependencyProperty.Register(
            nameof(ScrollBarThumbBorderBrush),
            typeof(Brush),
            typeof(ScrollViewerEx),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty ScrollBarMouseOverThumbBackgroundProperty = DependencyProperty.Register(
            nameof(ScrollBarMouseOverThumbBackground),
            typeof(Brush),
            typeof(ScrollViewerEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty ScrollBarMouseOverThumbBorderBrushProperty = DependencyProperty.Register(
            nameof(ScrollBarMouseOverThumbBorderBrush),
            typeof(Brush),
            typeof(ScrollViewerEx),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty ScrollBarDraggingThumbBackgroundProperty = DependencyProperty.Register(
            nameof(ScrollBarDraggingThumbBackground),
            typeof(Brush),
            typeof(ScrollViewerEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_DRAGGING)));

        public static readonly DependencyProperty ScrollBarDraggingThumbBorderBrushProperty = DependencyProperty.Register(
            nameof(ScrollBarDraggingThumbBorderBrush),
            typeof(Brush),
            typeof(ScrollViewerEx),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty ScrollBarsCornerBackgroundProperty = DependencyProperty.Register(
            nameof(ScrollBarsCornerBackground),
            typeof(Brush),
            typeof(ScrollViewerEx),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        #endregion Appearance Colors Properties

        public static readonly DependencyProperty ScrollBarHorizontalHeightProperty = DependencyProperty.Register(
            nameof(ScrollBarHorizontalHeight),
            typeof(double),
            typeof(ScrollViewerEx),
            new PropertyMetadata(SCROLLBAR_HORIZONTAL_HEIGHT));

        public static readonly DependencyProperty ScrollBarThumbBorderThicknessProperty = DependencyProperty.Register(
            nameof(ScrollBarThumbBorderThickness),
            typeof(Thickness),
            typeof(ScrollViewerEx),
            new PropertyMetadata(new Thickness(0)));

        public static readonly DependencyProperty ScrollBarThumbCornerRadiusProperty = DependencyProperty.Register(
            nameof(ScrollBarThumbCornerRadius),
            typeof(CornerRadius),
            typeof(ScrollViewerEx),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));

        public static readonly DependencyProperty ScrollBarThumbMarginProperty = DependencyProperty.Register(
            nameof(ScrollBarThumbMargin),
            typeof(Thickness),
            typeof(ScrollViewerEx),
            new PropertyMetadata(new Thickness(4)));

        public static readonly DependencyProperty ScrollBarVerticalWidthProperty = DependencyProperty.Register(
            nameof(ScrollBarVerticalWidth),
            typeof(double),
            typeof(ScrollViewerEx),
            new PropertyMetadata(SCROLLBAR_VERTICAL_WIDTH));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  GETTERS & SETTERS

        #region Appearance Colors

        public Brush ScrollBarBackground
        {
            get => (Brush)GetValue(ScrollBarBackgroundProperty);
            set
            {
                SetValue(ScrollBarBackgroundProperty, value);
                OnPropertyChanged(nameof(ScrollBarBackground));
            }
        }

        public Brush ScrollBarThumbBackground
        {
            get => (Brush)GetValue(ScrollBarThumbBackgroundProperty);
            set
            {
                SetValue(ScrollBarThumbBackgroundProperty, value);
                OnPropertyChanged(nameof(ScrollBarThumbBackground));
            }
        }

        public Brush ScrollBarThumbBorderBrush
        {
            get => (Brush)GetValue(ScrollBarThumbBorderBrushProperty);
            set
            {
                SetValue(ScrollBarThumbBorderBrushProperty, value);
                OnPropertyChanged(nameof(ScrollBarThumbBorderBrush));
            }
        }

        public Brush ScrollBarMouseOverThumbBackground
        {
            get => (Brush)GetValue(ScrollBarMouseOverThumbBackgroundProperty);
            set
            {
                SetValue(ScrollBarMouseOverThumbBackgroundProperty, value);
                OnPropertyChanged(nameof(ScrollBarMouseOverThumbBackground));
            }
        }

        public Brush ScrollBarMouseOverThumbBorderBrush
        {
            get => (Brush)GetValue(ScrollBarMouseOverThumbBorderBrushProperty);
            set
            {
                SetValue(ScrollBarMouseOverThumbBorderBrushProperty, value);
                OnPropertyChanged(nameof(ScrollBarMouseOverThumbBorderBrush));
            }
        }

        public Brush ScrollBarDraggingThumbBackground
        {
            get => (Brush)GetValue(ScrollBarDraggingThumbBackgroundProperty);
            set
            {
                SetValue(ScrollBarDraggingThumbBackgroundProperty, value);
                OnPropertyChanged(nameof(ScrollBarDraggingThumbBackground));
            }
        }

        public Brush ScrollBarDraggingThumbBorderBrush
        {
            get => (Brush)GetValue(ScrollBarDraggingThumbBorderBrushProperty);
            set
            {
                SetValue(ScrollBarDraggingThumbBorderBrushProperty, value);
                OnPropertyChanged(nameof(ScrollBarDraggingThumbBorderBrush));
            }
        }

        public Brush ScrollBarsCornerBackground
        {
            get => (Brush)GetValue(ScrollBarsCornerBackgroundProperty);
            set
            {
                SetValue(ScrollBarsCornerBackgroundProperty, value);
                OnPropertyChanged(nameof(ScrollBarsCornerBackground));
            }
        }

        #endregion Appearance Colors

        public double ScrollBarHorizontalHeight
        {
            get => (double)GetValue(ScrollBarHorizontalHeightProperty);
            set
            {
                SetValue(ScrollBarHorizontalHeightProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(ScrollBarHorizontalHeight));
            }
        }

        public Thickness ScrollBarThumbBorderThickness
        {
            get => (Thickness)GetValue(ScrollBarThumbBorderThicknessProperty);
            set
            {
                SetValue(ScrollBarThumbBorderThicknessProperty, value);
                OnPropertyChanged(nameof(ScrollBarThumbBorderThickness));
            }
        }

        public CornerRadius ScrollBarThumbCornerRadius
        {
            get => (CornerRadius)GetValue(ScrollBarThumbCornerRadiusProperty);
            set
            {
                SetValue(ScrollBarThumbCornerRadiusProperty, value);
                OnPropertyChanged(nameof(ScrollBarThumbCornerRadius));
            }
        }

        public Thickness ScrollBarThumbMargin
        {
            get => (Thickness)GetValue(ScrollBarThumbMarginProperty);
            set
            {
                SetValue(ScrollBarThumbMarginProperty, value);
                OnPropertyChanged(nameof(ScrollBarThumbMargin));
            }
        }

        public double ScrollBarVerticalWidth
        {
            get => (double)GetValue(ScrollBarVerticalWidthProperty);
            set
            {
                SetValue(ScrollBarVerticalWidthProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(ScrollBarVerticalWidth));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ScrollViewerEx static class constructor. </summary>
        static ScrollViewerEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ScrollViewerEx),
                new FrameworkPropertyMetadata(typeof(ScrollViewerEx)));
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
