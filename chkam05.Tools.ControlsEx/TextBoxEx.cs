using chkam05.Tools.ControlsEx.Static;
using chkam05.Tools.ControlsEx.Utilities;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using static chkam05.Tools.ControlsEx.Events.Delegates;


namespace chkam05.Tools.ControlsEx
{
    public class TextBoxEx : TextBox, INotifyPropertyChanged
    {

        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty MouseOverBackgroundProperty = DependencyProperty.Register(
            nameof(MouseOverBackground),
            typeof(Brush),
            typeof(TextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty MouseOverBorderBrushProperty = DependencyProperty.Register(
            nameof(MouseOverBorderBrush),
            typeof(Brush),
            typeof(TextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty MouseOverForegroundProperty = DependencyProperty.Register(
            nameof(MouseOverForeground),
            typeof(Brush),
            typeof(TextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty SelectedBackgroundProperty = DependencyProperty.Register(
            nameof(SelectedBackground),
            typeof(Brush),
            typeof(TextBoxEx),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty SelectedBorderBrushProperty = DependencyProperty.Register(
            nameof(SelectedBorderBrush),
            typeof(Brush),
            typeof(TextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_PRESSED)));

        public static readonly DependencyProperty SelectedForegroundProperty = DependencyProperty.Register(
            nameof(SelectedForeground),
            typeof(Brush),
            typeof(TextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty SelectedTextBackgroundProperty = DependencyProperty.Register(
            nameof(SelectedTextBackground),
            typeof(Brush),
            typeof(TextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        #endregion Appearance Colors Properties

        public static readonly DependencyProperty ConversionTypeProperty = DependencyProperty.Register(
            nameof(ConversionType),
            typeof(TextBoxConversionType),
            typeof(TextBoxEx),
            new PropertyMetadata(TextBoxConversionType.Text));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(TextBoxEx),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;
        public event TextModifiedEventHandler TextModified;
        public event TextModifiedEventHandler TextLiveModified;


        //  VARIABLES

        protected bool _focused = false;
        protected bool _lockUpdate = false;
        protected bool _textChanged = false;
        internal TextBoxExValidator _validator;


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

        public virtual TextBoxConversionType ConversionType
        {
            get => (TextBoxConversionType)GetValue(ConversionTypeProperty);
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


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> TextBoxEx class constructor. </summary>
        public TextBoxEx()
        {
            //  Initialize events.
            Loaded += OnLoaded;

            //  Initialize modules.
            _validator = new TextBoxExValidator();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static TextBoxEx class constructor. </summary>
        static TextBoxEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TextBoxEx),
                new FrameworkPropertyMetadata(typeof(TextBoxEx)));
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
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Enter && _focused)
                TextModified?.Invoke(this, new Events.TextModifiedEventArgs(Text, _validator.PreviousText, true));

            base.OnKeyDown(e);
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

                TextModified?.Invoke(this, new Events.TextModifiedEventArgs(Text, _validator.PreviousText, true));
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

            if (!_focused)
                TextModified?.Invoke(this, new Events.TextModifiedEventArgs(Text, _validator.PreviousText, false));

            TextLiveModified?.Invoke(this, new Events.TextModifiedEventArgs(Text, _validator.PreviousText, _focused));

            base.OnTextChanged(e);
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

    }
}
