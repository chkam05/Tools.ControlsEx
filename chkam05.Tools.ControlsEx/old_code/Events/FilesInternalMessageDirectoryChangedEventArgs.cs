using chkam05.Tools.ControlsEx.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Events
{
    public class FilesInternalMessageDirectoryChangedEventArgs : EventArgs
    {

        //  VARIABLES

        public FilesInternalMessageDirectoryChangeMethod Method { get; private set; }
        public string NewPath { get; private set; }
        public string OldPath { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> FilesInternalMessageDirectoryChangedEventArgs class constructor. </summary>
        /// <param name="method"> Directory change method. </param>
        /// <param name="newPath"> New path that will be current path. </param>
        /// <param name="oldPath"> Old, previous path. </param>
        public FilesInternalMessageDirectoryChangedEventArgs(FilesInternalMessageDirectoryChangeMethod method, string newPath, string oldPath)
        {
            Method = method;
            NewPath = newPath;
            OldPath = oldPath;
        }

        #endregion CLASS METHODS

    }
}
