using chkam05.Tools.ControlsEx.Events;
using chkam05.Tools.ControlsEx.InternalMessages.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Threading;

namespace chkam05.Tools.ControlsEx.InternalMessages
{
    public partial class OpenFilesInternalMessageEx : BaseFilesInternalMessageEx, INotifyPropertyChanged
    {

        //  DEPENDENCY PROPERTIES



        //  VARIABLES

        private DispatcherTimer _directoriesTreeViewTimer;
        private DispatcherTimer _filesListViewTimer;
        private ObservableCollection<FileItem> _filesCollection;
        private ObservableCollection<FileTreeItem> _treeCollection;


        //  GETTERS & SETTERS

        public ObservableCollection<FileItem> Files
        {
            get => _filesCollection;
            private set
            {
                _filesCollection = value;
                _filesCollection.CollectionChanged += OnCollectionChanged<FileItem>;
                OnPropertyChanged(nameof(Files));
            }
        }

        public ObservableCollection<FileTreeItem> Tree
        {
            get => _treeCollection;
            private set
            {
                _treeCollection = value;
                _treeCollection.CollectionChanged += OnCollectionChanged<FileTreeItem>;
                OnPropertyChanged(nameof(Files));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> OpenFilesInternalMessageEx class constructor. </summary>
        public OpenFilesInternalMessageEx() : base()
        {
            //  Setup data containers.
            Files = new ObservableCollection<FileItem>();
            Tree = new ObservableCollection<FileTreeItem>();

            //  Setup modules.
            _directoriesTreeViewTimer = new DispatcherTimer();
            _directoriesTreeViewTimer.Interval = TimeSpan.FromMilliseconds(0.2);
            _directoriesTreeViewTimer.Tick += DirectoriesTreeViewTimer_Tick;
            _filesListViewTimer = new DispatcherTimer();
            _filesListViewTimer.Interval = TimeSpan.FromMilliseconds(0.2);
            _filesListViewTimer.Tick += FilesListViewTimer_Tick;

            //  Setup methods.
            DirectoryChanged += OnDirectoryChanged;

            //  Initialize interface components.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking on files list view. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Mouse Button Event Arguments. </param>
        private void FilesListView_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                //  Files list view double click.
                _filesListViewTimer.Stop();

                if (filesListView.SelectedItem != null)
                {
                    var item = filesListView.SelectedItem as FileItem;

                    if (item != null)
                    {
                        if (item.IsDirectory && Directory.Exists(item.Path))
                        {
                            NavigateTo(item.Path);
                        }
                        else if (!item.IsDirectory && File.Exists(item.Path))
                        {
                            //
                        }
                    }
                }
            }
            else
            {
                _filesListViewTimer.Start();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after missing double click time in files list view. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Event Arguments. </param>
        private void FilesListViewTimer_Tick(object sender, EventArgs e)
        {
            //  Files list view single click.
            _filesListViewTimer.Stop();

            if (filesListView.SelectedItem != null)
            {
                var item = filesListView.SelectedItem as FileItem;

                if (item != null && !item.IsDirectory && File.Exists(item.Path))
                {
                    //
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking on directories tree view. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Mouse Button Event Arguments. </param>
        private void DirectoriesTreeView_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                //  Directories tree view double click.
                _directoriesTreeViewTimer.Stop();

                if (directoriesTreeView.SelectedItem != null)
                {
                    var item = directoriesTreeView.SelectedItem as FileTreeItem;

                    if (item != null && Directory.Exists(item.Path))
                        NavigateTo(item.Path);
                }
            }
            else
            {
                _directoriesTreeViewTimer.Start();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after missing double click time in directories tree view. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Event Arguments. </param>
        private void DirectoriesTreeViewTimer_Tick(object sender, EventArgs e)
        {
            //  Directories tree view single click.
            _directoriesTreeViewTimer.Stop();
        }

        #endregion INTERACTION METHODS

        #region MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after directory update to update files list. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Files Internal Message Directory Changed Event Arguments. </param>
        private void OnDirectoryChanged(object sender, FilesInternalMessageDirectoryChangedEventArgs e)
        {
            FillFilesList();
            FillDirectoriesTree();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Fill files list with files. </summary>
        private void FillFilesList()
        {
            Files.Clear();
            GetDirectoryContent().ForEach(f => Files.Add(f));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Fill directories tree with directories. </summary>
        private void FillDirectoriesTree()
        {
            Tree.Clear();
            GetTreeContent().ForEach(t => Tree.Add(t));
        }

        #endregion MANAGEMENT METHODS

        #region MESSAGE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading message. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void BaseFilesInternalMessageEx_Loaded(object sender, RoutedEventArgs e)
        {
            FillFilesList();
            FillDirectoriesTree();
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

    }
}
