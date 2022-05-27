using chkam05.Tools.ControlsEx.Static;
using System;
using System.ComponentModel;
using System.Windows;


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


        //  VARIABLES

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

    }
}
