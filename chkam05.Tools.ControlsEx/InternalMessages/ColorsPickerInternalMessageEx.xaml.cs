using chkam05.Tools.ControlsEx.Colors;
using chkam05.Tools.ControlsEx.Events;
using chkam05.Tools.ControlsEx.Static;
using chkam05.Tools.ControlsEx.Utilities;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace chkam05.Tools.ControlsEx.InternalMessages
{

    public partial class ColorsPickerInternalMessageEx : BaseColorSelectorInternalMessageEx
    {

        //  CONST

        private readonly string[] RGB_CONTROLS = new string[] { 
            "redUpDownTextBoxEx", "greenUpDownTextBoxEx", "blueUpDownTextBoxEx", "alphaUpDownTextBoxEx" };

        private readonly string[] HSL_CONTROLS = new string[] {
            "hueUpDownTextBoxEx", "saturationUpDownTextBoxEx", "lightnessUpDownTextBoxEx" };


        //  DEPENDENCY PROPERTIES

        #region Appearance UpDownTextBoxEx Colors Properties

        public static readonly DependencyProperty ColorComponentMouseOverBackgroundProperty = DependencyProperty.Register(
            nameof(ColorComponentMouseOverBackground),
            typeof(Brush),
            typeof(ColorsPickerInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty ColorComponentMouseOverBorderBrushProperty = DependencyProperty.Register(
            nameof(ColorComponentMouseOverBorderBrush),
            typeof(Brush),
            typeof(ColorsPickerInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty ColorComponentMouseOverForegroundProperty = DependencyProperty.Register(
            nameof(ColorComponentMouseOverForeground),
            typeof(Brush),
            typeof(ColorsPickerInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty ColorComponentSelectedBackgroundProperty = DependencyProperty.Register(
            nameof(ColorComponentSelectedBackground),
            typeof(Brush),
            typeof(ColorsPickerInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty ColorComponentSelectedBorderBrushProperty = DependencyProperty.Register(
            nameof(ColorComponentSelectedBorderBrush),
            typeof(Brush),
            typeof(ColorsPickerInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_PRESSED)));

        public static readonly DependencyProperty ColorComponentSelectedForegroundProperty = DependencyProperty.Register(
            nameof(ColorComponentSelectedForeground),
            typeof(Brush),
            typeof(ColorsPickerInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty ColorComponentSelectedTextBackgroundProperty = DependencyProperty.Register(
            nameof(ColorComponentSelectedTextBackground),
            typeof(Brush),
            typeof(ColorsPickerInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        #endregion Appearance UpDownTextBoxEx Colors Properties

        public static readonly DependencyProperty AlphaComponentProperty = DependencyProperty.Register(
            nameof(AlphaComponent),
            typeof(int),
            typeof(ColorsPickerInternalMessageEx),
            new PropertyMetadata(0));

        public static readonly DependencyProperty RedComponentProperty = DependencyProperty.Register(
            nameof(RedComponent),
            typeof(int),
            typeof(ColorsPickerInternalMessageEx),
            new PropertyMetadata(0));

        public static readonly DependencyProperty GreenComponentProperty = DependencyProperty.Register(
            nameof(GreenComponent),
            typeof(int),
            typeof(ColorsPickerInternalMessageEx),
            new PropertyMetadata(0));

        public static readonly DependencyProperty BlueComponentProperty = DependencyProperty.Register(
            nameof(BlueComponent),
            typeof(int),
            typeof(ColorsPickerInternalMessageEx),
            new PropertyMetadata(0));

        public static readonly DependencyProperty HueComponentProperty = DependencyProperty.Register(
            nameof(HueComponent),
            typeof(int),
            typeof(ColorsPickerInternalMessageEx),
            new PropertyMetadata(0));

        public static readonly DependencyProperty SaturationComponentProperty = DependencyProperty.Register(
            nameof(SaturationComponent),
            typeof(int),
            typeof(ColorsPickerInternalMessageEx),
            new PropertyMetadata(0));

        public static readonly DependencyProperty LightnessComponentProperty = DependencyProperty.Register(
            nameof(LightnessComponent),
            typeof(int),
            typeof(ColorsPickerInternalMessageEx),
            new PropertyMetadata(0));


        //  GETTERS & SETTERS

        #region Appearance UpDownTextBoxEx Colors

        public Brush ColorComponentMouseOverBackground
        {
            get => (Brush)GetValue(ColorComponentMouseOverBackgroundProperty);
            set
            {
                SetValue(ColorComponentMouseOverBackgroundProperty, value);
                OnPropertyChanged(nameof(ColorComponentMouseOverBackground));
            }
        }

        public Brush ColorComponentMouseOverBorderBrush
        {
            get => (Brush)GetValue(ColorComponentMouseOverBorderBrushProperty);
            set
            {
                SetValue(ColorComponentMouseOverBorderBrushProperty, value);
                OnPropertyChanged(nameof(ColorComponentMouseOverBorderBrush));
            }
        }

        public Brush ColorComponentMouseOverForeground
        {
            get => (Brush)GetValue(ColorComponentMouseOverForegroundProperty);
            set
            {
                SetValue(ColorComponentMouseOverForegroundProperty, value);
                OnPropertyChanged(nameof(ColorComponentMouseOverForeground));
            }
        }

        public Brush ColorComponentSelectedBackground
        {
            get => (Brush)GetValue(ColorComponentSelectedBackgroundProperty);
            set
            {
                SetValue(ColorComponentSelectedBackgroundProperty, value);
                OnPropertyChanged(nameof(ColorComponentSelectedBackground));
            }
        }

        public Brush ColorComponentSelectedBorderBrush
        {
            get => (Brush)GetValue(ColorComponentSelectedBorderBrushProperty);
            set
            {
                SetValue(ColorComponentSelectedBorderBrushProperty, value);
                OnPropertyChanged(nameof(ColorComponentSelectedBorderBrush));
            }
        }

        public Brush ColorComponentSelectedForeground
        {
            get => (Brush)GetValue(ColorComponentSelectedForegroundProperty);
            set
            {
                SetValue(ColorComponentSelectedForegroundProperty, value);
                OnPropertyChanged(nameof(ColorComponentSelectedForeground));
            }
        }

        public Brush ColorComponentSelectedTextBackground
        {
            get => (Brush)GetValue(ColorComponentSelectedTextBackgroundProperty);
            set
            {
                SetValue(ColorComponentSelectedTextBackgroundProperty, value);
                OnPropertyChanged(nameof(ColorComponentSelectedTextBackground));
            }
        }

        #endregion Appearance UpDownTextBoxEx Colors

        public int AlphaComponent
        {
            get => (int)GetValue(AlphaComponentProperty);
            set
            {
                SetValue(AlphaComponentProperty, Math.Max(Math.Min(value, 255), 0));
                OnPropertyChanged(nameof(AlphaComponent));
            }
        }

        public int RedComponent
        {
            get => (int)GetValue(RedComponentProperty);
            set
            {
                SetValue(RedComponentProperty, Math.Max(Math.Min(value, 255), 0));
                OnPropertyChanged(nameof(RedComponent));
            }
        }

        public int GreenComponent
        {
            get => (int)GetValue(GreenComponentProperty);
            set
            {
                SetValue(GreenComponentProperty, Math.Max(Math.Min(value, 255), 0));
                OnPropertyChanged(nameof(GreenComponent));
            }
        }

        public int BlueComponent
        {
            get => (int)GetValue(BlueComponentProperty);
            set
            {
                SetValue(BlueComponentProperty, Math.Max(Math.Min(value, 255), 0));
                OnPropertyChanged(nameof(BlueComponent));
            }
        }

        public int HueComponent
        {
            get => (int)GetValue(HueComponentProperty);
            set
            {
                SetValue(HueComponentProperty, Math.Max(Math.Min(value, AHSLColor.HUE_MAX), AHSLColor.HUE_MIN));
                OnPropertyChanged(nameof(HueComponent));
            }
        }

        public int SaturationComponent
        {
            get => (int)GetValue(SaturationComponentProperty);
            set
            {
                SetValue(SaturationComponentProperty, Math.Max(Math.Min(value, AHSLColor.SATURATION_MAX), AHSLColor.SATURATION_MIN));
                OnPropertyChanged(nameof(SaturationComponent));
            }
        }

        public int LightnessComponent
        {
            get => (int)GetValue(LightnessComponentProperty);
            set
            {
                SetValue(LightnessComponentProperty, Math.Max(Math.Min(value, AHSLColor.LIGHTNESS_MAX), AHSLColor.LIGHTNESS_MIN));
                OnPropertyChanged(nameof(LightnessComponent));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ColorsPickerInternalMessageEx class constructor. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        /// <param name="title"> Message title. </param>
        /// <param name="icon"> Message header icon kind. </param>
        public ColorsPickerInternalMessageEx(InternalMessagesExContainer parentContainer, string title = "Select color",
            PackIconKind icon = PackIconKind.Pipette) : base(parentContainer)
        {
            Title = title;
            IconKind = icon;

            //  Initialize interface components.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region MESSAGE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing color selection in colors palette. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Colors Palette Selection Changed Event Args. </param>
        private void OnColorSelectionChanged(object sender, ColorsPaletteSelectionChangedEventArgs e)
        {
            if (e.SelectedColorItem != null)
            {
                SelectedColor = e.SelectedColorItem.Color;
                SelectedColorCode = e.SelectedColorItem.ColorCode;
                SelectedColorName = e.SelectedColorItem.Name;

                UpdateARGBComponents(SelectedColor);
                UpdateAHSLComponents(SelectedColor);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading message. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed event arguments. </param>
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            colorPicker.SelectedColor = SelectedColor;

            UpdateARGBComponents(SelectedColor);
            UpdateAHSLComponents(SelectedColor);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after manual changing color components. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Text Modified Event Arguments. </param>
        private void UpDownTextBoxEx_TextModified(object sender, TextModifiedEventArgs e)
        {
            if (e.UserModified)
            {
                var color = SelectedColor;
                var senderName = (sender as UpDownTextBoxEx)?.Name ?? string.Empty;
                
                if (RGB_CONTROLS.Contains(senderName))
                {
                    color = Color.FromArgb(
                        (byte)AlphaComponent, (byte)RedComponent, (byte)GreenComponent, (byte)BlueComponent);

                    if (senderName != "redUpDownTextBoxEx")
                        RedComponent = color.R;

                    if (senderName != "greenUpDownTextBoxEx")
                        GreenComponent = color.G;

                    if (senderName != "blueUpDownTextBoxEx")
                        BlueComponent = color.B;

                    if (senderName != "alphaUpDownTextBoxEx")
                        AlphaComponent = color.A;

                    UpdateAHSLComponents(SelectedColor);
                }
                else if (HSL_CONTROLS.Contains(senderName))
                {
                    var ahslColor = new AHSLColor(
                        (byte)AlphaComponent, HueComponent, SaturationComponent, LightnessComponent);

                    if (senderName != "hueUpDownTextBoxEx")
                        HueComponent = ahslColor.H;

                    if (senderName != "saturationUpDownTextBoxEx")
                        SaturationComponent = ahslColor.S;

                    if (senderName != "lightnessUpDownTextBoxEx")
                        LightnessComponent = ahslColor.L;

                    color = ahslColor.ToColor();

                    UpdateARGBComponents(color);
                }

                SelectedColor = color;
                string hexCode = ColorsUtilities.ColorToHex(SelectedColor);
                SelectedColorName = hexCode;
                SelectedColorCode = hexCode;
            }
        }

        #endregion MESSAGE METHODS

        #region UPDATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Update ARGB components. </summary>
        /// <param name="color"> Color. </param>
        private void UpdateARGBComponents(Color color)
        {
            RedComponent = color.R;
            GreenComponent = color.G;
            BlueComponent = color.B;
            AlphaComponent = color.A;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update AHSL components. </summary>
        /// <param name="color"> Color. </param>
        private void UpdateAHSLComponents(Color color)
        {
            var ahsl = AHSLColor.FromColor(color);
            HueComponent = ahsl.H;
            SaturationComponent = ahsl.S;
            LightnessComponent = ahsl.L;
        }

        #endregion UPDATE METHODS

    }

}
