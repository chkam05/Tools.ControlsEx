using System;
using System.Windows;


namespace chkam05.Tools.ControlsEx.Utilities
{
    public static class MathUtilitiesEx
    {

        //  METHODS

        #region CIRCLE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Convert degrees to radians. </summary>
        /// <param name="degrees"> Degrees. </param>
        /// <returns> Radians. </returns>
        public static double ConvertDegreesToRadians(double degrees)
        {
            return (Math.PI / 180) * degrees;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Convert radians to degrees. </summary>
        /// <param name="radians"> Radians. </param>
        /// <returns> Degrees. </returns>
        public static double ConvertRadiansToDegrees(double radians)
        {
            return (180 / Math.PI) * radians;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Find point on circle with radius and center point by angle. </summary>
        /// <param name="centerPoint"> Center point. </param>
        /// <param name="radius"> Circle radius. </param>
        /// <param name="angle"> Angle. </param>
        /// <returns> Point on circle. </returns>
        public static Point FindPointOnCircle(Point centerPoint, double radius, double angle)
        {
            var radians = ConvertDegreesToRadians(angle);

            return new Point(
                centerPoint.X + (radius * Math.Cos(radians)),
                centerPoint.Y + (radius * Math.Sin(radians)));
        }

        #endregion CIRCLE METHODS

    }
}
