using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Data
{
    public class InternalMessageFileType
    {

        //  VARIABLES

        public string Title { get; set; }
        public string[] Extensions { get; set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> InternalMessageFileType class constructor. </summary>
        /// <param name="title"> File type/group title. </param>
        /// <param name="extensions"> Array of files extensions. </param>
        public InternalMessageFileType(string title, string[] extensions)
        {
            Title = title;

            if (extensions != null && extensions.Any())
                Extensions = extensions.Where(e => e.StartsWith("*.")).ToArray();
        }

        #endregion CLASS METHODS

        #region PRESET INSTANCES

        //  --------------------------------------------------------------------------------
        /// <summary> Preset InternalMessageFileType class constructor for all files. </summary>
        /// <param name="title"> Overwritable file type/group title. </param>
        /// <returns> InternalMessageFileType class instance for all files. </returns>
        public static InternalMessageFileType AllFiles(string title = "All Files") 
            => new InternalMessageFileType(title, new string[] { "*.*" });

        //  --------------------------------------------------------------------------------
        /// <summary> Preset InternalMessageFileType class constructor for image files. </summary>
        /// <param name="title"> Overwritable file type/group title. </param>
        /// <returns> InternalMessageFileType class instance for image files. </returns>
        public static InternalMessageFileType ImageFiles(string title = "Image Files")
            => new InternalMessageFileType(title, new string[] { "*.bmp", "*.gif", "*.jpg", "*.jpeg", "*.png", "*.tiff" });

        //  --------------------------------------------------------------------------------
        /// <summary> Preset InternalMessageFileType class constructor for text files. </summary>
        /// <param name="title"> Overwritable file type/group title. </param>
        /// <returns> InternalMessageFileType class instance for text files. </returns>
        public static InternalMessageFileType TextFiles(string title = "Text Files")
            => new InternalMessageFileType(title, new string[] { "*.txt" });

        #endregion PRESET INSTANCES

        #region CHECK METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Check if file extension match file type extensions. </summary>
        /// <param name="fileName"> File name. </param>
        /// <returns> True - file extension matches; False - otherwise. </returns>
        public bool MatchFile(string fileName)
        {
            if (Extensions == null || Extensions.Length == 0)
                return false;

            if (Extensions.Contains("*.*"))
                return true;

            var extension = Path.GetExtension(fileName);

            if (!string.IsNullOrEmpty(extension))
                return Extensions.Any(e => e.Replace("*", "").ToLower() == extension.ToLower());

            return false;
        }

        #endregion CHECK METHODS

        #region GLOBAL METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Returns a string that represents the current object. </summary>
        /// <returns> A string that represents the current object. </returns>
        public override string ToString()
        {
            return $"{Title} [{string.Join("; ", Extensions)}]";
        }

        #endregion GLOBAL METHODS

    }
}
