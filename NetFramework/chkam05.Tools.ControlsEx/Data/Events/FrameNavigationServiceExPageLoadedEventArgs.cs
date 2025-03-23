using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace chkam05.Tools.ControlsEx.Data.Events
{
    public class FrameNavigationServiceExPageLoadedEventArgs<T> : EventArgs where T : Page
    {

        //  VARIABLES

        public T LoadedPage { get; private set; }
        public T UnloadedPage { get; private set; }


        //  METHODS

        #region  CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> FrameNavigationServiceExPageLoadedEventArgs class constructor. </summary>
        /// <param name="loadedPage"> Loaded page. </param>
        /// <param name="unloadedPage"> Unloaded page. </param>
        public FrameNavigationServiceExPageLoadedEventArgs(T loadedPage, T unloadedPage) : base()
        {
            LoadedPage = loadedPage;
            UnloadedPage = unloadedPage;
        }

        #endregion CONSTURCTORS

    }
}
