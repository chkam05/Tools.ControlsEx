using chkam05.Tools.ControlsEx.Static;
using chkam05.Tools.ControlsEx.Utilities;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static chkam05.Tools.ControlsEx.Events.Delegates;


namespace chkam05.Tools.ControlsEx
{
    public class UpDownTextBoxEx : TextBox, INotifyPropertyChanged
    {

        //  CONST

        protected readonly static double BUTTON_HEIGHT = 12d;
        protected readonly static double BUTTON_WIDTH = 12d;
        protected readonly static double MAX_VALUE = 100d;
        protected readonly static double MIN_VALUE = 0d;


        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty ButtonBackgroundProperty = DependencyProperty.Register(
            nameof(ButtonBackground),
            typeof(Brush),
            typeof(UpDownTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty ButtonForegroundProperty = DependencyProperty.Register(
            nameof(ButtonForeground),
            typeof(Brush),
            typeof(UpDownTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty ButtonMouseOverBackgroundProperty = DependencyProperty.Register(
            nameof(ButtonMouseOverBackground),
            typeof(Brush),
            typeof(UpDownTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty ButtonMouseOverForegroundProperty = DependencyProperty.Register(
            nameof(ButtonMouseOverForeground),
            typeof(Brush),
            typeof(UpDownTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty ButtonPressedBackgroundProperty = DependencyProperty.Register(
            nameof(ButtonPressedBackground),
            typeof(Brush),
            typeof(UpDownTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_PRESSED)));

        public static readonly DependencyProperty ButtonPressedForegroundProperty = DependencyProperty.Register(
            nameof(ButtonPressedForeground),
            typeof(Brush),
            typeof(UpDownTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty MouseOverBackgroundProperty = DependencyProperty.Register(
            nameof(MouseOverBackground),
            typeof(Brush),
            typeof(UpDownTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty MouseOverBorderBrushProperty = DependencyProperty.Register(
            nameof(MouseOverBorderBrush),
            typeof(Brush),
            typeof(UpDownTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty MouseOverForegroundProperty = DependencyProperty.Register(
            nameof(MouseOverForeground),
            typeof(Brush),
            typeof(UpDownTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty SelectedBackgroundProperty = DependencyProperty.Register(
            nameof(SelectedBackground),
            typeof(Brush),
            typeof(UpDownTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static readonly DependencyProperty SelectedBorderBrushProperty = DependencyProperty.Register(
            nameof(SelectedBorderBrush),
            typeof(Brush),
            typeof(UpDownTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_PRESSED)));

        public static readonly DependencyProperty SelectedForegroundProperty = DependencyProperty.Register(
            nameof(SelectedForeground),
            typeof(Brush),
            typeof(UpDownTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty SelectedTextBackgroundProperty = DependencyProperty.Register(
            nameof(SelectedTextBackground),
            typeof(Brush),
            typeof(UpDownTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        #endregion Appearance Colors Properties

        #region Buttons Properties

        public static readonly DependencyProperty ButtonHeightProperty = DependencyProperty.Register(
            nameof(ButtonHeight),
            typeof(double),
            typeof(UpDownTextBoxEx),
            new PropertyMetadata(BUTTON_HEIGHT));

        public static readonly DependencyProperty ButtonWidthProperty = DependencyProperty.Register(
            nameof(ButtonWidth),
            typeof(double),
            typeof(UpDownTextBoxEx),
            new PropertyMetadata(BUTTON_WIDTH));

        #endregion Buttons Properties

        public static readonly DependencyProperty ConversionTypeProperty = DependencyProperty.Register(
            nameof(ConversionType),
            typeof(UpDownTextBoxConversionType),
            typeof(UpDownTextBoxEx),
            new PropertyMetadata(UpDownTextBoxConversionType.Decimal));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(UpDownTextBoxEx),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            nameof(MaxValue),
            typeof(double),
            typeof(UpDownTextBoxEx),
            new PropertyMetadata(MAX_VALUE));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            nameof(MinValue),
            typeof(double),
            typeof(UpDownTextBoxEx),
            new PropertyMetadata(MIN_VALUE));

        public static readonly DependencyProperty TickProperty = DependencyProperty.Register(
            nameof(Tick),
            typeof(double),
            typeof(UpDownTextBoxEx),
            new PropertyMetadata(1d));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;
        public event TextModifiedEventHandler TextModified;


        //  VARIABLES

        protected bool _focused = false;
        protected bool _lockUpdate = false;
        protected bool _textChanged = false;
        internal UpDownTextBoxExValidator _validator;


        //  GETTERS & SETTERS

        #region Appearance Colors

        public Brush ButtonBackground
        {
            get => (Brush)GetValue(ButtonBackgroundProperty);
            set
            {
                SetValue(ButtonBackgroundProperty, value);
                OnPropertyChanged(nameof(ButtonBackground));
            }
        }

        public Brush ButtonForeground
        {
            get => (Brush)GetValue(ButtonForegroundProperty);
            set
            {
                SetValue(ButtonForegroundProperty, value);
                OnPropertyChanged(nameof(ButtonForeground));
            }
        }

        public Brush ButtonMouseOverBackground
        {
            get => (Brush)GetValue(ButtonMouseOverBackgroundProperty);
            set
            {
                SetValue(ButtonMouseOverBackgroundProperty, value);
                OnPropertyChanged(nameof(ButtonMouseOverBackground));
            }
        }

        public Brush ButtonMouseOverForeground
        {
            get => (Brush)GetValue(ButtonMouseOverForegroundProperty);
            set
            {
                SetValue(ButtonMouseOverForegroundProperty, value);
                OnPropertyChanged(nameof(ButtonMouseOverForeground));
            }
        }

        public Brush ButtonPressedBackground
        {
            get => (Brush)GetValue(ButtonPressedBackgroundProperty);
            set
            {
                SetValue(ButtonPressedBackgroundProperty, value);
                OnPropertyChanged(nameof(ButtonPressedBackground));
            }
        }

        public Brush ButtonPressedForeground
        {
            get => (Brush)GetValue(ButtonPressedForegroundProperty);
            set
            {
                SetValue(ButtonPressedForegroundProperty, value);
                OnPropertyChanged(nameof(ButtonPressedForeground));
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

        public Brush SelectedTextBackground
        {
            get => (Brush)GetValue(SelectedTextBackgroundProperty);
            set
            {
                SetValue(SelectedTextBackgroundProperty, value);
                OnPropertyChanged(nameof(SelectedTextBackground));
            }
        }

        #endregion Appearance Colors

        #region Buttons

        public double ButtonHeight
        {
            get => (double)GetValue(ButtonHeightProperty);
            set
            {
                SetValue(ButtonHeightProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(ButtonHeight));
            }
        }

        public double ButtonWidth
        {
            get => (double)GetValue(ButtonWidthProperty);
            set
            {
                SetValue(ButtonWidthProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(ButtonWidth));
            }
        }

        #endregion Buttons

        public virtual UpDownTextBoxConversionType ConversionType
        {
            get => (UpDownTextBoxConversionType)GetValue(ConversionTypeProperty);
            set
            {
                SetValue(ConversionTypeProperty, value);
                OnPropertyChanged(nameof(ConversionType));

                if (_validator != null)
                {
                    _validator.SetConversionType(value, Text);
                    Text = _validator.PreviousCorrectValue;
                }
            }
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set
            {
                SetValue(CornerRadiusProperty, value);
                OnPropertyChanged(nameof(CornerRadius));
            }
        }

        public double MaxValue
        {
            get => (double)GetValue(MaxValueProperty);
            set
            {
                SetValue(MaxValueProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(MaxValue));
            }
        }

        public double MinValue
        {
            get => (double)GetValue(MinValueProperty);
            set
            {
                SetValue(MinValueProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(MinValue));
            }
        }

        public double Tick
        {
            get => (double)GetValue(TickProperty);
            set
            {
                SetValue(TickProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(Tick));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> UpDownTextBoxEx class constructor. </summary>
        public UpDownTextBoxEx()
        {
            //  Initialize events.
            Loaded += OnLoaded;

            //  Initialize modules.
            _validator = new UpDownTextBoxExValidator();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static UpDownTextBoxEx class constructor. </summary>
        static UpDownTextBoxEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UpDownTextBoxEx),
                new FrameworkPropertyMetadata(typeof(UpDownTextBoxEx)));
        }

        #endregion CLASS METHODS

        #region COMPONENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading control. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (ConversionType != _validator.ConversionType)
            {
                _validator.SetConversionType(ConversionType, Text);

                if (Text != _validator.PreviousCorrectValue)
                {
                    _lockUpdate = true;
                    Text = _validator.PreviousCorrectValue;
                }
            }
        }

        #endregion COMPONENT METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked when component got focused by user. </summary>
        /// <param name="e"> Routed Event Arguments. </param>
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            _focused = true;
            base.OnGotFocus(e);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked when component lost focus from user. </summary>
        /// <param name="e"> Routed Event Arguments. </param>
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            _focused = false;

            if (_textChanged)
            {
                _textChanged = false;

                if (!_validator.TryConvertValue(Text, out string correctText))
                {
                    _lockUpdate = true;
                    Text = correctText;
                }
            }

            base.OnLostFocus(e);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after text change. </summary>
        /// <param name="e"> Text Changed Event Arguments. </param>
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            if (!_lockUpdate)
            {
                if (_focused)
                {
                    _textChanged = true;

                    if (!_validator.CanConvertValue(Text, out string correctValue, true))
                    {
                        int carretPosition = SelectionStart;
                        int textLength = Text.Length;
                        int textLengthDiff = Math.Max(0, textLength - correctValue.Length);

                        _lockUpdate = true;
                        Text = correctValue;
                        SelectionStart = Math.Max(0, Math.Min(carretPosition - textLengthDiff, correctValue.Length));
                    }
                }
                else if (!_validator.TryConvertValue(Text, out string correctText))
                {
                    _lockUpdate = true;
                    Text = correctText;
                }
            }
            else
            {
                _lockUpdate = false;
            }

            TextModified?.Invoke(this, new Events.TextModifiedEventArgs(Text, _validator.PreviousText, _focused));
            base.OnTextChanged(e);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Up Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void OnUpClick(object sender, RoutedEventArgs e)
        {
            switch (ConversionType)
            {
                case UpDownTextBoxConversionType.FloatingPoint:
                    if (double.TryParse(Text, out double dValue))
                    {
                        _lockUpdate = true;
                        Text = Math.Min(dValue + Tick, Math.Min(double.MaxValue, MaxValue)).ToString();
                    }
                    break;

                case UpDownTextBoxConversionType.Decimal:
                    if (long.TryParse(Text, out long lValue))
                    {
                        _lockUpdate = true;
                        Text = Math.Min(lValue + (long)Tick, Math.Min(long.MaxValue, (long)MaxValue)).ToString();
                    }
                    break;
                default:
                    break;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Down Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void OnDownClick(object sender, RoutedEventArgs e)
        {
            switch (ConversionType)
            {
                case UpDownTextBoxConversionType.FloatingPoint:
                    if (double.TryParse(Text, out double dValue))
                    {
                        _lockUpdate = true;
                        Text = Math.Max(dValue - Tick, Math.Max(double.MinValue, MinValue)).ToString();
                    }
                    break;

                case UpDownTextBoxConversionType.Decimal:
                    if (long.TryParse(Text, out long lValue))
                    {
                        _lockUpdate = true;
                        Text = Math.Max(lValue - (long)Tick, Math.Max(long.MinValue, (long)MinValue)).ToString();
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion INTERACTION METHODS

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

        #region TEMPLATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> When overridden in a derived class,cis invoked whenever 
        /// application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            //  Apply Template
            base.OnApplyTemplate();

            ApplyClickMethod(GetButton("upButton"), OnUpClick);
            ApplyClickMethod(GetButton("downButton"), OnDownClick);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get ButtonEx from ContentTemplate. </summary>
        /// <param name="buttonName"> ButtonEx name. </param>
        /// <returns> ButtonEx or null. </returns>
        protected ButtonEx GetButton(string buttonName)
        {
            return this.Template.FindName(buttonName, this) as ButtonEx;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Apply Click method on ButtonEx. </summary>
        /// <param name="buttonEx"> ButtonEx. </param>
        /// <param name="eventHandler"> Click method. </param>
        protected void ApplyClickMethod(ButtonEx buttonEx, RoutedEventHandler eventHandler)
        {
            if (buttonEx != null)
                buttonEx.Click += eventHandler;
        }

        #endregion TEMPLATE METHODS

    }
}
