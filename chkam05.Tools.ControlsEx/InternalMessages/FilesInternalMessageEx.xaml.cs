using chkam05.Tools.ControlsEx.Events;
using chkam05.Tools.ControlsEx.InternalMessages.Data;
using chkam05.Tools.ControlsEx.Static;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

using Path = System.IO.Path;


namespace chkam05.Tools.ControlsEx.InternalMessages
{
    public partial class FilesInternalMessageEx : BaseFilesInternalMessageEx, INotifyPropertyChanged
    {

        //  DEPENDENCY PROPERTIES



        //  VARIABLES

        private DispatcherTimer _directoriesTreeViewTimer;
        private DispatcherTimer _filesListViewTimer;
        private ObservableCollection<FileItem> _filesCollection;
        private FileItem _lastSelectedFileItem = null;
        private ObservableCollection<FileTreeItem> _treeCollection;
        private KeyValuePair<CheckBoxEx, bool>? _selectedFileItemCheckBox = null;


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
        /// <summary> Create files selection internal message ex. </summary>
        /// <param name="multiselect"> Select multiple files. </param>
        /// <returns> FilesInternalMessageEx. </returns>
        public static FilesInternalMessageEx CreateOpenFile(bool multiselect)
        {
            return new FilesInternalMessageEx()
            {
                SelectionType = multiselect
                    ? FilesInternalMessageExSelectionType.MultiSelect
                    : FilesInternalMessageExSelectionType.SingleSelect,
            };
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Save file selection internal message ex. </summary>
        /// <returns> FilesInternalMessageEx. </returns>
        public static FilesInternalMessageEx CreateSaveFile()
        {
            return new FilesInternalMessageEx()
            {
                SelectionType = FilesInternalMessageExSelectionType.Save
            };
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create directory selection internal message ex. </summary>
        /// <param name="createDirectory"> Create directory if not exists. </param>
        /// <returns> FilesInternalMessageEx. </returns>
        public static FilesInternalMessageEx CreateDirectorySelect(bool createDirectory)
        {
            return new FilesInternalMessageEx()
            {
                SelectionType = createDirectory
                    ? FilesInternalMessageExSelectionType.DirectoryCreate
                    : FilesInternalMessageExSelectionType.DirectorySelect
            };
        }

        //  --------------------------------------------------------------------------------
        /// <summary> OpenFilesInternalMessageEx class constructor. </summary>
        internal FilesInternalMessageEx() : base()
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
                    ProcessSelectedItem(((ListViewEx)sender).SelectedItem as FileItem, true);
            }
            else
            {
                _filesListViewTimer.Start();
            }
        }

