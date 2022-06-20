using chkam05.Tools.ControlsEx.Events;
using chkam05.Tools.ControlsEx.Example.Data.Config;
using chkam05.Tools.ControlsEx.Example.Windows;
using chkam05.Tools.ControlsEx.InternalMessages;
using chkam05.Tools.ControlsEx.Static;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
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
        /// <param name="progressInternalMessageEx"> Progress internal message. </param>
        /// <param name="tick"> Tick time. </param>
        /// <returns> Background worker. </returns>
        private BackgroundWorker CreateBackgroundWorker(ProgressInternalMessageEx progressInternalMessageEx, TimeSpan tick)
        {
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;

            int progress = (int) progressInternalMessageEx.ProgressMin;
            int maxProgress = (int)progressInternalMessageEx.ProgressMax;
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
                progressInternalMessageEx.InvokeProgressChange(e.ProgressPercentage);
            };

            backgroundWorker.RunWorkerCompleted += (s, e) =>
            {
                if (isCanceled)
                    progressInternalMessageEx.InvokeFinish(InternalMessageResult.Cancel);
                else
                    progressInternalMessageEx.InvokeFinish();
            };

            return backgroundWorker;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create background worker for testing ProgressInternalMessageEx. </summary>
        /// <param name="progressInternalMessageEx"> Progress internal message. </param>
        /// <param name="tick"> Tick time. </param>
        /// <returns> Background worker. </returns>
        private BackgroundWorker CreateBackgroundWorker(AwaitInternalMessageEx progressInternalMessageEx, TimeSpan tick)
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
                if (isCanceled)
                    progressInternalMessageEx.InvokeFinish(InternalMessageResult.Cancel);
                else
                    progressInternalMessageEx.InvokeFinish();
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
            _mainWindow.InternalMessages.ShowHidden();
            MessageHidden = _mainWindow.InternalMessages.HasHidden;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Info IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void InfoIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var message = _mainWindow.InternalMessages.CreateDefaultMessage("Info Message Test", "This is message example text",
                onClose: OnMessageClose, onHide: OnMessageHide);

            UpdateInternalMessageAppearance(message);
        }
        
        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Info IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void QuestionIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var message = _mainWindow.InternalMessages.CreateDefaultMessage("Question Message Test", "This is message example text",
                PackIconKind.QuestionMarkCircle, InternalMessageButtons.YesNo,
                onClose: OnMessageClose, onHide: OnMessageHide);

            UpdateInternalMessageAppearance(message);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Info IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void AlertIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var message = _mainWindow.InternalMessages.CreateDefaultMessage("Alert Message Test", "This is message example text",
                PackIconKind.Alert, InternalMessageButtons.OkCancel,
                onClose: OnMessageClose, onHide: OnMessageHide);

            UpdateInternalMessageAppearance(message);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Info IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void ErrorIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var message = _mainWindow.InternalMessages.CreateDefaultMessage("Alert Message Test", "This is message example text",
                PackIconKind.Alert, InternalMessageButtons.Ok,
                onClose: OnMessageClose, onHide: OnMessageHide);

            UpdateInternalMessageAppearance(message);
        }
        
        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Info IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void ProgressIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var message = _mainWindow.InternalMessages.CreateDefaultProgressMessage(
                "Progress Message Test", "This is message example text",
                onClose: OnMessageClose, onHide: OnMessageHide);

            UpdateInternalMessageAppearance(message);
            CreateBackgroundWorker(message, TimeSpan.FromMilliseconds(25)).RunWorkerAsync();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Info IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void CancelableProgressIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var message = _mainWindow.InternalMessages.CreateDefaultProgressMessage(
                "Progress Message Test", "This is message example text",
                onClose: OnMessageClose, onHide: OnMessageHide);

            message.AllowCancel = true;
            UpdateInternalMessageAppearance(message);
            var bgWorker = CreateBackgroundWorker(message, TimeSpan.FromMilliseconds(25));

            message.ProgressCancel += (s, ce) =>
            {
                if (ce.Result == InternalMessageResult.Cancel)
                    bgWorker.CancelAsync();
            };

            bgWorker.RunWorkerAsync();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Info IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void HideableProgressIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var message = _mainWindow.InternalMessages.CreateDefaultProgressMessage(
                "Progress Message Test", "This is message example text",
                onClose: OnMessageClose, onHide: OnMessageHide);

            message.AllowHide = true;
            message.KeepOnScreenCompleted = true;
            UpdateInternalMessageAppearance(message);
            CreateBackgroundWorker(message, TimeSpan.FromMilliseconds(25)).RunWorkerAsync();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Info IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void KeepAliveProgressIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var message = _mainWindow.InternalMessages.CreateDefaultProgressMessage(
                "Progress Message Test", "This is message example text",
                onClose: OnMessageClose, onHide: OnMessageHide);

            message.AllowCancel = true;
            message.KeepOnScreenCompleted = true;
            UpdateInternalMessageAppearance(message);
            var bgWorker = CreateBackgroundWorker(message, TimeSpan.FromMilliseconds(25));

            message.ProgressCancel += (s, ce) =>
            {
                if (ce.Result == InternalMessageResult.Cancel)
                    bgWorker.CancelAsync();
            };

            bgWorker.RunWorkerAsync();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Info IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void AwaitIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var message = _mainWindow.InternalMessages.CreateDefaultAwaitMessage(
                "Progress Message Test", "This is message example text",
                onClose: OnMessageClose, onHide: OnMessageHide);

            UpdateInternalMessageAppearance(message);
            CreateBackgroundWorker(message, TimeSpan.FromMilliseconds(50)).RunWorkerAsync();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Info IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void CancelableAwaitIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var message = _mainWindow.InternalMessages.CreateDefaultAwaitMessage(
                "Progress Message Test", "This is message example text",
                onClose: OnMessageClose, onHide: OnMessageHide);

            var bgWorker = CreateBackgroundWorker(message, TimeSpan.FromMilliseconds(50));

            message.AllowCancel = true;
            UpdateInternalMessageAppearance(message);
            message.IndicatorFill = Configuration.AccentColorBrush;
            message.IndicatorPen = Configuration.AccentColorBrush;
            message.IndicatorPenThickness = new Thickness(1);
            message.ProgressCancel += (s, ce) =>
            {
                if (ce.Result == InternalMessageResult.Cancel)
                    bgWorker.CancelAsync();
            };

            bgWorker.RunWorkerAsync();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Info IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void HideableAwaitIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var message = _mainWindow.InternalMessages.CreateDefaultAwaitMessage(
                "Progress Message Test", "This is message example text",
                onClose: OnMessageClose, onHide: OnMessageHide);

            message.AllowHide = true;
            UpdateInternalMessageAppearance(message);
            message.IndicatorFill = Configuration.AccentColorBrush;
            message.IndicatorPen = Configuration.AccentColorBrush;
            message.IndicatorPenThickness = new Thickness(1);
            message.KeepOnScreenCompleted = true;

            CreateBackgroundWorker(message, TimeSpan.FromMilliseconds(50)).RunWorkerAsync();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Info IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void KeepAliveAwaitIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var message = _mainWindow.InternalMessages.CreateDefaultAwaitMessage(
                "Progress Message Test", "This is message example text",
                onClose: OnMessageClose, onHide: OnMessageHide);

            var bgWorker = CreateBackgroundWorker(message, TimeSpan.FromMilliseconds(50));

            message.AllowCancel = true;
            UpdateInternalMessageAppearance(message);
            message.IndicatorFill = Configuration.AccentColorBrush;
            message.IndicatorPen = Configuration.AccentColorBrush;
            message.IndicatorPenThickness = new Thickness(1);
            message.KeepOnScreenCompleted = true;
            message.ProgressCancel += (s, ce) =>
            {
                if (ce.Result == InternalMessageResult.Cancel)
                    bgWorker.CancelAsync();
            };

            bgWorker.RunWorkerAsync();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Open File IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void OpenFileIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var message = _mainWindow.InternalMessages.CreateDefaultOpenFilesMessage(
                "Open File", onClose: OnFileMessageClose);

            UpdateInternalMessageAppearance(message);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Open Files IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void OpenFilesIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Save File IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void SaveFileIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Select Folder IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void SelectFolderIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            //
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
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after closing InternalMessage. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Internal Message Close Event Arguments. </param>
        private void OnFileMessageClose(object sender, FilesInternalMessageCloseEventArgs e)
        {
            LastResult = e.Result;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after hiding InternalMessage. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Internal Message Close Event Arguments. </param>
        private void OnMessageHide(object sender, InternalMessageHideEventArgs e)
        {
            MessageHidden = e.IsHidden;
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
        private void UpdateInternalMessageAppearance(BaseInternalMessageEx message)
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
                var progressMessage = (BaseProgressInternalMessageEx)message;
                progressMessage.ProgressBarBorderBrush = Configuration.AccentColorBrush;
                progressMessage.ProgressBarProgressBrush = Configuration.AccentColorBrush;
            }

            if (message.GetType().IsSubclassOf(typeof(BaseAwaitInternalMessageEx)))
            {
                var awaitMessage = (BaseAwaitInternalMessageEx)message;
                awaitMessage.IndicatorFill = Configuration.AccentColorBrush;
                awaitMessage.IndicatorPen = Configuration.AccentColorBrush;
                awaitMessage.IndicatorPenThickness = new Thickness(1);
            }

            if (message.GetType().IsSubclassOf(typeof(BaseFilesInternalMessageEx)))
            {
                var filesMessage = (BaseFilesInternalMessageEx)message;
                filesMessage.TextBoxMouseOverBackground = Configuration.AccentMouseOverColorBrush;
                filesMessage.TextBoxMouseOverBorderBrush = Configuration.AccentColorBrush;
                filesMessage.TextBoxMouseOverForeground = Configuration.AccentForegroundColorBrush;
                filesMessage.TextBoxSelectedBackground = Configuration.BackgroundColorBrush;
                filesMessage.TextBoxSelectedBorderBrush = Configuration.AccentSelectedColorBrush;
                filesMessage.TextBoxSelectedForeground = Configuration.ForegroundColorBrush;
                filesMessage.TextBoxSelectedTextBackground = Configuration.AccentSelectedColorBrush;
            }
        }

        #endregion UPDATE METHODS

    }
}
