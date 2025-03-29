using chkam05.Tools.ControlsEx.Data.Collections;
using chkam05.Tools.ControlsEx.Example.Commands;
using chkam05.Tools.ControlsEx.Example.Pages;
using chkam05.Tools.ControlsEx.Example.Pages.Components;
using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace chkam05.Tools.ControlsEx.Example.Data
{
    public class ComponentsPageDataContext : BaseViewModel
    {

        //  VARIABLES

        private IFrameNavigationServiceEx<Page> navigationService;
        private ICommand buttonExButtonCommand;
        private ICommand buttonExWithIconButtonCommand;
        private ICommand calendarExButtonCommand;
        private ICommand checkBoxExButtonCommand;
        private ICommand colorPaletteExButtonCommand;
        private ICommand colorPickerExButtonCommand;
        private ICommand comboBoxExButtonCommand;
        private ICommand contextMenuExButtonCommand;
        private ICommand datePickerExButtonCommand;
        private ICommand directoryViewerExAndFileViewerExButtonCommand;
        private ICommand expanderExButtonCommand;
        private ICommand groupBoxButtonCommand;
        private ICommand hamburgerMenuExButtonCommand;
        private ICommand listBoxExButtonCommand;
        private ICommand listViewExButtonCommand;
        private ICommand gridViewExButtonCommand;
        private ICommand menuExButtonCommand;
        private ICommand progressBarExButtonCommand;
        private ICommand radioButtonExButtonCommand;
        private ICommand repeatButtonExButtonCommand;
        private ICommand richTextBoxExButtonCommand;
        private ICommand scrollBarExButtonCommand;
        private ICommand sliderExButtonCommand;
        private ICommand tabControlExButtonCommand;
        private ICommand textBoxExButtonCommand;
        private ICommand toggleButtonExButtonCommand;
        private ICommand toggleExButtonCommand;
        private ICommand treeViewExButtonCommand;
        private ICommand upDownDoubleExButtonCommand;
        private ICommand upDownLongExButtonCommand;
        private ICommand wideViewButtonExButtonCommand;
        private ICommand windowExButtonCommand;
        private ICommand windowTitleBarExButtonCommand;


        //  GETTERS & SETTERS

        public ICommand ButtonExButtonCommand
        {
            get => buttonExButtonCommand;
            set => UpdateProperty(ref buttonExButtonCommand, value);
        }

        public ICommand ButtonExWithIconButtonCommand
        {
            get => buttonExWithIconButtonCommand;
            set => UpdateProperty(ref buttonExWithIconButtonCommand, value);
        }

        public ICommand CalendarExButtonCommand
        {
            get => calendarExButtonCommand;
            set => UpdateProperty(ref calendarExButtonCommand, value);
        }

        public ICommand CheckBoxExButtonCommand
        {
            get => checkBoxExButtonCommand;
            set => UpdateProperty(ref checkBoxExButtonCommand, value);
        }

        public ICommand ColorPaletteExButtonCommand
        {
            get => colorPaletteExButtonCommand;
            set => UpdateProperty(ref colorPaletteExButtonCommand, value);
        }

        public ICommand ColorPickerExButtonCommand
        {
            get => colorPickerExButtonCommand;
            set => UpdateProperty(ref colorPickerExButtonCommand, value);
        }

        public ICommand ComboBoxExButtonCommand
        {
            get => comboBoxExButtonCommand;
            set => UpdateProperty(ref comboBoxExButtonCommand, value);
        }

        public ICommand ContextMenuExButtonCommand
        {
            get => contextMenuExButtonCommand;
            set => UpdateProperty(ref contextMenuExButtonCommand, value);
        }

        public ICommand DatePickerExButtonCommand
        {
            get => datePickerExButtonCommand;
            set => UpdateProperty(ref datePickerExButtonCommand, value);
        }

        public ICommand DirectoryViewerExAndFileViewerExButtonCommand
        {
            get => directoryViewerExAndFileViewerExButtonCommand;
            set => UpdateProperty(ref directoryViewerExAndFileViewerExButtonCommand, value);
        }

        public ICommand ExpanderExButtonCommand
        {
            get => expanderExButtonCommand;
            set => UpdateProperty(ref expanderExButtonCommand, value);
        }

        public ICommand GroupBoxButtonCommand
        {
            get => groupBoxButtonCommand;
            set => UpdateProperty(ref groupBoxButtonCommand, value);
        }

        public ICommand HamburgerMenuExButtonCommand
        {
            get => hamburgerMenuExButtonCommand;
            set => UpdateProperty(ref hamburgerMenuExButtonCommand, value);
        }

        public ICommand ListBoxExButtonCommand
        {
            get => listBoxExButtonCommand;
            set => UpdateProperty(ref listBoxExButtonCommand, value);
        }

        public ICommand ListViewExButtonCommand
        {
            get => listViewExButtonCommand;
            set => UpdateProperty(ref listViewExButtonCommand, value);
        }

        public ICommand GridViewExButtonCommand
        {
            get => gridViewExButtonCommand;
            set => UpdateProperty(ref gridViewExButtonCommand, value);
        }

        public ICommand MenuExButtonCommand
        {
            get => menuExButtonCommand;
            set => UpdateProperty(ref menuExButtonCommand, value);
        }

        public ICommand ProgressBarExButtonCommand
        {
            get => progressBarExButtonCommand;
            set => UpdateProperty(ref progressBarExButtonCommand, value);
        }

        public ICommand RadioButtonExButtonCommand
        {
            get => radioButtonExButtonCommand;
            set => UpdateProperty(ref radioButtonExButtonCommand, value);
        }

        public ICommand RepeatButtonExButtonCommand
        {
            get => repeatButtonExButtonCommand;
            set => UpdateProperty(ref repeatButtonExButtonCommand, value);
        }

        public ICommand RichTextBoxExButtonCommand
        {
            get => richTextBoxExButtonCommand;
            set => UpdateProperty(ref richTextBoxExButtonCommand, value);
        }

        public ICommand ScrollBarExButtonCommand
        {
            get => scrollBarExButtonCommand;
            set => UpdateProperty(ref scrollBarExButtonCommand, value);
        }

        public ICommand SliderExButtonCommand
        {
            get => sliderExButtonCommand;
            set => UpdateProperty(ref sliderExButtonCommand, value);
        }

        public ICommand TabControlExButtonCommand
        {
            get => tabControlExButtonCommand;
            set => UpdateProperty(ref tabControlExButtonCommand, value);
        }

        public ICommand TextBoxExButtonCommand
        {
            get => textBoxExButtonCommand;
            set => UpdateProperty(ref textBoxExButtonCommand, value);
        }

        public ICommand ToggleButtonExButtonCommand
        {
            get => toggleButtonExButtonCommand;
            set => UpdateProperty(ref toggleButtonExButtonCommand, value);
        }

        public ICommand ToggleExButtonCommand
        {
            get => toggleExButtonCommand;
            set => UpdateProperty(ref toggleExButtonCommand, value);
        }

        public ICommand TreeViewExButtonCommand
        {
            get => treeViewExButtonCommand;
            set => UpdateProperty(ref treeViewExButtonCommand, value);
        }

        public ICommand UpDownDoubleExButtonCommand
        {
            get => upDownDoubleExButtonCommand;
            set => UpdateProperty(ref upDownDoubleExButtonCommand, value);
        }

        public ICommand UpDownLongExButtonCommand
        {
            get => upDownLongExButtonCommand;
            set => UpdateProperty(ref upDownLongExButtonCommand, value);
        }

        public ICommand WideViewButtonExButtonCommand
        {
            get => wideViewButtonExButtonCommand;
            set => UpdateProperty(ref wideViewButtonExButtonCommand, value);
        }

        public ICommand WindowExButtonCommand
        {
            get => windowExButtonCommand;
            set => UpdateProperty(ref windowExButtonCommand, value);
        }

        public ICommand WindowTitleBarExButtonCommand
        {
            get => windowTitleBarExButtonCommand;
            set => UpdateProperty(ref windowTitleBarExButtonCommand, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ComponentsPageDataContext class constructor. </summary>
        /// <param name="navigationService"> FrameEx Pages navigation service. </param>
        public ComponentsPageDataContext(IFrameNavigationServiceEx<Page> navigationService)
        {
            this.navigationService = navigationService;
            SetupCommands();
        }

        #endregion CONSTRUCTORS

        #region COMMANDS

        //  --------------------------------------------------------------------------------
        /// <summary> ButtonEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void ButtonExButtonCommandAction(object obj)
        {
            var componentsPage = GetPageByType(typeof(ButtonExComponentPage));

            if (componentsPage != null)
                navigationService.LoadPage(componentsPage);
            else
                navigationService.AddAndLoad(new ButtonExComponentPage());
        }

        //  --------------------------------------------------------------------------------
        /// <summary> ButtonExWithIcon Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void ButtonExWithIconButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> CalendarEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void CalendarExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> CheckBoxEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void CheckBoxExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> ColorPaletteEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void ColorPaletteExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> ColorPickerEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void ColorPickerExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> ComboBoxEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void ComboBoxExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> ContextMenuEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void ContextMenuExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> DatePickerEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void DatePickerExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> DirectoryViewerEx and FileViewerEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void DirectoryViewerExAndFileViewerExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> ExpanderEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void ExpanderExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> GroupBox Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void GroupBoxButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> HamburgerMenuEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void HamburgerMenuExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> ListBoxEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void ListBoxExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> ListViewEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void ListViewExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> GridViewEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void GridViewExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> MenuEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void MenuExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> ProgressBarEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void ProgressBarExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> RadioButtonEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void RadioButtonExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> RepeatButtonEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void RepeatButtonExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> RichTextBoxEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void RichTextBoxExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> ScrollBarEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void ScrollBarExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> SliderEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void SliderExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> TabControlEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void TabControlExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> TextBoxEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void TextBoxExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> ToggleButtonEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void ToggleButtonExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> ToggleEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void ToggleExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> TreeViewEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void TreeViewExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> UpDownDoubleEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void UpDownDoubleExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> UpDownLongEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void UpDownLongExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> WideViewButtonEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void WideViewButtonExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> WindowEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void WindowExButtonCommandAction(object obj)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> WindowTitleBarEx Button command action method. </summary>
        /// <param name="obj"> Command action parameter. </param>
        private void WindowTitleBarExButtonCommandAction(object obj)
        {
            //
        }

        #endregion COMMANDS

        #region PAGES MANAGEMENT

        //  --------------------------------------------------------------------------------
        /// <summary> Get loaded page by type. </summary>
        /// <param name="pageType"> Page type to get. </param>
        /// <returns> Loaded page with specified type or null. </returns>
        private Page GetPageByType(Type pageType)
        {
            return (navigationService as FrameNavigationServiceEx<Page>)?.FirstOrDefault(p => p.GetType() == pageType);
        }

        #endregion PAGES MANAGEMENT

        #region SETUP

        //  --------------------------------------------------------------------------------
        /// <summary> Setup commands. </summary>
        private void SetupCommands()
        {
            ButtonExButtonCommand = new RelayCommand(ButtonExButtonCommandAction);
            ButtonExWithIconButtonCommand = new RelayCommand(ButtonExWithIconButtonCommandAction);
            CalendarExButtonCommand = new RelayCommand(CalendarExButtonCommandAction);
            CheckBoxExButtonCommand = new RelayCommand(CheckBoxExButtonCommandAction);
            ColorPaletteExButtonCommand = new RelayCommand(ColorPaletteExButtonCommandAction);
            ColorPickerExButtonCommand = new RelayCommand(ColorPickerExButtonCommandAction);
            ComboBoxExButtonCommand = new RelayCommand(ComboBoxExButtonCommandAction);
            ContextMenuExButtonCommand = new RelayCommand(ContextMenuExButtonCommandAction);
            DatePickerExButtonCommand = new RelayCommand(DatePickerExButtonCommandAction);
            DirectoryViewerExAndFileViewerExButtonCommand = new RelayCommand(DirectoryViewerExAndFileViewerExButtonCommandAction);
            ExpanderExButtonCommand = new RelayCommand(ExpanderExButtonCommandAction);
            GroupBoxButtonCommand = new RelayCommand(GroupBoxButtonCommandAction);
            HamburgerMenuExButtonCommand = new RelayCommand(HamburgerMenuExButtonCommandAction);
            ListBoxExButtonCommand = new RelayCommand(ListBoxExButtonCommandAction);
            ListViewExButtonCommand = new RelayCommand(ListViewExButtonCommandAction);
            GridViewExButtonCommand = new RelayCommand(GridViewExButtonCommandAction);
            MenuExButtonCommand = new RelayCommand(MenuExButtonCommandAction);
            ProgressBarExButtonCommand = new RelayCommand(ProgressBarExButtonCommandAction);
            RadioButtonExButtonCommand = new RelayCommand(RadioButtonExButtonCommandAction);
            RepeatButtonExButtonCommand = new RelayCommand(RepeatButtonExButtonCommandAction);
            RichTextBoxExButtonCommand = new RelayCommand(RichTextBoxExButtonCommandAction);
            ScrollBarExButtonCommand = new RelayCommand(ScrollBarExButtonCommandAction);
            SliderExButtonCommand = new RelayCommand(SliderExButtonCommandAction);
            TabControlExButtonCommand = new RelayCommand(TabControlExButtonCommandAction);
            TextBoxExButtonCommand = new RelayCommand(TextBoxExButtonCommandAction);
            ToggleButtonExButtonCommand = new RelayCommand(ToggleButtonExButtonCommandAction);
            ToggleExButtonCommand = new RelayCommand(ToggleExButtonCommandAction);
            TreeViewExButtonCommand = new RelayCommand(TreeViewExButtonCommandAction);
            UpDownDoubleExButtonCommand = new RelayCommand(UpDownDoubleExButtonCommandAction);
            UpDownLongExButtonCommand = new RelayCommand(UpDownLongExButtonCommandAction);
            WideViewButtonExButtonCommand = new RelayCommand(WideViewButtonExButtonCommandAction);
            WindowExButtonCommand = new RelayCommand(WindowExButtonCommandAction);
            WindowTitleBarExButtonCommand = new RelayCommand(WindowTitleBarExButtonCommandAction);
        }

        #endregion SETUP

    }
}
