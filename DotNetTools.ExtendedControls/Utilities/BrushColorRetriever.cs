using System.Linq;
using System.Windows.Media;


namespace chkam05.DotNetTools.ExtendedControls.Utilities
{
    public static class BrushColorRetriever
    {

        //  CONST

        private static Color DEFAULT_COLOR = Colors.White;


        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Get color from brush (SolidColorBrush, LinearGradientBrush, RadialGradientBrush). </summary>
        /// <param name="brush"> Brush with color. </param>
        /// <param name="defaultColor"> Default color if brush is not supported or does not have any color. </param>
        /// <returns> RGB color. </returns>
        public static Color GetColorFromBrush(Brush brush, Color? defaultColor = null)
        {
            if (brush.GetType() == typeof(SolidColorBrush))
                return GetColorFromSolidColorBrush((SolidColorBrush)brush, defaultColor);

            if (brush.GetType() == typeof(LinearGradientBrush))
                return GetColorLinearGradientBrush((LinearGradientBrush)brush, defaultColor);

            if (brush.GetType() == typeof(RadialGradientBrush))
                return GetColorRadialGradientBrush((RadialGradientBrush)brush, defaultColor);

            if (defaultColor.HasValue)
                return defaultColor.Value;

            return DEFAULT_COLOR;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get color from SolidColorBrush. </summary>
        /// <param name="brush"> SolidColorBrush with color. </param>
        /// <param name="defaultColor"> Default color if brush does not have any color. </param>
        /// <returns> RGB color. </returns>
        private static Color GetColorFromSolidColorBrush(SolidColorBrush brush, Color? defaultColor = null)
        {
            if (brush != null)
                return brush.Color;

            if (defaultColor.HasValue)
                return defaultColor.Value;

            return DEFAULT_COLOR;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get color from LinearGradientBrush. </summary>
        /// <param name="brush"> LinearGradientBrush with color. </param>
        /// <param name="defaultColor"> Default color if brush does not have any color. </param>
        /// <returns> RGB color. </returns>
        private static Color GetColorLinearGradientBrush(LinearGradientBrush brush, Color? defaultColor = null)
        {
            if (brush != null && brush.GradientStops.Any())
                return brush.GradientStops.FirstOrDefault().Color;

            if (defaultColor.HasValue)
                return defaultColor.Value;

            return DEFAULT_COLOR;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get color from RadialGradientBrush. </summary>
        /// <param name="brush"> RadialGradientBrush with color. </param>
        /// <param name="defaultColor"> Default color if brush does not have any color. </param>
        /// <returns> RGB color. </returns>
        private static Color GetColorRadialGradientBrush(RadialGradientBrush brush, Color? defaultColor = null)
        {
            if (brush != null && brush.GradientStops.Any())
                return brush.GradientStops.FirstOrDefault().Color;

            if (defaultColor.HasValue)
                return defaultColor.Value;

            return DEFAULT_COLOR;
        }

    }
}
