using chkam05.Tools.ControlsEx.Static;
using chkam05.Tools.ControlsEx.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx
{
    public class RichTextBoxEx : RichTextBox, INotifyPropertyChanged
    {

        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty MouseOverBorderBrushProperty = DependencyProperty.Register(
            nameof(MouseOverBorderBrush),
            typeof(Brush),
            typeof(RichTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty SelectedInactiveBorderBrushProperty = DependencyProperty.Register(
            nameof(SelectedInactiveBorderBrush),
            typeof(Brush),
            typeof(RichTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_SELECTED_INACTIVE)));

        public static readonly DependencyProperty SelectedTextBackgroundProperty = DependencyProperty.Register(
            nameof(SelectedTextBackground),
            typeof(Brush),
            typeof(RichTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        #endregion Appearance Colors Properties

        #region Hyperlinks Properties

        public static readonly DependencyProperty HyperlinkForegroundProperty = DependencyProperty.Register(
            nameof(HyperlinkForeground),
            typeof(Brush),
            typeof(RichTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty HyperlinkDisabledForegroundProperty = DependencyProperty.Register(
            nameof(HyperlinkDisabledForeground),
            typeof(Brush),
            typeof(RichTextBoxEx),
            new PropertyMetadata(new SolidColorBrush(SystemColors.GrayTextColor)));

        #endregion Hyperlinks Properties

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(RichTextBoxEx),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        public EasyRichTextManager EasyTextManager { get; private set; }


        //  GETTERS & SETTERS

        #region Appearance Colors

        public Brush MouseOverBorderBrush
        {
            get => (Brush)GetValue(MouseOverBorderBrushProperty);
            set
            {
                SetValue(MouseOverBorderBrushProperty, value);
                OnPropertyChanged(nameof(MouseOverBorderBrush));
            }
        }

        public Brush SelectedInactiveBorderBrush
        {
            get => (Brush)GetValue(SelectedInactiveBorderBrushProperty);
            set
            {
                SetValue(SelectedInactiveBorderBrushProperty, value);
                OnPropertyChanged(nameof(SelectedInactiveBorderBrush));
            }
        }

        public Brush SelectedTextBackground
        {
            get => (Brush)GetValue(SelectedTextBackgroundProperty);
            set
            {
                SetValue(SelectedTextBackgroundProperty, value);
                OnPropertyChanged(nameof(SelectedTextBackground));
            }
        }

        #endregion Appearance Colors

        #region Hyperlinks

        public Brush HyperlinkForeground
        {
            get => (Brush)GetValue(HyperlinkForegroundProperty);
            set
            {
                SetValue(HyperlinkForegroundProperty, value);
                OnPropertyChanged(nameof(HyperlinkForeground));
            }
        }

        public CornerRadius HyperlinkDisabledForeground
        {
            get => (CornerRadius)GetValue(HyperlinkDisabledForegroundProperty);
            set
            {
                SetValue(HyperlinkDisabledForegroundProperty, value);
                OnPropertyChanged(nameof(HyperlinkDisabledForeground));
            }
        }

        #endregion Hyperlinks

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set
            {
                SetValue(CornerRadiusProperty, value);
                OnPropertyChanged(nameof(CornerRadius));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> RichTextBoxEx class constructor. </summary>
        public RichTextBoxEx() : base()
        {
            EasyTextManager = new EasyRichTextManager(this);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static RichTextBoxEx class constructor. </summary>
        static RichTextBoxEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RichTextBoxEx),
                new FrameworkPropertyMetadata(typeof(RichTextBoxEx)));
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
