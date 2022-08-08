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
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static chkam05.Tools.ControlsEx.Events.Delegates;

namespace chkam05.Tools.ControlsEx.InternalMessages
{
    public class BaseFilesInternalMessageEx : BaseInternalMessageEx, INotifyPropertyChanged
    {

        //  CONST

        private static readonly string DEFAULT_PATH = Environment.GetEnvironmentVariable("USERPROFILE");


        //  DEPENDENCY PROPERTIES

        #region Appearance TextBoxes Colors Properties

        public static readonly DependencyProperty TextBoxMouseOverBackgroundProperty = DependencyProperty.Register(
            nameof(TextBoxMouseOverBackground),
            typeof(Brush),
            typeof(BaseFilesInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty TextBoxMouseOverBorderBrushProperty = DependencyProperty.Register(
            nameof(TextBoxMouseOverBorderBrush),
            typeof(Brush),
            typeof(BaseFilesInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty TextBoxMouseOverForegroundProperty = DependencyProperty.Register(
            nameof(TextBoxMouseOverForeground),
            typeof(Brush),
            typeof(BaseFilesInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty TextBoxSelectedBackgroundProperty = DependencyProperty.Register(
            nameof(TextBoxSelectedBackground),
            typeof(Brush),
            typeof(BaseFilesInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty TextBoxSelectedBorderBrushProperty = DependencyProperty.Register(
            nameof(TextBoxSelectedBorderBrush),
            typeof(Brush),
            typeof(BaseFilesInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_PRESSED)));

        public static readonly DependencyProperty TextBoxSelectedForegroundProperty = DependencyProperty.Register(
            nameof(TextBoxSelectedForeground),
            typeof(Brush),
            typeof(BaseFilesInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty TextBoxSelectedTextBackgroundProperty = DependencyProperty.Register(
            nameof(TextBoxSelectedTextBackground),
            typeof(Brush),
            typeof(BaseFilesInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        #endregion Appearance TextBoxes Colors Properties

        public static readonly DependencyProperty CanGoBackProperty = DependencyProperty.Register(
            nameof(CanGoBack),
            typeof(bool),
            typeof(BaseFilesInternalMessageEx),
            new PropertyMetadata(true));

        public static readonly DependencyProperty CanGoForwardProperty = DependencyProperty.Register(
            nameof(CanGoForward),
            typeof(bool),
            typeof(BaseFilesInternalMessageEx),
            new PropertyMetadata(false));

        public static readonly DependencyProperty FilesTypesProperty = DependencyProperty.Register(
            nameof(FilesTypes),
            typeof(ObservableCollection<FileTypeItem>),
            typeof(BaseFilesInternalMessageEx),
            new PropertyMetadata(new ObservableCollection<FileTypeItem>(
                new List<FileTypeItem>()
                {
                    new FileTypeItem("All Files", new string[] { "*.*" })
                }
            )));

        public static readonly DependencyProperty InitialDirectoryProperty = DependencyProperty.Register(
            nameof(InitialDirectory),
            typeof(string),
            typeof(BaseFilesInternalMessageEx),
            new PropertyMetadata(DEFAULT_PATH));

        public static readonly DependencyProperty SelectionTypeProperty = DependencyProperty.Register(
            nameof(SelectionType),
            typeof(FilesInternalMessageExSelectionType),
            typeof(BaseFilesInternalMessageEx),
            new PropertyMetadata(FilesInternalMessageExSelectionType.SingleSelect));


        //  EVENTS

        public event FilesInternalMessageDirectoryChanged DirectoryChanged;
        public event FilesInternalMessageClose MessageClose;


        //  VARIABLES

        private string _currentDirectory = DEFAULT_PATH;
        private FileTypeItem _fileItemType = null;
        private List<string> _historyForward;
        private bool _isAnySelected = false;
        private FileItem _selectedFile = null;
        private ObservableCollection<FileItem> _selectedFiles;
        private bool _selectionUpdate = false;
        private string _textBoxAddressText = DEFAULT_PATH;
        private string _textBoxFileNameText;


        //  GETTERS & SETTERS

        #region Appearance TextBoxes Colors

        public Brush TextBoxMouseOverBackground
        {
            get => (Brush)GetValue(TextBoxMouseOverBackgroundProperty);
            set
            {
                SetValue(TextBoxMouseOverBackgroundProperty, value);
                OnPropertyChanged(nameof(TextBoxMouseOverBackground));
            }
        }

        public Brush TextBoxMouseOverBorderBrush
        {
            get => (Brush)GetValue(TextBoxMouseOverBorderBrushProperty);
            set
            {
                SetValue(TextBoxMouseOverBorderBrushProperty, value);
                OnPropertyChanged(nameof(TextBoxMouseOverBorderBrush));
            }
        }

        public Brush TextBoxMouseOverForeground
        {
            get => (Brush)GetValue(TextBoxMouseOverForegroundProperty);
            set
            {
                SetValue(TextBoxMouseOverForegroundProperty, value);
                OnPropertyChanged(nameof(TextBoxMouseOverForeground));
            }
        }

        public Brush TextBoxSelectedBackground
        {
            get => (Brush)GetValue(TextBoxSelectedBackgroundProperty);
            set
            {
                SetValue(TextBoxSelectedBackgroundProperty, value);
                OnPropertyChanged(nameof(TextBoxSelectedBackground));
            }
        }

        public Brush TextBoxSelectedBorderBrush
        {
            get => (Brush)GetValue(TextBoxSelectedBorderBrushProperty);
            set
            {
                SetValue(TextBoxSelectedBorderBrushProperty, value);
                OnPropertyChanged(nameof(TextBoxSelectedBorderBrush));
            }
        }

        public Brush TextBoxSelectedForeground
        {
            get => (Brush)GetValue(TextBoxSelectedForegroundProperty);
            set
            {
                SetValue(TextBoxSelectedForegroundProperty, value);
                OnPropertyChanged(nameof(TextBoxSelectedForeground));
            }
        }

        public Brush TextBoxSelectedTextBackground
        {
            get => (Brush)GetValue(TextBoxSelectedTextBackgroundProperty);
            set
            {
                SetValue(TextBoxSelectedTextBackgroundProperty, value);
                OnPropertyChanged(nameof(TextBoxSelectedTextBackground));
            }
        }

        #endregion Appearance TextBoxes Colors

        //  Control

        public bool CanGoBack
        {
            get => (bool)GetValue(CanGoBackProperty);
            private set
            {
                SetValue(CanGoBackProperty, value);
                OnPropertyChanged(nameof(CanGoBack));
            }
        }

        public bool CanGoForward
        {
            get => (bool)GetValue(CanGoForwardProperty);
            private set
            {
                SetValue(CanGoForwardProperty, value);
                OnPropertyChanged(nameof(CanGoForward));
            }
        }

        public string CurrentDirectory
        {
            get => _currentDirectory;
            private set
            {
                _currentDirectory = value;
                OnPropertyChanged(nameof(CurrentDirectory));
            }
        }

        public bool IsAnySelected
        {
            get => _isAnySelected;
            private set
            {
                _isAnySelected = value;
                OnPropertyChanged(nameof(IsAnySelected));
            }
        }

        public FilesInternalMessageExSelectionType SelectionType
        {
            get => (FilesInternalMessageExSelectionType)GetValue(SelectionTypeProperty);
            protected set
            {
                SetValue(SelectionTypeProperty, value);
                OnPropertyChanged(nameof(SelectionType));
            }
        }

        //  Data

        public FileItem SelectedFile
        {
            get => _selectedFile;
            protected set
            {
                _selectedFile = value;
                IsAnySelected = _selectedFile != null;
                OnPropertyChanged(nameof(SelectedFile));
                OnSelectionUpdate(false);
            }
        }

        public ObservableCollection<FileItem> SelectedFiles
        {
            get => _selectedFiles;
            protected set
            {
                _selectedFiles = value != null ? value : new ObservableCollection<FileItem>();
                _selectedFiles.CollectionChanged += OnSelectionCollectionChanged;
                OnPropertyChanged(nameof(SelectedFiles));
                OnSelectionUpdate(true);
            }
        }

        //  Editable

        public ObservableCollection<FileTypeItem> FilesTypes
        {
            get => (ObservableCollection<FileTypeItem>)GetValue(FilesTypesProperty);
            set
            {
                SetValue(FilesTypesProperty, value);
                OnPropertyChanged(nameof(FilesTypes));
            }
        }

        public string InitialDirectory
        {
            get => (string)GetValue(InitialDirectoryProperty);
            set
            {
                SetValue(InitialDirectoryProperty, value);
                OnPropertyChanged(nameof(InitialDirectory));
            }
        }

        //  UI

        public FileTypeItem SelectedFileType
        {
            get => _fileItemType;
            private set
            {
                _fileItemType = value;
                OnPropertyChanged(nameof(SelectedFileType));
            }
        }

        public string TextBoxAddressText
        {
            get => _textBoxAddressText;
            set
            {
                _textBoxAddressText = value;
                OnPropertyChanged(nameof(TextBoxAddressText));
            }
        }

        public string TextBoxFileNameText
        {
            get => _textBoxFileNameText;
            set
            {
                _textBoxFileNameText = value;
                OnPropertyChanged(nameof(TextBoxFileNameText));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> BaseFilesInternalMessageEx class constructor. </summary>
        public BaseFilesInternalMessageEx()
        {
            Loaded += OnLoaded;

            if (!Directory.Exists(InitialDirectory))
                InitialDirectory = DEFAULT_PATH;

            SelectedFiles = new ObservableCollection<FileItem>();

            _historyForward = new List<string>();
            UpdateDirectory(InitialDirectory);
            UpdateAfterNavigation();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static BaseFilesInternalMessageEx class constructor. </summary>
        static BaseFilesInternalMessageEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseFilesInternalMessageEx),
                new FrameworkPropertyMetadata(typeof(BaseFilesInternalMessageEx)));
        }

        #endregion CLASS METHODS

        #region COMBOBOX METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing file type selection. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Selection Changed Event Arguments. </param>
        private void OnFileTypeComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxEx = sender as ComboBoxEx;

            if (comboBoxEx != null && comboBoxEx.SelectedItem != null)
            {
                var fileType = comboBoxEx.SelectedItem as FileTypeItem;

                if (fileType != null)
                {
                    SelectedFileType = fileType;
                    OnFileTypeChanged(fileType);
                }
            }
        }

        #endregion COMBOBOX METHODS

        #region BUTTONS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Back Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void OnBackClick(object sender, RoutedEventArgs e)
        {
            GoBack();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Forward Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void OnForwardClick(object sender, RoutedEventArgs e)
        {
            GoForward();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Ok Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void OnOkClick(object sender, RoutedEventArgs e)
        {
            Result = InternalMessageResult.Ok;
            MessageClose?.Invoke(this, new FilesInternalMessageCloseEventArgs(
                Result, SelectedFiles.Select(f => f.Path).ToArray()));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Cancel Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            Result = InternalMessageResult.Cancel;
            MessageClose?.Invoke(this, new FilesInternalMessageCloseEventArgs(Result, null));
        }

        #endregion BUTTONS METHODS

        #region FILES & DIRECTORIES METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Go to parent directory. </summary>
        internal void GoBack()
        {
            if (!string.IsNullOrEmpty(CurrentDirectory))
            {
                var currentDirectory = CurrentDirectory;
                var previousDirectory = Path.GetDirectoryName(currentDirectory);

                _historyForward.Insert(0, currentDirectory);
                UpdateDirectory(previousDirectory);
                UpdateAfterNavigation();

                DirectoryChanged?.Invoke(this, new FilesInternalMessageDirectoryChangedEventArgs(
                    FilesInternalMessageDirectoryChangeMethod.OnBack, previousDirectory, currentDirectory));
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Go back to previous directory before go to parent directory. </summary>
        internal void GoForward()
        {
            if (_historyForward.Any())
            {
                var currentDirectory = CurrentDirectory;
                var forwardDirectory = _historyForward[0];

                if (Directory.Exists(forwardDirectory))
                {
                    _historyForward.RemoveAt(0);
                    UpdateDirectory(forwardDirectory);
                    UpdateAfterNavigation();

                    DirectoryChanged?.Invoke(this, new FilesInternalMessageDirectoryChangedEventArgs(
                        FilesInternalMessageDirectoryChangeMethod.OnForward, forwardDirectory, currentDirectory));
                }
                else
                {
                    _historyForward.Clear();
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Navigate to directory. </summary>
        /// <param name="path"> Path to directory to navigate to. </param>
        internal void NavigateTo(string path)
        {
            if (Directory.Exists(path))
            {
                string oldDirectory = CurrentDirectory;

                _historyForward.Clear();
                UpdateDirectory(path);
                UpdateAfterNavigation();

                DirectoryChanged?.Invoke(this, new FilesInternalMessageDirectoryChangedEventArgs(
                    FilesInternalMessageDirectoryChangeMethod.OnNavigate, path, oldDirectory));
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get list of files and folders in current path. </summary>
        /// <returns> List of files and folders in current path. </returns>
        internal List<FileItem> GetDirectoryContent()
        {
            List<FileItem> result = new List<FileItem>();

            //  Get base directories and files.
            if (Directory.Exists(CurrentDirectory))
            {
                foreach (var dir in Directory.GetDirectories(CurrentDirectory))
                {
                    var fileInfo = new FileInfo(dir);

                    if (fileInfo.Attributes.HasFlag(FileAttributes.Directory)
                        && !fileInfo.Attributes.HasFlag(FileAttributes.Hidden)
                        && !fileInfo.Attributes.HasFlag(FileAttributes.System))
                        result.Add(new FileItem(dir));
                }

                if (SelectionType != FilesInternalMessageExSelectionType.DirectoryCreate
                    && SelectionType != FilesInternalMessageExSelectionType.DirectorySelect)
                {
                    foreach (var file in Directory.GetFiles(CurrentDirectory))
                    {
                        var fileInfo = new FileInfo(file);

                        if (!fileInfo.Attributes.HasFlag(FileAttributes.Hidden)
                            && !fileInfo.Attributes.HasFlag(FileAttributes.System)
                            && (SelectedFileType?.ValidateFileName(Path.GetFileName(file)) ?? true))
                            result.Add(new FileItem(file));
                    }
                }
            }
            //  Get drives.
            else if (string.IsNullOrEmpty(CurrentDirectory))
            {
                foreach (var drive in DriveInfo.GetDrives())
                {
                    if (Directory.Exists(drive.Name) || File.Exists(drive.Name))
                        result.Add(new FileItem(drive.Name));
                }
            }

            return result;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get nested list of directories in current path. </summary>
        /// <returns> Nested list of directories in current path starting from 0 parent path. </returns>
        internal List<FileTreeItem> GetTreeContent()
        {
            List<FileTreeItem> result = new List<FileTreeItem>();
            List<string> hierarchy = GetTreeHierarchy();

            //  Get drives.
            foreach (var drive in DriveInfo.GetDrives())
            {
                if (Directory.Exists(drive.Name) || File.Exists(drive.Name))
                    result.Add(new FileTreeItem(drive.Name));
            }

            if (hierarchy.Any())
            {
                FillTreeContent(result.FirstOrDefault(t => t.Path == hierarchy[0]), hierarchy);
            }

            return result;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Fill nestings in list of directories. </summary>
        /// <param name="item"> Nested directory item. </param>
        /// <param name="hierarchy"> List of paths forward. </param>
        private void FillTreeContent(FileTreeItem item, List<string> hierarchy)
        {
            if (item != null && hierarchy.Any())
            {
                foreach (var dir in Directory.GetDirectories(hierarchy[0]))
                {
                    var fileInfo = new FileInfo(dir);

                    if (fileInfo.Attributes.HasFlag(FileAttributes.Directory)
                        && !fileInfo.Attributes.HasFlag(FileAttributes.Hidden)
                        && !fileInfo.Attributes.HasFlag(FileAttributes.System))
                        item.Childs.Add(new FileTreeItem(dir));
                }

                hierarchy.RemoveAt(0);

                if (hierarchy.Any())
                {
                    FillTreeContent(item.Childs.FirstOrDefault(t => t.Path == hierarchy[0]), hierarchy);
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get list of parent directories from currend directories. </summary>
        /// <returns> List of parent directories from current directory. </retsurns>
        private List<string> GetTreeHierarchy()
        {
            List<string> result = new List<string>();
            string directory = CurrentDirectory;

            while (directory != null)
            {
                result.Insert(0, directory);
                directory = Path.GetDirectoryName(directory);
            }

            return result;
        }

        #endregion FILES & DIRECTORIES METHODS

        #region MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing file type selection. </summary>
        /// <param name="fileType"> File type selection. </param>
        protected virtual void OnFileTypeChanged(FileTypeItem fileType)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after manually changed selected files. </summary>
        /// <param name="filesNames"> List of files names. </param>
        protected virtual void OnSelectionUpdate(string[] filesNames)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after selecting file to select. </summary>
        /// <param name="updateFromFilesList"> Is selection from selected files list. </param>
        private void OnSelectionUpdate(bool updateFromFilesList = false)
        {
            if (_selectionUpdate)
                return;

            _selectionUpdate = true;

            if (updateFromFilesList)
            {
                if (SelectionType != FilesInternalMessageExSelectionType.MultiSelect && SelectedFiles.Count > 1)
                    SelectedFiles = new ObservableCollection<FileItem>(new List<FileItem>() { SelectedFiles[0] });

                SelectedFile = SelectedFiles.FirstOrDefault();
            }
            else
            {
                SelectedFiles = new ObservableCollection<FileItem>(new List<FileItem>() { SelectedFile });
            }
            
            TextBoxFileNameText = SelectedFiles.Any() 
                ? string.Join("; ", SelectedFiles.Select(f => f.Name)) : string.Empty;
            _selectionUpdate = false;
        }

        #endregion MANAGEMENT METHODS

        #region MESSAGE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading message. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnLoaded(object sender, RoutedEventArgs e)
        {
            GetComboBoxEx("filesTypesComboBox").SelectedItem = FilesTypes.FirstOrDefault();
        }

        #endregion MESSAGE METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method for invoking PropertyChangedEventHandler external method. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Notify Collection Changed Event Arguments. </param>
        protected void OnSelectionCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnSelectionUpdate(true);
        }

        #endregion NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        #region TEXTBOXES METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after modifying text in address TextBox. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Text Modified Event Arguments. </param>
        private void OnAddressTextBoxTextModified(object sender, TextModifiedEventArgs e)
        {
            if (e.UserModified)
            {
                NavigateTo(e.NewText);
                TextBoxAddressText = CurrentDirectory;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after modifying text in file name TextBox. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Text Modified Event Arguments. </param>
        private void OnFileNameTextBoxTexModified(object sender, TextModifiedEventArgs e)
        {
            if (e.UserModified)
            {
                var filesNames = e.NewText.Split(
                        new string[] { "; ", ";" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(f => f.Trim()).ToArray();

                OnSelectionUpdate(filesNames);
            }
        }

        #endregion TEXTBOXES METHODS

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
            ApplyButtonExClickMethod(GetButtonEx("backButton"), OnBackClick);
            ApplyButtonExClickMethod(GetButtonEx("forwardButton"), OnForwardClick);

            ApplyTextBoxExModifiedMethod(GetTextBoxEx("addressTextBox"), OnAddressTextBoxTextModified);
            ApplyTextBoxExModifiedMethod(GetTextBoxEx("fileNameTextBox"), OnFileNameTextBoxTexModified);

            ApplyComboBoxExSelectionChangedMethod(GetComboBoxEx("filesTypesComboBox"), OnFileTypeComboBoxSelectionChanged);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get ComboBoxEx from ContentTemplate. </summary>
        /// <param name="comboBoxName"> ComboBoxEx name. </param>
        /// <returns> ComboBoxEx or null. </returns>
        protected ComboBoxEx GetComboBoxEx(string comboBoxName)
        {
            return this.Template.FindName(comboBoxName, this) as ComboBoxEx;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get TextBoxEx from ContentTemplate. </summary>
        /// <param name="textBoxName"> TextBoxEx name. </param>
        /// <returns> TextBoxEx or null. </returns>
        protected TextBoxEx GetTextBoxEx(string textBoxName)
        {
            return this.Template.FindName(textBoxName, this) as TextBoxEx;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Apply Click method on TextBoxEx. </summary>
        /// <param name="textBoxEx"> TextBoxEx. </param>
        /// <param name="eventHandler"> Click method. </param>
        protected void ApplyComboBoxExSelectionChangedMethod(ComboBoxEx comboBoxEx, SelectionChangedEventHandler eventHandler)
        {
            if (comboBoxEx != null)
            {
                comboBoxEx.SelectionChanged += eventHandler;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Apply Click method on TextBoxEx. </summary>
        /// <param name="textBoxEx"> TextBoxEx. </param>
        /// <param name="eventHandler"> Click method. </param>
        protected void ApplyTextBoxExModifiedMethod(TextBoxEx textBoxEx, TextModifiedEventHandler eventHandler)
        {
            if (textBoxEx != null)
            {
                textBoxEx.TextModified += eventHandler;
            }
        }

        #endregion TEMPLATE METHODS

        #region UPDATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method for update current directory to new directory. </summary>
        /// <param name="directory"> Directory path. </param>
        private void UpdateDirectory(string directory)
        {
            CurrentDirectory = directory;
            TextBoxAddressText = directory;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method for update control variables. </summary>
        private void UpdateAfterNavigation()
        {
            CanGoBack = !string.IsNullOrEmpty(CurrentDirectory);
            CanGoForward = _historyForward != null && _historyForward.Any();
            SelectedFiles.Clear();
        }

        #endregion UPDATE METHODS

    }
}
