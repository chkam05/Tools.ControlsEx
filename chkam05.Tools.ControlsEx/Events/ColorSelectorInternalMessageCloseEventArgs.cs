using chkam05.Tools.ControlsEx.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Events
{
    public class ColorSelectorInternalMessageCloseEventArgs : InternalMessageCloseEventArgs
    {

        //  VARIABLES

        public Color Color { get; private set; }

        public string ColorName { get; private set; }

        public string ColorCode { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ColorSelectorInternalMessageCloseEventArgs class constructor. </summary>
        /// <param name="result"> Result. </param>
        /// <param name="color"> Color. </param>
        public ColorSelectorInternalMessageCloseEventArgs(InternalMessageResult result, Color color, string colorName, string colorCode) : base(result)
        {
            Color = color;
            ColorName = colorName;
            ColorCode = colorCode;
        }

        #endregion CLASS METHODS

    }
}
