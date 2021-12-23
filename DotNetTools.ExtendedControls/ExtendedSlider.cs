using chkam05.DotNetTools.ExtendedControls.Data.Static;
using chkam05.DotNetTools.ExtendedControls.Utilities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace chkam05.DotNetTools.ExtendedControls
{
    public class ExtendedSlider : Slider
    {

        //  CONST

        private static readonly CornerRadius CORNER_RADIUS_DEFAULT = new CornerRadius(4);

        private static readonly double INTERACTION_BEHAVIOUR_COLOR_SHADE_HIGLIHTED = 10;
        private static readonly double INTERACTION_BEHAVIOUR_COLOR_SHADE_SELECTED = 15;
        private static readonly InteractionBehaviour INTERACTION_BEHAVIOUR_DEFAULT = InteractionBehaviour.LightColorShading;

        private static readonly Color THUMB_BACKGROUND_COLOR_DEFAULT = Color.FromArgb(255, 240, 240, 240);
        private static readonly Color THUMB_BACKGROUND_HIGLIHTED_COLOR_DEFAULT = Color.FromArgb(255, 220, 236, 252);
        private static readonly Color THUMB_BACKGROUND_SELECTED_COLOR_DEFAULT = Color.FromArgb(255, 218, 236, 252);

        private static readonly Color THUMB_BORDER_BRUSH_COLOR_DEFAULT = Color.FromArgb(255, 172, 172, 172);
        private static readonly Color THUMB_BORDER_BRUSH_HIGLIHTED_COLOR_DEFAULT = Color.FromArgb(255, 126, 180, 234);
        private static readonly Color THUMB_BORDER_BRUSH_SELECTED_COLOR_DEFAULT = Color.FromArgb(255, 86, 157, 229);

        private static readonly Thickness THUMB_BORDER_THICKNESS_DEFAULT = new Thickness(1);
        private static readonly CornerRadius THUMB_CORNER_RADIUS_DEFAULT = new CornerRadius(2);
        private static readonly double THUMB_HEIGHT_DEFAULT = 18;
        private static readonly double THUMB_WIDTH_DEFAULT = 8;

        private static readonly Color TICK_COLOR_DEFAULT = Color.FromArgb(255, 229, 229, 229);
        private static readonly Color TRACK_BACKGROUND_COLOR_DEFAULT = Color.FromArgb(255, 231, 234, 234);
        private static readonly Color TRACK_BORDER_BRUSH_COLOR_DEFAULT = Color.FromArgb(255, 214, 214, 214);

        private static readonly Thickness TRACK_BORDER_THICKNESS_DEFAULT = new Thickness(1);


        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius), typeof(CornerRadius), typeof(ExtendedSlider),
            new PropertyMetadata(CORNER_RADIUS_DEFAULT));


        public static readonly DependencyProperty InteractionBehaviourProperty = DependencyProperty.Register(
            nameof(InteractionBehaviour), typeof(InteractionBehaviour), typeof(ExtendedSlider),
            new PropertyMetadata(INTERACTION_BEHAVIOUR_DEFAULT));


        public static readonly DependencyProperty ThumbBackgroundProperty = DependencyProperty.Register(
            nameof(ThumbBackground), typeof(Brush), typeof(ExtendedSlider),
            new PropertyMetadata(new SolidColorBrush(THUMB_BACKGROUND_COLOR_DEFAULT)));

        public static readonly DependencyProperty ThumbBackgroundHiglihtedProperty = DependencyProperty.Register(
            nameof(ThumbBackgroundHiglihted), typeof(Brush), typeof(ExtendedSlider),
            new PropertyMetadata(new SolidColorBrush(THUMB_BACKGROUND_HIGLIHTED_COLOR_DEFAULT)));

        public static readonly DependencyProperty ThumbBackgroundSelectedProperty = DependencyProperty.Register(
            nameof(ThumbBackgroundSelected), typeof(Brush), typeof(ExtendedSlider),
            new PropertyMetadata(new SolidColorBrush(THUMB_BACKGROUND_SELECTED_COLOR_DEFAULT)));


        public static readonly DependencyProperty ThumbBorderBrushProperty = DependencyProperty.Register(
            nameof(ThumbBorderBrush), typeof(Brush), typeof(ExtendedSlider),
            new PropertyMetadata(new SolidColorBrush(THUMB_BORDER_BRUSH_COLOR_DEFAULT)));

        public static readonly DependencyProperty ThumbBorderBrushHiglihtedProperty = DependencyProperty.Register(
            nameof(ThumbBorderBrushHiglihted), typeof(Brush), typeof(ExtendedSlider),
            new PropertyMetadata(new SolidColorBrush(THUMB_BORDER_BRUSH_HIGLIHTED_COLOR_DEFAULT)));

        public static readonly DependencyProperty ThumbBorderBrushSelectedProperty = DependencyProperty.Register(
            nameof(ThumbBorderBrushSelected), typeof(Brush), typeof(ExtendedSlider),
            new PropertyMetadata(new SolidColorBrush(THUMB_BORDER_BRUSH_SELECTED_COLOR_DEFAULT)));


        public static readonly DependencyProperty ThumbBorderThicknessProperty = DependencyProperty.Register(
            nameof(ThumbBorderThickness), typeof(Thickness), typeof(ExtendedSlider),
            new PropertyMetadata(THUMB_BORDER_THICKNESS_DEFAULT));

        public static readonly DependencyProperty ThumbCornerRadiusProperty = DependencyProperty.Register(
            nameof(ThumbCornerRadius), typeof(CornerRadius), typeof(ExtendedSlider),
            new PropertyMetadata(THUMB_CORNER_RADIUS_DEFAULT));

        public static readonly DependencyProperty ThumbHeightProperty = DependencyProperty.Register(
            nameof(ThumbHeight), typeof(double), typeof(ExtendedSlider),
            new PropertyMetadata(THUMB_HEIGHT_DEFAULT));

        public static readonly DependencyProperty ThumbWidthProperty = DependencyProperty.Register(
            nameof(ThumbWidth), typeof(double), typeof(ExtendedSlider),
            new PropertyMetadata(THUMB_WIDTH_DEFAULT));


        public static readonly DependencyProperty TickBrushProperty = DependencyProperty.Register(
            nameof(TickBrush), typeof(Brush), typeof(ExtendedSlider),
            new PropertyMetadata(new SolidColorBrush(TICK_COLOR_DEFAULT)));

        public static readonly DependencyProperty TrackBackgroundProperty = DependencyProperty.Register(
            nameof(TrackBackground), typeof(Brush), typeof(ExtendedSlider),
            new PropertyMetadata(new SolidColorBrush(TRACK_BACKGROUND_COLOR_DEFAULT)));

        public static readonly DependencyProperty TrackBorderBrushProperty = DependencyProperty.Register(
            nameof(TrackBorderBrush), typeof(Brush), typeof(ExtendedSlider),
            new PropertyMetadata(new SolidColorBrush(TRACK_BORDER_BRUSH_COLOR_DEFAULT)));

        public static readonly DependencyProperty TrackBorderThicknessProperty = DependencyProperty.Register(
            nameof(TrackBorderThickness), typeof(Thickness), typeof(ExtendedSlider),
            new PropertyMetadata(TRACK_BORDER_THICKNESS_DEFAULT));


        //  GETTERS & SETTERS

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


        public Brush ThumbBackground
        {
            get => (Brush)GetValue(ThumbBackgroundProperty);
            set => SetValue(ThumbBackgroundProperty, value);
        }

        public Brush ThumbBackgroundHiglihted
        {
            get => (Brush)GetValue(ThumbBackgroundHiglihtedProperty);
            set => SetValue(ThumbBackgroundHiglihtedProperty, value);
        }

        public Brush ThumbBackgroundSelected
        {
            get => (Brush)GetValue(ThumbBackgroundSelectedProperty);
            set => SetValue(ThumbBackgroundSelectedProperty, value);
        }


        public Brush ThumbBorderBrush
        {
            get => (Brush)GetValue(ThumbBorderBrushProperty);
            set => SetValue(ThumbBorderBrushProperty, value);
        }

        public Brush ThumbBorderBrushHiglihted
        {
            get => (Brush)GetValue(ThumbBorderBrushHiglihtedProperty);
            set => SetValue(ThumbBorderBrushHiglihtedProperty, value);
        }

        public Brush ThumbBorderBrushSelected
        {
            get => (Brush)GetValue(ThumbBorderBrushSelectedProperty);
            set => SetValue(ThumbBorderBrushSelectedProperty, value);
        }


        public Thickness ThumbBorderThickness
        {
            get => (Thickness)GetValue(TrackBorderThicknessProperty);
            set => SetValue(TrackBorderThicknessProperty, value);
        }

        public CornerRadius ThumbCornerRadius
        {
            get => (CornerRadius)GetValue(ThumbCornerRadiusProperty);
            set => SetValue(ThumbCornerRadiusProperty, value);
        }

        public double ThumbHeight
        {
            get => (double)GetValue(ThumbHeightProperty);
            set => SetValue(ThumbHeightProperty, value);
        }

        public double ThumbWidth
        {
            get => (double)GetValue(ThumbWidthProperty);
            set => SetValue(ThumbWidthProperty, value);
        }


        public Brush TickBrush
        {
            get => (Brush)GetValue(TickBrushProperty);
            set => SetValue(TickBrushProperty, value);
        }

        public Brush TrackBackground
        {
            get => (Brush)GetValue(TrackBackgroundProperty);
            set => SetValue(TrackBackgroundProperty, value);
        }

        public Brush TrackBorderBrush
        {
            get => (Brush)GetValue(TrackBorderBrushProperty);
            set => SetValue(TrackBorderBrushProperty, value);
        }

        public Thickness TrackBorderThickness
        {
            get => (Thickness)GetValue(TrackBorderThicknessProperty);
            set => SetValue(TrackBorderThicknessProperty, value);
        }

        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ExtendedSlider class constructor. </summary>
        public ExtendedSlider() : base()
        {
            Loaded += ExtendedSlider_Loaded;
            GotFocus += CustomizableSlider_GotFocus;
            LostFocus += CustomizableSlider_LostFocus;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static class constructor to override default style. </summary>
        static ExtendedSlider()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtendedSlider),
                new FrameworkPropertyMetadata(typeof(ExtendedSlider)));
        }

        #endregion CLASS METHODS

        #region COMPONENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method called when component is loaded, rendered and ready for interaction. </summary>
        /// <param name="sender"> Object that invoked an event. </param>
        /// <param name="e"> Routed event arguemnts. </param>
        private void ExtendedSlider_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateInteractionBehaviourProperty(InteractionBehaviour);
        }

        #endregion COMPONENT METHODS

        #region COMPONENT INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method called when component got focused. </summary>
        /// <param name="sender"> Object that invoked an event. </param>
        /// <param name="e"> Routed event arguemnts. </param>
        private void CustomizableSlider_GotFocus(object sender, RoutedEventArgs e)
        {
            IsSelected = true;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method called when component lost focused. </summary>
        /// <param name="sender"> Object that invoked an event. </param>
        /// <param name="e"> Routed event arguemnts. </param>
        private void CustomizableSlider_LostFocus(object sender, RoutedEventArgs e)
        {
            IsSelected = false;
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

                    ThumbBackgroundHiglihted = ThumbBackground;
                    ThumbBackgroundSelected = ThumbBackground;

                    ThumbBorderBrushHiglihted = ThumbBorderBrush;
                    ThumbBorderBrushSelected = ThumbBorderBrush;

                    break;

                case InteractionBehaviour.DarkColorShading:

                    ThumbBackgroundHiglihted = new SolidColorBrush(
                        ColorShader.DimColor(
                            BrushColorRetriever.GetColorFromBrush(ThumbBackground, THUMB_BACKGROUND_HIGLIHTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_HIGLIHTED));

                    ThumbBackgroundSelected = new SolidColorBrush(
                        ColorShader.DimColor(
                            BrushColorRetriever.GetColorFromBrush(ThumbBackground, THUMB_BACKGROUND_SELECTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_SELECTED));

                    ThumbBorderBrushHiglihted = new SolidColorBrush(
                        ColorShader.DimColor(
                            BrushColorRetriever.GetColorFromBrush(ThumbBorderBrush, THUMB_BORDER_BRUSH_HIGLIHTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_HIGLIHTED));

                    ThumbBorderBrushSelected = new SolidColorBrush(
                        ColorShader.DimColor(
                            BrushColorRetriever.GetColorFromBrush(ThumbBorderBrush, THUMB_BORDER_BRUSH_SELECTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_SELECTED));

                    break;

                case InteractionBehaviour.LightColorShading:

                    ThumbBackgroundHiglihted = new SolidColorBrush(
                        ColorShader.BrightColor(
                            BrushColorRetriever.GetColorFromBrush(ThumbBackground, THUMB_BACKGROUND_HIGLIHTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_HIGLIHTED));

                    ThumbBackgroundSelected = new SolidColorBrush(
                        ColorShader.BrightColor(
                            BrushColorRetriever.GetColorFromBrush(ThumbBackground, THUMB_BACKGROUND_SELECTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_SELECTED));

                    ThumbBorderBrushHiglihted = new SolidColorBrush(
                        ColorShader.BrightColor(
                            BrushColorRetriever.GetColorFromBrush(ThumbBorderBrush, THUMB_BORDER_BRUSH_HIGLIHTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_HIGLIHTED));

                    ThumbBorderBrushSelected = new SolidColorBrush(
                        ColorShader.BrightColor(
                            BrushColorRetriever.GetColorFromBrush(ThumbBorderBrush, THUMB_BORDER_BRUSH_SELECTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_SELECTED));

                    break;

                case InteractionBehaviour.CustomColors:

                    break;
            }
        }

        #endregion INTERFACE MANAGEMENT METHODS

    }
}
