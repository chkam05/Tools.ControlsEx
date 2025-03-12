using chkam05.Tools.ControlsEx.Data.Collections;
using chkam05.Tools.ControlsEx.Data.Enums;
using chkam05.Tools.ControlsEx.Example.Pages;
using chkam05.Tools.ControlsEx.Interfaces;
using chkam05.Tools.ControlsEx.ViewModels;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace chkam05.Tools.ControlsEx.Example.Data
{
    public class MainWindowDataContext : BaseViewModel
    {

        //  VARIABLES

        private HamburgerMenuExCollection hamburgerMenuExItemsCollection;
        private FrameExPagesCollection<Page> pagesCollection;
        private IFrameEx<Page> pagesNavigationContainer;


        //  GETTERS & SETTERS

        public HamburgerMenuExCollection HamburgerMenuExCollection
        {
            get => hamburgerMenuExItemsCollection;
            set => UpdateProperty(ref hamburgerMenuExItemsCollection, value);
        }

        public FrameExPagesCollection<Page> PagesCollection
        {
            get => pagesCollection;
            set => UpdateProperty(ref pagesCollection, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> MainWindowDataContext class constructor. </summary>
        public MainWindowDataContext()
        {
            SetupHamburgerMenuExCollection();
            SetupPagesCollection();
        }

        #endregion CONSTRUCTORS

        #region ACTIONS

        //  --------------------------------------------------------------------------------
        private void BackHamburgerMenuExItemAction()
        {
            if (pagesNavigationContainer.CanGoBack)
            {
                pagesNavigationContainer.GoBack();
                RemoveForwardPages();
            }
        }

        //  --------------------------------------------------------------------------------
        private void ComponentsHamburgerMenuExItemAction()
        {
            var componentsPage = GetPageByType(typeof(ComponentsPage));

            if (componentsPage != null)
                pagesNavigationContainer.GoToPage(componentsPage);
            else
                pagesNavigationContainer.LoadPage(new ComponentsPage());
        }

        //  --------------------------------------------------------------------------------
        private void SettingsHamburgerMenuExItemAction()
        {
            var settingsPage = GetPageByType(typeof(SettingsPage));

            if (settingsPage != null)
                pagesNavigationContainer.GoToPage(settingsPage);
            else
                pagesNavigationContainer.LoadPage(new SettingsPage());
        }

        //  --------------------------------------------------------------------------------
        private void InfoHamburgerMenuExItemAction()
        {
            var infoPage = GetPageByType(typeof(InfoPage));

            if (infoPage != null)
                pagesNavigationContainer.GoToPage(infoPage);
            else
                pagesNavigationContainer.LoadPage(new InfoPage());
        }

        #endregion ACTIONS

        #region PAGES MANAGEMENT

        //  --------------------------------------------------------------------------------
        private Page GetPageByType(Type pageType)
        {
            return pagesCollection.FirstOrDefault(p => p.GetType() == pageType);
        }

        //  --------------------------------------------------------------------------------
        private void RemoveForwardPages()
        {
            var currentIndex = pagesNavigationContainer.CurrentPageIndex;

            for (int i = pagesCollection.Count - 1; i > currentIndex; i--)
                pagesCollection.RemoveAt(i);
        }

        #endregion PAGES MANAGEMENT

        #region SETUP

        //  --------------------------------------------------------------------------------
        public void AssignPagesNavigationContainer(IFrameEx<Page> pagesNavigationContainer)
        {
            this.pagesNavigationContainer = pagesNavigationContainer;
            this.pagesNavigationContainer.GoToPage(0);
        }

        //  --------------------------------------------------------------------------------
        private void SetupHamburgerMenuExCollection()
        {
            HamburgerMenuExCollection = new HamburgerMenuExCollection()
            {
                new HamburgerMenuExItem("Components", "Component testing", PackIconKind.CubeOutline,
                    ComponentsHamburgerMenuExItemAction),
                new HamburgerMenuExItem("Settings", "Application settings.", PackIconKind.GearOutline,
                    SettingsHamburgerMenuExItemAction, HamburgerMenuExItemPosition.Bottom),
                new HamburgerMenuExItem("Info", "Application information.", PackIconKind.InfoCircleOutline,
                    InfoHamburgerMenuExItemAction, HamburgerMenuExItemPosition.Bottom)
            };

            var backItem = HamburgerMenuExCollection.GetBackItem();

            if (backItem != null)
                backItem.Action += BackHamburgerMenuExItemAction;
        }

        //  --------------------------------------------------------------------------------
        private void SetupPagesCollection()
        {
            pagesCollection = new FrameExPagesCollection<Page>()
            {
                new InfoPage()
            };
        }

        #endregion SETUP

    }
}
