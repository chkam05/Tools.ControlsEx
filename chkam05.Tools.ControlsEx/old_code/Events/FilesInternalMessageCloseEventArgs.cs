using chkam05.Tools.ControlsEx.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Events
{
    public class FilesInternalMessageCloseEventArgs : InternalMessageCloseEventArgs
    {

        //  VARIABLES

        public string FilePath { get; private set; }
        public string[] FilesPaths { get; private set; }


        //  GETTERS & SETTERS

        public bool HasMultipleFiles
        {
            get => FilesPaths != null && FilesPaths.Length > 1;
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> FilesInternalMessageCloseEventArgs class constructor. </summary>
        /// <param name="result"> InternalMessageResult. </param>
        /// <param name="filesPaths"> Selected files paths. </param>
        public FilesInternalMessageCloseEventArgs(InternalMessageResult result, string[] filesPaths) : base(result)
        {
            if (filesPaths != null && filesPaths.Any())
            {
                FilePath = filesPaths[0];
                FilesPaths = filesPaths;
            }
        }

        #endregion CLASS METHODS

    }
}