        //  --------------------------------------------------------------------------------
        private void FilesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _lastSelectedFileItem = ((ListViewEx)sender).SelectedItem as FileItem;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after missing double click time in files list view. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Event Arguments. </param>
        private void FilesListViewTimer_Tick(object sender, EventArgs e)
        {
            //  Files list view single click.
            _filesListViewTimer.Stop();

            if (_lastSelectedFileItem != null)
            {
                ProcessSelectedItem(_lastSelectedFileItem, false);
                _lastSelectedFileItem = null;
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
                    ProcessSelectedItem(((TreeViewEx)sender).SelectedItem as FileTreeItem, true);
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

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after focusing file item checkbox. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void SelectorCheckBox_GotFocus(object sender, RoutedEventArgs e)
        {
            _selectedFileItemCheckBox = new KeyValuePair<CheckBoxEx, bool>((CheckBoxEx)sender, true);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after unfocusing file item checkbox. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void SelectorCheckBox_LostFocus(object sender, RoutedEventArgs e)
        {
            _selectedFileItemCheckBox = null;
        }

        #endregion INTERACTION METHODS

        #region MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after checking file item checkbox. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void SelectorCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (SelectionType == FilesInternalMessageExSelectionType.MultiSelect
                && _selectedFileItemCheckBox.HasValue 
                && _selectedFileItemCheckBox.Value.Key == (CheckBoxEx)sender
                && _selectedFileItemCheckBox.Value.Value)
            {
                var item = (sender as CheckBoxEx)?.DataContext as FileItem;

                if (item != null && !SelectedFiles.Contains(item))
                    SelectedFiles.Add(item);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after checking file item checkbox. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void SelectorCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (SelectionType == FilesInternalMessageExSelectionType.MultiSelect
                && _selectedFileItemCheckBox.HasValue
                && _selectedFileItemCheckBox.Value.Key == (CheckBoxEx)sender
                && _selectedFileItemCheckBox.Value.Value)
            {
                var item = (sender as CheckBoxEx)?.DataContext as FileItem;

                if (item != null && SelectedFiles.Contains(item))
                    SelectedFiles.Remove(item);
            }
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
        /// <summary> Method invoked after changing file type selection. </summary>
        /// <param name="fileType"> File type selection. </param>
        protected override void OnFileTypeChanged(FileTypeItem fileType)
        {
            FillFilesList();
            FillDirectoriesTree();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after manually changed selected files. </summary>
        /// <param name="filesNames"> List of files names. </param>
        protected override void OnSelectionUpdate(string[] filesNames)
        {
            foreach (var file in Files)
            {
                if (file.Selected)
                    file.Selected = false;
            }

            if (filesNames != null && filesNames.Any())
            {
                bool breakLoop = false;
                List<FileItem> selectedFiles = new List<FileItem>();

                foreach (var fileName in filesNames)
                {
                    FileItem fileItem = null;

                    if (breakLoop)
                        break;

                    switch (SelectionType)
                    {
                        //  Select File
                        case FilesInternalMessageExSelectionType.SingleSelect:
                        case FilesInternalMessageExSelectionType.MultiSelect:
                            fileItem = Files.FirstOrDefault(f => f.Name == fileName);

                            if (fileItem != null)
                            {
                                selectedFiles.Add(fileItem);
                                fileItem.Selected = true;

                                if (SelectionType == FilesInternalMessageExSelectionType.SingleSelect)
                                    breakLoop = true;
                            }

                            break;

                        //  Save file
                        case FilesInternalMessageExSelectionType.Save:
                            fileItem = Files.FirstOrDefault(f => f.Name == fileName);

                            if (fileItem != null)
                            {
                                if (fileItem.IsDirectory)
                                    continue;

                                selectedFiles.Add(fileItem);
                            }
                            else
                            {
                                selectedFiles.Add(new FileItem(Path.Combine(CurrentDirectory, fileName)));
                            }

                            breakLoop = true;
                            break;

                        //  Select Directory.
                        case FilesInternalMessageExSelectionType.DirectorySelect:
                        case FilesInternalMessageExSelectionType.DirectoryCreate:
                            fileItem = Files.FirstOrDefault(f => f.Name == fileName);

                            if (fileItem != null)
                            {
                                if (!fileItem.IsDirectory)
                                    continue;

                                selectedFiles.Add(fileItem);
                            }
                            else if (SelectionType == FilesInternalMessageExSelectionType.DirectoryCreate)
                            {
                                selectedFiles.Add(new FileItem(Path.Combine(CurrentDirectory, fileName)));
                            }

                            breakLoop = true;
                            break;
                    }
                }

                SelectedFiles.Clear();
                selectedFiles.ForEach(f => SelectedFiles.Add(f));
            }
            else
            {
                SelectedFiles.Clear();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Process selected item from files list view. </summary>
        /// <param name="item"> FileItem. </param>
        /// <param name="doubleClick"> Is item double clicked. </param>
        private void ProcessSelectedItem(FileItem item, bool doubleClick)
        {
            if (item != null)
            {
                //  Navigate to selected directory.
                if (doubleClick && item.IsDirectory && Directory.Exists(item.Path))
                    NavigateTo(item.Path);

                //  Select file.
                else
                    SelectFile(item);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Process selected item from directories tree view. </summary>
        /// <param name="item"> FileTreeItem. </param>
        /// <param name="doubleClick"> Is item double clicked. </param>
        private void ProcessSelectedItem(FileTreeItem item, bool doubleClick)
        {
            if (doubleClick && item != null && Directory.Exists(item.Path))
                NavigateTo(item.Path);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Mark selected item and unselect previous. </summary>
        /// <param name="item"> New item to select. </param>
        private void SelectFile(FileItem item)
        {
            switch (SelectionType)
            {
                case FilesInternalMessageExSelectionType.SingleSelect:
                case FilesInternalMessageExSelectionType.Save:
                    if (!item.IsDirectory)
                    {
                        item.Selected = !item.Selected;

                        if (SelectedFile != null)
                            SelectedFile.Selected = false;

                        SelectedFile = item;
                    }
                    break;

                case FilesInternalMessageExSelectionType.MultiSelect:
                    if (!item.IsDirectory)
                    {
                        item.Selected = !item.Selected;

                        if (item.Selected)
                            SelectedFiles.Add(item);

                        else if (SelectedFiles.Contains(item))
                            SelectedFiles.Remove(item);
                    }
                    
                    break;

                case FilesInternalMessageExSelectionType.DirectoryCreate:
                case FilesInternalMessageExSelectionType.DirectorySelect:
                    if (item.IsDirectory)
                    {
                        item.Selected = !item.Selected;

                        if (SelectedFile != null)
                            SelectedFile.Selected = false;

                        SelectedFile = item;
                    }
                    break;
            }
        }

        #endregion MANAGEMENT METHODS

        #region MESSAGE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading message. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected override void OnLoaded(object sender, RoutedEventArgs e)
        {
            base.OnLoaded(sender, e);
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
