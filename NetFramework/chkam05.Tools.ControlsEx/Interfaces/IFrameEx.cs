using chkam05.Tools.ControlsEx.Data.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace chkam05.Tools.ControlsEx.Interfaces
{
    public interface IFrameEx<T> where T : Page
    {

        //  GETTERS & SETTERS

        bool CanGoBack { get; }
        bool CanGoForward { get; }
        T CurrentPage { get; set; }
        int CurrentPageIndex { get; set; }
        FrameExPagesCollection<T> Pages { get; set; }
        int PagesCount { get; }


        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Loads previous page. </summary>
        void GoBack();

        //  --------------------------------------------------------------------------------
        /// <summary> Loads next page. </summary>
        void GoForward();

        //  --------------------------------------------------------------------------------
        /// <summary> Go to current loaded page. </summary>
        /// <param name="page"> Page (from pages collection) to load. </param>
        void GoToPage(T page);

        //  --------------------------------------------------------------------------------
        /// <summary> Loads page at particular index in pages collection. </summary>
        /// <param name="pageIndex"> Index of page in pages collection. </param>
        void GoToPage(int pageIndex);

        //  --------------------------------------------------------------------------------
        /// <summary> Adds new page to pages collection navigates to it. </summary>
        /// <param name="page"> Page to add and load. </param>
        void LoadPage(T page);

    }
}
