using chkam05.Tools.ControlsEx.Utilities;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;


namespace chkam05.Tools.ControlsEx.Indicators
{
    public class CircleSmoothIndicatorEx : BaseIndicatorEx, INotifyPropertyChanged
    {

        //  CONST

        protected readonly static double INDICATOR_INNER_RADIUS = 4;


        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty IndicatorThicknessProperty = DependencyProperty.Register(
            nameof(IndicatorThickness),
            typeof(double),
            typeof(CircleSmoothIndicatorEx),
            new PropertyMetadata(INDICATOR_INNER_RADIUS));

        public static readonly DependencyProperty InnerArcEndPointProperty = DependencyProperty.Register(
            nameof(InnerArcEndPoint),
            typeof(Point),
            typeof(CircleSmoothIndicatorEx),
            new PropertyMetadata(new Point(0d, 0d)));

        public static readonly DependencyProperty InnerArcLargeProperty = DependencyProperty.Register(
            nameof(InnerArcLarge),
            typeof(bool),
            typeof(CircleSmoothIndicatorEx),
            new PropertyMetadata(false));

        public static readonly DependencyProperty InnerArcRotationAngleProperty = DependencyProperty.Register(
            nameof(InnerArcRotationAngle),
            typeof(double),
            typeof(CircleSmoothIndicatorEx),
            new PropertyMetadata(45d));

        public static readonly DependencyProperty InnerArcSizeProperty = DependencyProperty.Register(
            nameof(InnerArcSize),
            typeof(Size),
            typeof(CircleSmoothIndicatorEx),
            new PropertyMetadata(new Size(0d, 0d)));

        public static readonly DependencyProperty InnerArcStartPointProperty = DependencyProperty.Register(
            nameof(InnerArcStartPoint),
            typeof(Point),
            typeof(CircleSmoothIndicatorEx),
            new PropertyMetadata(new Point(0d, 0d)));

        public static readonly DependencyProperty InnerArcSweepDirectionProperty = DependencyProperty.Register(
            nameof(InnerArcSweepDirection),
            typeof(SweepDirection),
            typeof(CircleSmoothIndicatorEx),
            new PropertyMetadata(SweepDirection.Counterclockwise));

        public static readonly DependencyProperty OuterArcEndPointProperty = DependencyProperty.Register(
            nameof(OuterArcEndPoint),
            typeof(Point),
            typeof(CircleSmoothIndicatorEx),
            new PropertyMetadata(new Point(0d, 0d)));

        public static readonly DependencyProperty OuterArcLargeProperty = DependencyProperty.Register(
            nameof(OuterArcLarge),
            typeof(bool),
            typeof(CircleSmoothIndicatorEx),
            new PropertyMetadata(false));

        public static readonly DependencyProperty OuterArcRotationAngleProperty = DependencyProperty.Register(
            nameof(OuterArcRotationAngle),
            typeof(double),
            typeof(CircleSmoothIndicatorEx),
            new PropertyMetadata(45d));

        public static readonly DependencyProperty OuterArcSizeProperty = DependencyProperty.Register(
            nameof(OuterArcSize),
            typeof(Size),
            typeof(CircleSmoothIndicatorEx),
            new PropertyMetadata(new Size(0d, 0d)));

        public static readonly DependencyProperty OuterArcStartPointProperty = DependencyProperty.Register(
            nameof(OuterArcStartPoint),
            typeof(Point),
            typeof(CircleSmoothIndicatorEx),
            new PropertyMetadata(new Point(0d, 0d)));

        public static readonly DependencyProperty OuterArcSweepDirectionProperty = DependencyProperty.Register(
            nameof(OuterArcSweepDirection),
            typeof(SweepDirection),
            typeof(CircleSmoothIndicatorEx),
            new PropertyMetadata(SweepDirection.Clockwise));


        //  VARIABLES

        private Point _workIndicatorCenterPoint;
        private double _workIndicatorRadius = 0;
        private double _workStartPos = 0.0;
        private double _workEndPos = 0.0;
        private bool _workInverse = false;
        private bool _workInversed = false;
        private bool _workIsLarge = false;


        //  GETTERS & SETTERS

        public double IndicatorThickness
        {
            get => (double)GetValue(IndicatorThicknessProperty);
            set
            {
                SetValue(IndicatorThicknessProperty, value);
                OnPropertyChanged(nameof(IndicatorThickness));
            }
        }

