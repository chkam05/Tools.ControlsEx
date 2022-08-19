using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Events;
using chkam05.Tools.ControlsEx.Static;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using static chkam05.Tools.ControlsEx.Events.Delegates;

namespace chkam05.Tools.ControlsEx.InternalMessages
{
    public class BaseFilesSelectorInternalMessageEx : BaseInternalMessageEx<FilesSelectorInternalMessageCloseEventArgs>
    {

        //  CONST

        public static readonly string USER_PROFILE_PATH = Environment.GetEnvironmentVariable("USERPROFILE");
        protected static readonly string[] FORBIDDEN_CHARACTERS = new string[]
        {
            "/", "<", ">", ":", "\"", "|", "?", "*"
        };


        //  DEPENDENCY PROPERTIES

        #region Appearance TextBoxes Colors Properties

        public static readonly DependencyProperty TextBoxMouseOverBackgroundProperty = DependencyProperty.Register(
            nameof(TextBoxMouseOverBackground),
            typeof(Brush),
            typeof(BaseFilesSelectorInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty TextBoxMouseOverBorderBrushProperty = DependencyProperty.Register(
            nameof(TextBoxMouseOverBorderBrush),
            typeof(Brush),
            typeof(BaseFilesSelectorInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty TextBoxMouseOverForegroundProperty = DependencyProperty.Register(
            nameof(TextBoxMouseOverForeground),
            typeof(Brush),
            typeof(BaseFilesSelectorInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty TextBoxSelectedBackgroundProperty = DependencyProperty.Register(
            nameof(TextBoxSelectedBackground),
            typeof(Brush),
            typeof(BaseFilesSelectorInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty TextBoxSelectedBorderBrushProperty = DependencyProperty.Register(
            nameof(TextBoxSelectedBorderBrush),
            typeof(Brush),
            typeof(BaseFilesSelectorInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_PRESSED)));

        public static readonly DependencyProperty TextBoxSelectedForegroundProperty = DependencyProperty.Register(
            nameof(TextBoxSelectedForeground),
            typeof(Brush),
            typeof(BaseFilesSelectorInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty TextBoxSelectedTextBackgroundProperty = DependencyProperty.Register(
            nameof(TextBoxSelectedTextBackground),
            typeof(Brush),
            typeof(BaseFilesSelectorInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        #endregion Appearance TextBoxes Colors Properties

        public static readonly DependencyProperty AllowCreateProperty = DependencyProperty.Register(
            nameof(AllowCreate),
            typeof(bool),
            typeof(BaseFilesSelectorInternalMessageEx),
            new PropertyMetadata(false));

        public static readonly DependencyProperty FilesTypesProperty = DependencyProperty.Register(
            nameof(FilesTypes),
            typeof(ObservableCollection<InternalMessageFileType>),
            typeof(BaseFilesSelectorInternalMessageEx),
            new PropertyMetadata(new ObservableCollection<InternalMessageFileType>(
                new List<InternalMessageFileType>()
                {
                    InternalMessageFileType.AllFiles()
                }
            )));

        public static readonly DependencyProperty MultipleFilesProperty = DependencyProperty.Register(
            nameof(MultipleFiles),
            typeof(bool),
            typeof(BaseFilesSelectorInternalMessageEx),
            new PropertyMetadata(false));

        public static readonly DependencyProperty OnlyDirectoriesProperty = DependencyProperty.Register(
            nameof(OnlyDirectories),
            typeof(bool),
            typeof(BaseFilesSelectorInternalMessageEx),
            new PropertyMetadata(false));

        public static readonly DependencyProperty UseFilesTypesProperty = DependencyProperty.Register(
            nameof(UseFilesTypes),
            typeof(bool),
            typeof(BaseFilesSelectorInternalMessageEx),
            new PropertyMetadata(true));


        //  VARIABLES

        protected TextBoxEx _addressTextBox = null;
        protected TextBoxEx _filesTextBox = null;
        protected ComboBoxEx _filesTypesComboBox = null;

        private string _currentDirectory;
        private InternalMessageFileType _fileType;
        private List<string> _historyForward;
        private string _initialDirectory = USER_PROFILE_PATH;


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

        public string CurrentDirectory
        {
            get => _currentDirectory;
            protected set
            {
                _currentDirectory = value;
                OnPropertyChanged(nameof(CurrentDirectory));
            }
        }

        public InternalMessageFileType FileType
        {
            get => _fileType;
            protected set
            {
                _fileType = value;
                OnPropertyChanged(nameof(FileType));
            }
        }

        public string InitialDirectory
        {
            get => _initialDirectory;
            set
            {
                if (Directory.Exists(value))
                    _initialDirectory = value;
                OnPropertyChanged(nameof(InitialDirectory));
            }
        }

        public bool AllowCreate
        {
            get => (bool)GetValue(AllowCreateProperty);
            set
            {
                SetValue(AllowCreateProperty, value);
                OnPropertyChanged(nameof(AllowCreate));

                if (value == true)
                    MultipleFiles = false;
            }
        }

        public ObservableCollection<InternalMessageFileType> FilesTypes
        {
            get => (ObservableCollection<InternalMessageFileType>)GetValue(FilesTypesProperty);
            set
            {
                SetValue(FilesTypesProperty, value);
                OnPropertyChanged(nameof(FilesTypes));

                if (IsLoadingComplete)
                {
                    _fileType = FilesTypes.FirstOrDefault();
                    _filesTypesComboBox.SelectedItem = _fileType;
                }
            }
        }

        public bool MultipleFiles
        {
            get => (bool)GetValue(MultipleFilesProperty);
            set
            {
                SetValue(MultipleFilesProperty, value);
                OnPropertyChanged(nameof(MultipleFiles));

                if (value == true)
                {
                    AllowCreate = false;
                    OnlyDirectories = false;
                }
            }
        }

        public bool OnlyDirectories
        {
            get => (bool)GetValue(OnlyDirectoriesProperty);
            set
            {
                SetValue(OnlyDirectoriesProperty, value);
                OnPropertyChanged(nameof(OnlyDirectories));

                if (value == true)
                {
                    MultipleFiles = false;
                    UseFilesTypes = false;
                }
            }
        }

        public bool UseFilesTypes
        {
            get => (bool)GetValue(UseFilesTypesProperty);
            set
            {
                SetValue(UseFilesTypesProperty, value);
                OnPropertyChanged(nameof(UseFilesTypes));

                if (value == true)
                    OnlyDirectories = false;
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> BaseFilesSelectorInternalMessageEx class constructor. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        public BaseFilesSelectorInternalMessageEx(InternalMessagesExContainer parentContainer) : base(parentContainer)
        {
            _historyForward = new List<string>();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static BaseFilesSelectorInternalMessageEx class constructor. </summary>
        static BaseFilesSelectorInternalMessageEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseFilesSelectorInternalMessageEx),
                new FrameworkPropertyMetadata(typeof(BaseFilesSelectorInternalMessageEx)));
        }

        #endregion CLASS METHODS

        #region CHECKBOXES METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing file type selection. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Selection Changed Event Arguments. </param>
        private void OnFileTypeComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxEx = sender as ComboBoxEx;

            if (comboBoxEx != null && comboBoxEx.SelectedItem != null)
            {
                FileType = comboBoxEx.SelectedItem as InternalMessageFileType;
                OnNavigate();
            }
        }

        #endregion CHECKBOXES METHODS

        #region BUTTONS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Ok Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnBackClick(object sender, RoutedEventArgs e)
        {
            GoBack();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Ok Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnForwardClick(object sender, RoutedEventArgs e)
        {
            GoForward();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Ok Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnNavigateClick(object sender, RoutedEventArgs e)
        {
            Navigate(_addressTextBox.Text);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Ok Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnOkClick(object sender, RoutedEventArgs e)
        {
            Result = InternalMessageResult.Ok;
            Close();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Yes Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnCancelClick(object sender, RoutedEventArgs e)
        {
            Result = InternalMessageResult.Cancel;
            Close();
        }

        #endregion BUTTONS METHODS

        #region DATA METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Get list of files and directories inside selected path. </summary>
        /// <returns> List of files and directories. </returns>
        protected List<InternalMessageFileItem> GetFilesAndDirectories()
        {
            List<InternalMessageFileItem> result = new List<InternalMessageFileItem>();

            if (Directory.Exists(CurrentDirectory))
            {
                //  Get directories.
                foreach (var directoryPath in Directory.GetDirectories(CurrentDirectory))
                {
                    var fileInfo = new FileInfo(directoryPath);

                    if (fileInfo.Attributes.HasFlag(FileAttributes.Directory)
                        && !fileInfo.Attributes.HasFlag(FileAttributes.Hidden)
                        && !fileInfo.Attributes.HasFlag(FileAttributes.System))
                        result.Add(new InternalMessageFileItem(directoryPath));
                }

                //  Get files.
                if (!OnlyDirectories)
                {
                    var checkType = UseFilesTypes && FileType != null;

                    foreach (var filePath in Directory.GetFiles(CurrentDirectory))
                    {
                        var fileInfo = new FileInfo(filePath);

                        if (!fileInfo.Attributes.HasFlag(FileAttributes.Hidden)
                            && !fileInfo.Attributes.HasFlag(FileAttributes.System)
                            && (checkType ? FileType.MatchFile(Path.GetFileName(Path.GetFileName(filePath))) : true))
                            result.Add(new InternalMessageFileItem(filePath));
                    }
                }
            }

            //  Get drives.
            else if (string.IsNullOrEmpty(CurrentDirectory))
            {
                foreach (var drive in DriveInfo.GetDrives())
                {
                    if (Directory.Exists(drive.Name) || File.Exists(drive.Name))
                        result.Add(new InternalMessageFileItem(drive.Name));
                }
            }

            return result;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get list of directories with subdirectories tree. </summary>
        /// <returns> List of directories with subdirectories tree. </returns>
        protected List<InternalMessageFileTreeItem> GetDirectoriesTree()
        {
            List<InternalMessageFileTreeItem> result = new List<InternalMessageFileTreeItem>();
            List<string> hierarchy = GetTreeHierarchy();

            //  Get drives.
            foreach (var drive in DriveInfo.GetDrives())
            {
                if (Directory.Exists(drive.Name) || File.Exists(drive.Name))
                    result.Add(new InternalMessageFileTreeItem(drive.Name));
            }

            if (hierarchy.Any())
            {
                FillTreeContent(result.FirstOrDefault(t => t.Path == hierarchy[0]), hierarchy);
            }

            return result;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Fill nestings in list of directories. </summary>
        /// <param name="item"> Nested file tree item. </param>
        /// <param name="hierarchy"> List of paths forward. </param>
        private void FillTreeContent(InternalMessageFileTreeItem item, List<string> hierarchy)
        {
            if (item != null && hierarchy.Any())
            {
                foreach (var directoryPath in Directory.GetDirectories(hierarchy[0]))
                {
                    var fileInfo = new FileInfo(directoryPath);

                    if (fileInfo.Attributes.HasFlag(FileAttributes.Directory)
                        && !fileInfo.Attributes.HasFlag(FileAttributes.Hidden)
                        && !fileInfo.Attributes.HasFlag(FileAttributes.System))
                        item.SubDirectories.Add(new InternalMessageFileTreeItem(directoryPath));
                }

                hierarchy.RemoveAt(0);

                if (hierarchy.Any())
                {
                    FillTreeContent(item.SubDirectories.FirstOrDefault(t => t.Path == hierarchy[0]), hierarchy);
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get list of parent directories from selected directory. </summary>
        /// <returns> List of parent directories. </returns>
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

        #endregion DATA METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Create close method event arguments. </summary>
        /// <returns> Close method event arguments. </returns>
        protected override FilesSelectorInternalMessageCloseEventArgs CreateCloseEventArgs()
        {
            return new FilesSelectorInternalMessageCloseEventArgs(Result, null);
        }

        #endregion INTERACTION METHODS

        #region NAVIGATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Go to the directory above. </summary>
        protected void GoBack()
        {
            if (!string.IsNullOrEmpty(_currentDirectory))
            {
                var previousDirectory = Path.GetDirectoryName(CurrentDirectory);

                _historyForward.Insert(0, CurrentDirectory);

                CurrentDirectory = previousDirectory;
                _addressTextBox.Text = previousDirectory;
                OnNavigate();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Go to previous visited directory. </summary>
        protected void GoForward()
        {
            if (_historyForward != null && _historyForward.Any())
            {
                var forwardDirectory = _historyForward[0];

                if (Directory.Exists(forwardDirectory))
                {
                    _historyForward.RemoveAt(0);

                    CurrentDirectory = forwardDirectory;
                    _addressTextBox.Text = forwardDirectory;
                    OnNavigate();
                }
                else
                {
                    _historyForward.Clear();
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Navigate to specified directory. </summary>
        /// <param name="directoryPath"> Directory path. </param>
        protected void Navigate(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                _historyForward.Clear();
                _historyForward.Insert(0, CurrentDirectory);

                CurrentDirectory = directoryPath;
                _addressTextBox.Text = directoryPath;
                OnNavigate();
            }
            else
            {
                _addressTextBox.Text = CurrentDirectory;
            }
        }

        #endregion NAVIGATION METHODS

        #region TEMPLATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Apply Selection changed method on ComboBoxEx. </summary>
        /// <param name="comboBoxEx"> ComboBoxEx. </param>
        /// <param name="eventHandler"> Selection changed method. </param>
        protected void ApplyComboBoxExSelectionChangedMethod(ComboBoxEx comboBoxEx, SelectionChangedEventHandler eventHandler)
        {
            if (comboBoxEx != null)
                comboBoxEx.SelectionChanged += eventHandler;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Apply TextModified method on TextBoxEx. </summary>
        /// <param name="textBoxEx"> TextBoxEx. </param>
        /// <param name="eventHandler"> TextModified method. </param>
        protected void ApplyTextBoxExTextModifiedMethod(TextBoxEx textBoxEx, TextModifiedEventHandler eventHandler)
        {
            if (textBoxEx != null)
                textBoxEx.TextModified += eventHandler;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get TextBoxEx from GetComboBoxEx. </summary>
        /// <param name="comboBoxName"> GetComboBoxEx name. </param>
        /// <returns> GetComboBoxEx or null. </returns>
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
        /// <summary> When overridden in a derived class,cis invoked whenever 
        /// application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            //  Apply Template
            base.OnApplyTemplate();

            _currentDirectory = InitialDirectory;

            ApplyButtonExClickMethod(GetButtonEx("cancelButton"), OnCancelClick);
            ApplyButtonExClickMethod(GetButtonEx("okButton"), OnOkClick);
            ApplyButtonExClickMethod(GetButtonEx("backButton"), OnBackClick);
            ApplyButtonExClickMethod(GetButtonEx("forwardButton"), OnForwardClick);
            ApplyButtonExClickMethod(GetButtonEx("goButton"), OnNavigateClick);

            _addressTextBox = GetTextBoxEx("addressTextBox");
            _addressTextBox.Text = CurrentDirectory;
            _addressTextBox.PreviewKeyDown += OnAddressTextBoxExPreviewKeyDown;

            _filesTextBox = GetTextBoxEx("fileNameTextBox");
            _filesTextBox.Text = string.Empty;

            ApplyTextBoxExTextModifiedMethod(_addressTextBox, OnAddressTextBoxExTextModified);
            ApplyTextBoxExTextModifiedMethod(_filesTextBox, OnFileNameTextBoxExTextModified);

            _filesTypesComboBox = GetComboBoxEx("filesTypesComboBox");
            _fileType = FilesTypes.FirstOrDefault();
            _filesTypesComboBox.SelectedItem = _fileType;

            ApplyComboBoxExSelectionChangedMethod(_filesTypesComboBox, OnFileTypeComboBoxSelectionChanged);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after navigating / changing path for refresh data. </summary>
        protected virtual void OnNavigate()
        {
            //
        }

        #endregion TEMPLATE METHODS

        #region TEXTBOXES METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing text in AddressTextBoxEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Text Modified Event Arguments. </param>
        protected virtual void OnAddressTextBoxExTextModified(object sender, TextModifiedEventArgs e)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after pressing key in AddressTextBoxEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Key Event Arguments. </param>
        protected virtual void OnAddressTextBoxExPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Navigate(_addressTextBox.Text);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing text in FileNameTextBoxEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Text Modified Event Arguments. </param>
        protected virtual void OnFileNameTextBoxExTextModified(object sender, TextModifiedEventArgs e)
        {
            //
        }

        #endregion TEXTBOXES METHODS

        #region UTILITY METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Get list of files names from list in string available in fileNameTextBox. </summary>
        /// <param name="filesList"> List of files in string. </param>
        /// <returns> List of files names. </returns>
        protected List<string> GetFilesListFromString(string filesList)
        {
            if (!string.IsNullOrEmpty(filesList))
            {
                var matchList = Regex.Matches(filesList, "\"(.*?)\"");

                if (matchList.Count > 0)
                    return matchList.Cast<Match>().Select(match => ReplaceFilesInvalidCharacters(match.Value)).ToList();
                else
                    return new List<string>() { filesList };
            }

            return new List<string>();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Replace invalid characters in file name. </summary>
        /// <param name="fileName"> File name. </param>
        /// <returns> Corrected file name. </returns>
        protected string ReplaceFilesInvalidCharacters(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                var updatedFileName = fileName;

                foreach (var character in FORBIDDEN_CHARACTERS)
                    updatedFileName = updatedFileName.Replace(character, "");

                return updatedFileName;
            }

            return fileName;
        }

        #endregion UTILITY METHODS

    }
}
