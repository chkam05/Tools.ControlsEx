using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Events;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class FilesSelectorInternalMessageEx : BaseFilesSelectorInternalMessageEx
    {

        //  VARIABLES

        private bool _anyFileSelected = false;
        private bool _manualInput = false;
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
        public FilesSelectorInternalMessageEx(InternalMessagesExContainer parentContainer, string title = "Select file",
            PackIconKind icon = PackIconKind.FolderOpen) : base(parentContainer)
        {
            Title = title;
            IconKind = icon;
            Files = new ObservableCollection<InternalMessageFileItem>();
            Tree = new ObservableCollection<InternalMessageFileTreeItem>();

            //  Initialize interface components.
            InitializeComponent();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create instance of OpenFileInternalMessageEx with configuration to open file. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        /// <param name="title"> Message title. </param>
        /// <param name="icon"> Message header icon kind. </param>
        /// <returns></returns>
        public static FilesSelectorInternalMessageEx CreateOpenFileInternalMessageEx(InternalMessagesExContainer parentContainer,
            string title = "Select file", PackIconKind icon = PackIconKind.FolderOpen)
        {
            var filesSelector = new FilesSelectorInternalMessageEx(parentContainer, title, icon)
            {
                AllowCreate = false,
                UseFilesTypes = true
            };

            return filesSelector;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create instance of OpenFileInternalMessageEx with configuration to save file. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        /// <param name="title"> Message title. </param>
        /// <param name="icon"> Message header icon kind. </param>
        public static FilesSelectorInternalMessageEx CreateSaveFileInternalMessageEx(InternalMessagesExContainer parentContainer,
            string title = "Save file", PackIconKind icon = PackIconKind.ContentSave)
        {
            var filesSelector = new FilesSelectorInternalMessageEx(parentContainer, title, icon)
            {
                AllowCreate = true,
                UseFilesTypes = true
            };

            return filesSelector;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create instance of OpenFileInternalMessageEx with configuration to select directory. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        /// <param name="title"> Message title. </param>
        /// <param name="icon"> Message header icon kind. </param>
        public static FilesSelectorInternalMessageEx CreateSelectDirectoryInternalMessageEx(InternalMessagesExContainer parentContainer,
            string title = "Select directory", PackIconKind icon = PackIconKind.Folder)
        {
            var filesSelector = new FilesSelectorInternalMessageEx(parentContainer, title, icon)
            {
                AllowCreate = true,
                OnlyDirectories = true
            };

            return filesSelector;
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after double clicking on item in directories TreeViewEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Mouse buttons event arguments. </param>
        private void DirectoriesTreeView_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var treeView = sender as TreeViewEx;

            if (treeView != null)
            {
                var selectedItem = treeView.SelectedItem as InternalMessageFileTreeItem;

                if (selectedItem != null)
                    Navigate(selectedItem.Path);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after selecting item in files ListViewEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Mouse buttons event arguments. </param>
        private void FilesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView = sender as ListViewEx;

            if (listView != null)
            {
                var selectedItems = listView.SelectedItems.Cast<InternalMessageFileItem>();

                if (selectedItems != null && selectedItems.Any())
                {
                    if (selectedItems.Any(f => f.IsDirectory || f.IsDrive) && selectedItems.Count() > 1)
                        listView.SelectedItems.Remove(selectedItems.First(f => f.IsDirectory || f.IsDrive));

                    if (!MultipleFiles && selectedItems.Count() > 1)
                        listView.SelectedItems.Remove(selectedItems.First());

                    string selectedFilesNames = string.Join("; ", selectedItems
                        .Where(f => OnlyDirectories
                            ? f.IsDirectory || f.IsDrive
                            : !f.IsDirectory && !f.IsDrive)
                        .Select(f => $"\"{f.Name}\""));

                    _anyFileSelected = !string.IsNullOrEmpty(selectedFilesNames);

                    if (!_manualInput)
                        _filesTextBox.Text = selectedFilesNames;
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after double clicking on item in files ListViewEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Mouse buttons event arguments. </param>
        private void FilesListView_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var listView = sender as ListViewEx;

            if (listView != null)
            {
                var selectedItems = listView.SelectedItems.Cast<InternalMessageFileItem>();

                if (selectedItems != null && selectedItems.Any())
                {
                    var dirItem = selectedItems.LastOrDefault(i => i.IsDirectory);

                    if (dirItem != null)
                        Navigate(dirItem.Path);

                    else if (_anyFileSelected)
                    {
                        Result = InternalMessageResult.Ok;
                        Close();
                    }
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create close method event arguments. </summary>
        /// <returns> Close method event arguments. </returns>
        protected override FilesSelectorInternalMessageCloseEventArgs CreateCloseEventArgs()
        {
            string[] filesArray = null;

            if (AllowCreate)
            {
                string saveFilePath = System.IO.Path.Combine(
                    CurrentDirectory, ReplaceFilesInvalidCharacters(_filesTextBox.Text));

                if (!OnlyDirectories && UseFilesTypes)
                    if (!FileType.MatchFile(saveFilePath) && !FileType.IsUniversal())
                        saveFilePath += FileType.Extensions.FirstOrDefault().Replace("*", "");

                filesArray = new string[] { saveFilePath };
            }
            else
            {
                filesArray = filesListView.SelectedItems
                    .Cast<InternalMessageFileItem>()
                    .Select(f => f.Path).ToArray();
            }

            return new FilesSelectorInternalMessageCloseEventArgs(Result, filesArray);
        }

        #endregion INTERACTION METHODS

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

            if (!AllowCreate)
                _filesTextBox.Text = string.Empty;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing text in FileNameTextBoxEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Text Modified Event Arguments. </param>
        protected override void OnFileNameTextBoxExTextModified(object sender, TextModifiedEventArgs e)
        {
            if (e.UserModified)
            {
                var textBox = sender as TextBoxEx;
                var files = GetFilesListFromString(e?.NewText);
                var selection = "";

                _manualInput = false;

                if (files.Any())
                {
                    if (AllowCreate)
                    {
                        selection = files.FirstOrDefault(n => OnlyDirectories
                            ? !File.Exists(System.IO.Path.Combine(CurrentDirectory, n))
                            : !Files.Any(f => (!f.IsDirectory && !f.IsDrive) && f.Name == n)) ?? "";

                        SelectSingleFile(selection);
                    }
                    else if (MultipleFiles)
                    {
                        var selections = files
                            .Where(n => Files.Any(f => !f.IsDirectory && !f.IsDrive && f.Name == n))
                            .ToList();

                        SelectMultipleFiles(selections);

                        selection = selections != null && selections.Any() 
                            ? string.Join("; ", selections.Select(n => $"\"{n}\""))
                            : "";
                    }
                    else
                    {
                        selection = files.FirstOrDefault(n => OnlyDirectories
                            ? Files.Any(f => (f.IsDirectory || f.IsDrive) && f.Name == n)
                            : Files.Any(f => (!f.IsDirectory && !f.IsDrive) && f.Name == n)) ?? "";

                        SelectSingleFile(selection);
                    }

                    textBox.Text = selection;

                    if (IsLoadingComplete)
                        GetButtonEx("okButton").IsEnabled = !string.IsNullOrEmpty(e.NewText);
                }
            }

            if (!e.UserModified && IsLoadingComplete)
                GetButtonEx("okButton").IsEnabled = !string.IsNullOrEmpty(e.NewText);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing text in FileNameTextBoxEx in edit mode. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Text Modified Event Arguments. </param>
        protected override void OnFileNameTextBoxExTextLiveModified(object sender, TextModifiedEventArgs e)
        {
            if (e.UserModified)
            {
                var textBox = sender as TextBoxEx;
                var files = GetFilesListFromString(e?.NewText);
                var selection = "";

                _manualInput = true;

                if (files.Any())
                {
                    if (AllowCreate)
                    {
                        selection = files.FirstOrDefault(n => OnlyDirectories
                            ? !File.Exists(System.IO.Path.Combine(CurrentDirectory, n))
                            : !Files.Any(f => (!f.IsDirectory && !f.IsDrive) && f.Name == n)) ?? "";

                        SelectSingleFile(selection);
                    }
                    else if (MultipleFiles)
                    {
                        var selections = files
                            .Where(n => Files.Any(f => !f.IsDirectory && !f.IsDrive && f.Name == n))
                            .ToList();

                        SelectMultipleFiles(selections);

                        selection = selections != null && selections.Any()
                            ? string.Join("; ", selections.Select(n => $"\"{n}\""))
                            : "";
                    }
                    else
                    {
                        selection = files.FirstOrDefault(n => OnlyDirectories
                            ? Files.Any(f => (f.IsDirectory || f.IsDrive) && f.Name == n)
                            : Files.Any(f => (!f.IsDirectory && !f.IsDrive) && f.Name == n)) ?? "";

                        SelectSingleFile(selection);
                    }

                    if (IsLoadingComplete)
                        GetButtonEx("okButton").IsEnabled = !string.IsNullOrEmpty(selection);
                }
            }

            if (!e.UserModified && IsLoadingComplete)
                GetButtonEx("okButton").IsEnabled = !string.IsNullOrEmpty(e.NewText);
        }

        #endregion TEMPLATE METHODS

        #region UTILITY METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Manual select files in files ListView. </summary>
        /// <param name="filesNames"> List of files names. </param>
        private void SelectMultipleFiles(List<string> filesNames)
        {
            filesListView.SelectedItems.Clear();

            if (filesNames != null && filesNames.Any())
                foreach (var file in Files.Where(f => filesNames.Any(s => s == f.Name)))
                    filesListView.SelectedItems.Add(file);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Manual select file. </summary>
        /// <param name="fileName"> File name. </param>
        private void SelectSingleFile(string fileName)
        {
            filesListView.SelectedItems.Clear();

            if (!string.IsNullOrEmpty(fileName))
            {
                var selectedItem = Files.FirstOrDefault(f => f.Name == fileName);

                if (selectedItem != null)
                    filesListView.SelectedItems.Add(selectedItem);
            }
        }

        #endregion UTILITY METHODS

    }
}
