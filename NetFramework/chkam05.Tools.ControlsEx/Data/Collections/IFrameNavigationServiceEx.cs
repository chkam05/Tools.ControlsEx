using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace chkam05.Tools.ControlsEx.Data.Collections
{
    public interface IFrameNavigationServiceEx<T> : IFrameExPagesCollection<T> where T : Page
    {

        //  GETTERS & SETTERS

        bool CanGoBack { get; }
        bool CanGoForward { get; }
        T CurrentPage { get; set; }
        int CurrentPageIndex { get; set; }


        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Adds a new item to the collection. </summary>
        /// <param name="item"> The item to add. </param>
        void AddAndLoad(T item);

        //  --------------------------------------------------------------------------------
        /// <summary> Loads previous page. </summary>
        void GoBack();

        //  --------------------------------------------------------------------------------
        /// <summary> Loads next page. </summary>
        void GoForward();

        //  --------------------------------------------------------------------------------
        /// <summary> Loads the page for display. </summary>
        /// <param name="page"> Page to load. </param>
        void LoadPage(T page);

        //  --------------------------------------------------------------------------------
        /// <summary> Loads the page with the specified index for display. </summary>
        /// <param name="pageIndex"> Index of page to load. </param>
        void LoadPage(int pageIndex);

    }
}
