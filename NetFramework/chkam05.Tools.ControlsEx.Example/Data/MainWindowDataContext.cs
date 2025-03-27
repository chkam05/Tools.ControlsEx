using chkam05.Tools.ControlsEx.Data.Collections;
using chkam05.Tools.ControlsEx.Data.Enums;
using chkam05.Tools.ControlsEx.Example.Pages;
using chkam05.Tools.ControlsEx.Example.Utilities;
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
        private FrameNavigationServiceEx<Page> navigationService;


        //  GETTERS & SETTERS

        public HamburgerMenuExCollection HamburgerMenuExCollection
        {
            get => hamburgerMenuExItemsCollection;
            set => UpdateProperty(ref hamburgerMenuExItemsCollection, value);
        }

        public FrameNavigationServiceEx<Page> NavigationService
        {
            get => navigationService;
            set => UpdateProperty(ref navigationService, value);
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
        /// <summary> Back HamburgerMenuEx item action method. </summary>
        private void BackHamburgerMenuExItemAction()
        {
            if (navigationService.CanGoBack)
            {
                navigationService.GoBack();
                RemoveForwardPages();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Components HamburgerMenuEx item action method. </summary>
        private void ComponentsHamburgerMenuExItemAction()
        {
            var componentsPage = GetPageByType(typeof(ComponentsPage));

            if (componentsPage != null)
                navigationService.LoadPage(componentsPage);
            else
                navigationService.AddAndLoad(new ComponentsPage(NavigationService));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Settings HamburgerMenuEx item action method. </summary>
        private void SettingsHamburgerMenuExItemAction()
        {
            var settingsPage = GetPageByType(typeof(SettingsPage));

            if (settingsPage != null)
                navigationService.LoadPage(settingsPage);
            else
                navigationService.AddAndLoad(new SettingsPage());
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Info HamburgerMenuEx item action method. </summary>
        private void InfoHamburgerMenuExItemAction()
        {
            var infoPage = GetPageByType(typeof(InfoPage));

            if (infoPage != null)
                navigationService.LoadPage(infoPage);
            else
                navigationService.AddAndLoad(new InfoPage());
        }

        #endregion ACTIONS

        #region PAGES MANAGEMENT

        //  --------------------------------------------------------------------------------
        private Page GetPageByType(Type pageType)
        {
            return navigationService.FirstOrDefault(p => p.GetType() == pageType);
        }

        //  --------------------------------------------------------------------------------
        private void RemoveForwardPages()
        {
            var currentIndex = navigationService.CurrentPageIndex;

            for (int i = navigationService.Count - 1; i > currentIndex; i--)
                navigationService.RemoveAt(i);
        }

        #endregion PAGES MANAGEMENT

        #region SETUP

        //  --------------------------------------------------------------------------------
        /// <summary> Setup HamburgerMenuEx items collection. </summary>
        private void SetupHamburgerMenuExCollection()
        {
            HamburgerMenuExCollection = new HamburgerMenuExCollection()
            {
                new HamburgerMenuExItem("Back", "Go to previous page", PackIconKind.ArrowLeft,
                    BackHamburgerMenuExItemAction),
                new HamburgerMenuExItem("Components", "Component testing", PackIconKind.CubeOutline,
                    ComponentsHamburgerMenuExItemAction),
                new HamburgerMenuExItem("Settings", "Application settings.", PackIconKind.GearOutline,
                    SettingsHamburgerMenuExItemAction, HamburgerMenuExItemPosition.Bottom),
                new HamburgerMenuExItem("Info", "Application information.", PackIconKind.InfoCircleOutline,
                    InfoHamburgerMenuExItemAction, HamburgerMenuExItemPosition.Bottom)
            };
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Setup pages collection. </summary>
        private void SetupPagesCollection()
        {
            navigationService = new FrameNavigationServiceEx<Page>()
            {
                new InfoPage()
            };

            navigationService.LoadPage(0);
        }

        #endregion SETUP

    }
}
