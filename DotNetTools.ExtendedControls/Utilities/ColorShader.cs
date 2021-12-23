using chkam05.DotNetTools.ExtendedControls.Data;
using System.Windows.Media;


namespace chkam05.DotNetTools.ExtendedControls.Utilities
{
    public class ColorShader
    {

        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Make color brighter. </summary>
        /// <param name="color"> RGB color. </param>
        /// <param name="lightPercent"> Percent of light that will be increased. </param>
        /// <returns> Brighter color. </returns>
        public static Color BrightColor(Color color, double lightPercent)
        {
            HslColor hslColor = ColorConverter.RgbToHsl(color);
            hslColor.L += lightPercent;
            return ColorConverter.HslToRgb(hslColor);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Make color darker. </summary>
        /// <param name="color"> RGB color. </param>
        /// <param name="lightPercent"> Percent of light that will be decreased. </param>
        /// <returns> Darker color. </returns>
        public static Color DimColor(Color color, double lightPercent)
        {
            HslColor hslColor = ColorConverter.RgbToHsl(color);
            hslColor.L -= lightPercent;
            return ColorConverter.HslToRgb(hslColor);
        }

    }
}
