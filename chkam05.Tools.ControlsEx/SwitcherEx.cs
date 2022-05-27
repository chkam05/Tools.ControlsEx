using chkam05.Tools.ControlsEx.Static;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace chkam05.Tools.ControlsEx
{
    public class SwitcherEx : CheckBox, INotifyPropertyChanged
    {

        //  CONST

        protected readonly static double CHECK_MARK_HEIGHT = 28d;
        protected readonly static double CHECK_MARK_WIDTH = 28d;


        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty CheckMarkBrushProperty = DependencyProperty.Register(
            nameof(CheckMarkBrush),
            typeof(Brush),
            typeof(SwitcherEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty MouseOverCheckMarkBrushProperty = DependencyProperty.Register(
            nameof(MouseOverCheckMarkBrush),
            typeof(Brush),
            typeof(SwitcherEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty PressedCheckMarkBrushProperty = DependencyProperty.Register(
            nameof(PressedCheckMarkBrush),
            typeof(Brush),
            typeof(SwitcherEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_PRESSED)));

        #endregion Appearance Colors Properties

        public static readonly DependencyProperty CheckMarkHeightProperty = DependencyProperty.Register(
            nameof(CheckMarkHeight),
            typeof(double),
            typeof(SwitcherEx),
            new PropertyMetadata(CHECK_MARK_HEIGHT));

        public static readonly DependencyProperty CheckMarkOutlineProperty = DependencyProperty.Register(
            nameof(CheckMarkOutline),
            typeof(bool),
            typeof(SwitcherEx),
            new PropertyMetadata(false));

        public static readonly DependencyProperty CheckMarkWidthProperty = DependencyProperty.Register(
            nameof(CheckMarkWidth),
            typeof(double),
            typeof(SwitcherEx),
            new PropertyMetadata(CHECK_MARK_WIDTH));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  GETTERS & SETTERS

        #region Appearance Colors

        public Brush CheckMarkBrush
        {
            get => (Brush)GetValue(CheckMarkBrushProperty);
            set
            {
                SetValue(CheckMarkBrushProperty, value);
                OnPropertyChanged(nameof(CheckMarkBrush));
            }
        }

        public Brush MouseOverCheckMarkBrush
        {
            get => (Brush)GetValue(MouseOverCheckMarkBrushProperty);
            set
            {
                SetValue(MouseOverCheckMarkBrushProperty, value);
                OnPropertyChanged(nameof(MouseOverCheckMarkBrush));
            }
        }

        public Brush PressedCheckMarkBrush
        {
            get => (Brush)GetValue(PressedCheckMarkBrushProperty);
            set
            {
                SetValue(PressedCheckMarkBrushProperty, value);
                OnPropertyChanged(nameof(PressedCheckMarkBrush));
            }
        }

        #endregion Appearance Colors

        public double CheckMarkHeight
        {
            get => (double)GetValue(CheckMarkHeightProperty);
            set
            {
                SetValue(CheckMarkHeightProperty, value);
                OnPropertyChanged(nameof(CheckMarkHeight));
            }
        }

        public bool CheckMarkOutline
        {
            get => (bool)GetValue(CheckMarkOutlineProperty);
            set
            {
                SetValue(CheckMarkOutlineProperty, value);
                OnPropertyChanged(nameof(CheckMarkOutline));
            }
        }

        public double CheckMarkWidth
        {
            get => (double)GetValue(CheckMarkWidthProperty);
            set
            {
                SetValue(CheckMarkWidthProperty, value);
                OnPropertyChanged(nameof(CheckMarkWidth));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Static SwitcherEx class constructor. </summary>
        static SwitcherEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SwitcherEx),
                new FrameworkPropertyMetadata(typeof(SwitcherEx)));
        }

        #endregion CLASS METHODS

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
