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
            new PropertyMetadata(true));

        public static readonly DependencyProperty MarqueeDurationProperty = DependencyProperty.Register(
            nameof(MarqueeDuration),
            typeof(Duration),
            typeof(MarqueeTextBlockEx),
            new PropertyMetadata(new Duration(TimeSpan.FromMilliseconds(5000))));

        public static readonly DependencyProperty MarqueeEnabledProperty = DependencyProperty.Register(
            nameof(MarqueeEnabled),
            typeof(bool),
            typeof(MarqueeTextBlockEx),
            new FrameworkPropertyMetadata(true, new PropertyChangedCallback(OnMarqueeEnabledPropertyUpdate)));

        public static readonly DependencyProperty MarqueeStartPositionProperty = DependencyProperty.Register(
            nameof(MarqueeStartPosition),
            typeof(MarqueeTextAnimationPlace),
            typeof(MarqueeTextBlockEx),
            new PropertyMetadata(MarqueeTextAnimationPlace.RightOutside));

        public static readonly DependencyProperty MarqueeEndPositionProperty = DependencyProperty.Register(
            nameof(MarqueeEndPosition),
            typeof(MarqueeTextAnimationPlace),
            typeof(MarqueeTextBlockEx),
            new PropertyMetadata(MarqueeTextAnimationPlace.LeftOutside));

        public static readonly DependencyProperty WaitForTextProperty = DependencyProperty.Register(
            nameof(WaitForText),
            typeof(bool),
            typeof(MarqueeTextBlockEx),
            new PropertyMetadata(true));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private Storyboard _storyboard = null;
        private double _textPosition = 0;


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
        /// <summary> Static MarqueeTextBlockEx class constructor. </summary>
        static MarqueeTextBlockEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MarqueeTextBlockEx),
                new FrameworkPropertyMetadata(typeof(MarqueeTextBlockEx)));
        }

        #endregion CLASS METHODS

        #region DEPENDENCY PROPERTIES UPDATE METHODS

        private static void OnMarqueeEnabledPropertyUpdate(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as MarqueeTextBlockEx;

            if (control != null && control._storyboard != null)
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

        #region STORYBOARD CONTROL METHODS

        //  --------------------------------------------------------------------------------
        private void RestartStoryboard()
        {
            if (_storyboard != null)
                _storyboard.Begin();
        }

        //  --------------------------------------------------------------------------------
        private void StopStoryboard()
        {
            if (_storyboard != null)
            {
                _storyboard.Stop();
                TextPosition = 0;
            }
        }

        #endregion STORYBOARD CONTROL METHODS

        #region TEMPLATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> When overridden in a derived class,cis invoked whenever 
        /// application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            //  Apply Template
            base.OnApplyTemplate();

            _storyboard = GetStoryboard("contentStoryboard");

            if (!MarqueeEnabled)
                StopStoryboard();
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
