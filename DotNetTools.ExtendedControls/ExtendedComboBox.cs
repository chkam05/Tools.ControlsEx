using chkam05.DotNetTools.ExtendedControls.Data.Static;
using chkam05.DotNetTools.ExtendedControls.Utilities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace chkam05.DotNetTools.ExtendedControls
{
    public class ExtendedComboBox : ComboBox
    {

        //  CONST

        private static readonly Color BACKGROUND_HIGLIHTED_COLOR_DEFAULT = Color.FromArgb(255, 255, 255, 255);
        private static readonly Color BACKGROUND_SELECTED_COLOR_DEFAULT = Color.FromArgb(255, 255, 255, 255);

        private static readonly Color BORDER_HIGLIHTED_COLOR_DEFAULT = Color.FromArgb(255, 126, 180, 234);
        private static readonly Color BORDER_SELECTED_COLOR_DEFAULT = Color.FromArgb(255, 86, 157, 229);

        private static readonly Color FOREGROUND_HIGLIHTED_COLOR_DEFAULT = Color.FromArgb(255, 0, 0, 0);
        private static readonly Color FOREGROUND_SELECTED_COLOR_DEFAULT = Color.FromArgb(255, 0, 0, 0);

        private static readonly Color DROPDOWN_BACKGROUND_COLOR_DEFAULT = Color.FromArgb(255, 255, 255, 255);
        private static readonly Color DROPDOWN_BORDER_BRUSH_COLOR_DEFAULT = Color.FromArgb(255, 172, 172, 172);

        private static readonly Color GRYPHL_BRUSH_COLOR_DEFAULT = Color.FromArgb(255, 96, 96, 96);
        private static readonly Color GRYPHL_BRUSH_HIGLIHTED_COLOR_DEFAULT = Color.FromArgb(255, 126, 180, 234);
        private static readonly Color GRYPHL_BRUSH_SELECTED_COLOR_DEFAULT = Color.FromArgb(255, 86, 157, 229);

        private static readonly CornerRadius CORNER_RADIUS_DEFAULT = new CornerRadius(4);
        private static readonly CornerRadius DROPDOWN_CORNER_RADIUS_DEFAULT = new CornerRadius(4);

        private static readonly double INTERACTION_BEHAVIOUR_COLOR_SHADE_HIGLIHTED = 10;
        private static readonly double INTERACTION_BEHAVIOUR_COLOR_SHADE_SELECTED = 15;
        private static readonly InteractionBehaviour INTERACTION_BEHAVIOUR_DEFAULT = InteractionBehaviour.LightColorShading;


        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundHiglihtedProperty = DependencyProperty.Register(
            nameof(BackgroundHiglihted), typeof(Brush), typeof(ExtendedComboBox),
            new PropertyMetadata(new SolidColorBrush(BACKGROUND_HIGLIHTED_COLOR_DEFAULT)));

        public static readonly DependencyProperty BackgroundSelectedProperty = DependencyProperty.Register(
            nameof(BackgroundSelected), typeof(Brush), typeof(ExtendedComboBox),
            new PropertyMetadata(new SolidColorBrush(BACKGROUND_SELECTED_COLOR_DEFAULT)));


        public static readonly DependencyProperty BorderBrushHiglihtedProperty = DependencyProperty.Register(
            nameof(BorderBrushHiglihted), typeof(Brush), typeof(ExtendedComboBox),
            new PropertyMetadata(new SolidColorBrush(BORDER_HIGLIHTED_COLOR_DEFAULT)));

        public static readonly DependencyProperty BorderBrushSelectedProperty = DependencyProperty.Register(
            nameof(BorderBrushSelected), typeof(Brush), typeof(ExtendedComboBox),
            new PropertyMetadata(new SolidColorBrush(BORDER_SELECTED_COLOR_DEFAULT)));


        public static readonly DependencyProperty ForegroundHiglihtedProperty = DependencyProperty.Register(
            nameof(ForegroundHiglihted), typeof(Brush), typeof(ExtendedComboBox),
            new PropertyMetadata(new SolidColorBrush(FOREGROUND_HIGLIHTED_COLOR_DEFAULT)));

        public static readonly DependencyProperty ForegroundSelectedProperty = DependencyProperty.Register(
            nameof(ForegroundSelected), typeof(Brush), typeof(ExtendedComboBox),
            new PropertyMetadata(new SolidColorBrush(FOREGROUND_SELECTED_COLOR_DEFAULT)));


        public static readonly DependencyProperty DropdownBackgroundProperty = DependencyProperty.Register(
            nameof(DropdownBackground), typeof(Brush), typeof(ExtendedComboBox),
            new PropertyMetadata(new SolidColorBrush(DROPDOWN_BACKGROUND_COLOR_DEFAULT)));

        public static readonly DependencyProperty DropdownBorderBrushProperty = DependencyProperty.Register(
            nameof(DropdownBorderBrush), typeof(Brush), typeof(ExtendedComboBox),
            new PropertyMetadata(new SolidColorBrush(DROPDOWN_BORDER_BRUSH_COLOR_DEFAULT)));


        public static readonly DependencyProperty GryphlBrushProperty = DependencyProperty.Register(
            nameof(GryphlBrush), typeof(Brush), typeof(ExtendedComboBox),
            new PropertyMetadata(new SolidColorBrush(GRYPHL_BRUSH_COLOR_DEFAULT)));

        public static readonly DependencyProperty GryphlBrushHiglihtedProperty = DependencyProperty.Register(
            nameof(GryphlBrushHiglihted), typeof(Brush), typeof(ExtendedComboBox),
            new PropertyMetadata(new SolidColorBrush(GRYPHL_BRUSH_HIGLIHTED_COLOR_DEFAULT)));

        public static readonly DependencyProperty GryphlBrushSelectedProperty = DependencyProperty.Register(
            nameof(GryphlBrushSelected), typeof(Brush), typeof(ExtendedComboBox),
            new PropertyMetadata(new SolidColorBrush(GRYPHL_BRUSH_SELECTED_COLOR_DEFAULT)));


        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius), typeof(CornerRadius), typeof(ExtendedComboBox),
            new PropertyMetadata(CORNER_RADIUS_DEFAULT));

        public static readonly DependencyProperty DropdownCornerRadiusProperty = DependencyProperty.Register(
            nameof(DropdownCornerRadius), typeof(CornerRadius), typeof(ExtendedComboBox),
            new PropertyMetadata(DROPDOWN_CORNER_RADIUS_DEFAULT));

        public static readonly DependencyProperty InteractionBehaviourProperty = DependencyProperty.Register(
            nameof(InteractionBehaviour), typeof(InteractionBehaviour), typeof(ExtendedComboBox),
            new PropertyMetadata(INTERACTION_BEHAVIOUR_DEFAULT));


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


        public Brush DropdownBackground
        {
            get => (Brush)GetValue(DropdownBackgroundProperty);
            set => SetValue(DropdownBackgroundProperty, value);
        }

        public Brush DropdownBorderBrush
        {
            get => (Brush)GetValue(DropdownBorderBrushProperty);
            set => SetValue(DropdownBorderBrushProperty, value);
        }


        public Brush GryphlBrush
        {
            get => (Brush)GetValue(GryphlBrushProperty);
            set => SetValue(GryphlBrushProperty, value);
        }

        public Brush GryphlBrushHiglihted
        {
            get => (Brush)GetValue(GryphlBrushHiglihtedProperty);
            set => SetValue(GryphlBrushHiglihtedProperty, value);
        }

        public Brush GryphlBrushSelected
        {
            get => (Brush)GetValue(GryphlBrushSelectedProperty);
            set => SetValue(GryphlBrushSelectedProperty, value);
        }


        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public CornerRadius DropdownCornerRadius
        {
            get => (CornerRadius)GetValue(DropdownCornerRadiusProperty);
            set => SetValue(DropdownCornerRadiusProperty, value);
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


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ExtendedComboBox class constructor. </summary>
        public ExtendedComboBox() : base()
        {
            Loaded += ExtendedComboBox_Loaded;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static class constructor to override default style. </summary>
        static ExtendedComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtendedComboBox),
                new FrameworkPropertyMetadata(typeof(ExtendedComboBox)));
        }

        #endregion CLASS METHODS

        #region COMPONENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method called when component is loaded, rendered and ready for interaction. </summary>
        /// <param name="sender"> Object that invoked an event. </param>
        /// <param name="e"> Routed event arguemnts. </param>
        private void ExtendedComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateInteractionBehaviourProperty(InteractionBehaviour);
        }

        #endregion COMPONENT METHODS

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

                    GryphlBrushHiglihted = GryphlBrush;
                    GryphlBrushSelected = GryphlBrush;

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

                    GryphlBrushHiglihted = new SolidColorBrush(
                        ColorShader.DimColor(
                            BrushColorRetriever.GetColorFromBrush(GryphlBrush, GRYPHL_BRUSH_HIGLIHTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_HIGLIHTED));

                    GryphlBrushSelected = new SolidColorBrush(
                        ColorShader.DimColor(
                            BrushColorRetriever.GetColorFromBrush(GryphlBrush, GRYPHL_BRUSH_SELECTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_SELECTED));

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

                    GryphlBrushHiglihted = new SolidColorBrush(
                        ColorShader.BrightColor(
                            BrushColorRetriever.GetColorFromBrush(GryphlBrush, GRYPHL_BRUSH_HIGLIHTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_HIGLIHTED));

                    GryphlBrushSelected = new SolidColorBrush(
                        ColorShader.BrightColor(
                            BrushColorRetriever.GetColorFromBrush(GryphlBrush, GRYPHL_BRUSH_SELECTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_SELECTED));

                    break;

                case InteractionBehaviour.CustomColors:

                    break;
            }
        }

        #endregion INTERFACE MANAGEMENT METHODS

    }
}
