using chkam05.Tools.ControlsEx.Static;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace chkam05.Tools.ControlsEx
{
    public class MarqueeTextBlockEx : TextBlockEx, INotifyPropertyChanged
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty MarqueeBouncingProperty = DependencyProperty.Register(
            nameof(MarqueeBouncing),
            typeof(bool),
            typeof(MarqueeTextBlockEx),
            new FrameworkPropertyMetadata(true, new PropertyChangedCallback(OnMarqueeAnyPropertyUpdate)));

        public static readonly DependencyProperty MarqueeDurationProperty = DependencyProperty.Register(
            nameof(MarqueeDuration),
            typeof(Duration),
            typeof(MarqueeTextBlockEx),
            new FrameworkPropertyMetadata(
                new Duration(TimeSpan.FromMilliseconds(5000)),
                new PropertyChangedCallback(OnMarqueeAnyPropertyUpdate)));

        public static readonly DependencyProperty MarqueeEnabledProperty = DependencyProperty.Register(
            nameof(MarqueeEnabled),
            typeof(bool),
            typeof(MarqueeTextBlockEx),
            new FrameworkPropertyMetadata(true, new PropertyChangedCallback(OnMarqueeEnabledPropertyUpdate)));

        public static readonly DependencyProperty MarqueeStartPositionProperty = DependencyProperty.Register(
            nameof(MarqueeStartPosition),
            typeof(MarqueeTextAnimationPlace),
            typeof(MarqueeTextBlockEx),
            new FrameworkPropertyMetadata(
                MarqueeTextAnimationPlace.RightOutside,
                new PropertyChangedCallback(OnMarqueeAnyPropertyUpdate)));

        public static readonly DependencyProperty MarqueeEndPositionProperty = DependencyProperty.Register(
            nameof(MarqueeEndPosition),
            typeof(MarqueeTextAnimationPlace),
            typeof(MarqueeTextBlockEx),
            new FrameworkPropertyMetadata(
                MarqueeTextAnimationPlace.LeftOutside,
                new PropertyChangedCallback(OnMarqueeAnyPropertyUpdate)));

        public static readonly DependencyProperty WaitForTextProperty = DependencyProperty.Register(
            nameof(WaitForText),
            typeof(bool),
            typeof(MarqueeTextBlockEx),
            new FrameworkPropertyMetadata(true, new PropertyChangedCallback(OnMarqueeAnyPropertyUpdate)));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private Border _contentBorder = null;
        private Canvas _contentCanvas = null;
        private TextBlock _contentTextBlock = null;
        private bool _loaded = false;
        private double _textPosition = 0;

        public Storyboard Storyboard { get; private set; }


        //  GETTERS & SETTERS

        public bool MarqueeBouncing
        {
            get => (bool)GetValue(MarqueeBouncingProperty);
            set
            {
                SetValue(MarqueeBouncingProperty, value);
                OnPropertyChanged(nameof(MarqueeBouncing));
            }
        }

        public Duration MarqueeDuration
        {
            get => (Duration)GetValue(MarqueeDurationProperty);
            set
            {
                SetValue(MarqueeDurationProperty, value);
                OnPropertyChanged(nameof(MarqueeDuration));
            }
        }

        public bool MarqueeEnabled
        {
            get => (bool)GetValue(MarqueeEnabledProperty);
            set
            {
                SetValue(MarqueeEnabledProperty, value);
                OnPropertyChanged(nameof(MarqueeEnabled));
            }
        }

        public MarqueeTextAnimationPlace MarqueeStartPosition
        {
            get => (MarqueeTextAnimationPlace)GetValue(MarqueeStartPositionProperty);
            set
            {
                SetValue(MarqueeStartPositionProperty, value);
                OnPropertyChanged(nameof(MarqueeStartPosition));
            }
        }

        public MarqueeTextAnimationPlace MarqueeEndPosition
        {
            get => (MarqueeTextAnimationPlace)GetValue(MarqueeEndPositionProperty);
            set
            {
                SetValue(MarqueeEndPositionProperty, value);
                OnPropertyChanged(nameof(MarqueeEndPosition));
            }
        }

        public double TextPosition
        {
            get => _textPosition;
            private set
            {
                _textPosition = value;
                OnPropertyChanged(nameof(_textPosition));
            }
        }

        public bool WaitForText
        {
            get => (bool)GetValue(WaitForTextProperty);
            set
            {
                SetValue(WaitForTextProperty, value);
                OnPropertyChanged(nameof(WaitForText));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> MarqueeTextBlockEx class constructor. </summary>
        public MarqueeTextBlockEx()
        {
            Loaded += OnLoaded;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static MarqueeTextBlockEx class constructor. </summary>
        static MarqueeTextBlockEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MarqueeTextBlockEx),
                new FrameworkPropertyMetadata(typeof(MarqueeTextBlockEx)));
        }

        #endregion CLASS METHODS

        #region COMPONENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading control. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnLoaded(object sender, RoutedEventArgs e)
        {
            Storyboard = CreateStoryboard();

            if (MarqueeEnabled)
                RestartStoryboard();

            _loaded = true;
        }

        #endregion COMPONENT METHODS

        #region DEPENDENCY PROPERTIES UPDATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after updating any MarqueeTextBlockEx Property. </summary>
        /// <param name="sender"> Dependency object. </param>
        /// <param name="e"> Dependency Property Changed Event Arguments. </param>
        private static void OnMarqueeAnyPropertyUpdate(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as MarqueeTextBlockEx;

            if (control != null)
                control.RecreateStoryboard();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after updating MarqueeEnabledProperty. </summary>
        /// <param name="sender"> Dependency object. </param>
        /// <param name="e"> Dependency Property Changed Event Arguments. </param>
        private static void OnMarqueeEnabledPropertyUpdate(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as MarqueeTextBlockEx;

            if (control != null && control.Storyboard != null)
            {
                if ((bool)e.NewValue == true)
                {
                    control.RestartStoryboard();
                }
                else
                {
                    control.StopStoryboard();
                }
            }
        }

        #endregion DEPENDENCY PROPERTIES UPDATE METHODS

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

        #region STORYBOARD METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Create marquee storyboard. </summary>
        /// <returns> Marquee storyboard. </returns>
        private Storyboard CreateStoryboard()
        {
            var storyboard = new Storyboard();

            var doubleAnimation = new DoubleAnimation()
            {
                AutoReverse = MarqueeBouncing,
                BeginTime = new TimeSpan(0, 0, 0),
                Duration = MarqueeDuration,
                RepeatBehavior = RepeatBehavior.Forever,

                From = GetStartPosition(),
                To = GetEndPosition()
            };

            storyboard.Children.Add(doubleAnimation);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Canvas.Left)"));
            Storyboard.SetTarget(doubleAnimation, _contentTextBlock);

            return storyboard;
        }

        //  --------------------------------------------------------------------------------
        private void RecreateStoryboard()
        {
            if (_loaded)
            {
                if (Storyboard != null)
                    StopStoryboard();

                Storyboard = CreateStoryboard();

                if (MarqueeEnabled)
                    RestartStoryboard();
            }
        }

        //  --------------------------------------------------------------------------------
        private double GetStartPosition()
        {
            var startPosition = MarqueeStartPosition;
            var canvasWidth = _contentBorder.ActualWidth;
            var textWidth = _contentTextBlock.ActualWidth;
            var waitForText = WaitForText;

            switch (MarqueeStartPosition)
            {
                case MarqueeTextAnimationPlace.LeftOutside:
                    return -textWidth;

                case MarqueeTextAnimationPlace.LeftInside:
                    return waitForText &&  IsTextTooLong(canvasWidth, textWidth)
                        ? -(textWidth - canvasWidth)
                        : 0;

                case MarqueeTextAnimationPlace.RightInside:
                    return waitForText && IsTextTooLong(canvasWidth, textWidth)
                        ? 0
                        : canvasWidth - textWidth;

                case MarqueeTextAnimationPlace.RightOutside:
                default:
                    return canvasWidth;
            }
        }

        //  --------------------------------------------------------------------------------
        private double GetEndPosition()
        {
            var startPosition = MarqueeEndPosition;
            var canvasWidth = _contentBorder.ActualWidth;
            var textWidth = _contentTextBlock.ActualWidth;
            var waitForText = WaitForText;

            switch (startPosition)
            {
                case MarqueeTextAnimationPlace.LeftOutside:
                    return -textWidth;

                case MarqueeTextAnimationPlace.LeftInside:
                    return waitForText && IsTextTooLong(canvasWidth, textWidth)
                        ? -(textWidth - canvasWidth)
                        : 0;

                case MarqueeTextAnimationPlace.RightInside:
                    return waitForText && IsTextTooLong(canvasWidth, textWidth)
                        ? 0
                        : canvasWidth - textWidth;

                case MarqueeTextAnimationPlace.RightOutside:
                default:
                    return canvasWidth;
            }
        }

        //  --------------------------------------------------------------------------------
        private bool IsTextTooLong(double canvasWidth, double textWidth)
        {
            return textWidth >= canvasWidth;
        }

        //  --------------------------------------------------------------------------------
        private void RestartStoryboard()
        {
            if (Storyboard != null)
                Storyboard.Begin();
        }

        //  --------------------------------------------------------------------------------
        private void StopStoryboard()
        {
            if (Storyboard != null)
            {
                Storyboard.Stop();
                TextPosition = 0;
            }
        }

        #endregion STORYBOARD METHODS

        #region TEMPLATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> When overridden in a derived class,cis invoked whenever 
        /// application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            //  Apply Template
            base.OnApplyTemplate();

            _contentBorder = GetBorder("border");
            _contentCanvas = GetCanvas("contentCanvas");
            _contentTextBlock = GetTextBlock("contentText");
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get content Border from ContentTemplate. </summary>
        /// <param name="canvasName"> Border name. </param>
        /// <returns> Border or null. </returns>
        protected Border GetBorder(string canvasName)
        {
            return this.Template.FindName(canvasName, this) as Border;
        }
        
        //  --------------------------------------------------------------------------------
        /// <summary> Get content Canvas from ContentTemplate. </summary>
        /// <param name="canvasName"> Canvas name. </param>
        /// <returns> Border or null. </returns>
        protected Canvas GetCanvas(string canvasName)
        {
            return this.Template.FindName(canvasName, this) as Canvas;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get content Text Storyboard from ContentTemplate. </summary>
        /// <param name="storyboardName"> Storyboard name. </param>
        /// <returns> Storyboard or null. </returns>
        protected Storyboard GetStoryboard(string storyboardName)
        {
            return this.Template.FindName(storyboardName, this) as Storyboard;
        }
        
        //  --------------------------------------------------------------------------------
        /// <summary> Get content TextBlock from ContentTemplate. </summary>
        /// <param name="textBlockName"> TextBlock name. </param>
        /// <returns> Storyboard or null. </returns>
        protected TextBlock GetTextBlock(string textBlockName)
        {
            return this.Template.FindName(textBlockName, this) as TextBlock;
        }

        #endregion TEMPLATE METHODS

    }
}
