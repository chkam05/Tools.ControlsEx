using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Data.Theme
{
    public class ThemeManager : BaseViewModel
    {

        //  VARIABLES

        private static ThemeManager instance;
        private static object instanceLock = new object();
        private ThemeDataModel dataContext;


        //  GETTERS & SETTERS

        public static ThemeManager Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new ThemeManager();

                    return instance;
                }
            }
        }

        public ThemeDataModel DataContext
        {
            get => dataContext;
            set
            {
                UpdateProperty(ref dataContext, value);
                dataContext.Refresh();
            }
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ThemeManager private class constructor. </summary>
        private ThemeManager()
        {
            dataContext = new ThemeDataModel();
        }

        #endregion CONSTRUCTORS

    }
}
