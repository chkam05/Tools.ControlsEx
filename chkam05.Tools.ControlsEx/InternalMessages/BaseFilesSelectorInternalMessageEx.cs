using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Events;
using chkam05.Tools.ControlsEx.Static;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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


        //  VARIABLES

        private TextBoxEx _addressTextBox = null;
        private TextBoxEx _filesTextBox = null;

        private string _currentDirectory;
        private List<string> _historyForward;
        private string _initialDirectory = Environment.GetEnvironmentVariable("USERPROFILE");


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
        protected void GetFilesAndDirectories()
        {
            //  Get base directories and files.
            if (Directory.Exists(CurrentDirectory))
            {
                foreach (var dir in Directory.GetDirectories(CurrentDirectory))
                {
                    var fileInfo = new FileInfo(dir);

                    //if (fileInfo.Attributes.HasFlag(FileAttributes.Directory)
                        //&& !fileInfo.Attributes.HasFlag(FileAttributes.Hidden)
                        //&& !fileInfo.Attributes.HasFlag(FileAttributes.System))
                        //result.Add(new FileItem(dir));
                }

                //if (SelectionType != FilesInternalMessageExSelectionType.DirectoryCreate
                //    && SelectionType != FilesInternalMessageExSelectionType.DirectorySelect)
                {
                    foreach (var file in Directory.GetFiles(CurrentDirectory))
                    {
                        var fileInfo = new FileInfo(file);

                        //if (!fileInfo.Attributes.HasFlag(FileAttributes.Hidden)
                        //    && !fileInfo.Attributes.HasFlag(FileAttributes.System)
                            //&& (SelectedFileType?.ValidateFileName(Path.GetFileName(file)) ?? true))
                            //result.Add(new FileItem(file));
                    }
                }
            }
            //  Get drives.
            else if (string.IsNullOrEmpty(CurrentDirectory))
            {
                foreach (var drive in DriveInfo.GetDrives())
                {
                    //if (Directory.Exists(drive.Name) || File.Exists(drive.Name))
                        //result.Add(new FileItem(drive.Name));
                }
            }
        }

        //  --------------------------------------------------------------------------------
        protected void GetDirectoriesTree()
        {
            List<string> hierarchy = GetTreeHierarchy();

            //  Get drives.
            foreach (var drive in DriveInfo.GetDrives())
            {
                //if (Directory.Exists(drive.Name) || File.Exists(drive.Name))
                    //result.Add(new FileTreeItem(drive.Name));
            }

            if (hierarchy.Any())
            {
                //FillTreeContent(result.FirstOrDefault(t => t.Path == hierarchy[0]), hierarchy);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Fill nestings in list of directories. </summary>
        /// <param name="item"> Nested directory item. </param>
        /// <param name="hierarchy"> List of paths forward. </param>
        private void FillTreeContent(object item, List<string> hierarchy)
        {
            if (item != null && hierarchy.Any())
            {
                foreach (var dir in Directory.GetDirectories(hierarchy[0]))
                {
                    var fileInfo = new FileInfo(dir);

                    //if (fileInfo.Attributes.HasFlag(FileAttributes.Directory)
                        //&& !fileInfo.Attributes.HasFlag(FileAttributes.Hidden)
                        //&& !fileInfo.Attributes.HasFlag(FileAttributes.System))
                        //item.Childs.Add(new FileTreeItem(dir));
                }

                hierarchy.RemoveAt(0);

                if (hierarchy.Any())
                {
                    //FillTreeContent(item.Childs.FirstOrDefault(t => t.Path == hierarchy[0]), hierarchy);
                }
            }
        }

        //  --------------------------------------------------------------------------------
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
        /// <summary> Apply TextModified method on TextBoxEx. </summary>
        /// <param name="textBoxEx"> TextBoxEx. </param>
        /// <param name="eventHandler"> TextModified method. </param>
        protected void ApplyTextBoxExTextModifiedMethod(TextBoxEx textBoxEx, TextModifiedEventHandler eventHandler)
        {
            if (textBoxEx != null)
                textBoxEx.TextModified += eventHandler;
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
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after navigating / changing path. </summary>
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

    }
}
