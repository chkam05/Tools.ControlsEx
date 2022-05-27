using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Example.Data.Config
{
    public class Configuration
    {

        //  VARIABLES

        private static Configuration _instance;


        //  GETTERS & SETTERS

        public static Configuration Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Configuration();

                return _instance;
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Configuration class constructor. </summary>
        private Configuration()
        {
            //
        }

        #endregion CLASS METHODS

    }
}
