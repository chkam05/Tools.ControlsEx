using chkam05.Tools.ControlsEx.Events;
using chkam05.Tools.ControlsEx.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static chkam05.Tools.ControlsEx.Events.Delegates;

namespace chkam05.Tools.ControlsEx.InternalMessages
{
    public class BaseFilesInternalMessageEx : BaseInternalMessageEx, INotifyPropertyChanged
    {

        //  CONT

        private static readonly string DEFAULT_PATH = Environment.GetEnvironmentVariable("USERPROFILE");


        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty InitialDirectoryProperty = DependencyProperty.Register(
            nameof(InitialDirectory),
            typeof(string),
            typeof(BaseFilesInternalMessageEx),
            new PropertyMetadata(DEFAULT_PATH));


        //  EVENTS

        public event FilesInternalMessageClose MessageClose;


        //  VARIABLES


        //  GETTERS & SETTERS

        public string InitialDirectory
        {
            get => (string)GetValue(InitialDirectoryProperty);
            set
            {
                SetValue(InitialDirectoryProperty, value);
                OnPropertyChanged(nameof(InitialDirectory));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> BaseFilesInternalMessageEx class constructor. </summary>
        public BaseFilesInternalMessageEx()
        {
            if (!Directory.Exists(InitialDirectory))
                InitialDirectory = DEFAULT_PATH;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static BaseFilesInternalMessageEx class constructor. </summary>
        static BaseFilesInternalMessageEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseFilesInternalMessageEx),
                new FrameworkPropertyMetadata(typeof(BaseFilesInternalMessageEx)));
        }

        #endregion CLASS METHODS

        #region FILES & DIRECTORIES METHODS

        //  --------------------------------------------------------------------------------
        internal void GoBack()
        {
            //
        }

        //  --------------------------------------------------------------------------------
        internal void GoForward()
        {
            //
        }

        //  --------------------------------------------------------------------------------
        internal void GetDirectoryContent()
        {
            //
        }

        //  --------------------------------------------------------------------------------
        internal void GetTreeContent()
        {
            //
        }

        #endregion FILES & DIRECTORIES METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Ok Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected void OnOkClick(object sender, RoutedEventArgs e)
        {
            Result = InternalMessageResult.Ok;
            MessageClose?.Invoke(this, new FilesInternalMessageCloseEventArgs(Result, null));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Cancel Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected void OnCancelClick(object sender, RoutedEventArgs e)
        {
            Result = InternalMessageResult.Cancel;
            MessageClose?.Invoke(this, new FilesInternalMessageCloseEventArgs(Result, null));
        }

        #endregion INTERACTION METHODS

        #region TEMPLATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> When overridden in a derived class,cis invoked whenever 
        /// application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            //  Apply Template
            base.OnApplyTemplate();

            ApplyButtonExClickMethod(GetButtonEx("okButton"), OnOkClick);
            ApplyButtonExClickMethod(GetButtonEx("cancelButton"), OnCancelClick);
        }

        #endregion TEMPLATE METHODS

    }
}
