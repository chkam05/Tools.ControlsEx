using chkam05.Tools.ControlsEx.Static;
using chkam05.Tools.ControlsEx.Utilities;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static chkam05.Tools.ControlsEx.Events.Delegates;


namespace chkam05.Tools.ControlsEx.Indicators
{
    public class BaseIndicatorEx : Control, INotifyPropertyChanged
    {

        //  CONST

        internal readonly static double ANIMATION_DEFAULT_SPEED = 1d;


        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty FillProperty = DependencyProperty.Register(
            nameof(Fill),
            typeof(Brush),
            typeof(BaseIndicatorEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty PenProperty = DependencyProperty.Register(
            nameof(Pen),
            typeof(Brush),
            typeof(BaseIndicatorEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        #endregion Appearance Colors Properties

        public static readonly DependencyProperty AnimationSpeedProperty = DependencyProperty.Register(
            nameof(AnimationSpeed),
            typeof(TimeSpan),
            typeof(BaseIndicatorEx),
            new PropertyMetadata(TimeSpan.FromMilliseconds(ANIMATION_DEFAULT_SPEED)));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(BaseIndicatorEx),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));

        public static readonly DependencyProperty PathDataProperty = DependencyProperty.Register(
            nameof(PathData),
            typeof(Geometry),
            typeof(BaseIndicatorEx),
            new PropertyMetadata(null));

        public static readonly DependencyProperty PenThicknessProperty = DependencyProperty.Register(
            nameof(PenThickness),
            typeof(Thickness),
            typeof(BaseIndicatorEx),
            new PropertyMetadata(new Thickness(1)));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;
        public event IndicatorAnimationEnd AnimationEnded;
        public event IndicatorAnimationFrameUpdate AnimationFrameUpdated;


        //  VARIABLES

        private BackgroundWorker _animationWorker;
        public DispatcherInvokerEx DispatcherInvoker;


        //  GETTERS & SETTERS

        #region Appearance Colors

        public Brush Fill
        {
            get => (Brush)GetValue(FillProperty);
            set
            {
                SetValue(FillProperty, value);
                OnPropertyChanged(nameof(Fill));
            }
        }

        public Brush Pen
        {
            get => (Brush)GetValue(PenProperty);
            set
            {
                SetValue(PenProperty, value);
                OnPropertyChanged(nameof(Pen));
            }
        }

        #endregion Appearance Colors

        public TimeSpan AnimationSpeed
        {
            get => (TimeSpan)GetValue(AnimationSpeedProperty);
            set
            {
                SetValue(AnimationSpeedProperty, value);
                OnPropertyChanged(nameof(AnimationSpeed));
            }
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set
            {
                SetValue(CornerRadiusProperty, value);
                OnPropertyChanged(nameof(CornerRadius));
            }
        }

        public virtual bool IsPathEditable
        {
            get => true;
        }

        public virtual Geometry PathData
        {
            get => (Geometry)GetValue(PathDataProperty);
            set
            {
                SetValue(PathDataProperty, value);
                OnPropertyChanged(nameof(PathData));
            }
        }

        public Thickness PenThickness
        {
            get => (Thickness)GetValue(PenThicknessProperty);
            set
            {
                SetValue(PenThicknessProperty, value);
                OnPropertyChanged(nameof(PenThickness));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> IndicatorEx class constructor. </summary>
        public BaseIndicatorEx()
        {
            DispatcherInvoker = new DispatcherInvokerEx(this.Dispatcher);
            Loaded += OnLoaded;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static IndicatorEx class constructor. </summary>
        static BaseIndicatorEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseIndicatorEx),
                new FrameworkPropertyMetadata(typeof(BaseIndicatorEx)));
        }

        #endregion CLASS METHODS

        #region ANIMATION MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Animation worker method. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Do Work Event Arguments. </param>
        private void Animate(object sender, DoWorkEventArgs e)
        {
            DateTime workTime = DateTime.Now;
            bool working = !_animationWorker.CancellationPending;
            TimeSpan frameTime = TimeSpan.FromSeconds(ANIMATION_DEFAULT_SPEED);

            DispatcherInvoker.TryInvoke(() => frameTime = AnimationSpeed);

            while (working)
            {
                if (DateTime.Now - workTime <= frameTime)
                    continue;

                if (_animationWorker.CancellationPending)
                    break;

                if (!DispatcherInvoker.TryInvoke(() => working = AnimationFrameUpdated?.Invoke(this) ?? false))
                    break;

                workTime = DateTime.Now;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Animation worker finish method. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Run Worker Completed Event Arguments. </param>
        private void AnimationFinish(object sender, RunWorkerCompletedEventArgs e)
        {
            DispatcherInvoker.TryInvoke(() => AnimationEnded?.Invoke(this));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create animation worker. </summary>
        private void CreateAnimationWorker()
        {
            if (_animationWorker != null && _animationWorker.IsBusy)
            {
                StopAnimation();
                while (_animationWorker != null && _animationWorker.IsBusy) { }
            }

            _animationWorker = new BackgroundWorker();
            _animationWorker.WorkerReportsProgress = true;
            _animationWorker.WorkerSupportsCancellation = true;

            _animationWorker.DoWork += Animate;
            _animationWorker.RunWorkerCompleted += AnimationFinish;
        }

        #endregion ANIMATION MANAGEMENT METHODS

        #region COMPONENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading control. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnLoaded(object sender, RoutedEventArgs e)
        {
            StartAnimation();
        }

        #endregion COMPONENT METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Start animation. </summary>
        public void StartAnimation()
        {
            CreateAnimationWorker();
            _animationWorker.RunWorkerAsync();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Request stop animation. </summary>
        public void StopAnimation()
        {
            if (_animationWorker != null && _animationWorker.IsBusy)
                _animationWorker.CancelAsync();
        }

        #endregion INTERACTION METHODS

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
