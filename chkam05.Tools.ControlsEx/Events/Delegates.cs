using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Events
{
    public class Delegates
    {

        //  COLOR PALETTES

        /// <summary> Method invoked after changing color selection in ColorsPaletteEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Colors Palette Selection Changed Event Arguments. </param>
        public delegate void ColorsPalleteSelectionChanged(object sender, ColorsPaletteSelectionChangedEventArgs e);


        //  INDICATORS

        /// <summary> Method invoked after animation finish in IndicatorEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Internal Message Close Event Arguments. </param>
        public delegate void IndicatorAnimationEnd(object sender);

        /// <summary> Method invoked after animation frame changed in IndicatorEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Internal Message Close Event Arguments. </param>
        /// <returns> True - allow next frame; False - otherwise. </returns>
        public delegate bool IndicatorAnimationFrameUpdate(object sender);


        //  INTERNAL MESSAGES

        /// <summary> Method invoked after closing base InternalMessage. </summary>
        /// <typeparam name="T"> Event arguments type based on InternalMessageCloseEventArgs. </typeparam>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Internal Message Close Event Arguments. </param>
        public delegate void InternalMessageClose<T>(object sender, T e) where T : InternalMessageCloseEventArgs;

        /// <summary> Method invoked after hiding InternalMessage. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Internal Message Hide Event Arguments. </param>
        public delegate void InternalMessageHide(object sender, InternalMessageHideEventArgs e);


        //  TEXT BOXES

        /// <summary> Method invoked after modifying text. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Text Modified Event Arguments. </param>
        public delegate void TextModifiedEventHandler(object sender, TextModifiedEventArgs e);

        /// <summary> Method invoked after modifying up down double value. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Up Down Double Modified Event Arguments. </param>
        public delegate void UpDownDoubleModifiedEventHandler(object sender, UpDownDoubleModifiedEventArgs e);


        /// <summary> Method invoked after modifying up down long value. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Up Down Long Modified Event Arguments. </param>
        public delegate void UpDownLongModifiedEventHandler(object sender, UpDownLongModifiedEventArgs e);

    }
}
