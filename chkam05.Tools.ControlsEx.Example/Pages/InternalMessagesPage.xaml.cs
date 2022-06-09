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
        private BackgroundWorker CreateBackgroundWorker(IProgressInternalMessageEx progressInternalMessageEx, TimeSpan tick)
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

            message.Background = Configuration.BackgroundColorBrush;
            message.BorderBrush = Configuration.AccentColorBrush;
            message.Foreground = Configuration.ForegroundColorBrush;
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

            message.Background = Configuration.BackgroundColorBrush;
            message.BorderBrush = Configuration.AccentColorBrush;
            message.Foreground = Configuration.ForegroundColorBrush;
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

            message.Background = Configuration.BackgroundColorBrush;
            message.BorderBrush = Configuration.AccentColorBrush;
            message.Foreground = Configuration.ForegroundColorBrush;
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

            message.Background = Configuration.BackgroundColorBrush;
            message.BorderBrush = Configuration.AccentColorBrush;
            message.Foreground = Configuration.ForegroundColorBrush;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Info IM Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void HideableIMButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var message = _mainWindow.InternalMessages.CreateDefaultMessage(
                "Alert Message Test", "This is message example text",
                PackIconKind.Hide, InternalMessageButtons.Ok,
                onClose: OnMessageClose, onHide: OnMessageHide);

            message.AllowHide = true;
            message.Background = Configuration.BackgroundColorBrush;
            message.BorderBrush = Configuration.AccentColorBrush;
            message.Foreground = Configuration.ForegroundColorBrush;
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

            message.Background = Configuration.BackgroundColorBrush;
            message.BorderBrush = Configuration.AccentColorBrush;
            message.Foreground = Configuration.ForegroundColorBrush;

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

            var bgWorker = CreateBackgroundWorker(message, TimeSpan.FromMilliseconds(25));

            message.AllowCancel = true;
            message.Background = Configuration.BackgroundColorBrush;
            message.BorderBrush = Configuration.AccentColorBrush;
            message.Foreground = Configuration.ForegroundColorBrush;
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
            message.Background = Configuration.BackgroundColorBrush;
            message.BorderBrush = Configuration.AccentColorBrush;
            message.Foreground = Configuration.ForegroundColorBrush;
            message.KeepOnScreenCompleted = true;

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

            var bgWorker = CreateBackgroundWorker(message, TimeSpan.FromMilliseconds(25));

            message.AllowCancel = true;
            message.Background = Configuration.BackgroundColorBrush;
            message.BorderBrush = Configuration.AccentColorBrush;
            message.Foreground = Configuration.ForegroundColorBrush;
            message.KeepOnScreenCompleted = true;
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

            message.Background = Configuration.BackgroundColorBrush;
            message.BorderBrush = Configuration.AccentColorBrush;
            message.Foreground = Configuration.ForegroundColorBrush;
            message.IndicatorFill = Configuration.AccentColorBrush;
            message.IndicatorPen = Configuration.AccentColorBrush;
            message.IndicatorPenThickness = new Thickness(1);

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
            message.Background = Configuration.BackgroundColorBrush;
            message.BorderBrush = Configuration.AccentColorBrush;
            message.Foreground = Configuration.ForegroundColorBrush;
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
            message.Background = Configuration.BackgroundColorBrush;
            message.BorderBrush = Configuration.AccentColorBrush;
            message.Foreground = Configuration.ForegroundColorBrush;
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
            message.Background = Configuration.BackgroundColorBrush;
            message.BorderBrush = Configuration.AccentColorBrush;
            message.Foreground = Configuration.ForegroundColorBrush;
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

    }
}
