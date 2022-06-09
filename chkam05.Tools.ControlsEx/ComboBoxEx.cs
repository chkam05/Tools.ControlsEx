using chkam05.Tools.ControlsEx.Static;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace chkam05.Tools.ControlsEx
{
    public class ComboBoxEx : ComboBox, INotifyPropertyChanged
    {

        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty DropDownBackgroundProperty = DependencyProperty.Register(
            nameof(DropDownBackground),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_COLOR)));

        public static readonly DependencyProperty DropDownBorderBrushProperty = DependencyProperty.Register(
            nameof(DropDownBorderBrush),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty DropDownForegroundProperty = DependencyProperty.Register(
            nameof(DropDownForeground),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty DropDownIconBrushProperty = DependencyProperty.Register(
            nameof(DropDownIconBrush),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty DropDownMouseOverIconBrushProperty = DependencyProperty.Register(
            nameof(DropDownMouseOverIconBrush),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty DropDownSelectedIconBrushProperty = DependencyProperty.Register(
            nameof(DropDownSelectedIconBrush),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty MouseOverBackgroundProperty = DependencyProperty.Register(
            nameof(MouseOverBackground),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_COLOR)));

        public static readonly DependencyProperty MouseOverBorderBrushProperty = DependencyProperty.Register(
            nameof(MouseOverBorderBrush),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty MouseOverForegroundProperty = DependencyProperty.Register(
            nameof(MouseOverForeground),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty SelectedBackgroundProperty = DependencyProperty.Register(
            nameof(SelectedBackground),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_COLOR)));

        public static readonly DependencyProperty SelectedBorderBrushProperty = DependencyProperty.Register(
            nameof(SelectedBorderBrush),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_PRESSED)));

        public static readonly DependencyProperty SelectedForegroundProperty = DependencyProperty.Register(
           nameof(SelectedForeground),
           typeof(Brush),
           typeof(ComboBoxEx),
           new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        #endregion Appearance Colors Properties

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ComboBoxEx),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));

        public static readonly DependencyProperty DropDownCornerRadiusProperty = DependencyProperty.Register(
            nameof(DropDownCornerRadius),
            typeof(CornerRadius),
            typeof(ComboBoxEx),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));

        public static readonly DependencyProperty DropDownBorderThicknessProperty = DependencyProperty.Register(
            nameof(DropDownBorderThickness),
            typeof(Thickness),
            typeof(ComboBoxEx),
            new PropertyMetadata(new Thickness(1)));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private CornerRadius _buttonCornerRadius = new CornerRadius(0, 4, 4, 0);


        //  GETTERS & SETTERS

        #region Appearance Colors

        public Brush DropDownBackground
        {
            get => (Brush)GetValue(DropDownBackgroundProperty);
            set
            {
                SetValue(DropDownBackgroundProperty, value);
                OnPropertyChanged(nameof(DropDownBackground));
            }
        }

        public Brush DropDownBorderBrush
        {
            get => (Brush)GetValue(DropDownBorderBrushProperty);
            set
            {
                SetValue(DropDownBorderBrushProperty, value);
                OnPropertyChanged(nameof(DropDownBorderBrush));
            }
        }

        public Brush DropDownForeground
        {
            get => (Brush)GetValue(DropDownForegroundProperty);
            set
            {
                SetValue(DropDownForegroundProperty, value);
                OnPropertyChanged(nameof(DropDownForeground));
            }
        }
        
        public Brush DropDownIconBrush
        {
            get => (Brush)GetValue(DropDownIconBrushProperty);
            set
            {
                SetValue(DropDownIconBrushProperty, value);
                OnPropertyChanged(nameof(DropDownIconBrush));
            }
        }

        public Brush DropDownMouseOverIconBrush
        {
            get => (Brush)GetValue(DropDownMouseOverIconBrushProperty);
            set
            {
                SetValue(DropDownMouseOverIconBrushProperty, value);
                OnPropertyChanged(nameof(DropDownMouseOverIconBrush));
            }
        }

        public Brush DropDownSelectedIconBrush
        {
            get => (Brush)GetValue(DropDownSelectedIconBrushProperty);
            set
            {
                SetValue(DropDownSelectedIconBrushProperty, value);
                OnPropertyChanged(nameof(DropDownSelectedIconBrush));
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

        #endregion Appearance Colors

        public CornerRadius ButtonCornerRadius
        {
            get => _buttonCornerRadius;
            set
            {
                _buttonCornerRadius = value;
                OnPropertyChanged(nameof(ButtonCornerRadius));
            }
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set
            {
                SetValue(CornerRadiusProperty, value);
                OnPropertyChanged(nameof(CornerRadius));

                ButtonCornerRadius = new CornerRadius(0, value.TopRight, value.BottomRight, 0);
            }
        }

        public CornerRadius DropDownCornerRadius
        {
            get => (CornerRadius)GetValue(DropDownCornerRadiusProperty);
            set
            {
                SetValue(DropDownCornerRadiusProperty, value);
                OnPropertyChanged(nameof(DropDownCornerRadius));
            }
        }

        public Thickness DropDownBorderThickness
        {
            get => (Thickness)GetValue(DropDownBorderThicknessProperty);
            set
            {
                SetValue(DropDownBorderThicknessProperty, value);
                OnPropertyChanged(nameof(DropDownBorderThickness));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Static ButtonEx class constructor. </summary>
        static ComboBoxEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ComboBoxEx),
                new FrameworkPropertyMetadata(typeof(ComboBoxEx)));
        }

        #endregion CLASS METHODS

        #region ITEMS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Creates and returns new ComboBoxItemEx container. </summary>
        /// <returns> A new ComboBoxItemEx control. </returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ComboBoxItemEx();
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
