using chkam05.Tools.ControlsEx.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Events
{
    public class FilesSelectorInternalMessageCloseEventArgs : InternalMessageCloseEventArgs
    {

        //  VARIABLES

        public string[] FilesPaths { get; private set; }


        //  GETTERS & SETTERS

        public string FilePath
        {
            get => FilesPaths?[0] ?? null;
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> FilesSelectorInternalMessageCloseEventArgs class constructor. </summary>
        /// <param name="result"> Result. </param>
        /// <param name="filesPaths"> Array of selected files. </param>
        public FilesSelectorInternalMessageCloseEventArgs(InternalMessageResult result, string[] filesPaths) : base(result)
        {
            FilesPaths = filesPaths;
        }

        #endregion CLASS METHODS

    }
}
