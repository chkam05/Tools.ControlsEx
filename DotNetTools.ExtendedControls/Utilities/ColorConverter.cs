using chkam05.DotNetTools.ExtendedControls.Data;
using System;
using System.Windows.Media;


namespace chkam05.DotNetTools.ExtendedControls.Utilities
{
    public static class ColorConverter
    {

        //  --------------------------------------------------------------------------------
        /// <summary> Convert RGB color to HSL color. </summary>
        /// <param name="rgbColor"> RGB color. </param>
        /// <returns> HSL color. </returns>
        public static HslColor RgbToHsl(Color rgbColor)
        {
            double R = (double)rgbColor.R / 255;
            double G = (double)rgbColor.G / 255;
            double B = (double)rgbColor.B / 255;

            double maxRgbValue = Math.Max(R, Math.Max(G, B));
            double minRgbValue = Math.Min(R, Math.Min(G, B));
            double rgbDelta = maxRgbValue - minRgbValue;

            /* If max and min are equal, that means the color is shade of gray. 
             * So H and S must be set to zero, and L to either max or min. */

            if (maxRgbValue == minRgbValue)
                return new HslColor(rgbColor.A, 0, maxRgbValue * 100, 0);

            //  Color is not a shade of gray.

            double H = 0;
            double L = (minRgbValue + maxRgbValue) / 2;
            double S = (L < 0.5)
                ? rgbDelta / (minRgbValue + maxRgbValue)
                : rgbDelta / (2.0 - maxRgbValue - minRgbValue);

            if (R == maxRgbValue)
                H = ((G - B) / 6) / rgbDelta;

            else if (G == maxRgbValue)
                H = (1.0 / 3) + ((B - R) / 6) / rgbDelta;

            else if (B == maxRgbValue)
                H = (2.0 / 3) + ((R - G) / 6) / rgbDelta;

            if (H < 0)
                H += 1;

            else if (H > 1)
                H -= 1;

            return new HslColor(rgbColor.A, H * 360, L * 100, S * 100);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Convert HSL color to RGB color. </summary>
        /// <param name="hslColor"> HSL color. </param>
        /// <returns> RGB color. </returns>
        public static Color HslToRgb(HslColor hslColor)
        {
            double A = hslColor.A / 255;
            double H = hslColor.H / 360;
            double L = hslColor.L / 100;
            double S = hslColor.S / 100;

            /* If S = 0, that means the color is a shade of gray. 
             * So, R, G, and B must be set to L. */

            if (hslColor.S == 0)
                return Color.FromArgb(
                    ConvertToRgbValue(A),
                    ConvertToRgbValue(L),
                    ConvertToRgbValue(L),
                    ConvertToRgbValue(L));

            double v2 = (L < 0.5) ? L * (1 + S) : (L + S) - (L * S);
            double v1 = 2 * L - v2;

            byte newA = ConvertToRgbValue(A);
            byte R = ConvertToRgbValue(HueToRgb(v1, v2, H + (1.0 / 3)));
            byte G = ConvertToRgbValue(HueToRgb(v1, v2, H));
            byte B = ConvertToRgbValue(HueToRgb(v1, v2, H - (1.0 / 3)));

            return Color.FromArgb(newA, R, G, B);
        }


        #region UTILITY METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Convert double color component to byte color component. </summary>
        /// <param name="colorComponent"> Double color component. </param>
        /// <returns> Byte color component. </returns>
        private static byte ConvertToRgbValue(double colorComponent)
        {
            return (byte)Math.Max(0, Math.Min(255, colorComponent * 255));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Convert HUE HLS color component to RGB color component. </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="vH"> HUE HLS color component. </param>
        /// <returns> RGB color component. </returns>
        private static double HueToRgb(double v1, double v2, double vH)
        {
            if (vH < 0)
                vH += 1;

            if (vH > 1)
                vH -= 1;

            if ((6 * vH) < 1)
                return (v1 + (v2 - v1) * 6 * vH);

            if ((2 * vH) < 1)
                return v2;

            if ((3 * vH) < 2)
                return (v1 + (v2 - v1) * ((2.0 / 3) - vH) * 6);

            return v1;
        }

        #endregion UTILITY METHODS

    }
}
