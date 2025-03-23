using chkam05.Tools.ControlsEx.Data.Theme;
using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Example.Data.Settings
{
    public class SettingsDataContext : BaseViewModel
    {

        //  VARIABLES

        private ThemeDataModel theme;
        private SettingsWindow window;


        //  GETTERS & SETTERS

        public ThemeDataModel Theme
        {
            get => theme;
            set => UpdateProperty(ref theme, value);
        }

        public SettingsWindow Window
        {
            get => window;
            set => UpdateProperty(ref window, value);
        }


        //  METHODS

        #region CLASS CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> SettingsDataContext class constructor. </summary>
        public SettingsDataContext(ThemeDataModel theme = null, SettingsWindow window = null)
        {
            Theme = theme ?? new ThemeDataModel();
            Window = window ?? new SettingsWindow();
        }

        #endregion CLASS CONSTRUCTORS

    }
}
