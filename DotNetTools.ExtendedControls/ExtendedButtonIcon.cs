using chkam05.DotNetTools.ExtendedControls.Data.Static;
using chkam05.DotNetTools.ExtendedControls.Utilities;
using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace chkam05.DotNetTools.ExtendedControls
{
    public class ExtendedButtonIcon : Button
    {

        //  CONST

        private static readonly Color BACKGROUND_CHECKED_COLOR_DEFAULT = Color.FromArgb(255, 188, 221, 238);
        private static readonly Color BACKGROUND_HIGLIHTED_COLOR_DEFAULT = Color.FromArgb(255, 190, 230, 253);
        private static readonly Color BACKGROUND_SELECTED_COLOR_DEFAULT = Color.FromArgb(255, 196, 229, 246);

        private static readonly Color BORDER_CHECKED_COLOR_DEFAULT = Color.FromArgb(255, 36, 90, 131);
        private static readonly Color BORDER_HIGLIHTED_COLOR_DEFAULT = Color.FromArgb(255, 60, 127, 177);
        private static readonly Color BORDER_SELECTED_COLOR_DEFAULT = Color.FromArgb(255, 44, 98, 139);

        private static readonly Color FOREGROUND_CHECKED_COLOR_DEFAULT = Color.FromArgb(255, 0, 0, 0);
        private static readonly Color FOREGROUND_HIGLIHTED_COLOR_DEFAULT = Color.FromArgb(255, 0, 0, 0);
        private static readonly Color FOREGROUND_SELECTED_COLOR_DEFAULT = Color.FromArgb(255, 0, 0, 0);

        private static readonly CornerRadius CORNER_RADIUS_DEFAULT = new CornerRadius(4);

        private static readonly PackIconKind ICON_KIND_DEFAULT = PackIconKind.None;
        private static readonly IconPosition ICON_POSITION_DEFAULT = IconPosition.LEFT;
        private static readonly double ICON_SEPARATION_DEFAULT = 2;
        private static readonly double ICON_HEIGHT_DEFAULT = 20;
        private static readonly double ICON_WIDTH_DEFAULT = 20;

        private static readonly double INTERACTION_BEHAVIOUR_COLOR_SHADE_CHECKED = 20;
        private static readonly double INTERACTION_BEHAVIOUR_COLOR_SHADE_HIGLIHTED = 10;
        private static readonly double INTERACTION_BEHAVIOUR_COLOR_SHADE_SELECTED = 15;
        private static readonly InteractionBehaviour INTERACTION_BEHAVIOUR_DEFAULT = InteractionBehaviour.LightColorShading;


        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundCheckedProperty = DependencyProperty.Register(
            nameof(BackgroundChecked), typeof(Brush), typeof(ExtendedButtonIcon),
            new PropertyMetadata(new SolidColorBrush(BACKGROUND_CHECKED_COLOR_DEFAULT)));

        public static readonly DependencyProperty BackgroundHiglihtedProperty = DependencyProperty.Register(
            nameof(BackgroundHiglihted), typeof(Brush), typeof(ExtendedButtonIcon),
            new PropertyMetadata(new SolidColorBrush(BACKGROUND_HIGLIHTED_COLOR_DEFAULT)));

        public static readonly DependencyProperty BackgroundSelectedProperty = DependencyProperty.Register(
            nameof(BackgroundSelected), typeof(Brush), typeof(ExtendedButtonIcon),
            new PropertyMetadata(new SolidColorBrush(BACKGROUND_SELECTED_COLOR_DEFAULT)));


        public static readonly DependencyProperty BorderBrushCheckedProperty = DependencyProperty.Register(
            nameof(BorderBrushChecked), typeof(Brush), typeof(ExtendedButtonIcon),
            new PropertyMetadata(new SolidColorBrush(BORDER_CHECKED_COLOR_DEFAULT)));

        public static readonly DependencyProperty BorderBrushHiglihtedProperty = DependencyProperty.Register(
            nameof(BorderBrushHiglihted), typeof(Brush), typeof(ExtendedButtonIcon),
            new PropertyMetadata(new SolidColorBrush(BORDER_HIGLIHTED_COLOR_DEFAULT)));

        public static readonly DependencyProperty BorderBrushSelectedProperty = DependencyProperty.Register(
            nameof(BorderBrushSelected), typeof(Brush), typeof(ExtendedButtonIcon),
            new PropertyMetadata(new SolidColorBrush(BORDER_SELECTED_COLOR_DEFAULT)));


        public static readonly DependencyProperty ForegroundCheckedProperty = DependencyProperty.Register(
            nameof(ForegroundChecked), typeof(Brush), typeof(ExtendedButtonIcon),
            new PropertyMetadata(new SolidColorBrush(FOREGROUND_CHECKED_COLOR_DEFAULT)));

        public static readonly DependencyProperty ForegroundHiglihtedProperty = DependencyProperty.Register(
            nameof(ForegroundHiglihted), typeof(Brush), typeof(ExtendedButtonIcon),
            new PropertyMetadata(new SolidColorBrush(FOREGROUND_HIGLIHTED_COLOR_DEFAULT)));

        public static readonly DependencyProperty ForegroundSelectedProperty = DependencyProperty.Register(
            nameof(ForegroundSelected), typeof(Brush), typeof(ExtendedButtonIcon),
            new PropertyMetadata(new SolidColorBrush(FOREGROUND_SELECTED_COLOR_DEFAULT)));


        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius), typeof(CornerRadius), typeof(ExtendedButtonIcon),
            new PropertyMetadata(CORNER_RADIUS_DEFAULT));


        public static readonly DependencyProperty IconKindProperty = DependencyProperty.Register(
            nameof(IconKind), typeof(PackIconKind), typeof(ExtendedButtonIcon),
            new PropertyMetadata(ICON_KIND_DEFAULT));

        public static readonly DependencyProperty IconPositionProperty = DependencyProperty.Register(
            nameof(IconPosition), typeof(IconPosition), typeof(ExtendedButtonIcon),
            new PropertyMetadata(ICON_POSITION_DEFAULT));

        public static readonly DependencyProperty IconSeparationProperty = DependencyProperty.Register(
            nameof(IconSeparation), typeof(double), typeof(ExtendedButtonIcon),
            new PropertyMetadata(ICON_SEPARATION_DEFAULT));

        public static readonly DependencyProperty IconHeightProperty = DependencyProperty.Register(
            nameof(IconHeight), typeof(double), typeof(ExtendedButtonIcon),
            new PropertyMetadata(ICON_HEIGHT_DEFAULT));

        public static readonly DependencyProperty IconWidthProperty = DependencyProperty.Register(
            nameof(IconWidth), typeof(double), typeof(ExtendedButtonIcon),
            new PropertyMetadata(ICON_WIDTH_DEFAULT));


        public static readonly DependencyProperty InteractionBehaviourProperty = DependencyProperty.Register(
            nameof(InteractionBehaviour), typeof(InteractionBehaviour), typeof(ExtendedButtonIcon),
            new PropertyMetadata(INTERACTION_BEHAVIOUR_DEFAULT));


        //  GETTERS & SETTERS

        public Brush BackgroundChecked
        {
            get => (Brush)GetValue(BackgroundCheckedProperty);
            set => SetValue(BackgroundCheckedProperty, value);
        }

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


        public Brush BorderBrushChecked
        {
            get => (Brush)GetValue(BorderBrushCheckedProperty);
            set => SetValue(BorderBrushCheckedProperty, value);
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


        public Brush ForegroundChecked
        {
            get => (Brush)GetValue(ForegroundCheckedProperty);
            set => SetValue(ForegroundCheckedProperty, value);
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


        public IconPosition IconPosition
        {
            get
            {
                return (IconPosition)this.GetValue(IconPositionProperty);
            }
            set
            {
                SetValue(IconPositionProperty, value);
                UpdateIconPositionProperty(value);
            }
        }

        public PackIconKind IconKind
        {
            get => (PackIconKind)GetValue(IconKindProperty);
            set => SetValue(IconKindProperty, value);
        }

        public double IconSeparation
        {
            get
            {
                return (double)GetValue(IconSeparationProperty);
            }
            set
            {
                SetValue(IconSeparationProperty, value);
                UpdateIconSeparationProperty(value);
            }
        }

        public double IconHeight
        {
            get => (double)GetValue(IconHeightProperty);
            set => SetValue(IconHeightProperty, value);
        }

        public double IconWidth
        {
            get => (double)GetValue(IconWidthProperty);
            set => SetValue(IconWidthProperty, value);
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
        /// <summary> ExtendedButtonIcon class constructor. </summary>
        public ExtendedButtonIcon() : base()
        {
            Loaded += ExtendedButtonIcon_Loaded;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static class constructor to override default style. </summary>
        static ExtendedButtonIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtendedButtonIcon),
                new FrameworkPropertyMetadata(typeof(ExtendedButtonIcon)));
        }

        #endregion CLASS METHODS

        #region COMPONENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method called when component is loaded, rendered and ready for interaction. </summary>
        /// <param name="sender"> Object that invoked an event. </param>
        /// <param name="e"> Routed event arguemnts. </param>
        private void ExtendedButtonIcon_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateIconPositionProperty(IconPosition);
            UpdateInteractionBehaviourProperty(InteractionBehaviour);
        }

        #endregion COMPONENT METHODS

        #region INTERFACE MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method for adjust other component properties to icon position property. </summary>
        /// <param name="iconPositionPropertyValue"> Component icon position property value. </param>
        private void UpdateIconPositionProperty(IconPosition iconPositionPropertyValue)
        {
            var icon = (PackIcon)Template.FindName("icon", this);
            var separation = (double)GetValue(IconSeparationProperty);
            var stackPanel = (StackPanel)Template.FindName("stackPanel", this);

            switch (iconPositionPropertyValue)
            {
                case IconPosition.LEFT:
                    stackPanel.Orientation = Orientation.Horizontal;
                    icon.Margin = new Thickness(0, 0, separation, 0);
                    break;

                case IconPosition.TOP:
                    stackPanel.Orientation = Orientation.Vertical;
                    icon.Margin = new Thickness(0, 0, 0, separation);
                    break;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method for adjust other component properties to icon separation property. </summary>
        /// <param name="iconSeparationPropertyValue"> Component icon separation property value. </param>
        private void UpdateIconSeparationProperty(double iconSeparationPropertyValue)
        {
            var icon = (PackIcon)Template.FindName("icon", this);
            var iconPosition = (IconPosition)GetValue(IconPositionProperty);

            switch (iconPosition)
            {
                case IconPosition.LEFT:
                    icon.Margin = new Thickness(0, 0, iconSeparationPropertyValue, 0);
                    break;

                case IconPosition.TOP:
                    icon.Margin = new Thickness(0, 0, 0, iconSeparationPropertyValue);
                    break;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method for adjust other component properties to interaction behaviour. </summary>
        /// <param name="contentPositionPropertyValue"> Component multiline property value. </param>
        private void UpdateInteractionBehaviourProperty(InteractionBehaviour interactionBehaviourPropertyValue)
        {
            switch (interactionBehaviourPropertyValue)
            {
                case InteractionBehaviour.Nothing:

                    BackgroundChecked = Background;
                    BackgroundHiglihted = Background;
                    BackgroundSelected = Background;

                    BorderBrushChecked = BorderBrush;
                    BorderBrushHiglihted = BorderBrush;
                    BorderBrushSelected = BorderBrush;

                    ForegroundChecked = Foreground;
                    ForegroundHiglihted = Foreground;
                    ForegroundSelected = Foreground;

                    break;

                case InteractionBehaviour.DarkColorShading:

                    BackgroundChecked = new SolidColorBrush(
                        ColorShader.DimColor(
                            BrushColorRetriever.GetColorFromBrush(Background, BACKGROUND_CHECKED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_CHECKED));

                    BackgroundHiglihted = new SolidColorBrush(
                        ColorShader.DimColor(
                            BrushColorRetriever.GetColorFromBrush(Background, BACKGROUND_HIGLIHTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_HIGLIHTED));

                    BackgroundSelected = new SolidColorBrush(
                        ColorShader.DimColor(
                            BrushColorRetriever.GetColorFromBrush(Background, BACKGROUND_SELECTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_SELECTED));

                    BorderBrushChecked = new SolidColorBrush(
                        ColorShader.DimColor(
                            BrushColorRetriever.GetColorFromBrush(BorderBrush, BORDER_CHECKED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_CHECKED));

                    BorderBrushHiglihted = new SolidColorBrush(
                        ColorShader.DimColor(
                            BrushColorRetriever.GetColorFromBrush(BorderBrush, BORDER_HIGLIHTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_HIGLIHTED));

                    BorderBrushSelected = new SolidColorBrush(
                        ColorShader.DimColor(
                            BrushColorRetriever.GetColorFromBrush(BorderBrush, BORDER_SELECTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_SELECTED));

                    ForegroundChecked = Foreground;
                    ForegroundHiglihted = Foreground;
                    ForegroundSelected = Foreground;

                    break;

                case InteractionBehaviour.LightColorShading:

                    BackgroundChecked = new SolidColorBrush(
                        ColorShader.BrightColor(
                            BrushColorRetriever.GetColorFromBrush(Background, BACKGROUND_CHECKED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_CHECKED));

                    BackgroundHiglihted = new SolidColorBrush(
                        ColorShader.BrightColor(
                            BrushColorRetriever.GetColorFromBrush(Background, BACKGROUND_HIGLIHTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_HIGLIHTED));

                    BackgroundSelected = new SolidColorBrush(
                        ColorShader.BrightColor(
                            BrushColorRetriever.GetColorFromBrush(Background, BACKGROUND_SELECTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_SELECTED));

                    BorderBrushChecked = new SolidColorBrush(
                        ColorShader.BrightColor(
                            BrushColorRetriever.GetColorFromBrush(BorderBrush, BORDER_CHECKED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_CHECKED));

                    BorderBrushHiglihted = new SolidColorBrush(
                        ColorShader.BrightColor(
                            BrushColorRetriever.GetColorFromBrush(BorderBrush, BORDER_HIGLIHTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_HIGLIHTED));

                    BorderBrushSelected = new SolidColorBrush(
                        ColorShader.BrightColor(
                            BrushColorRetriever.GetColorFromBrush(BorderBrush, BORDER_SELECTED_COLOR_DEFAULT),
                            INTERACTION_BEHAVIOUR_COLOR_SHADE_SELECTED));

                    ForegroundChecked = Foreground;
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
