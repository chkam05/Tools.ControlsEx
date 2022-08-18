using chkam05.Tools.ControlsEx.Data;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace chkam05.Tools.ControlsEx.InternalMessages
{
    public partial class OpenFileInternalMessageEx : BaseFilesSelectorInternalMessageEx
    {

        //  VARIABLES

        private ObservableCollection<InternalMessageFileItem> _filesCollection;
        private ObservableCollection<InternalMessageFileTreeItem> _treeCollection;


        //  GETTERS & SETTERS

        public ObservableCollection<InternalMessageFileItem> Files
        {
            get => _filesCollection;
            private set
            {
                _filesCollection = value;
                _filesCollection.CollectionChanged += OnCollectionChanged<InternalMessageFileItem>;
                OnPropertyChanged(nameof(Files));
            }
        }

        public ObservableCollection<InternalMessageFileTreeItem> Tree
        {
            get => _treeCollection;
            private set
            {
                _treeCollection = value;
                _treeCollection.CollectionChanged += OnCollectionChanged<InternalMessageFileTreeItem>;
                OnPropertyChanged(nameof(Files));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> OpenFileInternalMessageEx class constructor. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        /// <param name="title"> Message title. </param>
        /// <param name="icon"> Message header icon kind. </param>
        public OpenFileInternalMessageEx(InternalMessagesExContainer parentContainer, string title = "Select file",
            PackIconKind icon = PackIconKind.FolderOpen) : base(parentContainer)
        {
            Title = title;
            IconKind = icon;
            Files = new ObservableCollection<InternalMessageFileItem>();
            Tree = new ObservableCollection<InternalMessageFileTreeItem>();

            //  Initialize interface components.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region MESSAGE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading message. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed event arguments. </param>
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            OnNavigate();
        }

        #endregion MESSAGE METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing item in collection. </summary>
        /// <typeparam name="T"> Item type. </typeparam>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Notify Collection Changed Event Arguments. </param>
        protected void OnCollectionChanged<T>(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (T item in e.OldItems)
                    if (item is INotifyPropertyChanged)
                        ((INotifyPropertyChanged)item).PropertyChanged -= (s, e1)
                            => OnCollectionItemChanged<T>(s, e1);
            }

            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (T item in e.NewItems)
                    if (item is INotifyPropertyChanged)
                        ((INotifyPropertyChanged)item).PropertyChanged -= (s, e1)
                            => OnCollectionItemChanged<T>(s, e1);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing property in collection item. </summary>
        /// <typeparam name="T"> Item type. </typeparam>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Property Changed Event Arguments. </param>
        protected void OnCollectionItemChanged<T>(object sender, PropertyChangedEventArgs e)
        {
            //
        }

        #endregion NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        #region TEMPLATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after navigating / changing path. </summary>
        protected override void OnNavigate()
        {
            Files.Clear();
            GetFilesAndDirectories().ForEach(f => Files.Add(f));

            Tree.Clear();
            GetDirectoriesTree().ForEach(t => Tree.Add(t));
        }

        #endregion TEMPLATE METHODS

    }
}
