using chkam05.Tools.ControlsEx.Example.Data.Enums;
using chkam05.Tools.ControlsEx.Resources;
using chkam05.Tools.ControlsEx.Utilities;
using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Example.Data.Components
{
    public class BaseDemoDataContext : BaseViewModel
    {

        //  VARIABLES

        private Brush backgroundProperty = new SolidColorBrush(ColorsResources.DefaultAccentColor);
        private Brush backgroundInactiveProperty = new SolidColorBrush(ColorsResources.DarkInactive);
        private Brush backgroundMouseOverProperty = new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver);
        private Brush backgroundPressedProperty = new SolidColorBrush(ColorsResources.DefaultAccentColorPressed);
        private Brush backgroundSelectedProperty = new SolidColorBrush(ColorsResources.DefaultAccentColorSelected);
        private Brush borderBrushProperty = new SolidColorBrush(ColorsResources.DefaultAccentColor);
        private Brush borderBrushInactiveProperty = new SolidColorBrush(ColorsResources.DarkInactive);
        private Brush borderBrushMouseOverProperty = new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver);
        private Brush borderBrushPressedProperty = new SolidColorBrush(ColorsResources.DefaultAccentColorPressed);
        private Brush borderBrushSelectedProperty = new SolidColorBrush(ColorsResources.DefaultAccentColorSelected);
        private Thickness borderThicknessProperty = new Thickness(1);
        private CornerRadius cornerRadiusProperty = new CornerRadius(4);
        private bool enabledProperty = true;
        private Brush foregroundProperty = new SolidColorBrush(ColorsResources.DefaultAccentColorForeground);
        private Brush foregroundInactiveProperty = new SolidColorBrush(ColorsResources.LightInactive);
        private Brush foregroundMouseOverProperty = new SolidColorBrush(ColorsResources.DefaultAccentColorForeground);
        private Brush foregroundPressedProperty = new SolidColorBrush(ColorsResources.DefaultAccentColorForeground);
        private Brush foregroundSelectedProperty = new SolidColorBrush(ColorsResources.DefaultAccentColorForeground);
        private double heightProperty = 100;
        private double opacityInactiveProperty = 0.56d;
        private double widthProperty = 100;


        //  GETTERS & SETTERS

        public Brush BackgroundProperty
        {
            get => backgroundProperty;
            set => UpdateProperty(ref backgroundProperty, value);
        }

        public Brush BackgroundInactiveProperty
        {
            get => backgroundInactiveProperty;
            set => UpdateProperty(ref backgroundInactiveProperty, value);
        }

        public Brush BackgroundMouseOverProperty
        {
            get => backgroundMouseOverProperty;
            set => UpdateProperty(ref backgroundMouseOverProperty, value);
        }

        public Brush BackgroundPressedProperty
        {
            get => backgroundPressedProperty;
            set => UpdateProperty(ref backgroundPressedProperty, value);
        }

        public Brush BackgroundSelectedProperty
        {
            get => backgroundSelectedProperty;
            set => UpdateProperty(ref backgroundSelectedProperty, value);
        }

        public Brush BorderBrushProperty
        {
            get => borderBrushProperty;
            set => UpdateProperty(ref borderBrushProperty, value);
        }

        public Brush BorderBrushInactiveProperty
        {
            get => borderBrushInactiveProperty;
            set => UpdateProperty(ref borderBrushInactiveProperty, value);
        }

        public Brush BorderBrushMouseOverProperty
        {
            get => borderBrushMouseOverProperty;
            set => UpdateProperty(ref borderBrushMouseOverProperty, value);
        }

        public Brush BorderBrushPressedProperty
        {
            get => borderBrushPressedProperty;
            set => UpdateProperty(ref borderBrushPressedProperty, value);
        }

        public Brush BorderBrushSelectedProperty
        {
            get => borderBrushSelectedProperty;
            set => UpdateProperty(ref borderBrushSelectedProperty, value);
        }

        public Thickness BorderThicknessProperty
        {
            get => borderThicknessProperty;
            set => UpdateBorderThicknessProperty(value);
        }

        public double BorderThicknessLeftProperty
        {
            get => borderThicknessProperty.Left;
            set => UpdateBorderThicknessProperty(value, Directions.Left);
        }

        public double BorderThicknessTopProperty
        {
            get => borderThicknessProperty.Top;
            set => UpdateBorderThicknessProperty(value, Directions.Top);
        }

        public double BorderThicknessRightProperty
        {
            get => borderThicknessProperty.Right;
            set => UpdateBorderThicknessProperty(value, Directions.Right);
        }

        public double BorderThicknessBottomProperty
        {
            get => borderThicknessProperty.Bottom;
            set => UpdateBorderThicknessProperty(value, Directions.Bottom);
        }

        public CornerRadius CornerRadiusProperty
        {
            get => cornerRadiusProperty;
            set => UpdateCornerRadiusProperty(value);
        }

        public double CornerRadiusPropertyTopLeftProperty
        {
            get => cornerRadiusProperty.TopLeft;
            set => UpdateCornerRadiusProperty(value, DirectionsDiagonal.TopLeft);
        }

        public double CornerRadiusPropertyTopRightProperty
        {
            get => cornerRadiusProperty.TopRight;
            set => UpdateCornerRadiusProperty(value, DirectionsDiagonal.TopRight);
        }

        public double CornerRadiusPropertyBottomRightProperty
        {
            get => cornerRadiusProperty.BottomRight;
            set => UpdateCornerRadiusProperty(value, DirectionsDiagonal.BottomRight);
        }

        public double CornerRadiusPropertyBottomLeftProperty
        {
            get => cornerRadiusProperty.BottomLeft;
            set => UpdateCornerRadiusProperty(value, DirectionsDiagonal.BottomLeft);
        }

        public bool EnabledProperty
        {
            get => enabledProperty;
            set => UpdateProperty(ref enabledProperty, value);
        }

        public Brush ForegroundProperty
        {
            get => foregroundProperty;
            set => UpdateProperty(ref foregroundProperty, value);
        }

        public Brush ForegroundInactiveProperty
        {
            get => foregroundInactiveProperty;
            set => UpdateProperty(ref foregroundInactiveProperty, value);
        }

        public Brush ForegroundMouseOverProperty
        {
            get => foregroundMouseOverProperty;
            set => UpdateProperty(ref foregroundMouseOverProperty, value);
        }

        public Brush ForegroundPressedProperty
        {
            get => foregroundPressedProperty;
            set => UpdateProperty(ref foregroundPressedProperty, value);
        }

        public Brush ForegroundSelectedProperty
        {
            get => foregroundSelectedProperty;
            set => UpdateProperty(ref foregroundSelectedProperty, value);
        }

        public double HeightProperty
        {
            get => heightProperty;
            set => UpdateProperty(ref heightProperty, Math.Max(0, value));
        }

        public double OpacityInactiveProperty
        {
            get => opacityInactiveProperty;
            set => UpdateProperty(ref opacityInactiveProperty, MathUtilities.Clamp(value, 0d, 1d));
        }

        public double WidthProperty
        {
            get => widthProperty;
            set => UpdateProperty(ref widthProperty, Math.Max(0, value));
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> BaseDemoDataContext class constructor. </summary>
        public BaseDemoDataContext()
        {
            SetupData();
        }

        #endregion CONSTRUCTORS

        #region PROPERTIES UPDATE

        //  --------------------------------------------------------------------------------
        /// <summary> Sets a value in a BorderThicknessProperty property and triggers a property changed notification event. </summary>
        /// <param name="newValue"> Value to set. </param>
        private void UpdateBorderThicknessProperty(Thickness newValue)
        {
            borderThicknessProperty = newValue;

            NotifyPropertyChanged(nameof(BorderThicknessProperty));
            NotifyPropertyChanged(nameof(BorderThicknessLeftProperty));
            NotifyPropertyChanged(nameof(BorderThicknessTopProperty));
            NotifyPropertyChanged(nameof(BorderThicknessRightProperty));
            NotifyPropertyChanged(nameof(BorderThicknessBottomProperty));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Sets a value in a BorderThicknessProperty property and triggers a property changed notification event. </summary>
        /// <param name="newValue"> Value to set. </param>
        /// <param name="direction"> Side of Thickness. </param>
        private void UpdateBorderThicknessProperty(double newValue, Directions direction)
        {
            var left = borderThicknessProperty.Left;
            var top = borderThicknessProperty.Top;
            var right = borderThicknessProperty.Right;
            var bottom = borderThicknessProperty.Bottom;
            string propertyName = null;

            switch (direction)
            {
                case Directions.Left:
                    left = newValue;
                    propertyName = nameof(BorderThicknessLeftProperty);
                    break;

                case Directions.Top:
                    top = newValue;
                    propertyName = nameof(BorderThicknessTopProperty);
                    break;

                case Directions.Right:
                    right = newValue;
                    propertyName = nameof(BorderThicknessRightProperty);
                    break;

                case Directions.Bottom:
                    bottom = newValue;
                    propertyName = nameof(BorderThicknessBottomProperty);
                    break;
            }

            borderThicknessProperty = new Thickness(left, top, right, bottom);

            NotifyPropertyChanged(nameof(BorderThicknessProperty));

            if (propertyName != null)
                NotifyPropertyChanged(propertyName);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Sets a value in a CornerRadiusProperty property and triggers a property changed notification event. </summary>
        /// <param name="newValue"> Value to set. </param>
        private void UpdateCornerRadiusProperty(CornerRadius newValue)
        {
            cornerRadiusProperty = newValue;

            NotifyPropertyChanged(nameof(CornerRadiusProperty));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Sets a value in a CornerRadiusProperty property and triggers a property changed notification event. </summary>
        /// <param name="newValue"> Value to set. </param>
        /// <param name="direction"> Side of CornerRadius. </param>
        private void UpdateCornerRadiusProperty(double newValue, DirectionsDiagonal direction)
        {
            var topLeft = cornerRadiusProperty.TopLeft;
            var topRight = cornerRadiusProperty.TopRight;
            var bottomRight = cornerRadiusProperty.BottomRight;
            var bottomLeft = cornerRadiusProperty.BottomLeft;
            string propertyName = null;

            switch (direction)
            {
                case DirectionsDiagonal.TopLeft:
                    topLeft = newValue;
                    propertyName = nameof(CornerRadiusPropertyTopLeftProperty);
                    break;

                case DirectionsDiagonal.TopRight:
                    topRight = newValue;
                    propertyName = nameof(CornerRadiusPropertyTopRightProperty);
                    break;

                case DirectionsDiagonal.BottomRight:
                    bottomRight = newValue;
                    propertyName = nameof(CornerRadiusPropertyBottomRightProperty);
                    break;

                case DirectionsDiagonal.BottomLeft:
                    bottomLeft = newValue;
                    propertyName = nameof(CornerRadiusPropertyBottomLeftProperty);
                    break;
            }

            cornerRadiusProperty = new CornerRadius(topLeft, topRight, bottomRight, bottomLeft);

            NotifyPropertyChanged(nameof(CornerRadiusProperty));

            if (propertyName != null)
                NotifyPropertyChanged(propertyName);
        }

        #endregion PROPERTIES UPDATE

        #region SETUP METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Setup default demo data. </summary>
        protected virtual void SetupData()
        {
            //  Leave default values.
        }

        #endregion SETUP METHODS

    }
}
