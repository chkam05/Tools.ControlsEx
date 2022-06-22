using chkam05.Tools.ControlsEx.Events;
using chkam05.Tools.ControlsEx.InternalMessages;
using chkam05.Tools.ControlsEx.Static;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using static chkam05.Tools.ControlsEx.Events.Delegates;


namespace chkam05.Tools.ControlsEx
{
    public class InternalMessagesEx : Frame, INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private List<BaseInternalMessageEx> _loadedMessages;


        //  GETTERS & SETTERS

        #region Hidden properties

        [Obsolete("Overrided Frame Property", true)]
        public new JournalOwnership JournalOwnership
        {
            get => base.JournalOwnership;
            set => base.JournalOwnership = value;
        }

        [Obsolete("Overrided Frame Property", true)]
        public new NavigationUIVisibility NavigationUIVisibility
        {
            get => base.NavigationUIVisibility;
            set => base.NavigationUIVisibility = value;
        }

        [Obsolete("Overrided Frame Property", true)]
        public new bool SandboxExternalContent
        {
            get => base.SandboxExternalContent;
            set => base.SandboxExternalContent = value;
        }

        [Obsolete("Overrided Frame Property", true)]
        public new Uri Source
        {
            get => base.Source;
            set => base.Source = value;
        }

        #endregion Hidden properties

        public new bool CanGoBack
        {
            get => MessageIndex > 0;
        }

        public bool HasHidden
        {
            get => _loadedMessages.Any(m 
                => m is IHideableInternalMessageEx
                && ((m as IHideableInternalMessageEx)?.IsHidden ?? false));
        }

        public BaseInternalMessageEx Message
        {
            get => Content != null ? Content as BaseInternalMessageEx : null;
        }

        public int MessageIndex
        {
            get => Message != null ? _loadedMessages.IndexOf(Message) : -1;
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> InternalMessagesEx class constructor. </summary>
        public InternalMessagesEx()
        {
            //  Initialize data containers.
            _loadedMessages = new List<BaseInternalMessageEx>();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static InternalMessagesEx class constructor. </summary>
        static InternalMessagesEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(InternalMessagesEx),
                new FrameworkPropertyMetadata(typeof(InternalMessagesEx)));
        }

        #endregion CLASS METHODS