        public Point InnerArcEndPoint
        {
            get => (Point)GetValue(InnerArcEndPointProperty);
            private set
            {
                SetValue(InnerArcEndPointProperty, value);
                OnPropertyChanged(nameof(InnerArcEndPoint));
            }
        }

        public bool InnerArcLarge
        {
            get => (bool)GetValue(InnerArcLargeProperty);
            private set
            {
                SetValue(InnerArcLargeProperty, value);
                OnPropertyChanged(nameof(InnerArcLarge));
            }
        }

        public double InnerArcRotationAngle
        {
            get => (double)GetValue(InnerArcRotationAngleProperty);
            private set
            {
                SetValue(InnerArcRotationAngleProperty, Math.Max(Math.Min(value, 360.0), -360.0));
                OnPropertyChanged(nameof(InnerArcRotationAngle));
            }
        }

        public Size InnerArcSize
        {
            get => (Size)GetValue(InnerArcSizeProperty);
            private set
            {
                SetValue(InnerArcSizeProperty, value);
                OnPropertyChanged(nameof(InnerArcSize));
            }
        }

        public Point InnerArcStartPoint
        {
            get => (Point)GetValue(InnerArcStartPointProperty);
            private set
            {
                SetValue(InnerArcStartPointProperty, value);
                OnPropertyChanged(nameof(InnerArcStartPoint));
            }
        }

        public SweepDirection InnerArcSweepDirection
        {
            get => (SweepDirection)GetValue(InnerArcSweepDirectionProperty);
            private set
            {
                SetValue(InnerArcSweepDirectionProperty, value);
                OnPropertyChanged(nameof(InnerArcSweepDirection));
            }
        }

        public Point OuterArcEndPoint
        {
            get => (Point)GetValue(OuterArcEndPointProperty);
            private set
            {
                SetValue(OuterArcEndPointProperty, value);
                OnPropertyChanged(nameof(OuterArcEndPoint));
            }
        }

        public bool OuterArcLarge
        {
            get => (bool)GetValue(OuterArcLargeProperty);
            private set
            {
                SetValue(OuterArcLargeProperty, value);
                OnPropertyChanged(nameof(OuterArcLarge));
            }
        }

        public double OuterArcRotationAngle
        {
            get => (double)GetValue(OuterArcRotationAngleProperty);
            private set
            {
                SetValue(OuterArcRotationAngleProperty, Math.Max(Math.Min(value, 360.0), -360.0));
                OnPropertyChanged(nameof(OuterArcRotationAngle));
            }
        }

        public Size OuterArcSize
        {
            get => (Size)GetValue(OuterArcSizeProperty);
            private set
            {
                SetValue(OuterArcSizeProperty, value);
                OnPropertyChanged(nameof(OuterArcSize));
            }
        }

        public Point OuterArcStartPoint
        {
            get => (Point)GetValue(OuterArcStartPointProperty);
            private set
            {
                SetValue(OuterArcStartPointProperty, value);
                OnPropertyChanged(nameof(OuterArcStartPoint));
            }
        }

        public SweepDirection OuterArcSweepDirection
        {
            get => (SweepDirection)GetValue(OuterArcSweepDirectionProperty);
            private set
            {
                SetValue(OuterArcSweepDirectionProperty, value);
                OnPropertyChanged(nameof(OuterArcSweepDirection));
            }
        }

        public override bool IsPathEditable
        {
            get => false;
        }

        public new Geometry PathData
        {
            get => (this.Template.FindName("path", this) as Path)?.Data;
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> CircleSmoothIndicatorEx class constructor. </summary>
        public CircleSmoothIndicatorEx() : base()
        {
            AnimationEnded += OnAnimationEnd;
            AnimationFrameUpdated += OnFrameUpdate;
            SizeChanged += OnSizeChanged;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static IndicatorEx class constructor. </summary>
        static CircleSmoothIndicatorEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CircleSmoothIndicatorEx),
                new FrameworkPropertyMetadata(typeof(CircleSmoothIndicatorEx)));
        }

        #endregion CLASS METHODS

