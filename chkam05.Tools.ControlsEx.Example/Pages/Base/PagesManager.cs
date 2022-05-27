using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace chkam05.Tools.ControlsEx.Example.Pages.Base
{
    public class PagesManager
    {

        //  VARIABLES

        private Frame _contentFrame;
        private List<Page> _pages;


        //  GETTERS & SETTERS

        public bool CanGoBack
        {
            get => _pages.Any() && LoadedPageIndex > 0;
        }

        public Page LoadedPage
        {
            get => _contentFrame.Content as Page;
        }

        public int LoadedPageIndex
        {
            get => LoadedPage != null ? _pages.IndexOf(LoadedPage) : -1;
        }

        public int PagesCount
        {
            get => _pages.Count;
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> PagesManager class constructor. </summary>
        /// <param name="frame"> Frame where the pages will be loaded. </param>
        public PagesManager(Frame frame)
        {
            _contentFrame = frame;
            _pages = new List<Page>();
        }

        #endregion CLASS METHODS

        #region FRAME METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Remove all loaded frames from PagesManager and ContentFrame. </summary>
        private void ClearPages()
        {
            RemoveBackEntry();

            _contentFrame.Content = null;
            _pages.Clear();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Metod invoked after loading page to the ContentFrame. </summary>
        /// <param name="sender"> Object that invoked event. </param>
        /// <param name="e"> Navigated Event Arguments. </param>
        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            //  Remove previous pages from content frame back entry.
            RemoveBackEntry();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Remove previous pages from ContentFrame back entry. </summary>
        private void RemoveBackEntry()
        {
            //  Get previous pages from ContentFrame navigation service.
            var backEntry = _contentFrame.NavigationService.RemoveBackEntry();

            //  While previous pages are available - try to remove it.
            while (backEntry != null)
                backEntry = _contentFrame.NavigationService.RemoveBackEntry();
        }

        #endregion FRAME METHODS

        #region NAVIGATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Load previously loaded page to ContentFrame. </summary>
        public void GoBack()
        {
            if (CanGoBack)
            {
                var loadedPageIndex = LoadedPageIndex;

                //  Get previous page from list to load into ContentFrame.
                var previousPage = _pages[loadedPageIndex - 1];

                //  Remove other pages loaded further.
                _pages.RemoveRange(loadedPageIndex, PagesCount - (loadedPageIndex));

                //  Load previous page to ContentFrame.
                _contentFrame.Navigate(previousPage);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Load newly created page to ContentFrame. </summary>
        /// <param name="page"> Page to load. </param>
        public void LoadPage(Page page)
        {
            if (page != null)
            {
                _pages.Add(page);
                _contentFrame.Navigate(page);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Load newly created page to ContentFrame as single page removing previously loaded. </summary>
        /// <param name="page"> Page to load. </param>
        public void LoadSinglePage(Page page)
        {
            if (page != null)
            {
                ClearPages();

                _pages.Add(page);
                _contentFrame.Navigate(page);
            }
        }

        #endregion NAVIGATION METHODS

    }
}
