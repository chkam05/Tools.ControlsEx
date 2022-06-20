using chkam05.Tools.ControlsEx.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace chkam05.Tools.ControlsEx
{
    public class TreeViewEx : TreeView, INotifyPropertyChanged
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(TreeViewEx),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  GETTERS & SETTERS

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set
            {
                SetValue(CornerRadiusProperty, value);
                OnPropertyChanged(nameof(CornerRadius));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> TreeViewEx static class constructor. </summary>
        static TreeViewEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeViewEx),
                new FrameworkPropertyMetadata(typeof(TreeViewEx)));
        }

        #endregion CLASS METHODS

        #region ITEMS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Creates and returns new ListViewItemEx container. </summary>
        /// <returns> A new ListViewItemEx control. </returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new TreeViewItemEx();
        }

        #endregion ITEMS METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method for invoking PropertyChangedEventHandler external method. </summary>
        /// <param name="propertyName"> Changed property name. </param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion NOTIFY PROPERTIES CHANGED INTERFACE METHODS

    }
}
