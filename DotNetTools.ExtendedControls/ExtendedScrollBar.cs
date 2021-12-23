using chkam05.DotNetTools.ExtendedControls.Data.Static;
using chkam05.DotNetTools.ExtendedControls.Utilities;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;


namespace chkam05.DotNetTools.ExtendedControls
{
    public class ExtendedScrollBar : ScrollBar
    {

        //  CONST

        private static readonly Color FOREGROUND_HIGLIHTED_COLOR_DEFAULT = Color.FromArgb(255, 166, 166, 166);
        private static readonly Color FOREGROUND_SELECTED_COLOR_DEFAULT = Color.FromArgb(255, 96, 96, 96);

        private static readonly CornerRadius CORNER_RADIUS_DEFAULT = new CornerRadius(4);
        private static readonly CornerRadius THUMB_CORNER_RADIUS_DEFAULT = new CornerRadius(2);

        private static readonly double INTERACTION_BEHAVIOUR_COLOR_SHADE_HIGLIHTED = 10;
        private static readonly double INTERACTION_BEHAVIOUR_COLOR_SHADE_SELECTED = 15;
        private static readonly InteractionBehaviour INTERACTION_BEHAVIOUR_DEFAULT = InteractionBehaviour.LightColorShading;


        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty ForegroundHiglihtedProperty = DependencyProperty.Register(
            nameof(ForegroundHiglihted), typeof(Brush), typeof(ExtendedScrollBar),
            new PropertyMetadata(new SolidColorBrush(FOREGROUND_HIGLIHTED_COLOR_DEFAULT)));

        public static readonly DependencyProperty ForegroundSelectedProperty = DependencyProperty.Register(
            nameof(ForegroundSelected), typeof(Brush), typeof(ExtendedScrollBar),
            new PropertyMetadata(new SolidColorBrush(FOREGROUND_SELECTED_COLOR_DEFAULT)));


        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius), typeof(CornerRadius), typeof(ExtendedScrollBar),
            new PropertyMetadata(CORNER_RADIUS_DEFAULT));

        public static readonly DependencyProperty ThumbCornerRadiusProperty = DependencyProperty.Register(
            nameof(ThumbCornerRadius), typeof(CornerRadius), typeof(ExtendedScrollBar),
            new PropertyMetadata(THUMB_CORNER_RADIUS_DEFAULT));

        public static readonly DependencyProperty InteractionBehaviourProperty = DependencyProperty.Register(
            nameof(InteractionBehaviour), typeof(InteractionBehaviour), typeof(ExtendedScrollBar),
            new PropertyMetadata(INTERACTION_BEHAVIOUR_DEFAULT));


        //  GETTERS & SETTERS

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

        public CornerRadius ThumbCornerRadius
        {
            get => (CornerRadius)GetValue(ThumbCornerRadiusProperty);
            set => SetValue(ThumbCornerRadiusProperty, value);
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
        /// <summary> ExtendedScrollBar class constructor. </summary>
        public ExtendedScrollBar() : base()
        {
            Loaded += ExtendedScrollBar_Loaded;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static class constructor to override default style. </summary>
        static ExtendedScrollBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtendedScrollBar),
                new FrameworkPropertyMetadata(typeof(ExtendedScrollBar)));
        }

        #endregion CLASS METHODS

        #region COMPONENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method called when component is loaded, rendered and ready for interaction. </summary>
        /// <param name="sender"> Object that invoked an event. </param>
        /// <param name="e"> Routed event arguemnts. </param>
        private void ExtendedScrollBar_Loaded(object sender, RoutedEventArgs e)
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

                    ForegroundHiglihted = Foreground;
                    ForegroundSelected = Foreground;

                    break;

                case InteractionBehaviour.DarkColorShading:

                    ForegroundHiglihted = new SolidColorBrush(
                        ColorShader.DimColor(
                            BrushColorRetriever.GetColorFromBrush(Foreground, FOREGROUND_HIGLIHTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_HIGLIHTED));

                    ForegroundSelected = new SolidColorBrush(
                        ColorShader.DimColor(
                            BrushColorRetriever.GetColorFromBrush(Foreground, FOREGROUND_SELECTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_SELECTED));

                    break;

                case InteractionBehaviour.LightColorShading:

                    ForegroundHiglihted = new SolidColorBrush(
                        ColorShader.BrightColor(
                            BrushColorRetriever.GetColorFromBrush(Foreground, FOREGROUND_HIGLIHTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_HIGLIHTED));

                    ForegroundSelected = new SolidColorBrush(
                        ColorShader.BrightColor(
                            BrushColorRetriever.GetColorFromBrush(Foreground, FOREGROUND_SELECTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_SELECTED));

                    break;

                case InteractionBehaviour.CustomColors:

                    break;
            }
        }

        #endregion INTERFACE MANAGEMENT METHODS

    }
}
