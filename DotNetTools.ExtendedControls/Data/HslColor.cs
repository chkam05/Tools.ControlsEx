using System;


namespace chkam05.DotNetTools.ExtendedControls.Data
{
    public class HslColor
    {

        //  CONST

        public static readonly double AlphaMax = 255;
        public static readonly double AlphaMin = 0;
        public static readonly double HueMax = 360;
        public static readonly double HueMin = 0;
        public static readonly double LightnessMax = 100;
        public static readonly double LightnessMin = 0;
        public static readonly double SaturationMax = 100;
        public static readonly double SaturationMin = 0;


        //  VARIABLES

        private double _alpha = 255;
        private double _hue = 0;
        private double _lightness = 100;
        private double _saturation = 50;


        //  GETTERS & SETTERS

        public double A
        {
            get => _alpha;
            set => _alpha = Math.Max(AlphaMin, Math.Min(AlphaMax, value));
        }

        public double H
        {
            get => _hue;
            set => _hue = Math.Max(HueMin, Math.Min(HueMax, value));
        }

        public double L
        {
            get => _lightness;
            set => _lightness = Math.Max(LightnessMin, Math.Min(LightnessMax, value));
        }

        public double S
        {
            get => _saturation;
            set => _saturation = Math.Max(SaturationMin, Math.Min(SaturationMax, value));
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> HlsColor class constructor with alpha. </summary>
        /// <param name="a"> Alpha. </param>
        /// <param name="h"> Hue. </param>
        /// <param name="l"> Lightness. </param>
        /// <param name="s"> Saturation. </param>

        public HslColor(double a, double h, double l, double s)
        {
            A = a;
            H = h;
            L = l;
            S = s;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> HlsColor class constructor. </summary>
        /// <param name="h"> Hue. </param>
        /// <param name="l"> Lightness. </param>
        /// <param name="s"> Saturation. </param>

        public HslColor(double h, double l, double s)
        {
            A = 255;
            H = h;
            L = l;
            S = s;
        }

        #endregion CLASS METHODS

    }
}
