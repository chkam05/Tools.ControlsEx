using chkam05.Tools.ControlsEx.Static;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;


namespace chkam05.Tools.ControlsEx
{
    public class ScrollBarEx : ScrollBar, INotifyPropertyChanged
    {

        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty ThumbBackgroundProperty = DependencyProperty.Register(
            nameof(ThumbBackground),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty ThumbBorderBrushProperty = DependencyProperty.Register(
            nameof(ThumbBorderBrush),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static readonly DependencyProperty MouseOverThumbBackgroundProperty = DependencyProperty.Register(
            nameof(MouseOverThumbBackground),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty MouseOverThumbBorderBrushProperty = DependencyProperty.Register(
            nameof(MouseOverThumbBorderBrush),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static readonly DependencyProperty DraggingThumbBackgroundProperty = DependencyProperty.Register(
            nameof(DraggingThumbBackground),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_DRAGGING)));

        public static readonly DependencyProperty DraggingThumbBorderBrushProperty = DependencyProperty.Register(
            nameof(DraggingThumbBorderBrush),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        #endregion Appearance Colors Properties

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ScrollBarEx),
            new PropertyMetadata(new CornerRadius(0)));

        public static readonly DependencyProperty ThumbBorderThicknessProperty = DependencyProperty.Register(
            nameof(ThumbBorderThickness),
            typeof(Thickness),
            typeof(ScrollBarEx),
            new PropertyMetadata(new Thickness(0)));

        public static readonly DependencyProperty ThumbCornerRadiusProperty = DependencyProperty.Register(
            nameof(ThumbCornerRadius),
            typeof(CornerRadius),
            typeof(ScrollBarEx),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  GETTERS & SETTERS

        #region Appearance Colors

        public Brush ThumbBackground
        {
            get => (Brush)GetValue(ThumbBackgroundProperty);
            set
            {
                SetValue(ThumbBackgroundProperty, value);
                OnPropertyChanged(nameof(ThumbBackground));
            }
        }

        public Brush ThumbBorderBrush
        {
            get => (Brush)GetValue(ThumbBorderBrushProperty);
            set
            {
                SetValue(ThumbBorderBrushProperty, value);
                OnPropertyChanged(nameof(ThumbBorderBrush));
            }
        }

        public Brush MouseOverThumbBackground
        {
            get => (Brush)GetValue(MouseOverThumbBackgroundProperty);
            set
            {
                SetValue(MouseOverThumbBackgroundProperty, value);
                OnPropertyChanged(nameof(MouseOverThumbBackground));
            }
        }

        public Brush MouseOverThumbBorderBrush
        {
            get => (Brush)GetValue(MouseOverThumbBorderBrushProperty);
            set
            {
                SetValue(MouseOverThumbBorderBrushProperty, value);
                OnPropertyChanged(nameof(MouseOverThumbBorderBrush));
            }
        }

        public Brush DraggingThumbBackground
        {
            get => (Brush)GetValue(DraggingThumbBackgroundProperty);
            set
            {
                SetValue(DraggingThumbBackgroundProperty, value);
                OnPropertyChanged(nameof(DraggingThumbBackground));
            }
        }

        public Brush DraggingThumbBorderBrush
        {
            get => (Brush)GetValue(DraggingThumbBorderBrushProperty);
            set
            {
                SetValue(DraggingThumbBorderBrushProperty, value);
                OnPropertyChanged(nameof(DraggingThumbBorderBrush));
            }
        }

        #endregion Appearance Colors

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set
            {
                SetValue(CornerRadiusProperty, value);
                OnPropertyChanged(nameof(CornerRadius));
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


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ScrollBarEx static class constructor. </summary>
        static ScrollBarEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ScrollBarEx),
                new FrameworkPropertyMetadata(typeof(ScrollBarEx)));
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
