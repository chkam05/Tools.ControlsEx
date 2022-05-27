using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Events
{
    public class Delegates
    {

        /// <summary> Method invoked after modifying text. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Text Modified Event Arguments. </param>
        public delegate void TextModifiedEventHandler(object sender, TextModifiedEventArgs e);

        /// <summary> Method invoked after closing InternalMessage. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Internal Message Close Event Arguments. </param>
        public delegate void InternalMessageClose(object sender, InternalMessageCloseEventArgs e);

        /// <summary> Method invoked after hiding InternalMessage. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Internal Message Hide Event Arguments. </param>
        public delegate void InternalMessageHide(object sender, InternalMessageHideEventArgs e);

        /// <summary> Method invoked after closing InternalMessage. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Internal Message Close Event Arguments. </param>
        public delegate void ProgressInternalMessageCancel(object sender, InternalMessageCloseEventArgs e);

        /// <summary> Method invoked after animation finish in IndicatorEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Internal Message Close Event Arguments. </param>
        public delegate void IndicatorAnimationEnd(object sender);

        /// <summary> Method invoked after animation frame changed in IndicatorEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Internal Message Close Event Arguments. </param>
        /// <returns> True - allow next frame; False - otherwise. </returns>
        public delegate bool IndicatorAnimationFrameUpdate(object sender);

    }
}
