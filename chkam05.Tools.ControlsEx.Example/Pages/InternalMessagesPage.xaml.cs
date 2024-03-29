﻿using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Events;
using chkam05.Tools.ControlsEx.Example.Data.Config;
using chkam05.Tools.ControlsEx.Example.ExtendedControls;
using chkam05.Tools.ControlsEx.Example.Windows;
using chkam05.Tools.ControlsEx.InternalMessages;
//using chkam05.Tools.ControlsEx.InternalMessages;
using chkam05.Tools.ControlsEx.Static;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace chkam05.Tools.ControlsEx.Example.Pages
{
    public partial class InternalMessagesPage : Page, INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private InternalMessageResult _lastResult = InternalMessageResult.None;
        private bool _messageHidden = false;
        private string _optionalKey = "";
        private string _optionalValue = "";
        private MainWindow _mainWindow;

        public Configuration Configuration { get; private set; }


        //  GETTERS & SETTERS

        public bool MessageHidden
        {
            get => _messageHidden;
            set
            {
                _messageHidden = value;
                OnPropertyChanged(nameof(MessageHidden));
            }
        }

        public InternalMessageResult LastResult
        {
            get => _lastResult;
            set
            {
                _lastResult = value;
                OnPropertyChanged(nameof(LastResult));
            }
        }

        public string OptionalKey
        {
            get => _optionalKey;
            set
            {
                _optionalKey = value;
                OnPropertyChanged(nameof(OptionalKey));
            }
        }

        public string OptionalValue
        {
            get => _optionalValue;
            set
            {
                _optionalValue = value;
                OnPropertyChanged(nameof(OptionalValue));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> InternalMessagesPage class constructor. </summary>
        public InternalMessagesPage()
        {
            //  Initialize values.
            _mainWindow = ((App) Application.Current).MainWindow as MainWindow;

            //  Initialize data containers.
            Configuration = Configuration.Instance;

            //  Initialize interface components.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region BACKGROUND WORKER METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Create background worker for testing ProgressInternalMessageEx. </summary>
        /// <param name="message"> Progress internal message. </param>
        /// <param name="tick"> Tick time. </param>
        /// <returns> Background worker. </returns>
        private BackgroundWorker CreateBackgroundWorker(BaseProgressInternalMessageEx message, TimeSpan tick)
        {
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;

            int progress = (int) message.ProgressMin;
            int maxProgress = (int)message.ProgressMax;
            bool isCanceled = false;

            backgroundWorker.DoWork += (s, e) =>
            {
                while (progress < maxProgress)
                {
                    if (backgroundWorker.CancellationPending)
                    {
                        isCanceled = true;
                        break;
                    }

                    progress++;
                    backgroundWorker.ReportProgress(progress);

                    Thread.Sleep(tick.Milliseconds);
                }
            };

            backgroundWorker.ProgressChanged += (s, e) =>
            {
                message.DispatcherInvoker.TryInvoke(() => { message.Progress = e.ProgressPercentage; });
            };

            backgroundWorker.RunWorkerCompleted += (s, e) =>
            {
                message.InvokeFinsh(!isCanceled);
            };

            return backgroundWorker;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create background worker for testing ProgressInternalMessageEx. </summary>
        /// <param name="message"> Progress internal message. </param>
        /// <param name="tick"> Tick time. </param>
        /// <returns> Background worker. </returns>
        private BackgroundWorker CreateBackgroundWorker(BaseAwaitInternalMessageEx message, TimeSpan tick)
        {
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;

            int progress = 0;
            int maxProgress = 100;
            bool isCanceled = false;

            backgroundWorker.DoWork += (s, e) =>
            {
                while (progress < maxProgress)
                {
                    if (backgroundWorker.CancellationPending)
                    {
                        isCanceled = true;
                        break;
                    }

                    progress++;
                    backgroundWorker.ReportProgress(progress);

                    Thread.Sleep(tick.Milliseconds);
                }
            };

            backgroundWorker.RunWorkerCompleted += (s, e) =>
            {
                message.InvokeFinsh(!isCanceled);
            };

            return backgroundWorker;
        }

        #endregion BACKGROUND WORKER METHODS

        #region INTERACTION METHODS
        
        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Show Hidden Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void ShowMessageButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var internalMessages = _mainWindow.InternalMessages;
            internalMessages.ShowLastHiddenMessage();
            MessageHidden = internalMessages.HasHidden;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Empty Standard IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void EmptyStandardIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var internalMessages = _mainWindow.InternalMessages;
            var message = new StandardInternalMessageEx(internalMessages)
            {
                Buttons = new InternalMessageButtons[]
                {
                    InternalMessageButtons.OkButton,
                    InternalMessageButtons.CancelButton,
                },
                IconKind = PackIconKind.Application,
                Title = "Standard Empty IM"
            };

            message.OnClose += OnMessageClose;

            UpdateInternalMessageAppearance(message);
            internalMessages.ShowMessage(message);
        }
        
        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Empty Standard Hideable IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void EmptyStandardHideableIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var internalMessages = _mainWindow.InternalMessages;
            var message = new StandardInternalMessageEx(internalMessages)
            {
                AllowHide = true,
                Buttons = new InternalMessageButtons[]
                {
                    InternalMessageButtons.OkButton,
                    InternalMessageButtons.CancelButton,
                },
                IconKind = PackIconKind.Application,
                Title = "Standard Hideable Empty IM"
            };

            message.OnClose += OnMessageClose;
            message.OnHide += OnMessageHide;

            UpdateInternalMessageAppearance(message);
            internalMessages.ShowMessage(message);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Extended List IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void ExtendedListIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var internalMessages = _mainWindow.InternalMessages;
            var message = new ListViewInternalMessageEx(internalMessages);

            message.OnClose += OnMessageClose;
            message.OnHide += OnMessageHide;

            internalMessages.ShowMessage(message);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Info IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void AlertIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var internalMessages = _mainWindow.InternalMessages;
            var message = InternalMessageEx.CreateAlertMessage(internalMessages, "Alert", "Alert message example.");

            message.OnClose += OnMessageClose;
            message.OnHide += OnMessageHide;

            UpdateInternalMessageAppearance(message);
            internalMessages.ShowMessage(message);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Info IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void ErrorIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var internalMessages = _mainWindow.InternalMessages;
            var message = InternalMessageEx.CreateErrorMessage(internalMessages, "Error", "Alert message example.");

            message.OnClose += OnMessageClose;
            message.OnHide += OnMessageHide;

            UpdateInternalMessageAppearance(message);
            internalMessages.ShowMessage(message);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Info IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void InfoIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var internalMessages = _mainWindow.InternalMessages;
            var message = InternalMessageEx.CreateInfoMessage(internalMessages, "Info", "Alert message example.");

            message.OnClose += OnMessageClose;
            message.OnHide += OnMessageHide;

            UpdateInternalMessageAppearance(message);
            internalMessages.ShowMessage(message);
        }
        
        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Info IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void QuestionIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var internalMessages = _mainWindow.InternalMessages;
            var message = InternalMessageEx.CreateQuestionMessage(internalMessages, "Question", "Alert message example.");

            message.OnClose += OnMessageClose;
            message.OnHide += OnMessageHide;

            UpdateInternalMessageAppearance(message);
            internalMessages.ShowMessage(message);
        }
        
        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Info IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void ProgressIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var internalMessages = _mainWindow.InternalMessages;
            var message = new ProgressInternalMessageEx(internalMessages, "Test progress", "Test progress in progress...")
            {
                KeepFinishedOpen = true
            };
            var bgWorker = CreateBackgroundWorker(message, TimeSpan.FromMilliseconds(25));

            message.OnClose += OnMessageClose;

            UpdateInternalMessageAppearance(message);
            internalMessages.ShowMessage(message);
            bgWorker.RunWorkerAsync();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Info IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void CancelableProgressIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var internalMessages = _mainWindow.InternalMessages;
            var message = new ProgressInternalMessageEx(internalMessages, "Test progress", "Test progress in progress...")
            {
                AllowCancel = true,
                KeepFinishedOpen = true
            };
            var bgWorker = CreateBackgroundWorker(message, TimeSpan.FromMilliseconds(25));

            message.OnClose += (s, ie) =>
            {
                if (ie.Result == InternalMessageResult.Cancel && bgWorker.IsBusy)
                    bgWorker.CancelAsync();

                OnMessageClose(s, ie);
            };

            UpdateInternalMessageAppearance(message);
            internalMessages.ShowMessage(message);
            bgWorker.RunWorkerAsync();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Info IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void HideableProgressIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var internalMessages = _mainWindow.InternalMessages;
            var message = new ProgressInternalMessageEx(internalMessages, "Test progress", "Test progress in progress...")
            {
                AllowHide = true,
                KeepFinishedOpen = true
            };
            var bgWorker = CreateBackgroundWorker(message, TimeSpan.FromMilliseconds(25));

            message.OnClose += OnMessageClose;
            message.OnHide += OnMessageHide;

            UpdateInternalMessageAppearance(message);
            internalMessages.ShowMessage(message);
            bgWorker.RunWorkerAsync();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Info IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void AwaitIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var internalMessages = _mainWindow.InternalMessages;
            var message = new AwaitInternalMessageEx(internalMessages, "Test progress", "Test progress in progress...")
            {
                KeepFinishedOpen = true
            };
            var bgWorker = CreateBackgroundWorker(message, TimeSpan.FromMilliseconds(25));

            message.OnClose += OnMessageClose;

            UpdateInternalMessageAppearance(message);
            internalMessages.ShowMessage(message);
            bgWorker.RunWorkerAsync();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Info IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void CancelableAwaitIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var internalMessages = _mainWindow.InternalMessages;
            var message = new AwaitInternalMessageEx(internalMessages, "Test progress", "Test progress in progress...")
            {
                AllowCancel = true,
                KeepFinishedOpen = true
            };
            var bgWorker = CreateBackgroundWorker(message, TimeSpan.FromMilliseconds(25));

            message.OnClose += (s, ie) =>
            {
                if (ie.Result == InternalMessageResult.Cancel && bgWorker.IsBusy)
                    bgWorker.CancelAsync();

                OnMessageClose(s, ie);
            };

            UpdateInternalMessageAppearance(message);
            internalMessages.ShowMessage(message);
            bgWorker.RunWorkerAsync();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Info IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void HideableAwaitIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var internalMessages = _mainWindow.InternalMessages;
            var message = new AwaitInternalMessageEx(internalMessages, "Test progress", "Test progress in progress...")
            {
                AllowHide = true,
                KeepFinishedOpen = true
            };
            var bgWorker = CreateBackgroundWorker(message, TimeSpan.FromMilliseconds(25));

            message.OnClose += OnMessageClose;
            message.OnHide += OnMessageHide;

            UpdateInternalMessageAppearance(message);
            internalMessages.ShowMessage(message);
            bgWorker.RunWorkerAsync();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Open File IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void OpenFileIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var internalMessages = _mainWindow.InternalMessages;
            var message = FilesSelectorInternalMessageEx.CreateOpenFileInternalMessageEx(internalMessages);

            message.OnClose += OnFileMessageClose;
            message.FilesTypes = new ObservableCollection<InternalMessageFileType>()
            {
                new InternalMessageFileType("All Files", new string[] { "*.*" }),
                new InternalMessageFileType("Image Files", new string[] { "*.bmp", "*.jpeg", "*.jpg", "*.png" }),
                new InternalMessageFileType("Music Files", new string[] { "*.mp3", "*.ogg", "*.wav" }),
                new InternalMessageFileType("Text Files", new string[] { "*.txt" })
            };

            UpdateInternalMessageAppearance(message);
            internalMessages.ShowMessage(message);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Open Files IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void OpenFilesIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var internalMessages = _mainWindow.InternalMessages;
            var message = FilesSelectorInternalMessageEx.CreateOpenFileInternalMessageEx(internalMessages, "Select files");

            message.MultipleFiles = true;
            message.OnClose += OnFileMessageClose;
            message.FilesTypes = new ObservableCollection<InternalMessageFileType>()
            {
                new InternalMessageFileType("All Files", new string[] { "*.*" }),
                new InternalMessageFileType("Image Files", new string[] { "*.bmp", "*.jpeg", "*.jpg", "*.png" }),
                new InternalMessageFileType("Music Files", new string[] { "*.mp3", "*.ogg", "*.wav" }),
                new InternalMessageFileType("Text Files", new string[] { "*.txt" })
            };

            UpdateInternalMessageAppearance(message);
            internalMessages.ShowMessage(message);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Save File IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void SaveFileIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var internalMessages = _mainWindow.InternalMessages;
            var message = FilesSelectorInternalMessageEx.CreateSaveFileInternalMessageEx(internalMessages);

            message.OnClose += OnFileMessageClose;
            message.FilesTypes = new ObservableCollection<InternalMessageFileType>()
            {
                new InternalMessageFileType("All Files", new string[] { "*.*" }),
                new InternalMessageFileType("Text Files", new string[] { "*.txt" })
            };

            UpdateInternalMessageAppearance(message);
            internalMessages.ShowMessage(message);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Select Folder IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void SelectFolderIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var internalMessages = _mainWindow.InternalMessages;
            var message = FilesSelectorInternalMessageEx.CreateSelectDirectoryInternalMessageEx(internalMessages);

            message.OnClose += OnFileMessageClose;

            UpdateInternalMessageAppearance(message);
            internalMessages.ShowMessage(message);
        }
        
        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Select Folder IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void OpenPaletteColorIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var internalMessages = _mainWindow.InternalMessages;
            var message = new ColorsPaletteInternalMessageEx(internalMessages);

            message.OnClose += OnColorMessageClose;

            UpdateInternalMessageAppearance(message);
            internalMessages.ShowMessage(message);
        }
        
        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Select Folder IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void OpenPickerColorIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var internalMessages = _mainWindow.InternalMessages;
            var message = new ColorsPickerInternalMessageEx(internalMessages);

            message.OnClose += OnColorMessageClose;

            UpdateInternalMessageAppearance(message);
            internalMessages.ShowMessage(message);
        }

        #endregion INTERACTION METHODS

        #region MESSAGES RESULT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after closing InternalMessage. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Internal Message Close Event Arguments. </param>
        private void OnMessageClose(object sender, InternalMessageCloseEventArgs e)
        {
            LastResult = e.Result;
            OptionalKey = string.Empty;
            OptionalValue = string.Empty;
        }
        
        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after closing InternalMessage. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Internal Message Close Event Arguments. </param>
        private void OnColorMessageClose(object sender, ColorSelectorInternalMessageCloseEventArgs e)
        {
            LastResult = e.Result;
            OptionalKey = nameof(e.Color);
            OptionalValue = $"{e.ColorName} [{e.ColorCode}]";
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after closing InternalMessage. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Internal Message Close Event Arguments. </param>
        private void OnFileMessageClose(object sender, FilesSelectorInternalMessageCloseEventArgs e)
        {
            LastResult = e.Result;
            OptionalKey = nameof(e.FilePath);
            OptionalValue = e.FilePath ?? string.Empty;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after hiding InternalMessage. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Internal Message Close Event Arguments. </param>
        private void OnMessageHide(object sender, InternalMessageHideEventArgs e)
        {
            MessageHidden = e.Hidden;
            OptionalKey = string.Empty;
            OptionalValue = string.Empty;
        }

        #endregion MESSAGES RESULT METHODS

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

        #region UPDATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Update Internal Message appearance. </summary>
        /// <param name="message"> Internal Message. </param>
        private void UpdateInternalMessageAppearance<T>(BaseInternalMessageEx<T> message) where T : InternalMessageCloseEventArgs
        {
            message.Background = Configuration.BackgroundColorBrush;
            message.BorderBrush = Configuration.AccentColorBrush;
            message.Foreground = Configuration.ForegroundColorBrush;
            message.ButtonBackground = Configuration.AccentColorBrush;
            message.ButtonBorderBrush = Configuration.AccentColorBrush;
            message.ButtonForeground = Configuration.AccentForegroundColorBrush;
            message.ButtonMouseOverBackground = Configuration.AccentMouseOverColorBrush;
            message.ButtonMouseOverBorderBrush = Configuration.AccentMouseOverColorBrush;
            message.ButtonMouseOverForeground = Configuration.AccentForegroundColorBrush;
            message.ButtonPressedBackground = Configuration.AccentPressedColorBrush;
            message.ButtonPressedBorderBrush = Configuration.AccentPressedColorBrush;
            message.ButtonPressedForeground = Configuration.AccentForegroundColorBrush;

            if (message.GetType().IsSubclassOf(typeof(BaseProgressInternalMessageEx)))
            {
                var progressMessage = message as BaseProgressInternalMessageEx;
                progressMessage.ProgressBarBorderBrush = Configuration.AccentColorBrush;
                progressMessage.ProgressBarProgressBrush = Configuration.AccentColorBrush;
            }

            if (message.GetType().IsSubclassOf(typeof(BaseAwaitInternalMessageEx)))
            {
                var awaitMessage = message as BaseAwaitInternalMessageEx;
                awaitMessage.IndicatorFill = Configuration.AccentColorBrush;
                awaitMessage.IndicatorPen = Configuration.AccentColorBrush;
            }

            if (message.GetType().IsSubclassOf(typeof(ColorsPickerInternalMessageEx)))
            {
                var pickerMessage = message as ColorsPickerInternalMessageEx;
                pickerMessage.ColorComponentMouseOverBackground = Configuration.AccentMouseOverColorBrush;
                pickerMessage.ColorComponentMouseOverBorderBrush = Configuration.AccentColorBrush;
                pickerMessage.ColorComponentMouseOverForeground = Configuration.AccentForegroundColorBrush;
                pickerMessage.ColorComponentSelectedBackground = Configuration.BackgroundColorBrush;
                pickerMessage.ColorComponentSelectedBorderBrush = Configuration.AccentSelectedColorBrush;
                pickerMessage.ColorComponentSelectedForeground = Configuration.ForegroundColorBrush;
                pickerMessage.ColorComponentSelectedTextBackground = Configuration.AccentSelectedColorBrush;
            }

            if (message.GetType().IsSubclassOf(typeof(BaseFilesSelectorInternalMessageEx)))
            {
                var fileMessage = message as BaseFilesSelectorInternalMessageEx;

                fileMessage.TextBoxMouseOverBackground = Configuration.AccentMouseOverColorBrush;
                fileMessage.TextBoxMouseOverBorderBrush = Configuration.AccentColorBrush;
                fileMessage.TextBoxMouseOverForeground = Configuration.AccentForegroundColorBrush;
                fileMessage.TextBoxSelectedBackground = Configuration.BackgroundColorBrush;
                fileMessage.TextBoxSelectedBorderBrush = Configuration.AccentSelectedColorBrush;
                fileMessage.TextBoxSelectedForeground = Configuration.ForegroundColorBrush;
                fileMessage.TextBoxSelectedTextBackground = Configuration.AccentSelectedColorBrush;
            }
        }

        #endregion UPDATE METHODS

    }
}
