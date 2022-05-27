using chkam05.Tools.ControlsEx.Static;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace chkam05.Tools.ControlsEx
{
    public class ListViewItemEx : ListViewItem, INotifyPropertyChanged
    {

        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty MouseOverBackgroundProperty = DependencyProperty.Register(
            nameof(MouseOverBackground),
            typeof(Brush),
            typeof(ListViewItemEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty MouseOverBorderBrushProperty = DependencyProperty.Register(
            nameof(MouseOverBorderBrush),
            typeof(Brush),
            typeof(ListViewItemEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty MouseOverForegroundProperty = DependencyProperty.Register(
            nameof(MouseOverForeground),
            typeof(Brush),
            typeof(ListViewItemEx),
            new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        public static readonly DependencyProperty SelectedBackgroundProperty = DependencyProperty.Register(
            nameof(SelectedBackground),
            typeof(Brush),
            typeof(ListViewItemEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_SELECTED)));

        public static readonly DependencyProperty SelectedBorderBrushProperty = DependencyProperty.Register(
            nameof(SelectedBorderBrush),
            typeof(Brush),
            typeof(ListViewItemEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_SELECTED)));

        public static readonly DependencyProperty SelectedForegroundProperty = DependencyProperty.Register(
            nameof(SelectedForeground),
            typeof(Brush),
            typeof(ListViewItemEx),
            new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        public static readonly DependencyProperty SelectedInactiveBackgroundProperty = DependencyProperty.Register(
            nameof(SelectedInactiveBackground),
            typeof(Brush),
            typeof(ListViewItemEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_SELECTED_INACTIVE)));

        public static readonly DependencyProperty SelectedInactiveBorderBrushProperty = DependencyProperty.Register(
            nameof(SelectedInactiveBorderBrush),
            typeof(Brush),
            typeof(ListViewItemEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_SELECTED_INACTIVE)));

        public static readonly DependencyProperty SelectedInactiveForegroundProperty = DependencyProperty.Register(
            nameof(SelectedInactiveForeground),
            typeof(Brush),
            typeof(ListViewItemEx),
            new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        #endregion Appearance Colors Properties

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ListViewItemEx),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  GETTERS & SETTERS

        #region Appearance Colors

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

        public Brush SelectedBackground
        {
            get => (Brush)GetValue(SelectedBackgroundProperty);
            set
            {
                SetValue(SelectedBackgroundProperty, value);
                OnPropertyChanged(nameof(SelectedBackground));
            }
        }

        public Brush SelectedBorderBrush
        {
            get => (Brush)GetValue(SelectedBorderBrushProperty);
            set
            {
                SetValue(SelectedBorderBrushProperty, value);
                OnPropertyChanged(nameof(SelectedBorderBrush));
            }
        }

        public Brush SelectedForeground
        {
            get => (Brush)GetValue(SelectedForegroundProperty);
            set
            {
                SetValue(SelectedForegroundProperty, value);
                OnPropertyChanged(nameof(SelectedForeground));
            }
        }

        public Brush SelectedInactiveBackground
        {
            get => (Brush)GetValue(SelectedInactiveBackgroundProperty);
            set
            {
                SetValue(SelectedInactiveBackgroundProperty, value);
                OnPropertyChanged(nameof(SelectedInactiveBackground));
            }
        }

        public Brush SelectedInactiveBorderBrush
        {
            get => (Brush)GetValue(SelectedInactiveBorderBrushProperty);
            set
            {
                SetValue(SelectedInactiveBorderBrushProperty, value);
                OnPropertyChanged(nameof(SelectedInactiveBorderBrush));
            }
        }

        public Brush SelectedInactiveForeground
        {
            get => (Brush)GetValue(SelectedInactiveForegroundProperty);
            set
            {
                SetValue(SelectedInactiveForegroundProperty, value);
                OnPropertyChanged(nameof(SelectedInactiveForeground));
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


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ListViewItemEx static class constructor. </summary>
        static ListViewItemEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ListViewItemEx),
                new FrameworkPropertyMetadata(typeof(ListViewItemEx)));
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
