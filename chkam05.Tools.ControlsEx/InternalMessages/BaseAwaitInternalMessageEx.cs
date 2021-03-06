using chkam05.Tools.ControlsEx.Events;
using chkam05.Tools.ControlsEx.Indicators;
using chkam05.Tools.ControlsEx.Static;
using chkam05.Tools.ControlsEx.Utilities;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static chkam05.Tools.ControlsEx.Events.Delegates;


namespace chkam05.Tools.ControlsEx.InternalMessages
{
    public class BaseAwaitInternalMessageEx : BaseInternalMessageEx, IProgressInternalMessageEx, INotifyPropertyChanged
    {

        //  DEPENDENCY PROPERTIES

        #region Indicator Properties

        public static readonly DependencyProperty IndicatorAnimationSpeedProperty = DependencyProperty.Register(
            nameof(IndicatorAnimationSpeed),
            typeof(TimeSpan),
            typeof(BaseAwaitInternalMessageEx),
            new PropertyMetadata(TimeSpan.FromMilliseconds(BaseIndicatorEx.ANIMATION_DEFAULT_SPEED)));

        public static readonly DependencyProperty IndicatorFillProperty = DependencyProperty.Register(
            nameof(IndicatorFill),
            typeof(Brush),
            typeof(BaseAwaitInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty IndicatorPenProperty = DependencyProperty.Register(
            nameof(IndicatorPen),
            typeof(Brush),
            typeof(BaseAwaitInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty IndicatorPenThicknessProperty = DependencyProperty.Register(
            nameof(IndicatorPenThickness),
            typeof(Thickness),
            typeof(BaseAwaitInternalMessageEx),
            new PropertyMetadata(new Thickness(1)));

        public static readonly DependencyProperty IndicatorTypeProperty = DependencyProperty.Register(
            nameof(IndicatorType),
            typeof(IndicatorType),
            typeof(BaseAwaitInternalMessageEx),
            new PropertyMetadata(IndicatorType.CircleSmoothIndicatorEx));

        #endregion Indicator Properties

        public static readonly DependencyProperty AllowCancelProperty = DependencyProperty.Register(
            nameof(AllowCancel),
            typeof(bool),
            typeof(BaseAwaitInternalMessageEx),
            new PropertyMetadata(false));

        public static readonly DependencyProperty IsFinishedProperty = DependencyProperty.Register(
            nameof(IsFinished),
            typeof(bool),
            typeof(BaseAwaitInternalMessageEx),
            new PropertyMetadata(false));

        public static readonly DependencyProperty KeepOnScreenCompletedProperty = DependencyProperty.Register(
            nameof(KeepOnScreenCompleted),
            typeof(bool),
            typeof(BaseAwaitInternalMessageEx),
            new PropertyMetadata(false));


        //  EVENTS

        public override event InternalMessageClose MessageClose;
        public virtual event ProgressInternalMessageCancel ProgressCancel;


        //  VARIABLES

        private double _progressMax = BaseProgressInternalMessageEx.PROGRESS_MAX;
        private double _progressMin = BaseProgressInternalMessageEx.PROGRESS_MIN;
        private double _progress = 0d;

        public DispatcherInvokerEx DispatcherInvoker { get; private set; }
        public BaseIndicatorEx Indicator { get; private set; } = null;


        //  GETTERS & SETTERS

        #region Indicator

        public TimeSpan IndicatorAnimationSpeed
        {
            get => (TimeSpan)GetValue(IndicatorAnimationSpeedProperty);
            set
            {
                SetValue(IndicatorAnimationSpeedProperty, value);
                OnPropertyChanged(nameof(IndicatorAnimationSpeed));
                UpdateIndicator();
            }
        }

        public Brush IndicatorFill
        {
            get => (Brush)GetValue(IndicatorFillProperty);
            set
            {
                SetValue(IndicatorFillProperty, value);
                OnPropertyChanged(nameof(IndicatorFill));
                UpdateIndicator();
            }
        }

        public Brush IndicatorPen
        {
            get => (Brush)GetValue(IndicatorPenProperty);
            set
            {
                SetValue(IndicatorPenProperty, value);
                OnPropertyChanged(nameof(IndicatorPen));
                UpdateIndicator();
            }
        }

        public Thickness IndicatorPenThickness
        {
            get => (Thickness)GetValue(IndicatorPenThicknessProperty);
            set
            {
                SetValue(IndicatorPenThicknessProperty, value);
                OnPropertyChanged(nameof(IndicatorPenThickness));
                UpdateIndicator();
            }
        }

        public IndicatorType IndicatorType
        {
            get => (IndicatorType)GetValue(IndicatorTypeProperty);
            set
            {
                SetValue(IndicatorTypeProperty, value);
                OnPropertyChanged(nameof(IndicatorType));
                SetupIndicator();
            }
        }

        #endregion Indicator

        #region ProgressBar

        public double ProgressMax
        {
            get => _progressMax;
            set => _progressMax = value;
        }

        public double ProgressMin
        {
            get => _progressMin;
            set => _progressMin = value;
        }

        public double Progress
        {
            get => _progress;
            set => _progress = Math.Max(Math.Min(value, ProgressMax), ProgressMin);
        }

        #endregion ProgressBar

        private Grid IndicatorContainer
        {
            get => Template.FindName("indicatorContainer", this) as Grid;
        }

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
        /// <summary> BaseAwaitInternalMessageEx class constructor. </summary>
        public BaseAwaitInternalMessageEx()
        {
            DispatcherInvoker = new DispatcherInvokerEx(Dispatcher);

            Loaded += OnLoaded;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static BaseAwaitInternalMessageEx class constructor. </summary>
        static BaseAwaitInternalMessageEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseAwaitInternalMessageEx),
                new FrameworkPropertyMetadata(typeof(BaseAwaitInternalMessageEx)));
        }

        #endregion CLASS METHODS

        #region COMPONENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading component. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            //  Setup indicator.
            SetupIndicator();
        }

        #endregion COMPONENT METHODS

        #region INDICATOR METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Remove indicator. </summary>
        private void RemoveIndicator()
        {
            if (Indicator != null)
            {
                Indicator.StopAnimation();
                Indicator = null;

                if (IndicatorContainer != null && IndicatorContainer.Children.Count > 0)
                    IndicatorContainer.Children.Clear();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Setup indicator. </summary>
        private void SetupIndicator()
        {
            if (IndicatorContainer != null)
            {
                RemoveIndicator();

                switch (IndicatorType)
                {
                    case IndicatorType.CircleSmoothIndicatorEx:
                    default:
                        Indicator = new CircleSmoothIndicatorEx();
                        IndicatorContainer.Children.Add(Indicator);
                        UpdateIndicator();
                        break;
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update indicator configuration. </summary>
        private void UpdateIndicator()
        {
            if (Indicator != null)
            {
                Indicator.AnimationSpeed = IndicatorAnimationSpeed;
                Indicator.Fill = IndicatorFill;
                Indicator.Pen = IndicatorPen;
                Indicator.PenThickness = IndicatorPenThickness;
            }
        }

        #endregion INDICATOR METHODS

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

                RemoveIndicator();

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

            RemoveIndicator();

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
