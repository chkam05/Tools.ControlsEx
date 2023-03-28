using chkam05.Tools.ControlsEx.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static chkam05.Tools.ControlsEx.Events.Delegates;

namespace chkam05.Tools.ControlsEx
{
    public class UpDownLongTextBoxEx : TextBox, INotifyPropertyChanged
    {

        //  CONST

        protected readonly static double BUTTON_HEIGHT = 12d;
        protected readonly static double BUTTON_WIDTH = 12d;


        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty ButtonBackgroundProperty = DependencyProperty.Register(
            nameof(ButtonBackground),
            typeof(Brush),
            typeof(UpDownLongTextBoxEx),
            new PropertyMetadata(Brushes.Transparent));

        public static readonly DependencyProperty ButtonBorderBrushProperty = DependencyProperty.Register(
            nameof(ButtonBorderBrush),
            typeof(Brush),
            typeof(UpDownLongTextBoxEx),
            new PropertyMetadata(Brushes.Transparent));

        public static readonly DependencyProperty ButtonForegroundProperty = DependencyProperty.Register(
            nameof(ButtonForeground),
            typeof(Brush),
            typeof(UpDownLongTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty ButtonMouseOverBackgroundProperty = DependencyProperty.Register(
            nameof(ButtonMouseOverBackground),
            typeof(Brush),
            typeof(UpDownLongTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty ButtonMouseOverBorderBrushProperty = DependencyProperty.Register(
            nameof(ButtonMouseOverBorderBrush),
            typeof(Brush),
            typeof(UpDownLongTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty ButtonMouseOverForegroundProperty = DependencyProperty.Register(
            nameof(ButtonMouseOverForeground),
            typeof(Brush),
            typeof(UpDownLongTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty ButtonPressedBackgroundProperty = DependencyProperty.Register(
            nameof(ButtonPressedBackground),
            typeof(Brush),
            typeof(UpDownLongTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_PRESSED)));

        public static readonly DependencyProperty ButtonPressedBorderBrushProperty = DependencyProperty.Register(
            nameof(ButtonPressedBorderBrush),
            typeof(Brush),
            typeof(UpDownLongTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_PRESSED)));

        public static readonly DependencyProperty ButtonPressedForegroundProperty = DependencyProperty.Register(
            nameof(ButtonPressedForeground),
            typeof(Brush),
            typeof(UpDownLongTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty MouseOverBackgroundProperty = DependencyProperty.Register(
            nameof(MouseOverBackground),
            typeof(Brush),
            typeof(UpDownLongTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty MouseOverBorderBrushProperty = DependencyProperty.Register(
            nameof(MouseOverBorderBrush),
            typeof(Brush),
            typeof(UpDownLongTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty MouseOverForegroundProperty = DependencyProperty.Register(
            nameof(MouseOverForeground),
            typeof(Brush),
            typeof(UpDownLongTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty SelectedBackgroundProperty = DependencyProperty.Register(
            nameof(SelectedBackground),
            typeof(Brush),
            typeof(UpDownLongTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty SelectedBorderBrushProperty = DependencyProperty.Register(
            nameof(SelectedBorderBrush),
            typeof(Brush),
            typeof(UpDownLongTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_PRESSED)));

        public static readonly DependencyProperty SelectedForegroundProperty = DependencyProperty.Register(
            nameof(SelectedForeground),
            typeof(Brush),
            typeof(UpDownLongTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty SelectedTextBackgroundProperty = DependencyProperty.Register(
            nameof(SelectedTextBackground),
            typeof(Brush),
            typeof(UpDownLongTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        #endregion Appearance Colors Properties

        #region Buttons Properties

        public static readonly DependencyProperty ButtonBorderThicknessProperty = DependencyProperty.Register(
            nameof(ButtonBorderThickness),
            typeof(Thickness),
            typeof(UpDownLongTextBoxEx),
            new PropertyMetadata(new Thickness(0)));

        public static readonly DependencyProperty ButtonHeightProperty = DependencyProperty.Register(
            nameof(ButtonHeight),
            typeof(double),
            typeof(UpDownLongTextBoxEx),
            new PropertyMetadata(BUTTON_HEIGHT));

        public static readonly DependencyProperty ButtonWidthProperty = DependencyProperty.Register(
            nameof(ButtonWidth),
            typeof(double),
            typeof(UpDownLongTextBoxEx),
            new PropertyMetadata(BUTTON_WIDTH));

        #endregion Buttons Properties

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(UpDownLongTextBoxEx),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            nameof(MaxValue),
            typeof(long),
            typeof(UpDownLongTextBoxEx),
            new PropertyMetadata(long.MaxValue));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            nameof(MinValue),
            typeof(long),
            typeof(UpDownLongTextBoxEx),
            new PropertyMetadata(long.MinValue));

        public static readonly DependencyProperty TickProperty = DependencyProperty.Register(
            nameof(Tick),
            typeof(long),
            typeof(UpDownLongTextBoxEx),
            new PropertyMetadata(1L));

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            nameof(Value),
            typeof(long),
            typeof(UpDownLongTextBoxEx),
            new PropertyMetadata(0L, new PropertyChangedCallback(OnValuePropertyChanged)));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;
        public event UpDownLongModifiedEventHandler ValueModified;


        //  VARIABLES

        private string _correctValue = 0L.ToString();
        private bool _focused = false;
        private bool _lockUpdate = false;
        private bool _lockUpdateValue = false;
        private bool _textChanged = false;


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

        public Brush ButtonBorderBrush
        {
            get => (Brush)GetValue(ButtonBorderBrushProperty);
            set
            {
                SetValue(ButtonBorderBrushProperty, value);
                OnPropertyChanged(nameof(ButtonBorderBrush));
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

        public Brush ButtonMouseOverBorderBrush
        {
            get => (Brush)GetValue(ButtonMouseOverBorderBrushProperty);
            set
            {
                SetValue(ButtonMouseOverBorderBrushProperty, value);
                OnPropertyChanged(nameof(ButtonMouseOverBorderBrush));
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

        public Brush ButtonPressedBorderBrush
        {
            get => (Brush)GetValue(ButtonPressedBorderBrushProperty);
            set
            {
                SetValue(ButtonPressedBorderBrushProperty, value);
                OnPropertyChanged(nameof(ButtonPressedBorderBrush));
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

        public Thickness ButtonBorderThickness
        {
            get => (Thickness)GetValue(ButtonBorderThicknessProperty);
            set
            {
                SetValue(ButtonBorderThicknessProperty, value);
                OnPropertyChanged(nameof(ButtonBorderThickness));
            }
        }

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

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set
            {
                SetValue(CornerRadiusProperty, value);
                OnPropertyChanged(nameof(CornerRadius));
            }
        }

        public long MaxValue
        {
            get => (long)GetValue(MaxValueProperty);
            set
            {
                SetValue(MaxValueProperty, Math.Max(MinValue, value));
                OnPropertyChanged(nameof(MaxValue));
            }
        }

        public long MinValue
        {
            get => (long)GetValue(MinValueProperty);
            set
            {
                SetValue(MinValueProperty, Math.Min(MaxValue, value));
                OnPropertyChanged(nameof(MinValue));
            }
        }

        public long Tick
        {
            get => (long)GetValue(TickProperty);
            set
            {
                SetValue(TickProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(Tick));
            }
        }

        public new string Text
        {
            get => (string)GetValue(TextProperty);
            set
            {
                SetValue(TextProperty, value);
                OnPropertyChanged(nameof(Text));
                OnPropertyChanged(nameof(Value));
            }
        }

        public long Value
        {
            get
            {
                return (long)GetValue(ValueProperty);
            }
            set
            {
                SetValue(ValueProperty, Math.Min(MaxValue, Math.Max(MinValue, value)));
                OnPropertyChanged(nameof(Value));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> UpDownLongTextBoxEx class constructor. </summary>
        public UpDownLongTextBoxEx() : base()
        {
            //  Initialize events.
            Loaded += OnLoaded;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static UpDownLongTextBoxEx class constructor. </summary>
        static UpDownLongTextBoxEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UpDownLongTextBoxEx),
                new FrameworkPropertyMetadata(typeof(UpDownLongTextBoxEx)));
        }

        #endregion CLASS METHODS

        #region COMPONENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading control. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (Text != Value.ToString())
            {
                _lockUpdate = true;
                long value = Math.Min(MaxValue, Math.Max(MinValue, Value));
                _correctValue = value.ToString();
                Text = _correctValue;
            }
        }

        #endregion COMPONENT METHODS

        #region CONVERSION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Try covert value to numeric. </summary>
        /// <param name="value"> Value to convert. </param>
        /// <param name="resultValue"> Converted value as text. </param>
        /// <param name="editMode"> Converting in edit mode. </param>
        /// <returns> True - conversion successed; False - otherwise. </returns>
        private bool TryConvertValue(string value, out string resultValue, bool editMode = false)
        {
            if (editMode && (string.IsNullOrEmpty(value) || value == "-"))
            {
                resultValue = value;
                return true;
            }

            bool canConvert = long.TryParse(value, out long _);

            if (canConvert)
            {
                resultValue = value;
                _correctValue = value;
            }
            else
            {
                resultValue = _correctValue;
            }
            
            return canConvert;
        }

        #endregion CONVERSION METHODS

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

                if (!TryConvertValue(Text, out string correctText))
                {
                    _lockUpdate = true;
                    Text = correctText;
                }

                _lockUpdateValue = true;
                Value = long.Parse(Text);
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

                    if (!TryConvertValue(Text, out string _correctValue, true))
                    {
                        int carretPosition = SelectionStart;
                        int textLength = Text.Length;
                        int textLengthDiff = Math.Max(0, textLength - _correctValue.Length);

                        _lockUpdate = true;
                        Text = _correctValue;
                        SelectionStart = Math.Max(0, Math.Min(carretPosition - textLengthDiff, _correctValue.Length));
                    }
                }
                else if (!TryConvertValue(Text, out string correctText))
                {
                    _lockUpdate = true;
                    Text = correctText;
                }

                _lockUpdateValue = true;
                Value = long.Parse(Text);
            }
            else
            {
                _lockUpdate = false;
            }

            OnTextModifiedInvoke();

            base.OnTextChanged(e);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing text. </summary>
        private void OnTextModifiedInvoke()
        {
            ValueModified?.Invoke(this, new Events.UpDownLongModifiedEventArgs(
                long.TryParse(Text, out long value) ? value : 0L,
                long.TryParse(_correctValue, out long corrValue) ? corrValue : 0L,
                _focused));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Up Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void OnUpClick(object sender, RoutedEventArgs e)
        {
            var notFocused = !_focused;

            if (notFocused)
                _focused = true;

            if (long.TryParse(Text, out long lValue))
            {
                _lockUpdate = true;
                _lockUpdateValue = true;
                long value = Math.Min(lValue + Tick, Math.Min(long.MaxValue, MaxValue));
                Text = value.ToString();
                Value = value;
            }

            if (notFocused)
                _focused = false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Down Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void OnDownClick(object sender, RoutedEventArgs e)
        {
            var notFocused = !_focused;

            if (notFocused)
                _focused = true;

            if (long.TryParse(Text, out long lValue))
            {
                _lockUpdate = true;
                _lockUpdateValue = true;
                long value = Math.Max(lValue - Tick, Math.Max(long.MinValue, MinValue));
                Text = value.ToString();
                Value = value;
            }

            if (notFocused)
                _focused = false;
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

        //  --------------------------------------------------------------------------------
        private static void OnValuePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var upDown = o as UpDownLongTextBoxEx;

            if (upDown != null)
            {
                if (!upDown._lockUpdateValue)
                {
                    upDown._lockUpdate = true;
                    upDown.Text = e.NewValue.ToString();
                }

                upDown._lockUpdateValue = false;
                upDown.OnPropertyChanged(nameof(Value));
            }
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
