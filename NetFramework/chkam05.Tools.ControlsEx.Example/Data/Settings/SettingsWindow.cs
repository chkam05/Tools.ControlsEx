using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Example.Data.Settings
{
    public class SettingsWindow : BaseViewModel
    {

        //  VARIABLES

        private double left;
        private double top;
        private double height;
        private double width;


        //  GETTERS & SETTERS

        public double Left
        {
            get => left;
            set => UpdateProperty(ref left, value);
        }

        public double Top
        {
            get => top;
            set => UpdateProperty(ref top, value);
        }

        public double Height
        {
            get => height;
            set => UpdateProperty(ref height, value);
        }

        public double Width
        {
            get => width;
            set => UpdateProperty(ref width, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> SettingsWindow class constructor. </summary>
        public SettingsWindow(
            double? left = null,
            double? top = null,
            double? height = null,
            double? width = null)
        {
            Left = left ?? 25;
            Top = top ?? 25;
            Height = height ?? 450;
            Width = width ?? 800;
        }

        #endregion CONSTRUCTORS

    }
}
