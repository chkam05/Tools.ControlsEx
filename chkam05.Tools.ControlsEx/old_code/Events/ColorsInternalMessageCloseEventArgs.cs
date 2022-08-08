using chkam05.Tools.ControlsEx.Colors;
using chkam05.Tools.ControlsEx.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Events
{
    public class ColorsInternalMessageCloseEventArgs : InternalMessageCloseEventArgs
    {

        //  VARIABLES

        public ColorPaletteItem SelectedColorItem { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ColorsInternalMessageCloseEventArgs class constructor. </summary>
        /// <param name="result"> InternalMessageResult. </param>
        /// <param name="filesPaths"> Selected files paths. </param>
        public ColorsInternalMessageCloseEventArgs(InternalMessageResult result, ColorPaletteItem selectedColor) : base(result)
        {
            SelectedColorItem = selectedColor;
        }

        #endregion CLASS METHODS

    }
}