        #region CREATE MESSAGES METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Creates default info message. </summary>
        /// <param name="title"> Message title. </param>
        /// <param name="message"> Message content. </param>
        /// <param name="icon"> Message icon. </param>
        /// <param name="buttons"> Message buttons set. </param>
        /// <param name="onClose"> Method invoked after closing message. </param>
        /// <param name="onHide"> Method invoked after hiding message. </param>
        /// <returns></returns>
        public InternalMessageEx CreateDefaultMessage(string title, string message, 
            PackIconKind icon = PackIconKind.InfoCircle, InternalMessageButtons buttons = InternalMessageButtons.Ok,
            StandardInternalMessageClose onClose = null, InternalMessageHide onHide = null)
        {
            var internalMessage = new InternalMessageEx()
            {
                Buttons = buttons,
                IconKind = icon,
                Message = message,
                Title = title,
            };

            LoadMessage(internalMessage);

            if (onClose != null)
                internalMessage.MessageClose += onClose;

            return internalMessage;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Creates default progress message. </summary>
        /// <param name="title"> Message title. </param>
        /// <param name="message"> Message content. </param>
        /// <param name="icon"> Message icon. </param>
        /// <param name="onClose"> Method invoked after closing message. </param>
        /// <param name="onHide"> Method invoked after hiding message. </param>
        /// <returns></returns>
        public ProgressInternalMessageEx CreateDefaultProgressMessage(string title, string message,
            PackIconKind icon = PackIconKind.ProgressClock,
            StandardInternalMessageClose onClose = null, InternalMessageHide onHide = null)
        {
            var internalMessage = new ProgressInternalMessageEx()
            {
                IconKind = icon,
                Message = message,
                Title = title,
            };

            LoadMessage(internalMessage);

            if (onClose != null)
                internalMessage.MessageClose += onClose;

            if (onClose != null)
                internalMessage.MessageHide += onHide;

            return internalMessage;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Creates default progress message. </summary>
        /// <param name="title"> Message title. </param>
        /// <param name="message"> Message content. </param>
        /// <param name="icon"> Message icon. </param>
        /// <param name="indicatorType"> Type of indicator. </param>
        /// <param name="onClose"> Method invoked after closing message. </param>
        /// <param name="onHide"> Method invoked after hiding message. </param>
        /// <returns></returns>
        public AwaitInternalMessageEx CreateDefaultAwaitMessage(string title, string message,
            PackIconKind icon = PackIconKind.ProgressClock, 
            IndicatorType indicatorType = IndicatorType.CircleSmoothIndicatorEx,
            StandardInternalMessageClose onClose = null, InternalMessageHide onHide = null)
        {
            var internalMessage = new AwaitInternalMessageEx()
            {
                IconKind = icon,
                Message = message,
                Title = title,
            };

            LoadMessage(internalMessage);

            if (onClose != null)
                internalMessage.MessageClose += onClose;

            if (onClose != null)
                internalMessage.MessageHide += onHide;

            return internalMessage;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Creates default open files message. </summary>
        /// <param name="title"> Message title. </param>
        /// <param name="multiselect"> Select multiple files. </param>
        /// <param name="icon"> Message icon. </param>
        /// <param name="onClose"> Method invoked after closing message. </param>
        /// <returns></returns>
        public FilesInternalMessageEx CreateDefaultOpenFilesMessage(string title,
            bool multiselect = false,
            PackIconKind icon = PackIconKind.FolderOpen, 
            FilesInternalMessageClose onClose = null)
        {
            var internalMessage = FilesInternalMessageEx.CreateOpenFile(multiselect);
            internalMessage.IconKind = icon;
            internalMessage.Title = title;

            LoadMessage(internalMessage);

            if (onClose != null)
                internalMessage.MessageClose += onClose;

            return internalMessage;
        }

        //  --------------------------------------------------------------------------------
        public FilesInternalMessageEx CreateDefaultSaveFileMessage(string title,
            PackIconKind icon = PackIconKind.FolderOpen,
            FilesInternalMessageClose onClose = null)
        {
            var internalMessage = FilesInternalMessageEx.CreateSaveFile();
            internalMessage.IconKind = icon;
            internalMessage.Title = title;

            LoadMessage(internalMessage);

            if (onClose != null)
                internalMessage.MessageClose += onClose;

            return internalMessage;
        }

        //  --------------------------------------------------------------------------------
        public FilesInternalMessageEx CreateDefaultSelectDirectoryMessage(string title,
            bool createFolderIfNotExists = false,
            PackIconKind icon = PackIconKind.FolderOpen,
            FilesInternalMessageClose onClose = null)
        {
            var internalMessage = FilesInternalMessageEx.CreateDirectorySelect(createFolderIfNotExists);
            internalMessage.IconKind = icon;
            internalMessage.Title = title;

            LoadMessage(internalMessage);

            if (onClose != null)
                internalMessage.MessageClose += onClose;

            return internalMessage;
        }

        #endregion CREATE MESSAGE METHODS

        #region HIDDEN NAVIGATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Adds an entry to back navigation history that contains a CustomContentState object. </summary>
        /// <param name="state"> A CustomContentState object that represents application-defined state 
        /// that is associated with a specific piece of content. </param>
        [Obsolete("Overrided Frame Method", true)]
        public new void AddBackEntry(CustomContentState state)
        {
            base.AddBackEntry(state);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Navigates to the most recent item in forward navigation history, if a Frame manages its own navigation history. </summary>
        [Obsolete("Overrided Frame Method", true)]
        private new void GoForward()
        {
            base.GoForward();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Navigates asynchronously to content that is specified by a uniform resource identifier (URI). </summary>
        /// <param name="source"> A Uri object initialized with the URI for the desired content. </param>
        /// <returns> True - if navigation is not canceled; False - otherwise. </returns>
        [Obsolete("Overrided Frame Method", true)]
        private new bool Navigate(Uri source)
        {
            return base.Navigate(source);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Navigates asynchronously to source content located at a uniform resource identifier (URI), 
        /// and passes an object that contains data to be used for processing during navigation. </summary>
        /// <param name="source"> A Uri object initialized with the URI for the desired content. </param>
        /// <param name="extraData"> A Object that contains data to be used for processing during navigation. </param>
        /// <returns> True - if navigation is not canceled; False - otherwise. </returns>
        [Obsolete("Overrided Frame Method", true)]
        private new bool Navigate(Uri source, object extraData)
        {
            return base.Navigate(source, extraData);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Navigates asynchronously to content that is contained by an object. </summary>
        /// <param name="source"> An Object that contains the content to navigate to. </param>
        /// <returns> True - if navigation is not canceled; False - otherwise. </returns>
        [Obsolete("Overrided Frame Method", true)]
        private new bool Navigate(object content)
        {
            return base.Navigate(content);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Navigates asynchronously to content that is contained by an object, 
        /// and passes an object that contains data to be used for processing during navigation. </summary>
        /// <param name="source"> An Object that contains the content to navigate to. </param>
        /// <param name="extraData"> A Object that contains data to be used for processing during navigation. </param>
        /// <returns> True - if navigation is not canceled; False - otherwise. </returns>
        [Obsolete("Overrided Frame Method", true)]
        private new bool Navigate(object content, object extraData)
        {
            return base.Navigate(content, extraData);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Reloads the current content. </summary>
        [Obsolete("Overrided Frame Method", true)]
        private new void Refresh()
        {
            base.Refresh();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Removes the most recent journal entry from back history. </summary>
        /// <returns> The most recent JournalEntry in back navigation history, if there is one. </returns>
        [Obsolete("Overrided Frame Method", true)]
        private new JournalEntry RemoveBackEntry()
        {
            return base.RemoveBackEntry();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Allows derived classes to determine the serialization behavior of the Content property. </summary>
        /// <returns> True - if content should be serialized; False - otherwise. </returns>
        [Obsolete("Overrided Frame Method", true)]
        private new bool ShouldSerializeContent()
        {
            return base.ShouldSerializeContent();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Stops further downloading of content for the current navigation request. </summary>
        [Obsolete("Overrided Frame Method", true)]
        private new void StopLoading()
        {
            base.StopLoading();
        }

        #endregion HIDDEN NAVIGATION METHODS

        #region INTERFACE MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Hide interface. </summary>
        private void HideInterface()
        {
            if (Visibility == Visibility.Visible)
                Visibility = Visibility.Collapsed;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Show interface. </summary>
        private void ShowInterface()
        {
            if (Visibility != Visibility.Visible)
                Visibility = Visibility.Visible;
        }

        #endregion INTERFACE MANAGEMENT METHODS

        #region MESSAGES MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Remove previous pages from content fram back entry. </summary>
        private void ClearBackEntry()
        {
            //  Get previous pages from content frame navigation service.
            var backEntry = NavigationService.RemoveBackEntry();

            //  While previous pages are available - try to remove it.
            while (backEntry != null)
                backEntry = NavigationService.RemoveBackEntry();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Remove previous pages. </summary>
        private void ClearMessages()
        {
            Content = null;
            ClearBackEntry();
            _loadedMessages.Clear();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Request close message method invoked from message. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Internal Message Close Event Arguments. </param>
        private void OnRequestCloseMessage(object sender, InternalMessageCloseEventArgs e)
        {
            CloseMessage();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Request hide message method invoked from message. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Internal Message Hide Event Arguments. </param>
        private void OnRequestHideMessage(object sender, InternalMessageHideEventArgs e)
        {
            if (e.IsHidden)
                HideInterface();
            else
                ShowInterface();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Show last hidden message. </summary>
        public void ShowHidden()
        {
            var hidden = _loadedMessages.LastOrDefault(m 
                => m is IHideableInternalMessageEx 
                && ((m as IHideableInternalMessageEx)?.IsHidden ?? false));

            if (hidden != null)
                (hidden as IHideableInternalMessageEx).IsHidden = false;
        }

        #endregion MESSAGES MANAGEMENT METHODS

        #region NAVIGATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Close current loaded messages. </summary>
        /// <param name="forceCloseAll"> True - close all loaded messages; False - otherwise. </param>
        public void CloseMessage(bool forceCloseAll = false)
        {
            if (CanGoBack && !forceCloseAll)
            {
                //  Get previous message.
                var previousMessage = _loadedMessages[MessageIndex - 1];

                //  Check if previous message was hided and change it.
                if ((previousMessage as IHideableInternalMessageEx)?.IsHidden ?? false)
                    (previousMessage as IHideableInternalMessageEx).IsHidden = false;

                GoBack();
            }
            else
            {
                HideInterface();
                ClearMessages();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Navigates to the most recent item in back navigation history, 
        /// if a Frame manages its own navigation history. </summary>
        public new void GoBack()
        {
            if (CanGoBack)
            {
                int index = MessageIndex;

                _loadedMessages.RemoveAt(MessageIndex);
                LoadMessage(_loadedMessages[index - 1]);
                ClearBackEntry();
            }
        }

        //  --------------------------------------------------------------------------------
        public void LoadMessage(BaseInternalMessageEx message)
        {
            var type = message.GetType();

            if (type.IsSubclassOf(typeof(BaseStandardInternalMessageEx)))
                (message as BaseStandardInternalMessageEx).MessageClose += OnRequestCloseMessage;
            else if (type.IsSubclassOf(typeof(BaseProgressInternalMessageEx)))
                (message as BaseProgressInternalMessageEx).MessageClose += OnRequestCloseMessage;
            else if (type.IsSubclassOf(typeof(BaseAwaitInternalMessageEx)))
                (message as BaseAwaitInternalMessageEx).MessageClose += OnRequestCloseMessage;
            else if (type.IsSubclassOf(typeof(BaseFilesInternalMessageEx)))
                (message as BaseFilesInternalMessageEx).MessageClose += OnRequestCloseMessage;

            if (message is IHideableInternalMessageEx)
                (message as IHideableInternalMessageEx).MessageHide += OnRequestHideMessage;

            _loadedMessages.Add(message);
            base.Navigate(message);
            ShowInterface();
        }

        #endregion NAVIGATION METHODS

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
