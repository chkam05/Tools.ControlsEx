using chkam05.DotNetTools.ExtendedControls.Data.EventsModels;
using chkam05.DotNetTools.ExtendedControls.Data.Static;
using chkam05.DotNetTools.ExtendedControls.Utilities;
using System;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;


namespace chkam05.DotNetTools.ExtendedControls
{
    public class ExtendedPasswordBox : TextBox
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

        private static readonly char PASSWORD_CHARACTED_DEFAULT = '●';


        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundHiglihtedProperty = DependencyProperty.Register(
            nameof(BackgroundHiglihted), typeof(Brush), typeof(ExtendedPasswordBox),
            new PropertyMetadata(new SolidColorBrush(BACKGROUND_HIGLIHTED_COLOR_DEFAULT)));

        public static readonly DependencyProperty BackgroundSelectedProperty = DependencyProperty.Register(
            nameof(BackgroundSelected), typeof(Brush), typeof(ExtendedPasswordBox),
            new PropertyMetadata(new SolidColorBrush(BACKGROUND_SELECTED_COLOR_DEFAULT)));


        public static readonly DependencyProperty BorderBrushHiglihtedProperty = DependencyProperty.Register(
            nameof(BorderBrushHiglihted), typeof(Brush), typeof(ExtendedPasswordBox),
            new PropertyMetadata(new SolidColorBrush(BORDER_HIGLIHTED_COLOR_DEFAULT)));

        public static readonly DependencyProperty BorderBrushSelectedProperty = DependencyProperty.Register(
            nameof(BorderBrushSelected), typeof(Brush), typeof(ExtendedPasswordBox),
            new PropertyMetadata(new SolidColorBrush(BORDER_SELECTED_COLOR_DEFAULT)));


        public static readonly DependencyProperty ForegroundHiglihtedProperty = DependencyProperty.Register(
            nameof(ForegroundHiglihted), typeof(Brush), typeof(ExtendedPasswordBox),
            new PropertyMetadata(new SolidColorBrush(FOREGROUND_HIGLIHTED_COLOR_DEFAULT)));

