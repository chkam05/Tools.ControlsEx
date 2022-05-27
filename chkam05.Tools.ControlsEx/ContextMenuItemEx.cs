using System.ComponentModel;
using System.Windows;


namespace chkam05.Tools.ControlsEx
{
    public class ContextMenuItemEx : MenuItemEx, INotifyPropertyChanged
    {

        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Static ContextMenuItemEx class constructor. </summary>
        static ContextMenuItemEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ContextMenuItemEx),
                new FrameworkPropertyMetadata(typeof(ContextMenuItemEx)));
        }

        #endregion CLASS METHODS

    }
}
