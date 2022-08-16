using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Events;
using chkam05.Tools.ControlsEx.Indicators;
using chkam05.Tools.ControlsEx.Static;
using chkam05.Tools.ControlsEx.Utilities;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace chkam05.Tools.ControlsEx.InternalMessages
{
    public class BaseAwaitInternalMessageEx : BaseInternalMessageEx<InternalMessageCloseEventArgs>
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

        public static readonly DependencyProperty IndicatorMarginProperty = DependencyProperty.Register(
            nameof(IndicatorMargin),
            typeof(Thickness),
            typeof(BaseAwaitInternalMessageEx),
            new PropertyMetadata(new Thickness(8, 0, 8, 8)));

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


        //  VARIABLES

        private bool _allowCancel = false;
        private bool _keepFinishedOpen = false;


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

        public Thickness IndicatorMargin
        {
            get => (Thickness)GetValue(IndicatorMarginProperty);
            set
            {
                SetValue(IndicatorMarginProperty, value);
                OnPropertyChanged(nameof(IndicatorMargin));
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
                SetupIndicator(value);
            }
        }

        #endregion Indicator

        private Grid IndicatorContainer
        {
            get => Template?.FindName("indicatorContainer", this) as Grid ?? null;
        }

        public bool AllowCancel
        {
            get => _allowCancel;
            set
            {
                _allowCancel = value;
                OnPropertyChanged(nameof(AllowCancel));

                if (IsLoadingComplete)
                    OnAllowCancelUpdate(value);
            }
        }

        public bool KeepFinishedOpen
        {
            get => _keepFinishedOpen;
            set
            {
                _keepFinishedOpen = value;
                OnPropertyChanged(nameof(KeepFinishedOpen));
            }
        }

        public BaseIndicatorEx Indicator { get; private set; }

        public DispatcherInvokerEx DispatcherInvoker { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> BaseAwaitInternalMessageEx class constructor. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        public BaseAwaitInternalMessageEx(InternalMessagesExContainer parentContainer) : base(parentContainer)
        {
            DispatcherInvoker = new DispatcherInvokerEx(this.Dispatcher);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static BaseAwaitInternalMessageEx class constructor. </summary>
        static BaseAwaitInternalMessageEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseAwaitInternalMessageEx),
                new FrameworkPropertyMetadata(typeof(BaseAwaitInternalMessageEx)));
        }

        #endregion CLASS METHODS

        #region BUTTONS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Ok Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnOkClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Yes Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnCancelClick(object sender, RoutedEventArgs e)
        {
            OnProgressCanceled();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Hide Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnHideClick(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        #endregion BUTTONS METHODS

        #region INDICATOR METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Create and load indicator by IndicatorType. </summary>
        /// <param name="indicatorType"> Type of indicator. </param>
        protected void SetupIndicator(IndicatorType indicatorType)
        {
            if (IndicatorContainer != null)
            {
                if (Indicator != null)
                {
                    Indicator.StopAnimation();
                    IndicatorContainer.Children.Clear();
                }

                switch (indicatorType)
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
        /// <summary> Stop and hide indicator. </summary>
        protected void StopAndHideIndicator()
        {
            if (Indicator != null)
            {
                Indicator.StopAnimation();
                Indicator.Visibility = Visibility.Hidden;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update indicator configuration. </summary>
        protected void UpdateIndicator()
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
        /// <summary> Invoke finish work of progressbar. </summary>
        /// <param name="finishedProperly"> True - progress finished properly; False - otherwise. </param>
        public void InvokeFinsh(bool finishedProperly = true)
        {
            DispatcherInvoker.TryInvoke(() =>
            {
                Result = finishedProperly ? InternalMessageResult.Ok : InternalMessageResult.Cancel;
                OnProgressFinish();
            });
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

            ApplyButtonExClickMethod(GetButtonEx("hideButton"), OnHideClick);
            ApplyButtonExClickMethod(GetButtonEx("cancelButton"), OnCancelClick);
            ApplyButtonExClickMethod(GetButtonEx("okButton"), OnOkClick);
            OnAllowCancelUpdate(AllowCancel);
            OnAllowHideUpdate(AllowHide);
            SetupIndicator(IndicatorType);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing AllowHide property. </summary>
        /// <param name="showHide"> True - allow hide; False - otherwise. </param>
        protected override void OnAllowHideUpdate(bool showHide = false)
        {
            var buttonHide = GetButtonEx("hideButton");
            buttonHide.Visibility = showHide ? Visibility.Visible : Visibility.Collapsed;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing AllowCancel property. </summary>
        /// <param name="allowCancel"> True - allow cancel; False - otherwise. </param>
        protected virtual void OnAllowCancelUpdate(bool allowCancel = false)
        {
            var buttonCancel = GetButtonEx("cancelButton");
            buttonCancel.IsEnabled = allowCancel;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Message invoked after canceling progress. </summary>
        protected virtual void OnProgressCanceled()
        {
            Result = InternalMessageResult.Cancel;

            if (KeepFinishedOpen)
            {
                var buttonCancel = GetButtonEx("cancelButton");
                buttonCancel.Visibility = Visibility.Collapsed;

                var buttonOk = GetButtonEx("okButton");
                buttonOk.Visibility = Visibility.Visible;

                StopAndHideIndicator();

                if (IsHidden)
                    Show();

                InvokeClose(new InternalMessageCloseEventArgs(Result));
            }
            else
            {
                Close();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after finishing progress. </summary>
        protected virtual void OnProgressFinish()
        {
            if (KeepFinishedOpen)
            {
                var buttonCancel = GetButtonEx("cancelButton");
                buttonCancel.Visibility = Visibility.Collapsed;

                var buttonOk = GetButtonEx("okButton");
                buttonOk.Visibility = Visibility.Visible;

                StopAndHideIndicator();

                if (IsHidden)
                    Show();
            }
            else
            {
                Close();
            }
        }

        #endregion TEMPLATE METHODS

    }
}
