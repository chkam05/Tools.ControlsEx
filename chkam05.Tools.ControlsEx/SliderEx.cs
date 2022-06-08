using chkam05.Tools.ControlsEx.Static;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace chkam05.Tools.ControlsEx
{
    public class SliderEx : Slider, INotifyPropertyChanged
    {

        //  CONST

        protected readonly static double TRACKBAR_HEIGHT = 6d;
        protected readonly static double TRACKBAR_WIDTH = 6d;
        protected readonly static double THUMB_HEIGHT = 32d;
        protected readonly static double THUMB_WIDTH = 32d;


        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty SelectionRangeColorBrushProperty = DependencyProperty.Register(
            nameof(SelectionRangeColorBrush),
            typeof(Brush),
            typeof(SliderEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty TicksColorBrushProperty = DependencyProperty.Register(
            nameof(TicksColorBrush),
            typeof(Brush),
            typeof(SliderEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        #endregion Appearance Colors Properties

        #region Trackbar Properties

        public static readonly DependencyProperty TrackBarBackgroundProperty = DependencyProperty.Register(
            nameof(TrackBarBackground),
            typeof(Brush),
            typeof(SliderEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty TrackBarBorderBrushProperty = DependencyProperty.Register(
            nameof(TrackBarBorderBrush),
            typeof(Brush),
            typeof(SliderEx),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty TrackBarBorderThicknessProperty = DependencyProperty.Register(
            nameof(TrackBarBorderThickness),
            typeof(Thickness),
            typeof(SliderEx),
            new PropertyMetadata(new Thickness(0)));

        public static readonly DependencyProperty TrackBarCornerRadiusProperty = DependencyProperty.Register(
            nameof(TrackBarCornerRadius),
            typeof(CornerRadius),
            typeof(SliderEx),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));

        public static readonly DependencyProperty TrackBarHeightProperty = DependencyProperty.Register(
            nameof(TrackBarHeight),
            typeof(double),
            typeof(SliderEx),
            new PropertyMetadata(TRACKBAR_HEIGHT));

        public static readonly DependencyProperty TrackBarWidthProperty = DependencyProperty.Register(
            nameof(TrackBarWidth),
            typeof(double),
            typeof(SliderEx),
            new PropertyMetadata(TRACKBAR_WIDTH));

        #endregion Trackbar Properties

        #region Thumb Properties

        public static readonly DependencyProperty ThumbBorderBrushProperty = DependencyProperty.Register(
            nameof(ThumbBorderBrush),
            typeof(Brush),
            typeof(SliderEx),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty ThumbMouseOverBackgroundProperty = DependencyProperty.Register(
            nameof(ThumbMouseOverBackground),
            typeof(Brush),
            typeof(SliderEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty ThumbMouseOverBorderBrushProperty = DependencyProperty.Register(
            nameof(ThumbMouseOverBorderBrush),
            typeof(Brush),
            typeof(SliderEx),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty ThumbDraggingBackgroundProperty = DependencyProperty.Register(
            nameof(ThumbDraggingBackground),
            typeof(Brush),
            typeof(SliderEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_DRAGGING)));

        public static readonly DependencyProperty ThumbDraggingBorderBrushProperty = DependencyProperty.Register(
            nameof(ThumbDraggingBorderBrush),
            typeof(Brush),
            typeof(SliderEx),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty ThumbBorderThicknessProperty = DependencyProperty.Register(
            nameof(ThumbBorderThickness),
            typeof(Thickness),
            typeof(SliderEx),
            new PropertyMetadata(new Thickness(0)));

        public static readonly DependencyProperty ThumbCornerRadiusProperty = DependencyProperty.Register(
            nameof(ThumbCornerRadius),
            typeof(CornerRadius),
            typeof(SliderEx),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));

        public static readonly DependencyProperty ThumbHeightProperty = DependencyProperty.Register(
            nameof(ThumbHeight),
            typeof(double),
            typeof(SliderEx),
            new PropertyMetadata(THUMB_HEIGHT));

        public static readonly DependencyProperty ThumbWidthProperty = DependencyProperty.Register(
            nameof(ThumbWidth),
            typeof(double),
            typeof(SliderEx),
            new PropertyMetadata(THUMB_WIDTH));

        #endregion Thumb Properties

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(SliderEx),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  GETTERS & SETTERS

        #region Appearance Colors

        public Brush SelectionRangeColorBrush
        {
            get => (Brush)GetValue(SelectionRangeColorBrushProperty);
            set
            {
                SetValue(SelectionRangeColorBrushProperty, value);
                OnPropertyChanged(nameof(SelectionRangeColorBrush));
            }
        }

        public Brush TicksColorBrush
        {
            get => (Brush)GetValue(TicksColorBrushProperty);
            set
            {
                SetValue(TicksColorBrushProperty, value);
                OnPropertyChanged(nameof(TicksColorBrush));
            }
        }

        #endregion Appearance Colors

        #region Trackbar

        public Brush TrackBarBackground
        {
            get => (Brush)GetValue(TrackBarBackgroundProperty);
            set
            {
                SetValue(TrackBarBackgroundProperty, value);
                OnPropertyChanged(nameof(TrackBarBackground));
            }
        }

        public Brush TrackBarBorderBrush
        {
            get => (Brush)GetValue(TrackBarBorderBrushProperty);
            set
            {
                SetValue(TrackBarBorderBrushProperty, value);
                OnPropertyChanged(nameof(TrackBarBorderBrush));
            }
        }

        public Thickness TrackBarBorderThickness
        {
            get => (Thickness)GetValue(TrackBarBorderThicknessProperty);
            set
            {
                SetValue(TrackBarBorderThicknessProperty, value);
                OnPropertyChanged(nameof(TrackBarBorderThickness));
            }
        }

        public CornerRadius TrackBarCornerRadius
        {
            get => (CornerRadius)GetValue(TrackBarCornerRadiusProperty);
            set
            {
                SetValue(TrackBarCornerRadiusProperty, value);
                OnPropertyChanged(nameof(TrackBarCornerRadius));
            }
        }

        public double TrackBarHeight
        {
            get => (double)GetValue(TrackBarHeightProperty);
            set
            {
                SetValue(TrackBarHeightProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(TrackBarHeight));
            }
        }

        public double TrackBarWidth
        {
            get => (double)GetValue(TrackBarWidthProperty);
            set
            {
                SetValue(TrackBarWidthProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(TrackBarWidth));
            }
        }

        #endregion Trackbar

        #region Thumb

        public Brush ThumbBorderBrush
        {
            get => (Brush)GetValue(ThumbBorderBrushProperty);
            set
            {
                SetValue(ThumbBorderBrushProperty, value);
                OnPropertyChanged(nameof(ThumbBorderBrush));
            }
        }

        public Brush ThumbMouseOverBackground
        {
            get => (Brush)GetValue(ThumbMouseOverBackgroundProperty);
            set
            {
                SetValue(ThumbMouseOverBackgroundProperty, value);
                OnPropertyChanged(nameof(ThumbMouseOverBackground));
            }
        }

        public Brush ThumbMouseOverBorderBrush
        {
            get => (Brush)GetValue(ThumbMouseOverBorderBrushProperty);
            set
            {
                SetValue(ThumbMouseOverBorderBrushProperty, value);
                OnPropertyChanged(nameof(ThumbMouseOverBorderBrush));
            }
        }

        public Brush ThumbDraggingBackground
        {
            get => (Brush)GetValue(ThumbDraggingBackgroundProperty);
            set
            {
                SetValue(ThumbDraggingBackgroundProperty, value);
                OnPropertyChanged(nameof(ThumbDraggingBackground));
            }
        }

        public Brush ThumbDraggingBorderBrush
        {
            get => (Brush)GetValue(ThumbDraggingBorderBrushProperty);
            set
            {
                SetValue(ThumbDraggingBorderBrushProperty, value);
                OnPropertyChanged(nameof(ThumbDraggingBorderBrush));
            }
        }

        public Thickness ThumbBorderThickness
        {
            get => (Thickness)GetValue(ThumbBorderThicknessProperty);
            set
            {
                SetValue(ThumbBorderThicknessProperty, value);
                OnPropertyChanged(nameof(ThumbBorderThickness));
            }
        }

        public CornerRadius ThumbCornerRadius
        {
            get => (CornerRadius)GetValue(ThumbCornerRadiusProperty);
            set
            {
                SetValue(ThumbCornerRadiusProperty, value);
                OnPropertyChanged(nameof(ThumbCornerRadius));
            }
        }

        public double ThumbHeight
        {
            get => (double)GetValue(ThumbHeightProperty);
            set
            {
                SetValue(ThumbHeightProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(ThumbHeight));
            }
        }

        public double ThumbWidth
        {
            get => (double)GetValue(ThumbWidthProperty);
            set
            {
                SetValue(ThumbWidthProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(ThumbWidth));
            }
        }

        #endregion Thumb

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
        /// <summary> Static SliderEx class constructor. </summary>
        static SliderEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SliderEx),
                new FrameworkPropertyMetadata(typeof(SliderEx)));
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
