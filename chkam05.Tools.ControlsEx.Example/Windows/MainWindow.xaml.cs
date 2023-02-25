using chkam05.Tools.ControlsEx.Example.Data.Config;
using chkam05.Tools.ControlsEx.Example.Data.Menu;
using chkam05.Tools.ControlsEx.Example.Pages;
using chkam05.Tools.ControlsEx.Example.Pages.Base;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

using MenuItem = chkam05.Tools.ControlsEx.Example.Data.Menu.MenuItem;


namespace chkam05.Tools.ControlsEx.Example.Windows
{
    public partial class MainWindow : Window
    {

        //  CONST

        private const string MAINMENU_BUTTONS_ITEM = "Buttons";
        private const string MAINMENU_CHECKBOXS_ITEM = "CheckBoxes";
        private const string MAINMENU_COLORSPALETTE_ITEM = "ColorsPalette";
        private const string MAINMENU_COMBOBOXS_ITEM = "ComboBoxes";
        private const string MAINMENU_CONTEXTMENUS_ITEM = "ContextMenus";
        private const string MAINMENU_EXPANDERS_ITEM = "Expanders";
        private const string MAINMENU_INDICATORS_ITEM = "Indicators";
        private const string MAINMENU_INTERNALMESSAGES_ITEM = "Internal Messages";
        private const string MAINMENU_LISTVIEWS_ITEM = "ListViews";
        private const string MAINMENU_SLIDERS_ITEM = "Sliders";
        private const string MAINMENU_SWITCHERS_ITEM = "Switchers";
        private const string MAINMENU_TABCONTROLS_ITEM = "TabControls";
        private const string MAINMENU_TEXTBLOCKS_ITEM = "TextBlocks";
        private const string MAINMENU_TEXTBOXES_ITEM = "TextBoxes";
        private const string MAINMENU_TREEVIEWS_ITEM = "TreeView";
        private const string MAINMENU_UPDOWNTEXTBOXES_ITEM = "UpDownTextBoxes";
        private const string MAINMENU_WINDOWS_ITEM = "Windows";


        //  VARIABLES

