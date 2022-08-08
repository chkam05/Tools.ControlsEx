using chkam05.Tools.ControlsEx.Events;
using chkam05.Tools.ControlsEx.Static;
using chkam05.Tools.ControlsEx.Utilities;
using System;
using System.ComponentModel;
using System.Windows;
using static chkam05.Tools.ControlsEx.Events.Delegates;


namespace chkam05.Tools.ControlsEx.InternalMessages
{
    public class BaseProgressInternalMessageEx : BaseInternalMessageEx, IProgressInternalMessageEx, INotifyPropertyChanged
    {

        //  CONST

        internal readonly static double PROGRESS_MAX = 100d;
        internal readonly static double PROGRESS_MIN = 0d;


        //  DEPENDENCY PROPERTIES

        #region ProgressBar Properties

        public static readonly DependencyProperty ProgressMaxProperty = DependencyProperty.Register(
            nameof(ProgressMax),
            typeof(double),
            typeof(BaseProgressInternalMessageEx),
            new PropertyMetadata(PROGRESS_MAX));

        public static readonly DependencyProperty ProgressMinProperty = DependencyProperty.Register(
            nameof(ProgressMin),
            typeof(double),
            typeof(BaseProgressInternalMessageEx),
            new PropertyMetadata(PROGRESS_MIN));

        public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register(
            nameof(Progress),
            typeof(double),
            typeof(BaseProgressInternalMessageEx),
            new PropertyMetadata(PROGRESS_MIN));

        #endregion ProgressBar Properties

        public static readonly DependencyProperty AllowCancelProperty = DependencyProperty.Register(
            nameof(AllowCancel),
            typeof(bool),
            typeof(BaseProgressInternalMessageEx),
            new PropertyMetadata(false));

        public static readonly DependencyProperty IsFinishedProperty = DependencyProperty.Register(
            nameof(IsFinished),
            typeof(bool),
            typeof(BaseProgressInternalMessageEx),
            new PropertyMetadata(false));

        public static readonly DependencyProperty KeepOnScreenCompletedProperty = DependencyProperty.Register(
            nameof(KeepOnScreenCompleted),
            typeof(bool),
            typeof(BaseProgressInternalMessageEx),
            new PropertyMetadata(false));


        //  EVENTS

        public override event InternalMessageClose<InternalMessageCloseEventArgs> MessageClose;
        public virtual event ProgressInternalMessageCancel ProgressCancel;


        //  VARIABLES

        public DispatcherInvokerEx DispatcherInvoker { get; private set; }


        //  GETTERS & SETTERS

        #region ProgressBar

        public double ProgressMax
        {
            get => (double)GetValue(ProgressMaxProperty);
            set
            {
                SetValue(ProgressMaxProperty, value);
                OnPropertyChanged(nameof(ProgressMax));
            }
        }
        
        public double ProgressMin
        {
            get => (double)GetValue(ProgressMinProperty);
            set
            {
                SetValue(ProgressMinProperty, value);
                OnPropertyChanged(nameof(ProgressMin));
            }
        }
        
        public double Progress
        {
            get => (double)GetValue(ProgressProperty);
            set
            {
                SetValue(ProgressProperty, Math.Max(Math.Min(value, ProgressMax), ProgressMin));
                OnPropertyChanged(nameof(Progress));
            }
        }

        #endregion ProgressBar

        public bool AllowCancel
        {
            get => (bool)GetValue(AllowCancelProperty);
            set
            {
                SetValue(AllowCancelProperty, value);
                OnPropertyChanged(nameof(AllowCancel));
            }
        }

        public bool IsFinished
        {
            get => (bool)GetValue(IsFinishedProperty);
            private set
            {
                SetValue(IsFinishedProperty, value);
                OnPropertyChanged(nameof(IsFinished));
            }
        }

        public bool KeepOnScreenCompleted
        {
            get => (bool)GetValue(KeepOnScreenCompletedProperty);
            set
            {
                SetValue(KeepOnScreenCompletedProperty, value);
                OnPropertyChanged(nameof(KeepOnScreenCompleted));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> BaseProgressInternalMessageEx class constructor. </summary>
        public BaseProgressInternalMessageEx()
        {
            DispatcherInvoker = new DispatcherInvokerEx(Dispatcher);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static BaseProgressInternalMessageEx class constructor. </summary>
        static BaseProgressInternalMessageEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseProgressInternalMessageEx),
                new FrameworkPropertyMetadata(typeof(BaseProgressInternalMessageEx)));
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Invoke change progress value. </summary>
        /// <param name="progress"> New progress value. </param>
        public void InvokeProgressChange(double progress)
        {
            DispatcherInvoker.TryInvoke(() => { Progress = progress; });
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoke finish method. </summary>
        /// <param name="forceResult"> Forced result value. </param>
        public void InvokeFinish(InternalMessageResult? forceResult = null)
        {
            DispatcherInvoker.TryInvoke(() =>
            {
                IsFinished = true;

                if (IsHidden)
                    IsHidden = false;

                if (!KeepOnScreenCompleted)
                {
                    Result = forceResult.HasValue ? forceResult.Value : Static.InternalMessageResult.Ok;
                    MessageClose?.Invoke(this, new Events.InternalMessageCloseEventArgs(Result));
                };
            });
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Ok Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected override void OnOkClick(object sender, RoutedEventArgs e)
        {
            Result = InternalMessageResult.Ok;
            MessageClose?.Invoke(this, new InternalMessageCloseEventArgs(Result));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Cancel Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected override void OnCancelClick(object sender, RoutedEventArgs e)
        {
            Result = InternalMessageResult.Cancel;
            ProgressCancel?.Invoke(this, new InternalMessageCloseEventArgs(Result));

            if (!KeepOnScreenCompleted)
                MessageClose?.Invoke(this, new InternalMessageCloseEventArgs(Result));
        }

        #endregion INTERACTION METHODS

        #region TEMPLATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> When overridden in a derived class,cis invoked whenever 
        /// application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            //  Apply Template
            base.OnApplyTemplate();

            ApplyClickMethod(GetButton("okButton"), OnOkClick);
            ApplyClickMethod(GetButton("cancelButton"), OnCancelClick);
            ApplyClickMethod(GetButton("hideButton"), OnHideClick);
        }

        #endregion TEMPLATE METHODS

    }
}