        public static readonly DependencyProperty ForegroundSelectedProperty = DependencyProperty.Register(
            nameof(ForegroundSelected), typeof(Brush), typeof(ExtendedPasswordBox),
            new PropertyMetadata(new SolidColorBrush(FOREGROUND_SELECTED_COLOR_DEFAULT)));


        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius), typeof(CornerRadius), typeof(ExtendedPasswordBox),
            new PropertyMetadata(CORNER_RADIUS_DEFAULT));

        public static readonly DependencyProperty InteractionBehaviourProperty = DependencyProperty.Register(
            nameof(InteractionBehaviour), typeof(InteractionBehaviour), typeof(ExtendedPasswordBox),
            new PropertyMetadata(INTERACTION_BEHAVIOUR_DEFAULT));


        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(
            nameof(Password), typeof(SecureString), typeof(ExtendedPasswordBox), new UIPropertyMetadata(new SecureString()));

        public static readonly DependencyProperty PasswordCharacterProperty = DependencyProperty.Register(
            nameof(PasswordCharacter), typeof(char), typeof(ExtendedPasswordBox), new PropertyMetadata(PASSWORD_CHARACTED_DEFAULT));


        //  EVENTS

        public event EventHandler<TextChangeEventArgs> OnTextChange;


        //  VARIABLES

        /// <summary> Private member holding mask visibile timer. </summary>
        private readonly DispatcherTimer _maskTimer;


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

        public SecureString Password
        {
            get => (SecureString)GetValue(PasswordProperty);
            set => SetValue(PasswordProperty, value);
        }

        public char PasswordCharacter
        {
            get => (char)GetValue(PasswordCharacterProperty);
            set => SetValue(PasswordCharacterProperty, value);
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ExtendedPasswordBox class constructor. </summary>
        public ExtendedPasswordBox() : base()
        {
            Loaded += ExtendedPasswordBox_Loaded;
            GotFocus += ExtendedPasswordBox_GotFocus;
            LostFocus += ExtendedPasswordBox_LostFocus;
            PreviewTextInput += ExtendedPasswordBox_PreviewTextInput;
            PreviewKeyDown += ExtendedPasswordBox_PreviewKeyDown;
            TextChanged += ExtendedPasswordBox_TextChanged;

            CommandManager.AddPreviewExecutedHandler(this, PreviewExecutedHandler);

            _maskTimer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 1) };
            _maskTimer.Tick += (sender, args) => MaskAllDisplayText();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static class constructor to override default style. </summary>
        static ExtendedPasswordBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtendedPasswordBox),
                new FrameworkPropertyMetadata(typeof(ExtendedPasswordBox)));
        }

        #endregion CLASS METHODS

        #region COMPONENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method called when component is loaded, rendered and ready for interaction. </summary>
        /// <param name="sender"> Object that invoked an event. </param>
        /// <param name="e"> Routed event arguemnts. </param>
        private void ExtendedPasswordBox_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateInteractionBehaviourProperty(InteractionBehaviour);
        }

        #endregion COMPONENT METHODS

        #region COMPONENT INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method called when component got focused. </summary>
        /// <param name="sender"> Object that invoked an event. </param>
        /// <param name="e"> Routed event arguemnts. </param>
        private void ExtendedPasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            IsSelected = true;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method called when component lost focused. </summary>
        /// <param name="sender"> Object that invoked an event. </param>
        /// <param name="e"> Routed event arguemnts. </param>
        private void ExtendedPasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            IsSelected = false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method to handle PreviewTextInput events. </summary>
        /// <param name="sender"> Object that invoked an event. </param>
        /// <param name="textCompositionEventArgs"> Text composition event arguments. </param>
        private void ExtendedPasswordBox_PreviewTextInput(object sender,
            TextCompositionEventArgs textCompositionEventArgs)
        {
            AddToSecureString(textCompositionEventArgs.Text);
            textCompositionEventArgs.Handled = true;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method to handle PreviewKeyDown events. </summary>
        /// <param name="sender"> Object that invoked an event. </param>
        /// <param name="keyEventArgs"> Key event arguments. </param>
        private void ExtendedPasswordBox_PreviewKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            Key pressedKey = keyEventArgs.Key == Key.System ? keyEventArgs.SystemKey : keyEventArgs.Key;

            switch (pressedKey)
            {
                case Key.Space:
                    AddToSecureString(" ");
                    keyEventArgs.Handled = true;
                    break;

                case Key.Back:
                case Key.Delete:
                    if (SelectionLength > 0)
                    {
                        RemoveFromSecureString(SelectionStart, SelectionLength);
                    }
                    else if (pressedKey == Key.Delete && CaretIndex < Text.Length)
                    {
                        RemoveFromSecureString(CaretIndex, 1);
                    }
                    else if (pressedKey == Key.Back && CaretIndex > 0)
                    {
                        int caretIndex = CaretIndex;
                        if (CaretIndex > 0 && CaretIndex < Text.Length)
                            caretIndex = caretIndex - 1;
                        RemoveFromSecureString(CaretIndex - 1, 1);
                        CaretIndex = caretIndex;
                    }

                    keyEventArgs.Handled = true;
                    break;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method called when component text is changed. </summary>
        /// <param name="sender"> Object that invoked an event. </param>
        /// <param name="e"> Routed event arguemnts. </param>
        private void ExtendedPasswordBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            OnTextChange?.Invoke(this, new TextChangeEventArgs(Text, !IsSelected));
        }

        #endregion COMPONENT INTERACTION METHODS

        #region INTERFACE MANAGEMENT METHODS

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

        #endregion INTERFACE MANAGEMENT METHODS

        #region PASSWORD MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method to handle PreviewExecutedHandler events. </summary>
        /// <param name="sender"> Object that invoked an event. </param>
        /// <param name="executedRoutedEventArgs"> Executed routed event arguments. </param>
        private static void PreviewExecutedHandler(object sender, ExecutedRoutedEventArgs executedRoutedEventArgs)
        {
            if (executedRoutedEventArgs.Command == ApplicationCommands.Copy ||
                executedRoutedEventArgs.Command == ApplicationCommands.Cut ||
                executedRoutedEventArgs.Command == ApplicationCommands.Paste)
            {
                executedRoutedEventArgs.Handled = true;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method to add new text into SecureString and process visual output. </summary>
        /// <param name="text"> Text to be added. </param>
        private void AddToSecureString(string text)
        {
            if (SelectionLength > 0)
                RemoveFromSecureString(SelectionStart, SelectionLength);

            foreach (char c in text)
            {
                int caretIndex = CaretIndex;
                Password.InsertAt(caretIndex, c);
                MaskAllDisplayText();

                if (caretIndex == Text.Length)
                {
                    _maskTimer.Stop();
                    _maskTimer.Start();
                    Text = Text.Insert(caretIndex++, c.ToString());
                }
                else
                {
                    Text = Text.Insert(caretIndex++, $"{PasswordCharacter}");
                }

                CaretIndex = caretIndex;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method to remove text from SecureString and process visual output. </summary>
        /// <param name="startIndex"> Start Position for Remove. </param>
        /// <param name="trimLength"> Length of Text to be removed. </param>
        private void RemoveFromSecureString(int startIndex, int trimLength)
        {
            int caretIndex = CaretIndex;

            for (int i = 0; i < trimLength; ++i)
                Password.RemoveAt(startIndex);

            Text = Text.Remove(startIndex, trimLength);
            CaretIndex = caretIndex;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Mask all displayed characters in text. </summary>
        private void MaskAllDisplayText()
        {
            _maskTimer.Stop();

            int caretIndex = CaretIndex;
            Text = new string(PasswordCharacter, Text.Length);
            CaretIndex = caretIndex;
        }

        #endregion PASSWORD MANAGEMENT METHODS

    }
}