        public Configuration Configuration { get; private set; }
        public MenuDataContext MenuDataContext { get; private set; }
        public PagesManager PagesManager { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> MainWindow class constructor. </summary>
        public MainWindow()
        {
            //  Setup data containers.
            Configuration = Configuration.Instance;
            SetupMainMenu();

            //  Initialize interface components.
            InitializeComponent();

            //  Setup modules related with UI.
            PagesManager = new PagesManager(ContentFrame);
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking settings button. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void SettingsButtonEx_Click(object sender, RoutedEventArgs e)
        {
            PagesManager.LoadSinglePage(new SettingsPage());
            MainMenu.SelectedItem = null;
        }
        
        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking about button. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void AboutButtonEx_Click(object sender, RoutedEventArgs e)
        {
            PagesManager.LoadSinglePage(new InfoPage());
            MainMenu.SelectedItem = null;
        }

        #endregion INTERACTION METHODS

        #region MAIN MENU METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after selecting item in MainMenu ListViewEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Selection Changed Event Arguments. </param>
        private void MainMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView = (ListViewEx)sender;
            var selectedItem = listView.SelectedItem;

            if (selectedItem != null)
            {
                var menuItem = (MenuItem)selectedItem;

                if (menuItem != null)
                    switch (menuItem.Name)
                    {
                        case MAINMENU_BUTTONS_ITEM:
                            PagesManager.LoadSinglePage(new ButtonsPage());
                            break;

                        case MAINMENU_CHECKBOXS_ITEM:
                            PagesManager.LoadSinglePage(new CheckBoxesPage());
                            break;

                        case MAINMENU_COLORSPALETTE_ITEM:
                            PagesManager.LoadSinglePage(new ColorsPalettePage());
                            break;

                        case MAINMENU_COMBOBOXS_ITEM:
                            PagesManager.LoadSinglePage(new ComboBoxesPage());
                            break;

                        case MAINMENU_CONTEXTMENUS_ITEM:
                            PagesManager.LoadSinglePage(new ContextMenusPage());
                            break;

                        case MAINMENU_EXPANDERS_ITEM:
                            PagesManager.LoadSinglePage(new ExpandersPage());
                            break;

                        case MAINMENU_INDICATORS_ITEM:
                            PagesManager.LoadSinglePage(new IndicatorsPage());
                            break;

                        case MAINMENU_INTERNALMESSAGES_ITEM:
                            PagesManager.LoadSinglePage(new InternalMessagesPage());
                            break;

                        case MAINMENU_LISTVIEWS_ITEM:
                            PagesManager.LoadSinglePage(new ListViewsPage());
                            break;

                        case MAINMENU_SLIDERS_ITEM:
                            PagesManager.LoadSinglePage(new SlidersPage());
                            break;

                        case MAINMENU_SWITCHERS_ITEM:
                            PagesManager.LoadSinglePage(new SwitchersPage());
                            break;

                        case MAINMENU_TABCONTROLS_ITEM:
                            PagesManager.LoadSinglePage(new TabControlsPage());
                            break;

                        case MAINMENU_TEXTBLOCKS_ITEM:
                            PagesManager.LoadSinglePage(new TextBlocksPage());
                            break;

                        case MAINMENU_TEXTBOXES_ITEM:
                            PagesManager.LoadSinglePage(new TextBoxesPage());
                            break;

                        case MAINMENU_TREEVIEWS_ITEM:
                            PagesManager.LoadSinglePage(new TreesPage());
                            break;

                        case MAINMENU_UPDOWNTEXTBOXES_ITEM:
                            PagesManager.LoadSinglePage(new UpDownTextBoxesPage());
                            break;

                        case MAINMENU_WINDOWS_ITEM:
                            PagesManager.LoadSinglePage(new WindowsPage());
                            break;
                    }

                //listView.SelectedItem = null;
            }
        }

        #endregion MAIN MENU METHODS

        #region SETUP METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Setup application MainMenu. </summary>
        private void SetupMainMenu()
        {
            MenuDataContext = new MenuDataContext(new List<MenuItem>()
            {
                new MenuItem(MAINMENU_BUTTONS_ITEM, PackIconKind.Button),
                new MenuItem(MAINMENU_CHECKBOXS_ITEM, PackIconKind.CheckboxesMarkedOutline),
                new MenuItem(MAINMENU_COLORSPALETTE_ITEM, PackIconKind.Palette),
                new MenuItem(MAINMENU_COMBOBOXS_ITEM, PackIconKind.ChevronDoubleDown),
                new MenuItem(MAINMENU_CONTEXTMENUS_ITEM, PackIconKind.MenuOpen),
                new MenuItem(MAINMENU_EXPANDERS_ITEM, PackIconKind.ArrowExpandDown),
                new MenuItem(MAINMENU_INDICATORS_ITEM, PackIconKind.Loading),
                new MenuItem(MAINMENU_INTERNALMESSAGES_ITEM, PackIconKind.Application),
                new MenuItem(MAINMENU_LISTVIEWS_ITEM, PackIconKind.ViewList),
                new MenuItem(MAINMENU_SLIDERS_ITEM, PackIconKind.Equaliser),
                new MenuItem(MAINMENU_SWITCHERS_ITEM, PackIconKind.ToggleSwitchOff),
                new MenuItem(MAINMENU_TABCONTROLS_ITEM, PackIconKind.Tab),
                new MenuItem(MAINMENU_TEXTBLOCKS_ITEM, PackIconKind.Text),
                new MenuItem(MAINMENU_TEXTBOXES_ITEM, PackIconKind.TextBox),
                new MenuItem(MAINMENU_TREEVIEWS_ITEM, PackIconKind.Tree),
                new MenuItem(MAINMENU_UPDOWNTEXTBOXES_ITEM, PackIconKind.ChevronUpDown),
                new MenuItem(MAINMENU_WINDOWS_ITEM, PackIconKind.ApplicationOutline),
            });
        }

        #endregion SETUP METHODS

        #region WINDOW METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked when window is closing. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Event Arguments. </param>
        private void Window_Closed(object sender, EventArgs e)
        {
            Configuration.WindowLocation = new Point(Left, Top);
            Configuration.WindowSize = new Size(Width, Height);

            Configuration.SaveConfiguration();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked when window is loading. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PagesManager.LoadSinglePage(new InfoPage());

            Left = Configuration.WindowLocation.X;
            Top = Configuration.WindowLocation.Y;
            Height = Configuration.WindowSize.Height;
            Width = Configuration.WindowSize.Width;
        }

        #endregion WINDOW METHODS

    }
}
