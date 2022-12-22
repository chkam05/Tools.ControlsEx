using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using chkam05.Tools.ControlsEx.Data;

namespace chkam05.Tools.ControlsEx.Utilities
{
    public static class FontUtilities
    {

        //  VARIABLES

        private static FontFamilyInfo _defaultFont;
        private static List<FontFamilyInfo> _systemFonts;


        //  GETTERS & SETTERS

        public static FontFamilyInfo DefaultFont
        {
            get
            {
                if (_defaultFont == null)
                    _defaultFont = SystemFonts.FirstOrDefault(f => f.Name == "Segoe UI");

                return _defaultFont;
            }
        }

        public static List<FontFamilyInfo> SystemFonts
        {
            get
            {
                if (_systemFonts == null)
                    _systemFonts = GetSystemFonts();

                return _systemFonts;
            }
        }


        //  METHODS

        #region FONTS MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Get list of system fonts as font family info. </summary>
        /// <returns> Font family info. </returns>
        private static List<FontFamilyInfo> GetSystemFonts()
        {
            return Fonts.SystemFontFamilies
                .OrderBy(o => o.FamilyNames.First().Value)
                .Select(f => new FontFamilyInfo(f))
                .ToList();
        }

        #endregion FONTS MANAGEMENT METHODS

        #region SEARCH METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Find font by its name. </summary>
        /// <param name="fonts"> Fonts collection. </param>
        /// <param name="familyName"> Font family name. </param>
        /// <returns> Found font or default. </returns>
        public static FontFamilyInfo FindFontByName(IEnumerable<FontFamilyInfo> fonts, string familyName)
        {
            if (fonts != null && !string.IsNullOrEmpty(familyName))
            {
                var foundFont = fonts.FirstOrDefault(f => f.Name == familyName);
                return foundFont != null ? foundFont : DefaultFont;
            }

            return DefaultFont;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Find font by its name and subname. </summary>
        /// <param name="fonts"> Fonts collection. </param>
        /// <param name="familyName"> Font family name. </param>
        /// <param name="familySubName"> Font family subname. </param>
        /// <returns> Found font or default. </returns>
        public static FontFamilyInfo FindFontByNameAndSubName(IEnumerable<FontFamilyInfo> fonts,
            string familyName, string familySubName)
        {
            if (fonts != null && !string.IsNullOrEmpty(familyName) && !string.IsNullOrEmpty(familySubName))
            {
                var foundFont = fonts.FirstOrDefault(f => f.Name == familyName && f.SubName == familySubName);
                return foundFont != null ? foundFont : DefaultFont;
            }

            return DefaultFont;
        }

        #endregion SEARCH METHODS

        #region STATIC ELEMENTS METHODS

        //  --------------------------------------------------------------------------------
        public static int GetBaselineTextDecorations()
        {
            return TextDecorations.Baseline.Count;
        }

        //  --------------------------------------------------------------------------------
        public static int GetOverLineTextDecorations()
        {
            return TextDecorations.OverLine.Count;
        }

        //  --------------------------------------------------------------------------------
        public static int GetStrikeTextDecorations()
        {
            return TextDecorations.Strikethrough.Count;
        }

        //  --------------------------------------------------------------------------------
        public static int GetUnderlineTextDecorations()
        {
            return TextDecorations.Underline.Count;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get list of text alignment types. </summary>
        /// <returns> List of text alignment types. </returns>
        public static List<TextAlignment> GetTextAlignments()
        {
            return new List<TextAlignment>()
            {
                TextAlignment.Left,
                TextAlignment.Center,
                TextAlignment.Right,
                TextAlignment.Justify
            };
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get list of font stretch types. </summary>
        /// <returns> List of font stretch types. </returns>
        public static List<FontStretch> GetStretches()
        {
            return new List<FontStretch>()
            {
                FontStretches.Normal,
                FontStretches.Condensed,
                FontStretches.Expanded,
                FontStretches.ExtraCondensed,
                FontStretches.ExtraExpanded,
                //FontStretches.Medium,
                FontStretches.SemiCondensed,
                FontStretches.SemiExpanded,
                FontStretches.UltraExpanded
            };
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get list of font style types. </summary>
        /// <returns> List of font style types. </returns>
        public static List<FontStyle> GetStyles()
        {
            return new List<FontStyle>()
            {
                FontStyles.Normal,
                FontStyles.Italic,
                FontStyles.Oblique
            };
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get list of font weight types. </summary>
        /// <returns> List of font weight types. </returns>
        public static List<FontWeight> GetWeights()
        {
            return new List<FontWeight>()
            {
                FontWeights.Normal,
                //FontWeights.Regular,
                FontWeights.Black,
                FontWeights.Bold,
                //FontWeights.DemiBold,
                FontWeights.ExtraBlack,
                FontWeights.ExtraBold,
                FontWeights.ExtraLight,
                //FontWeights.Heavy,
                FontWeights.Light,
                FontWeights.Medium,
                FontWeights.SemiBold,
                FontWeights.Thin,
                //FontWeights.UltraBlack,
                //FontWeights.UltraBold,
                //FontWeights.UltraLight,
            };
        }

        #endregion STATIC ELEMENTS METHODS

    }
}
