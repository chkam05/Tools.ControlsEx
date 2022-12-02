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


        //  FONTS

        /// <summary> Method invoked after requesting background change in FontControllerEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Font Background Changed Request Event Arguments. </param>
        public delegate void FontBackgroundChangedRequestEventHandler(object sender, FontBackgroundChangedRequestEventArgs e);

        /// <summary> Method invoked after changing font in FontControllerEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Font Changed Event Arguments. </param>
        public delegate void FontChangedEventHandler(object sender, FontChangedEventArgs e);

        /// <summary> Method invoked after requesting color change in FontControllerEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Font Color Changed Request Event Arguments. </param>
        public delegate void FontColorChangeRequestEventHandler(object sender, FontColorChangeRequestEventArgs e);

        /// <summary> Method invoked after changing font size in FontControllerEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Font Size Changed Request Event Arguments. </param>
        public delegate void FontSizeChangedEventHandler(object sender, FontSizeChangedEventArgs e);

        /// <summary> Method invoked after changing font strike in FontControllerEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Font Strike Changed Event Arguments. </param>
        public delegate void FontStrikeChangedEventHandler(object sender, FontStrikeChangedEventArgs e);

        /// <summary> Method invoked after changing font style in FontControllerEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Font Style Changed Event Arguments. </param>
        public delegate void FontStyleChangedEventHandler(object sender, FontStyleChangedEventArgs e);

        /// <summary> Method invoked after changing font underline in FontControllerEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Font Underline Changed Event Arguments. </param>
        public delegate void FontUnderlineChangedEventHandler(object sender, FontUnderlineChangedEventArgs e);

        /// <summary> Method invoked after changing font weight in FontControllerEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Font Weight Changed Event Arguments. </param>
        public delegate void FontWeightChangedEventHandler(object sender, FontWeightChangedEventArgs e);

        /// <summary> Method invoked after changing text alignment in FontControllerEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Text Alignment Changed Event Arguments. </param>
        public delegate void TextAlignmentChangedEventHandler(object sender, TextAlignmentChangedEventArgs e);

        /// <summary> Method invoked after changing text data format in FontControllerEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Text Data Format Changed Event Arguments. </param>
        public delegate void TextDataFormatChangedEventHandler(object sender, TextDataFormatChangedEventArgs e);


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
        
    }
}
