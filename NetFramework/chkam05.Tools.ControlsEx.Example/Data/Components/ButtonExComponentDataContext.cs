using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Example.Data.Components
{
    public class ButtonExComponentDataContext : BaseDemoDataContext
    {

        //  VARIABLES

        private string contentProperty = "Click me";


        //  GETTERS & SETTERS

        public string ContentProperty
        {
            get => contentProperty;
            set => UpdateProperty(ref contentProperty, value);
        }


        //  METHODS

        #region SETUP METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Setup default demo data. </summary>
        protected override void SetupData()
        {
            base.SetupData();

            HeightProperty = 48;
            WidthProperty = 128;
        }

        #endregion SETUP METHODS

    }
}