        #region ANIMATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked from animation worker to update frame. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        private bool OnFrameUpdate(object sender)
        {
            UpdateIndicatorProgress();

            Point outerStartPoint = CalculateOuterIndicatorStartPoint(_workStartPos);
            Point outerEndPoint = CalculateOuterIndicatorEndPoint(_workEndPos);
            Point innerStartPoint = CalculateInnerIndicatorStartPoint(_workEndPos);
            Point innerEndPoint = CalculateInnerIndicatorEndPoint(_workStartPos);

            _workIsLarge = CheckIndicatorArcSizeType(_workEndPos, _workStartPos);

            if (InnerArcLarge != OuterArcLarge || InnerArcLarge != _workIsLarge)
            {
                InnerArcLarge = _workIsLarge;
                OuterArcLarge = _workIsLarge;
            }

            OuterArcEndPoint = outerEndPoint;
            InnerArcStartPoint = innerStartPoint;
            OuterArcStartPoint = outerStartPoint;
            InnerArcEndPoint = innerEndPoint;

            return true;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked from animation worker after animation end. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        private void OnAnimationEnd(object sender)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Setup animation method. </summary>
        private void SetupAnimation()
        {
            _workIndicatorRadius = (ActualHeight / 2) - 1;
            _workIndicatorCenterPoint = new Point(_workIndicatorRadius + 1, _workIndicatorRadius + 1);

            double _innerRadius = _workIndicatorRadius - IndicatorThickness;

            OuterArcSize = new Size(_workIndicatorRadius, _workIndicatorRadius);
            InnerArcSize = new Size(_innerRadius, _innerRadius);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update indicator progress. </summary>
        private void UpdateIndicatorProgress()
        {
            if (_workEndPos == _workStartPos)
            {
                _workInverse = !_workInverse;
                _workInversed = true;
            }

            if (_workInverse)
            {
                _workStartPos = (_workStartPos + 1) % 360;
                if (!_workInversed && _workStartPos % 3 == 0)
                    _workEndPos = (_workEndPos + 1) % 360;
            }
            else
            {
                _workEndPos = (_workEndPos + 1) % 360;
                if (!_workInversed && _workEndPos % 3 == 0)
                    _workStartPos = (_workStartPos + 1) % 360;
            }

            _workInversed = false;
        }

        #endregion ANIMATION METHODS

        #region CALCULATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Calculate indicator inner arc end point. </summary>
        /// <param name="progress"> Current progress value. </param>
        /// <returns> Indicator inner arc end point. </returns>
        private Point CalculateInnerIndicatorEndPoint(double progress)
        {
            return MathUtilitiesEx.FindPointOnCircle(
                _workIndicatorCenterPoint, _workIndicatorRadius - IndicatorThickness, progress);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Calculate indicator inner arc start point. </summary>
        /// <param name="progress"> Current progress value. </param>
        /// <returns> Indicator inner arc start point. </returns>
        private Point CalculateInnerIndicatorStartPoint(double progress)
        {
            return MathUtilitiesEx.FindPointOnCircle(
                _workIndicatorCenterPoint, _workIndicatorRadius - IndicatorThickness, progress);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Calculate indicator outer arc end point. </summary>
        /// <param name="progress"> Current progress value. </param>
        /// <returns> Indicator outer arc end point. </returns>
        private Point CalculateOuterIndicatorEndPoint(double progress)
        {
            return MathUtilitiesEx.FindPointOnCircle(
                _workIndicatorCenterPoint, _workIndicatorRadius, progress);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Calculate indicator outer arc start point. </summary>
        /// <param name="progress"> Current progress value. </param>
        /// <returns> Indicator outer arc start point. </returns>
        private Point CalculateOuterIndicatorStartPoint(double progress)
        {
            return MathUtilitiesEx.FindPointOnCircle(
                _workIndicatorCenterPoint, _workIndicatorRadius, progress);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Check if indicator arcs need to be changed to large. </summary>
        /// <returns> True - large arcs; False - otherwise. </returns>
        private bool CheckIndicatorArcSizeType(double endProgress, double startProgress)
        {
            double correctedIndicatorEnd = endProgress < startProgress
                ? endProgress + 360 : endProgress;

            return correctedIndicatorEnd - startProgress >= 180;
        }

        #endregion CALCULATION METHODS

        #region COMPONENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading control. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected override void OnLoaded(object sender, RoutedEventArgs e)
        {
            //  Setup animation.
            SetupAnimation();

            //  Start animation.
            base.OnLoaded(sender, e);
        }

        //  --------------------------------------------------------------------------------
        protected virtual void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            //  Setup animation.
            SetupAnimation();
        }

        #endregion COMPONENT METHODS

    }
}
