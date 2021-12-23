using chkam05.DotNetTools.ExtendedControls.Data.EventsModels;
using chkam05.DotNetTools.ExtendedControls.Data.Static;
using chkam05.DotNetTools.ExtendedControls.Utilities;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace chkam05.DotNetTools.ExtendedControls
{
    public class ExtendedTextBox : TextBox
    {

        //  CONST

        private static readonly Color BACKGROUND_HIGLIHTED_COLOR_DEFAULT = Color.FromArgb(255, 255, 255, 255);
        private static readonly Color BACKGROUND_SELECTED_COLOR_DEFAULT = Color.FromArgb(255, 255, 255, 255);

        private static readonly Color BORDER_HIGLIHTED_COLOR_DEFAULT = Color.FromArgb(255, 126, 180, 234);
        private static readonly Color BORDER_SELECTED_COLOR_DEFAULT = Color.FromArgb(255, 86, 157, 229);

        private static readonly Color FOREGROUND_HIGLIHTED_COLOR_DEFAULT = Color.FromArgb(255, 0, 0, 0);
        private static readonly Color FOREGROUND_SELECTED_COLOR_DEFAULT = Color.FromArgb(255, 0, 0, 0);

        private static readonly CornerRadius CORNER_RADIUS_DEFAULT = new CornerRadius(4);

        private static readonly double INTERACTION_BEHAVIOUR_COLOR_SHADE_HIGLIHTED = 10;
        private static readonly double INTERACTION_BEHAVIOUR_COLOR_SHADE_SELECTED = 15;
        private static readonly InteractionBehaviour INTERACTION_BEHAVIOUR_DEFAULT = InteractionBehaviour.LightColorShading;

        public static readonly bool IS_NUMERIC_DEFAULT = false;
        public static readonly bool Is_NUMERIC_FLOATING_POINT_DEFAULT = false;
        public static readonly bool MUTLILINE_DEFAULT = false;

        public static readonly bool MULTILINE_ACCEPTS_RETURN = true;
        public static readonly double MULTILINE_MIN_HEIGHT_DEFAULT = 64;
        public static readonly ScrollBarVisibility MULTILINE_VSCROLLBAR_VISIBILITY_DEFAULT = ScrollBarVisibility.Visible;
        public static readonly VerticalAlignment MULTILINE_VCONTENT_ALIGNMENT_DEFAULT = VerticalAlignment.Stretch;
        public static readonly TextWrapping MULTILINE_TEXT_WRAPPING_CONTENT = TextWrapping.Wrap;

        public static readonly bool SINGLELINE_ACCEPTS_RETURN = false;
        public static readonly double SINGLELINE_MIN_HEIGHT_DEFAULT = 24;
        public static readonly ScrollBarVisibility SINGLELINE_VSCROLLBAR_VISIBILITY_DEFAULT = ScrollBarVisibility.Disabled;
        public static readonly VerticalAlignment SINGLELINE_VCONTENT_ALIGNMENT_DEFAULT = VerticalAlignment.Center;
        public static readonly TextWrapping SINGLELINE_TEXT_WRAPPING_CONTENT = TextWrapping.NoWrap;


        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundHiglihtedProperty = DependencyProperty.Register(
            nameof(BackgroundHiglihted), typeof(Brush), typeof(ExtendedTextBox),
            new PropertyMetadata(new SolidColorBrush(BACKGROUND_HIGLIHTED_COLOR_DEFAULT)));

        public static readonly DependencyProperty BackgroundSelectedProperty = DependencyProperty.Register(
            nameof(BackgroundSelected), typeof(Brush), typeof(ExtendedTextBox),
            new PropertyMetadata(new SolidColorBrush(BACKGROUND_SELECTED_COLOR_DEFAULT)));


        public static readonly DependencyProperty BorderBrushHiglihtedProperty = DependencyProperty.Register(
            nameof(BorderBrushHiglihted), typeof(Brush), typeof(ExtendedTextBox),
            new PropertyMetadata(new SolidColorBrush(BORDER_HIGLIHTED_COLOR_DEFAULT)));

        public static readonly DependencyProperty BorderBrushSelectedProperty = DependencyProperty.Register(
            nameof(BorderBrushSelected), typeof(Brush), typeof(ExtendedTextBox),
            new PropertyMetadata(new SolidColorBrush(BORDER_SELECTED_COLOR_DEFAULT)));


        public static readonly DependencyProperty ForegroundHiglihtedProperty = DependencyProperty.Register(
            nameof(ForegroundHiglihted), typeof(Brush), typeof(ExtendedTextBox),
            new PropertyMetadata(new SolidColorBrush(FOREGROUND_HIGLIHTED_COLOR_DEFAULT)));

        public static readonly DependencyProperty ForegroundSelectedProperty = DependencyProperty.Register(
            nameof(ForegroundSelected), typeof(Brush), typeof(ExtendedTextBox),
            new PropertyMetadata(new SolidColorBrush(FOREGROUND_SELECTED_COLOR_DEFAULT)));


        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius), typeof(CornerRadius), typeof(ExtendedTextBox),
            new PropertyMetadata(CORNER_RADIUS_DEFAULT));

        public static readonly DependencyProperty InteractionBehaviourProperty = DependencyProperty.Register(
            nameof(InteractionBehaviour), typeof(InteractionBehaviour), typeof(ExtendedTextBox),
            new PropertyMetadata(INTERACTION_BEHAVIOUR_DEFAULT));


        public static readonly DependencyProperty IsNumericProperty = DependencyProperty.Register(
            nameof(IsNumeric), typeof(bool), typeof(ExtendedTextBox),
            new PropertyMetadata(IS_NUMERIC_DEFAULT));

        public static readonly DependencyProperty IsNumericFloatingPointProperty = DependencyProperty.Register(
            nameof(IsNumericFloatingPoint), typeof(bool), typeof(ExtendedTextBox),
            new PropertyMetadata(Is_NUMERIC_FLOATING_POINT_DEFAULT));


        public static readonly DependencyProperty MultilineProperty = DependencyProperty.Register(
            nameof(Multiline), typeof(bool), typeof(ExtendedTextBox), new PropertyMetadata(MUTLILINE_DEFAULT));


        public static new readonly DependencyProperty VerticalContentAlignmentProperty = DependencyProperty.Register(
            nameof(VerticalContentAlignment), typeof(VerticalAlignment), typeof(ExtendedTextBox),
            new PropertyMetadata(SINGLELINE_VCONTENT_ALIGNMENT_DEFAULT));


        //  EVENTS

        public event EventHandler<TextChangeEventArgs> OnTextChange;


        //  VARIABLES

        private NumericTextValidator _numericTextValidator;


        //  GETTERS & SETTERS

        public Brush BackgroundHiglihted
        {
            get => (Brush)GetValue(BackgroundHiglihtedProperty);
            set => SetValue(BackgroundHiglihtedProperty, value);
        }

        public Brush BackgroundSelected
        {
            get => (Brush)GetValue(BackgroundSelectedProperty);
            set => SetValue(BackgroundSelectedProperty, value);
        }


        public Brush BorderBrushHiglihted
        {
            get => (Brush)GetValue(BorderBrushHiglihtedProperty);
            set => SetValue(BorderBrushHiglihtedProperty, value);
        }

        public Brush BorderBrushSelected
        {
            get => (Brush)GetValue(BorderBrushSelectedProperty);
            set => SetValue(BorderBrushSelectedProperty, value);
        }


        public Brush ForegroundHiglihted
        {
            get => (Brush)GetValue(ForegroundHiglihtedProperty);
            set => SetValue(ForegroundHiglihtedProperty, value);
        }

        public Brush ForegroundSelected
        {
            get => (Brush)GetValue(ForegroundSelectedProperty);
            set => SetValue(ForegroundSelectedProperty, value);
        }


        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public InteractionBehaviour InteractionBehaviour
        {
            get
            {
                return (InteractionBehaviour)GetValue(InteractionBehaviourProperty);
            }
            set
            {
                SetValue(InteractionBehaviourProperty, value);
                UpdateInteractionBehaviourProperty(value);
            }
        }

        public bool IsSelected { get; private set; }

        public bool Multiline
        {
            get
            {
                return (bool)this.GetValue(MultilineProperty);
            }
            set
            {
                SetValue(MultilineProperty, value);
                UpdateMultilineProperty(value);
            }
        }

        public bool IsNumeric
        {
            get
            {
                return (bool)GetValue(IsNumericProperty);
            }
            set
            {
                SetValue(IsNumericProperty, value);
                UpdateIsNumericProperty(value);
            }
        }

        public bool IsNumericFloatingPoint
        {
            get
            {
                return (bool)GetValue(IsNumericFloatingPointProperty);
            }
            set
            {
                SetValue(IsNumericFloatingPointProperty, value);
                _numericTextValidator.FloatingPointValue = value;
            }
        }

        public new VerticalAlignment VerticalContentAlignment
        {
            get
            {
                return (VerticalAlignment)this.GetValue(MultilineProperty);
            }
            set
            {
                SetValue(VerticalContentAlignmentProperty, value);
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ExtendedTextBox class constructor. </summary>
        public ExtendedTextBox() : base()
        {
            _numericTextValidator = new NumericTextValidator();

            Loaded += ExtendedTextBox_Loaded;
            GotFocus += ExtendedTextBox_GotFocus;
            LostFocus += ExtendedTextBox_LostFocus;
            base.TextChanged += ExtendedTextBox_TextChanged;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static class constructor to override default style. </summary>
        static ExtendedTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtendedTextBox),
                new FrameworkPropertyMetadata(typeof(ExtendedTextBox)));
        }

        #endregion CLASS METHODS

        #region COMPONENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method called when component is loaded, rendered and ready for interaction. </summary>
        /// <param name="sender"> Object that invoked an event. </param>
        /// <param name="e"> Routed event arguemnts. </param>
        private void ExtendedTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateInteractionBehaviourProperty(InteractionBehaviour);
            UpdateMultilineProperty(Multiline);
        }

        #endregion COMPONENT METHODS

        #region COMPONENT INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method called when component got focused. </summary>
        /// <param name="sender"> Object that invoked an event. </param>
        /// <param name="e"> Routed event arguemnts. </param>
        private void ExtendedTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            IsSelected = true;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method called when component lost focused. </summary>
        /// <param name="sender"> Object that invoked an event. </param>
        /// <param name="e"> Routed event arguemnts. </param>
        private void ExtendedTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            IsSelected = false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method called when component text is changed. </summary>
        /// <param name="sender"> Object that invoked an event. </param>
        /// <param name="e"> Routed event arguemnts. </param>
        private void ExtendedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool isValid = true;

            if (IsNumeric)
                isValid = _numericTextValidator.ValidateOnTextBox(this);

            if (isValid)
                OnTextChange?.Invoke(this, new TextChangeEventArgs(Text, !IsSelected));
        }

        #endregion COMPONENT INTERACTION METHODS

        #region INTERFACE MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method for update data in case of using numeric values. </summary>
        /// <param name="isNumericPropertyValue"> Component isNumeric property value. </param>
        private void UpdateIsNumericProperty(bool isNumericPropertyValue)
        {
            if (isNumericPropertyValue)
                _numericTextValidator.ValidateOnTextBox(this);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method for adjust other component properties to interaction behaviour. </summary>
        /// <param name="multiLinePropertyValue"> Component multiline property value. </param>
        private void UpdateInteractionBehaviourProperty(InteractionBehaviour interactionBehaviourPropertyValue)
        {
            switch (interactionBehaviourPropertyValue)
            {
                case InteractionBehaviour.Nothing:

                    BackgroundHiglihted = Background;
                    BackgroundSelected = Background;

                    BorderBrushHiglihted = BorderBrush;
                    BorderBrushSelected = BorderBrush;

                    ForegroundHiglihted = Foreground;
                    ForegroundSelected = Foreground;

                    break;

                case InteractionBehaviour.DarkColorShading:

                    BackgroundHiglihted = new SolidColorBrush(
                        ColorShader.DimColor(
                            BrushColorRetriever.GetColorFromBrush(Background, BACKGROUND_HIGLIHTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_HIGLIHTED));

                    BackgroundSelected = new SolidColorBrush(
                        ColorShader.DimColor(
                            BrushColorRetriever.GetColorFromBrush(Background, BACKGROUND_SELECTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_SELECTED));

                    BorderBrushHiglihted = new SolidColorBrush(
                        ColorShader.DimColor(
                            BrushColorRetriever.GetColorFromBrush(BorderBrush, BORDER_HIGLIHTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_HIGLIHTED));

                    BorderBrushSelected = new SolidColorBrush(
                        ColorShader.DimColor(
                            BrushColorRetriever.GetColorFromBrush(BorderBrush, BORDER_SELECTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_SELECTED));

                    ForegroundHiglihted = Foreground;
                    ForegroundSelected = Foreground;

                    break;

                case InteractionBehaviour.LightColorShading:

                    BackgroundHiglihted = new SolidColorBrush(
                        ColorShader.BrightColor(
                            BrushColorRetriever.GetColorFromBrush(Background, BACKGROUND_HIGLIHTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_HIGLIHTED));

                    BackgroundSelected = new SolidColorBrush(
                        ColorShader.BrightColor(
                            BrushColorRetriever.GetColorFromBrush(Background, BACKGROUND_SELECTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_SELECTED));

                    BorderBrushHiglihted = new SolidColorBrush(
                        ColorShader.BrightColor(
                            BrushColorRetriever.GetColorFromBrush(BorderBrush, BORDER_HIGLIHTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_HIGLIHTED));

                    BorderBrushSelected = new SolidColorBrush(
                        ColorShader.BrightColor(
                            BrushColorRetriever.GetColorFromBrush(BorderBrush, BORDER_SELECTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_SELECTED));

                    ForegroundHiglihted = Foreground;
                    ForegroundSelected = Foreground;

                    break;

                case InteractionBehaviour.CustomColors:

                    break;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method for adjust other component properties to multi line property. </summary>
        /// <param name="multiLinePropertyValue"> Component multiline property value. </param>
        private void UpdateMultilineProperty(bool multiLinePropertyValue)
        {
            if (multiLinePropertyValue)
            {
                AcceptsReturn = MULTILINE_ACCEPTS_RETURN;
                MinHeight = MULTILINE_MIN_HEIGHT_DEFAULT;
                VerticalContentAlignment = MULTILINE_VCONTENT_ALIGNMENT_DEFAULT;
                VerticalScrollBarVisibility = MULTILINE_VSCROLLBAR_VISIBILITY_DEFAULT;
                TextWrapping = MULTILINE_TEXT_WRAPPING_CONTENT;
            }
            else
            {
                AcceptsReturn = SINGLELINE_ACCEPTS_RETURN;
                MinHeight = SINGLELINE_MIN_HEIGHT_DEFAULT;
                VerticalContentAlignment = SINGLELINE_VCONTENT_ALIGNMENT_DEFAULT;
                VerticalScrollBarVisibility = SINGLELINE_VSCROLLBAR_VISIBILITY_DEFAULT;
                TextWrapping = SINGLELINE_TEXT_WRAPPING_CONTENT;
            }

            if (ActualHeight < MinHeight)
            {
                Height = MinHeight;
            }
        }

        #endregion INTERFACE MANAGEMENT METHODS

    }
}
