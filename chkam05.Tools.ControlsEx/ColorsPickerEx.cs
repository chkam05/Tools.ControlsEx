using chkam05.Tools.ControlsEx.Colors;
using chkam05.Tools.ControlsEx.Static;
using chkam05.Tools.ControlsEx.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using static chkam05.Tools.ControlsEx.Events.Delegates;

namespace chkam05.Tools.ControlsEx
{
    public class ColorsPickerEx : Control, INotifyPropertyChanged
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ColorsPickerEx),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));

        public static readonly DependencyProperty HueProperty = DependencyProperty.Register(
            nameof(Hue),
            typeof(double),
            typeof(ColorsPickerEx),
            new PropertyMetadata(0d));

        public static readonly DependencyProperty SelectedColorProperty = DependencyProperty.Register(
            nameof(SelectedColor),
            typeof(Color),
            typeof(ColorsPickerEx),
            new PropertyMetadata(System.Windows.Media.Colors.Red));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;
        public event ColorsPalleteSelectionChanged ColorSelectionChanged;


        //  VARIABLES

        private bool _isColorSelecting = false;
        private bool _isColorUpdating = false;
        private int _lightness = 100;
        private int _saturation = 100;


        //  GETTERS & SETTERS

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set
            {
                SetValue(CornerRadiusProperty, value);
                OnPropertyChanged(nameof(CornerRadius));
            }
        }

        public double Hue
        {
            get => (double)GetValue(HueProperty);
            set
            {
                SetValue(HueProperty, value);
                OnPropertyChanged(nameof(Hue));
            }
        }

        public Color SelectedColor
        {
            get => (Color)GetValue(SelectedColorProperty);
            set
            {
                SetValue(SelectedColorProperty, value);
                OnPropertyChanged(nameof(SelectedColor));

                if (!_isColorUpdating)
                {
                    _isColorUpdating = true;
                    UpdateSelectedColorVisualElements();
                    UpdateVisualElements();
                    _isColorUpdating = false;
                }
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ColorsPickerEx class constructor. </summary>
        public ColorsPickerEx()
        {
            SizeChanged += OnSizeChanged;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static ColorsPickerEx class constructor. </summary>
        static ColorsPickerEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorsPickerEx),
                new FrameworkPropertyMetadata(typeof(ColorsPickerEx)));
        }

        #endregion CLASS METHODS

        #region COMPONENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing value in color hue slider. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed Property Changed Event Arguments. </param>
        private void OnHueSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_isColorUpdating)
                return;

            UpdateVisualElements();
            UpdateSelectedColor();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked when mouse is moving color selector element on canvas selector. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Mouse Event Arguments. </param>
        private void OnMoveColorSelector(object sender, MouseEventArgs e)
        {
            if (_isColorSelecting)
            {
                var border = GetBorder("lowerBorder");
                var colorSelector = GetEllipse("colorSelector");
                var position = e.GetPosition(sender as Canvas);

                if (border != null && colorSelector != null)
                {
                    var selectorHalfX = colorSelector.ActualWidth / 2;
                    var selectorHalfY = colorSelector.ActualHeight / 2;

                    var x = Math.Max(
                        Math.Min(
                            position.X - selectorHalfX,
                            border.ActualWidth - selectorHalfX),
                        -selectorHalfX);

                    var y = Math.Max(
                        Math.Min(
                            position.Y - selectorHalfY,
                            border.ActualHeight - selectorHalfY),
                        -selectorHalfY);

                    Canvas.SetLeft(colorSelector, x);
                    Canvas.SetTop(colorSelector, y);

                    var lightness = 100 - (int)((y + selectorHalfY) * 100 / border.ActualHeight);
                    _saturation = (int)((x + selectorHalfX) * 100 / border.ActualWidth);
                    _lightness = Math.Max(0, lightness - (_saturation / 2));

                    UpdateVisualElements();
                    UpdateSelectedColor();
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after grabbing color selector. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Mouse Buttons Event Arguments. </param>
        private void OnPressColorSelector(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                _isColorSelecting = true;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after releasing from grab color selector. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Mouse Buttons Event Arguments. </param>
        private void OnReleaseColorSelector(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released)
                _isColorSelecting = false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked when component size is changed. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Size Changed Event Arguments. </param>
        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            _isColorUpdating = true;
            UpdateSelectedColorVisualElements();
            _isColorUpdating = false;
        }

        #endregion COMPONENT METHODS

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

        #region TEMPLATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> When overridden in a derived class,cis invoked whenever 
        /// application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            //  Apply Template
            base.OnApplyTemplate();

            var colorSelector = GetEllipse("colorSelector");

            ApplyCanvasMouseMoveMethod(GetCanvas("canvasSelector"), OnMoveColorSelector);
            ApplyEllipsePreviewMouseDownMethod(colorSelector, OnPressColorSelector);
            ApplyEllipsePreviewMouseUpMethod(colorSelector, OnReleaseColorSelector);
            ApplySliderExValueChangedMethod(GetSliderEx("hueSlider"), OnHueSliderValueChanged);

            UpdateSelectedColorVisualElements();
            UpdateVisualElements();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get Border from ContentTemplate. </summary>
        /// <param name="borderName"> Border name. </param>
        /// <returns> Border or null. </returns>
        protected Border GetBorder(string borderName)
        {
            return this.Template.FindName(borderName, this) as Border;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get Canvas from ContentTemplate. </summary>
        /// <param name="canvasName"> Canvas name. </param>
        /// <returns> Canvas or null. </returns>
        protected Canvas GetCanvas(string canvasName)
        {
            return this.Template.FindName(canvasName, this) as Canvas;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get Ellipse from ContentTemplate. </summary>
        /// <param name="ellipseName"> Ellipse name. </param>
        /// <returns> Ellipse or null. </returns>
        protected Ellipse GetEllipse(string ellipseName)
        {
            return this.Template.FindName(ellipseName, this) as Ellipse;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get SliderEx from ContentTemplate. </summary>
        /// <param name="sliderExName"> SliderEx name. </param>
        /// <returns> SliderEx or null. </returns>
        protected SliderEx GetSliderEx(string sliderExName)
        {
            return this.Template.FindName(sliderExName, this) as SliderEx;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Apply MouseMove method on Canvas. </summary>
        /// <param name="canvas"> Canvas. </param>
        /// <param name="eventHandler"> On Mouse Move method. </param>
        protected void ApplyCanvasMouseMoveMethod(Canvas canvas, MouseEventHandler eventHandler)
        {
            if (canvas != null)
                canvas.MouseMove += eventHandler;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Apply MouseMove method on Canvas. </summary>
        /// <param name="ellipse"> Ellipse. </param>
        /// <param name="eventHandler"> Mouse Button behaviour method. </param>
        protected void ApplyEllipsePreviewMouseDownMethod(Ellipse ellipse, MouseButtonEventHandler eventHandler)
        {
            if (ellipse != null)
                ellipse.PreviewMouseDown += eventHandler;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Apply MouseMove method on Canvas. </summary>
        /// <param name="ellipse"> Ellipse. </param>
        /// <param name="eventHandler"> Mouse Button behaviour method. </param>
        protected void ApplyEllipsePreviewMouseUpMethod(Ellipse ellipse, MouseButtonEventHandler eventHandler)
        {
            if (ellipse != null)
                ellipse.PreviewMouseUp += eventHandler;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Apply ValueChanged method on SliderEx. </summary>
        /// <param name="sliderEx"> SliderEx. </param>
        /// <param name="eventHandler"> Click method. </param>
        protected void ApplySliderExValueChangedMethod(SliderEx sliderEx, RoutedPropertyChangedEventHandler<double> eventHandler)
        {
            if (sliderEx != null)
                sliderEx.ValueChanged += eventHandler;
        }

        #endregion TEMPLATE METHODS

        #region UPDATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Update color method. </summary>
        private void UpdateSelectedColor()
        {
            _isColorUpdating = true;
            SelectedColor = new AHSLColor(255, (int)Hue, _saturation, _lightness).ToColor();
            ColorSelectionChanged(this, new Events.ColorsPaletteSelectionChangedEventArgs(
                new ColorPaletteItem(SelectedColor, ColorsUtilities.ColorToHex(SelectedColor))));
            _isColorUpdating = false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update color configuration position components.  </summary>
        private void UpdateSelectedColorVisualElements()
        {
            var ahlsColor = AHSLColor.FromColor(SelectedColor);
            Hue = ahlsColor.H;
            _lightness = ahlsColor.L;
            _saturation = ahlsColor.S;

            var border = GetBorder("lowerBorder");
            var colorSelector = GetEllipse("colorSelector");

            if (border != null && colorSelector != null)
            {
                var selectorHalfX = colorSelector.ActualWidth / 2;
                var selectorHalfY = colorSelector.ActualHeight / 2;

                Canvas.SetLeft(colorSelector, (100 - _saturation) * border.ActualWidth / 100 - selectorHalfX);
                Canvas.SetTop(colorSelector, _lightness * border.ActualHeight / 100 - selectorHalfY);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update appearance of color configuration components. </summary>
        private void UpdateVisualElements()
        {
            var colorSelector = GetEllipse("colorSelector");
            var hueSlider = GetSliderEx("hueSlider");
            var lowerBorder = GetBorder("lowerBorder");
            var selectedColor = new AHSLColor(255, (int)Hue, _saturation, _lightness).ToColor();
            var selectedHueColor = new AHSLColor(255, (int)Hue, 100, 50).ToColor();

            if (colorSelector != null)
            {
                colorSelector.Fill = new SolidColorBrush(selectedColor);
            }

            if (hueSlider != null)
            {
                var solidColorBrush = new SolidColorBrush(selectedHueColor);
                hueSlider.Foreground = solidColorBrush;
                hueSlider.ThumbDraggingBackground = solidColorBrush;
                hueSlider.ThumbMouseOverBackground = solidColorBrush;
            }

            if (lowerBorder != null)
            {
                lowerBorder.Background = new LinearGradientBrush(
                    new GradientStopCollection()
                    {
                        new GradientStop(System.Windows.Media.Colors.White, 0.0),
                        new GradientStop(selectedHueColor, 1.0),
                    },
                    new Point(0, 0),
                    new Point(1, 0));
            }
        }

        #endregion UDPATE METHODS

    }
}
