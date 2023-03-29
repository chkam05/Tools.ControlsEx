using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;


namespace chkam05.Tools.ControlsEx.Utilities
{
    public static class TextDecorationsHelper
    {

        #region ON COLLECTION MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Add text decoration to decorations collection. </summary>
        /// <param name="collection"> Text decoration collection. </param>
        /// <param name="textDecoration"> Text decoration type. </param>
        /// <returns> Modified text decoration collection. </returns>
        public static TextDecorationCollection AddDecoration(TextDecorationCollection collection, TextDecorationLocation textDecoration)
        {
            if (!HasDecroation(collection, textDecoration))
            {
                TextDecoration decoration = null;

                switch (textDecoration)
                {
                    case TextDecorationLocation.Baseline:
                        decoration = TextDecorations.Baseline[0];
                        break;

                    case TextDecorationLocation.OverLine:
                        decoration = TextDecorations.OverLine[0];
                        break;

                    case TextDecorationLocation.Strikethrough:
                        decoration = TextDecorations.Strikethrough[0];
                        break;

                    case TextDecorationLocation.Underline:
                        decoration = TextDecorations.Underline[0];
                        break;
                }

                if (collection == null)
                    return new TextDecorationCollection(new List<TextDecoration>() { decoration });

                collection.Add(decoration);
            }

            return collection;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Clear text decoration collection. </summary>
        /// <param name="collection"> Text decoration collection. </param>
        /// <returns> Cleared text decoration collection. </returns>
        public static TextDecorationCollection ClearDecorations(TextDecorationCollection collection)
        {
            if (collection != null)
            {
                collection.Clear();
                return collection;
            }

            return new TextDecorationCollection();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get a list of currently applied text decorations in text decorations collection. </summary>
        /// <param name="collection"> Text decoration collection. </param>
        /// <returns> List of currently applied text decoration for selected text. </returns>
        public static List<TextDecorationLocation> GetTextDecorations(TextDecorationCollection collection)
        {
            var result = new List<TextDecorationLocation>();

            if (collection != null)
            {
                foreach (var decoration in collection)
                    result.Add(decoration.Location);
            }

            return result;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Check if particular text decoration is in text decoration collection. </summary>
        /// <param name="collection"> Text decoration collection. </param>
        /// <param name="textDecoration"> Text decoration type. </param>
        /// <returns> True - text decoration is in text decoration collection; False - otherwise. </returns>
        public static bool HasDecroation(TextDecorationCollection collection, TextDecorationLocation textDecoration)
        {
            if (collection != null)
                return collection.Any(td => td.Location == textDecoration);

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Remove text decoration from decorations collection. </summary>
        /// <param name="collection"> Text decoration collection. </param>
        /// <param name="textDecoration"> Text decoration type. </param>
        /// <returns> Modified text decoration collection. </returns>
        public static TextDecorationCollection RemoveDecoration(TextDecorationCollection collection, TextDecorationLocation textDecoration)
        {
            if (collection != null && collection.Any(td => td.Location == textDecoration))
                collection.Remove(collection.First(td => td.Location == textDecoration));

            return collection;
        }

        #endregion ON COLLECTION MANAGEMENT METHODS

        #region ON TEXT RANGE MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Add text decoration to selected text. </summary>
        /// <param name="textRange"> Selected text (text range). </param>
        /// <param name="textDecoration"> Text decoration type. </param>
        /// <returns> True - text decorations added to selected text; False - otherwise. </returns>
        public static bool AddDecoration(TextRange textRange, TextDecorationLocation textDecoration)
        {
            var collection = GetTextDecorationsCollection(textRange) ?? new TextDecorationCollection();

            if (textRange != null)
            {
                TextDecoration decoration = null;

                switch (textDecoration)
                {
                    case TextDecorationLocation.Baseline:
                        decoration = TextDecorations.Baseline[0];
                        break;

                    case TextDecorationLocation.OverLine:
                        decoration = TextDecorations.OverLine[0];
                        break;

                    case TextDecorationLocation.Strikethrough:
                        decoration = TextDecorations.Strikethrough[0];
                        break;

                    case TextDecorationLocation.Underline:
                        decoration = TextDecorations.Underline[0];
                        break;
                }

                if (!HasDecroation(textRange, textDecoration))
                {
                    collection.Add(decoration);
                    UpdateTextDecorationsCollection(textRange, collection);
                    return true;
                }
            }

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Clear text decorations from selected text. </summary>
        /// <param name="textRange"> Selected text (text range). </param>
        /// <returns> True - text decorations removed from selected text; False - otherwise. </returns>
        public static bool ClearDecorations(TextRange textRange)
        {
            var collection = GetTextDecorationsCollection(textRange);

            if (collection != null)
            {
                collection.Clear();
                UpdateTextDecorationsCollection(textRange, collection);
                return true;
            }

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get a list of currently applied text decorations for selected text. </summary>
        /// <param name="textRange"> Selected text (text range). </param>
        /// <returns> List of currently applied text decoration for selected text. </returns>
        public static List<TextDecorationLocation> GetTextDecorations(TextRange textRange)
        {
            var collection = GetTextDecorationsCollection(textRange);
            var result = new List<TextDecorationLocation>();

            if (collection != null)
            {
                foreach (var decoration in collection)
                    result.Add(decoration.Location);
            }

            return result;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Check if particular text decoration is applied to selected text. </summary>
        /// <param name="textRange"> Selected text (text range). </param>
        /// <param name="textDecoration"> Text decoration type. </param>
        /// <returns> True - text decoration is applied to selected text; False - otherwise. </returns>
        public static bool HasDecroation(TextRange textRange, TextDecorationLocation textDecoration)
        {
            var collection = GetTextDecorationsCollection(textRange);

            if (collection != null)
                return collection.Any(td => td.Location == textDecoration);

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Remove text decoration from selected text. </summary>
        /// <param name="textRange"> Selected text (text range). </param>
        /// <param name="textDecoration"> Text decoration type. </param>
        /// <returns> True - text decoration removed; False - otherwise. </returns>
        public static bool RemoveDecoration(TextRange textRange, TextDecorationLocation textDecoration)
        {
            var collection = GetTextDecorationsCollection(textRange);

            if (collection != null && collection.Any(td => td.Location == textDecoration))
            {
                collection.Remove(collection.First(td => td.Location == textDecoration));
                UpdateTextDecorationsCollection(textRange, collection);
                return true;
            }

            return false;
        }

        #endregion ON TEXT RANGE MANAGEMENT METHODS

        #region UTILITY METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Get text decorations collection from selected text. </summary>
        /// <param name="textRange"> Selected text (text range). </param>
        /// <returns> Text decoractions collection. </returns>
        public static TextDecorationCollection GetTextDecorationsCollection(TextRange textRange)
        {
            if (textRange != null)
            {
                var property = textRange.GetPropertyValue(Inline.TextDecorationsProperty);

                if (property != null && property != DependencyProperty.UnsetValue)
                {
                    var textDecorations = property as TextDecorationCollection;
                    return textDecorations;
                }
            }

            return null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Apply a collection of text decorations to the selected text.  </summary>
        /// <param name="textRange"> Selected text (text range). </param>
        /// <param name="collection"> Text decorations collection. </param>
        public static void UpdateTextDecorationsCollection(TextRange textRange, TextDecorationCollection collection)
        {
            textRange.ApplyPropertyValue(Inline.TextDecorationsProperty, collection);
        }

        #endregion UTILITY METHODS

    }
}
