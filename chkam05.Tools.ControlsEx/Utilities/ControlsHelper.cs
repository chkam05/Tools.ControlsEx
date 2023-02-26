using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Utilities
{
    public static class ControlsHelper
    {

        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Check if component is visible. </summary>
        /// <param name="element"> UI component. </param>
        /// <returns> True - component is visible; False - otherwise. </returns>
        public static bool IsControlVisible(FrameworkElement element)
        {
            if (element == null)
                return false;

            if (element.Visibility != Visibility.Visible)
                return false;

            var parentElement = GetParentElement(element);

            if (parentElement == null)
                return true;

            return IsControlVisible(parentElement);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get parent component. </summary>
        /// <param name="element"> Child component. </param>
        /// <returns> Parent component or null. </returns>
        public static FrameworkElement GetParentElement(FrameworkElement element)
        {
            return VisualTreeHelper.GetParent(element) as FrameworkElement;
        }

    }
}
