using chkam05.Tools.ControlsEx.Static;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace chkam05.Tools.ControlsEx
{
    public class ListViewEx : ListView, INotifyPropertyChanged
    {

        //  CONST

        protected readonly static double COLUMN_HEADER_GRIPPER_WIDTH = 8d;


        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty ColumnHeaderBackgroundProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBackground),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_COLOR)));

        public static readonly DependencyProperty ColumnHeaderBorderBrushProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBorderBrush),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty ColumnHeaderForegroundProperty = DependencyProperty.Register(
            nameof(ColumnHeaderForeground),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty ColumnHeaderMouseOverBackgroundProperty = DependencyProperty.Register(
            nameof(ColumnHeaderMouseOverBackground),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty ColumnHeaderMouseOverBorderBrushProperty = DependencyProperty.Register(
            nameof(ColumnHeaderMouseOverBorderBrush),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty ColumnHeaderMouseOverForegroundProperty = DependencyProperty.Register(
            nameof(ColumnHeaderMouseOverForeground),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty ColumnHeaderPressedBackgroundProperty = DependencyProperty.Register(
            nameof(ColumnHeaderPressedBackground),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_PRESSED)));

        public static readonly DependencyProperty ColumnHeaderPressedBorderBrushProperty = DependencyProperty.Register(
            nameof(ColumnHeaderPressedBorderBrush),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty ColumnHeaderPressedForegroundProperty = DependencyProperty.Register(
            nameof(ColumnHeaderPressedForeground),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty ColumnHeaderEmptyBackgroundProperty = DependencyProperty.Register(
            nameof(ColumnHeaderEmptyBackground),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_COLOR)));

        public static readonly DependencyProperty ColumnHeaderEmptyBorderBrushProperty = DependencyProperty.Register(
            nameof(ColumnHeaderEmptyBorderBrush),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        #endregion Appearance Colors Properties

        public static readonly DependencyProperty ColumnHeaderBorderThicknessProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBorderThickness),
            typeof(Thickness),
            typeof(ListViewEx),
            new PropertyMetadata(new Thickness(0, 0, 1, 1)));

        public static readonly DependencyProperty ColumnHeaderCornerRadiusProperty = DependencyProperty.Register(
            nameof(ColumnHeaderCornerRadius),
            typeof(CornerRadius),
            typeof(ListViewEx),
            new PropertyMetadata(new CornerRadius(0)));

        public static readonly DependencyProperty ColumnHeaderGripperWidthProperty = DependencyProperty.Register(
            nameof(ColumnHeaderGripperWidth),
            typeof(double),
            typeof(ListViewEx),
            new PropertyMetadata(COLUMN_HEADER_GRIPPER_WIDTH));

        public static readonly DependencyProperty ColumnHeaderMarginProperty = DependencyProperty.Register(
            nameof(ColumnHeaderMargin),
            typeof(Thickness),
            typeof(ListViewEx),
            new PropertyMetadata(new Thickness(0)));

        public static readonly DependencyProperty ColumnHeaderPaddingProperty = DependencyProperty.Register(
            nameof(ColumnHeaderPadding),
            typeof(Thickness),
            typeof(ListViewEx),
            new PropertyMetadata(new Thickness(8, 2, 8, 2)));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  GETTERS & SETTERS

        #region Appearance Colors

        public Brush ColumnHeaderBackground
        {
            get => (Brush)GetValue(ColumnHeaderBackgroundProperty);
            set
            {
                SetValue(ColumnHeaderBackgroundProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderBackground));
            }
        }

        public Brush ColumnHeaderBorderBrush
        {
            get => (Brush)GetValue(ColumnHeaderBorderBrushProperty);
            set
            {
                SetValue(ColumnHeaderBorderBrushProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderBorderBrush));
            }
        }

        public Brush ColumnHeaderForeground
        {
            get => (Brush)GetValue(ColumnHeaderForegroundProperty);
            set
            {
                SetValue(ColumnHeaderForegroundProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderForeground));
            }
        }

        public Brush ColumnHeaderMouseOverBackground
        {
            get => (Brush)GetValue(ColumnHeaderMouseOverBackgroundProperty);
            set
            {
                SetValue(ColumnHeaderMouseOverBackgroundProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderMouseOverBackground));
            }
        }

        public Brush ColumnHeaderMouseOverBorderBrush
        {
            get => (Brush)GetValue(ColumnHeaderMouseOverBorderBrushProperty);
            set
            {
                SetValue(ColumnHeaderMouseOverBorderBrushProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderMouseOverBorderBrush));
            }
        }

        public Brush ColumnHeaderMouseOverForeground
        {
            get => (Brush)GetValue(ColumnHeaderMouseOverForegroundProperty);
            set
            {
                SetValue(ColumnHeaderMouseOverForegroundProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderMouseOverForeground));
            }
        }

        public Brush ColumnHeaderPressedBackground
        {
            get => (Brush)GetValue(ColumnHeaderPressedBackgroundProperty);
            set
            {
                SetValue(ColumnHeaderPressedBackgroundProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderPressedBackground));
            }
        }

        public Brush ColumnHeaderPressedBorderBrush
        {
            get => (Brush)GetValue(ColumnHeaderPressedBorderBrushProperty);
            set
            {
                SetValue(ColumnHeaderPressedBorderBrushProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderPressedBorderBrush));
            }
        }

        public Brush ColumnHeaderPressedForeground
        {
            get => (Brush)GetValue(ColumnHeaderPressedForegroundProperty);
            set
            {
                SetValue(ColumnHeaderPressedForegroundProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderPressedForeground));
            }
        }

        public Brush ColumnHeaderEmptyBackground
        {
            get => (Brush)GetValue(ColumnHeaderEmptyBackgroundProperty);
            set
            {
                SetValue(ColumnHeaderEmptyBackgroundProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderEmptyBackground));
            }
        }

        public Brush ColumnHeaderEmptyBorderBrush
        {
            get => (Brush)GetValue(ColumnHeaderEmptyBorderBrushProperty);
            set
            {
                SetValue(ColumnHeaderEmptyBorderBrushProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderEmptyBorderBrush));
            }
        }

        #endregion Appearance Colors

        public Thickness ColumnHeaderBorderThickness
        {
            get => (Thickness)GetValue(ColumnHeaderBorderThicknessProperty);
            set
            {
                SetValue(ColumnHeaderBorderThicknessProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderBorderThickness));
            }
        }

        public CornerRadius ColumnHeaderCornerRadius
        {
            get => (CornerRadius)GetValue(ColumnHeaderCornerRadiusProperty);
            set
            {
                SetValue(ColumnHeaderCornerRadiusProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderCornerRadius));
            }
        }

        public double ColumnHeaderGripperWidth
        {
            get => (double)GetValue(ColumnHeaderGripperWidthProperty);
            set
            {
                SetValue(ColumnHeaderGripperWidthProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderGripperWidth));
            }
        }

        public Thickness ColumnHeaderMargin
        {
            get => (Thickness)GetValue(ColumnHeaderMarginProperty);
            set
            {
                SetValue(ColumnHeaderMarginProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderMargin));
            }
        }

        public Thickness ColumnHeaderPadding
        {
            get => (Thickness)GetValue(ColumnHeaderPaddingProperty);
            set
            {
                SetValue(ColumnHeaderPaddingProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderPadding));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ListViewEx static class constructor. </summary>
        static ListViewEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ListViewEx),
                new FrameworkPropertyMetadata(typeof(ListViewEx)));
        }

        #endregion CLASS METHODS

        #region ITEMS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Creates and returns new ListViewItemEx container. </summary>
        /// <returns> A new ListViewItemEx control. </returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ListViewItemEx();
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
