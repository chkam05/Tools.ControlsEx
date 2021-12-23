using chkam05.DotNetTools.ExtendedControls.Data.Static;
using chkam05.DotNetTools.ExtendedControls.Utilities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace chkam05.DotNetTools.ExtendedControls
{
    public class ExtendedContextMenuItem : MenuItem
    {

        //  CONST

        private static readonly Color BACKGROUND_HIGLIHTED_COLOR_DEFAULT = Color.FromArgb(255, 195, 224, 238);
        private static readonly Color BACKGROUND_SELECTED_COLOR_DEFAULT = Color.FromArgb(255, 195, 224, 238);

        private static readonly Color BORDER_HIGLIHTED_COLOR_DEFAULT = Color.FromArgb(255, 38, 160, 218);
        private static readonly Color BORDER_SELECTED_COLOR_DEFAULT = Color.FromArgb(255, 38, 160, 218);

        private static readonly Color FOREGROUND_HIGLIHTED_COLOR_DEFAULT = Color.FromArgb(255, 0, 0, 0);
        private static readonly Color FOREGROUND_SELECTED_COLOR_DEFAULT = Color.FromArgb(255, 0, 0, 0);

        private static readonly Color GLYPH_BRUSH_COLOR_DEFAULT = Color.FromArgb(255, 0, 0, 0);
        private static readonly Color GLYPH_BACKGROUND_CHECKED_COLOR_DEFAULT = Color.FromArgb(255, 192, 221, 235);
        private static readonly Color GLYPH_BORDER_CHECKED_COLOR_DEFAULT = Color.FromArgb(255, 38, 160, 218);

        private static readonly CornerRadius CORNER_RADIUS_DEFAULT = new CornerRadius(4);

        private static readonly double INTERACTION_BEHAVIOUR_COLOR_SHADE_HIGLIHTED = 10;
        private static readonly double INTERACTION_BEHAVIOUR_COLOR_SHADE_SELECTED = 15;
        private static readonly InteractionBehaviour INTERACTION_BEHAVIOUR_DEFAULT = InteractionBehaviour.LightColorShading;


        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundHiglihtedProperty = DependencyProperty.Register(
            nameof(BackgroundHiglihted), typeof(Brush), typeof(ExtendedContextMenuItem),
            new PropertyMetadata(new SolidColorBrush(BACKGROUND_HIGLIHTED_COLOR_DEFAULT)));

        public static readonly DependencyProperty BackgroundSelectedProperty = DependencyProperty.Register(
            nameof(BackgroundSelected), typeof(Brush), typeof(ExtendedContextMenuItem),
            new PropertyMetadata(new SolidColorBrush(BACKGROUND_SELECTED_COLOR_DEFAULT)));


        public static readonly DependencyProperty BorderBrushHiglihtedProperty = DependencyProperty.Register(
            nameof(BorderBrushHiglihted), typeof(Brush), typeof(ExtendedContextMenuItem),
            new PropertyMetadata(new SolidColorBrush(BORDER_HIGLIHTED_COLOR_DEFAULT)));

        public static readonly DependencyProperty BorderBrushSelectedProperty = DependencyProperty.Register(
            nameof(BorderBrushSelected), typeof(Brush), typeof(ExtendedContextMenuItem),
            new PropertyMetadata(new SolidColorBrush(BORDER_SELECTED_COLOR_DEFAULT)));


        public static readonly DependencyProperty ForegroundHiglihtedProperty = DependencyProperty.Register(
            nameof(ForegroundHiglihted), typeof(Brush), typeof(ExtendedContextMenuItem),
            new PropertyMetadata(new SolidColorBrush(FOREGROUND_HIGLIHTED_COLOR_DEFAULT)));

        public static readonly DependencyProperty ForegroundSelectedProperty = DependencyProperty.Register(
            nameof(ForegroundSelected), typeof(Brush), typeof(ExtendedContextMenuItem),
            new PropertyMetadata(new SolidColorBrush(FOREGROUND_SELECTED_COLOR_DEFAULT)));


        public static readonly DependencyProperty GryphlBrushProperty = DependencyProperty.Register(
            nameof(GryphlBrush), typeof(Brush), typeof(ExtendedContextMenuItem),
            new PropertyMetadata(new SolidColorBrush(GLYPH_BRUSH_COLOR_DEFAULT)));

        public static readonly DependencyProperty GryphlBackgroundCheckedProperty = DependencyProperty.Register(
            nameof(GryphlBackgroundChecked), typeof(Brush), typeof(ExtendedContextMenuItem),
            new PropertyMetadata(new SolidColorBrush(GLYPH_BACKGROUND_CHECKED_COLOR_DEFAULT)));

        public static readonly DependencyProperty GryphlBorderCheckedProperty = DependencyProperty.Register(
            nameof(GryphlBorderChecked), typeof(Brush), typeof(ExtendedContextMenuItem),
            new PropertyMetadata(new SolidColorBrush(GLYPH_BORDER_CHECKED_COLOR_DEFAULT)));


        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius), typeof(CornerRadius), typeof(ExtendedContextMenuItem),
            new PropertyMetadata(CORNER_RADIUS_DEFAULT));

        public static readonly DependencyProperty InteractionBehaviourProperty = DependencyProperty.Register(
            nameof(InteractionBehaviour), typeof(InteractionBehaviour), typeof(ExtendedContextMenuItem),
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


        public Brush GryphlBrush
        {
            get => (Brush)GetValue(GryphlBrushProperty);
            set => SetValue(GryphlBrushProperty, value);
        }

        public Brush GryphlBackgroundChecked
        {
            get => (Brush)GetValue(GryphlBackgroundCheckedProperty);
            set => SetValue(GryphlBackgroundCheckedProperty, value);
        }

        public Brush GryphlBorderChecked
        {
            get => (Brush)GetValue(GryphlBorderCheckedProperty);
            set => SetValue(GryphlBorderCheckedProperty, value);
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


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ExtendedContextMenuItem class constructor. </summary>
        public ExtendedContextMenuItem() : base()
        {
            Loaded += ExtendedContextMenuItem_Loaded;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static class constructor to override default style. </summary>
        static ExtendedContextMenuItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtendedContextMenuItem),
                new FrameworkPropertyMetadata(typeof(ExtendedContextMenuItem)));
        }

        #endregion CLASS METHODS

        #region COMPONENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method called when component is loaded, rendered and ready for interaction. </summary>
        /// <param name="sender"> Object that invoked an event. </param>
        /// <param name="e"> Routed event arguemnts. </param>
        private void ExtendedContextMenuItem_Loaded(object sender, RoutedEventArgs e)
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

    }
}
