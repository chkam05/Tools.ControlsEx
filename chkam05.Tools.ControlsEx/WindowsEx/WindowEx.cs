using chkam05.Tools.ControlsEx.Static;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.WindowsEx
{
    public class WindowEx : BaseWindowEx
    {

        //  DEPENDENCY PROPERTIES

        #region Buttons Appearance Properties

        public static readonly DependencyProperty MouseOverTitleBarButtonBackgroundProperty = DependencyProperty.Register(
            nameof(MouseOverTitleBarButtonBackground),
            typeof(Brush),
            typeof(WindowEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty MouseOverTitleBarButtonForegroundProperty = DependencyProperty.Register(
            nameof(MouseOverTitleBarButtonForeground),
            typeof(Brush),
            typeof(WindowEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty PressedTitleBarButtonBackgroundProperty = DependencyProperty.Register(
            nameof(PressedTitleBarButtonBackground),
            typeof(Brush),
            typeof(WindowEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_PRESSED)));

        public static readonly DependencyProperty PressedTitleBarButtonForegroundProperty = DependencyProperty.Register(
            nameof(PressedTitleBarButtonForeground),
            typeof(Brush),
            typeof(WindowEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty MouseOverTitleBarCloseButtonBackgroundProperty = DependencyProperty.Register(
            nameof(MouseOverTitleBarCloseButtonBackground),
            typeof(Brush),
            typeof(WindowEx),
            new PropertyMetadata(new SolidColorBrush(Color.FromRgb(241, 79, 92))));

        public static readonly DependencyProperty MouseOverTitleBarCloseButtonForegroundProperty = DependencyProperty.Register(
            nameof(MouseOverTitleBarCloseButtonForeground),
            typeof(Brush),
            typeof(WindowEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty PressedTitleBarCloseButtonBackgroundProperty = DependencyProperty.Register(
            nameof(PressedTitleBarCloseButtonBackground),
            typeof(Brush),
            typeof(WindowEx),
            new PropertyMetadata(new SolidColorBrush(Color.FromRgb(180, 13, 27))));

        public static readonly DependencyProperty PressedTitleBarCloseButtonForegroundProperty = DependencyProperty.Register(
            nameof(PressedTitleBarCloseButtonForeground),
            typeof(Brush),
            typeof(WindowEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        #endregion Buttons Appearance Properties

        #region Buttons Properties

        public static readonly DependencyProperty MinimizeButtonIconKindProperty = DependencyProperty.Register(
            nameof(MinimizeButtonIconKind),
            typeof(PackIconKind),
            typeof(WindowEx),
            new PropertyMetadata(PackIconKind.WindowMinimize));

        public static readonly DependencyProperty MaximizeButtonIconKindProperty = DependencyProperty.Register(
            nameof(MaximizeButtonIconKind),
            typeof(PackIconKind),
            typeof(WindowEx),
            new PropertyMetadata(PackIconKind.WindowMaximize));

        public static readonly DependencyProperty CloseButtonIconKindProperty = DependencyProperty.Register(
            nameof(CloseButtonIconKind),
            typeof(PackIconKind),
            typeof(WindowEx),
            new PropertyMetadata(PackIconKind.Close));

        public static readonly DependencyProperty ShowMinimizeButtonProperty = DependencyProperty.Register(
            nameof(ShowMinimizeButton),
            typeof(bool),
            typeof(WindowEx),
            new PropertyMetadata(true));

        public static readonly DependencyProperty ShowMaximizeButtonProperty = DependencyProperty.Register(
            nameof(ShowMaximizeButton),
            typeof(bool),
            typeof(WindowEx),
            new PropertyMetadata(true));

        #endregion Buttons Properties

        public static readonly DependencyProperty BackgroundOpacityProperty = DependencyProperty.Register(
            nameof(BackgroundOpacity),
            typeof(double),
            typeof(WindowEx),
            new PropertyMetadata(.75d));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(WindowEx),
            new PropertyMetadata(new CornerRadius(8)));

        public static readonly DependencyProperty IconKindProperty = DependencyProperty.Register(
            nameof(IconKind),
            typeof(PackIconKind),
            typeof(WindowEx),
            new PropertyMetadata(PackIconKind.ApplicationOutline));

        public static readonly DependencyProperty ShowIconProperty = DependencyProperty.Register(
            nameof(ShowIcon),
            typeof(bool),
            typeof(WindowEx),
            new PropertyMetadata(true));

        public static readonly DependencyProperty TitleBarOpacityProperty = DependencyProperty.Register(
            nameof(TitleBarOpacity),
            typeof(double),
            typeof(WindowEx),
            new PropertyMetadata(1d));


        //  VARIABLES


        //  GETTERS & SETTERS

        #region Buttons Appearance

        public Brush MouseOverTitleBarButtonBackground
        {
            get => (Brush)GetValue(MouseOverTitleBarButtonBackgroundProperty);
            set
            {
                SetValue(MouseOverTitleBarButtonBackgroundProperty, value);
                OnPropertyChanged(nameof(MouseOverTitleBarButtonBackground));
            }
        }

        public Brush MouseOverTitleBarButtonForeground
        {
            get => (Brush)GetValue(MouseOverTitleBarButtonForegroundProperty);
            set
            {
                SetValue(MouseOverTitleBarButtonForegroundProperty, value);
                OnPropertyChanged(nameof(MouseOverTitleBarButtonForeground));
            }
        }

        public Brush PressedTitleBarButtonBackground
        {
            get => (Brush)GetValue(PressedTitleBarButtonBackgroundProperty);
            set
            {
                SetValue(PressedTitleBarButtonBackgroundProperty, value);
                OnPropertyChanged(nameof(PressedTitleBarButtonBackground));
            }
        }

        public Brush PressedTitleBarButtonForeground
        {
            get => (Brush)GetValue(PressedTitleBarButtonForegroundProperty);
            set
            {
                SetValue(PressedTitleBarButtonForegroundProperty, value);
                OnPropertyChanged(nameof(PressedTitleBarButtonForeground));
            }
        }

        public Brush MouseOverTitleBarCloseButtonBackground
        {
            get => (Brush)GetValue(MouseOverTitleBarCloseButtonBackgroundProperty);
            set
            {
                SetValue(MouseOverTitleBarCloseButtonBackgroundProperty, value);
                OnPropertyChanged(nameof(MouseOverTitleBarCloseButtonBackground));
            }
        }

        public Brush MouseOverTitleBarCloseButtonForeground
        {
            get => (Brush)GetValue(MouseOverTitleBarCloseButtonForegroundProperty);
            set
            {
                SetValue(MouseOverTitleBarCloseButtonForegroundProperty, value);
                OnPropertyChanged(nameof(MouseOverTitleBarCloseButtonForeground));
            }
        }

        public Brush PressedTitleBarCloseButtonBackground
        {
            get => (Brush)GetValue(PressedTitleBarCloseButtonBackgroundProperty);
            set
            {
                SetValue(PressedTitleBarCloseButtonBackgroundProperty, value);
                OnPropertyChanged(nameof(PressedTitleBarCloseButtonBackground));
            }
        }

        public Brush PressedTitleBarCloseButtonForeground
        {
            get => (Brush)GetValue(PressedTitleBarCloseButtonForegroundProperty);
            set
            {
                SetValue(PressedTitleBarCloseButtonForegroundProperty, value);
                OnPropertyChanged(nameof(PressedTitleBarCloseButtonForeground));
            }
        }

        #endregion Buttons Appearance

        #region Buttons

        public PackIconKind MinimizeButtonIconKind
        {
            get => (PackIconKind)GetValue(MinimizeButtonIconKindProperty);
            set
            {
                SetValue(MinimizeButtonIconKindProperty, value);
                OnPropertyChanged(nameof(MinimizeButtonIconKind));
            }
        }

        public PackIconKind MaximizeButtonIconKind
        {
            get => (PackIconKind)GetValue(MaximizeButtonIconKindProperty);
            set
            {
                SetValue(MaximizeButtonIconKindProperty, value);
                OnPropertyChanged(nameof(MaximizeButtonIconKind));
            }
        }

        public PackIconKind CloseButtonIconKind
        {
            get => (PackIconKind)GetValue(CloseButtonIconKindProperty);
            set
            {
                SetValue(CloseButtonIconKindProperty, value);
                OnPropertyChanged(nameof(CloseButtonIconKind));
            }
        }

        public bool ShowMinimizeButton
        {
            get => (bool)GetValue(ShowMinimizeButtonProperty);
            set
            {
                SetValue(ShowMinimizeButtonProperty, value);
                OnPropertyChanged(nameof(ShowMinimizeButton));
            }
        }

        public bool ShowMaximizeButton
        {
            get => (bool)GetValue(ShowMaximizeButtonProperty);
            set
            {
                SetValue(ShowMaximizeButtonProperty, value);
                OnPropertyChanged(nameof(ShowMaximizeButton));
            }
        }

        #endregion Buttons

        public double BackgroundOpacity
        {
            get => (double)GetValue(BackgroundOpacityProperty);
            set
            {
                SetValue(BackgroundOpacityProperty, Math.Min(1d, Math.Max(0.1d, value)));
                OnPropertyChanged(nameof(BackgroundOpacity));
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

        public PackIconKind IconKind
        {
            get => (PackIconKind)GetValue(IconKindProperty);
            set
            {
                SetValue(IconKindProperty, value);
                OnPropertyChanged(nameof(IconKind));
            }
        }

        public bool ShowIcon
        {
            get => (bool)GetValue(ShowIconProperty);
            set
            {
                SetValue(ShowIconProperty, value);
                OnPropertyChanged(nameof(ShowIcon));
            }
        }

        public double TitleBarOpacity
        {
            get => (double)GetValue(TitleBarOpacityProperty);
            set
            {
                SetValue(TitleBarOpacityProperty, Math.Min(1d, Math.Max(0.1d, value)));
                OnPropertyChanged(nameof(TitleBarOpacity));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Static WindowEx class constructor. </summary>
        static WindowEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowEx),
                new FrameworkPropertyMetadata(typeof(WindowEx)));
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after pressing Maximize Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnMaximizeButtonClick(object sender, RoutedEventArgs e)
        {
            Maximize();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after pressing Minimize Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnMinimizeButtonClick(object sender, RoutedEventArgs e)
        {
            Minimize();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after pressing Close Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnCloseButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after pressing left mouse button on TitleBar. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Mouse Button Event Arguments. </param>
        protected virtual void OnTitleBarDrag(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        #endregion INTERACTION METHODS

        #region RESIZE INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after pressing left mouse button when cursor is over resize border. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Mouse Button Event Arguments. </param>
        private void ResizeBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ResizeStart(sender as Border, e.GetPosition(this).X, e.GetPosition(this).Y);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after releasing left mouse button when cursor is over resize border. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Mouse Button Event Arguments. </param>
        private void ResizeBorder_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ResizeEnd(sender as Border);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after moving cursor over resize border. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Mouse Button Event Arguments. </param>
        private void ResizeBorder_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                ResizeMove(sender as Border, e.GetPosition(this).X, e.GetPosition(this).Y);
        }

        #endregion RESIZE INTERACTION METHODS

        #region TEMPLATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> When overridden in a derived class,cis invoked whenever 
        /// application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            //  Apply Template
            base.OnApplyTemplate();

            ApplyClickMethod(GetButton("MinimizeButton"), OnMinimizeButtonClick);
            ApplyClickMethod(GetButton("MaximizeButton"), OnMaximizeButtonClick);
            ApplyClickMethod(GetButton("CloseButton"), OnCloseButtonClick);

            ApplyResizeBordersMethods("ResizeBorderTop");
            ApplyResizeBordersMethods("ResizeBorderLeft");
            ApplyResizeBordersMethods("ResizeBorderRight");
            ApplyResizeBordersMethods("ResizeBorderBottom");
            ApplyResizeBordersMethods("ResizeBorderTopLeft");
            ApplyResizeBordersMethods("ResizeBorderTopRight");
            ApplyResizeBordersMethods("ResizeBorderBottomLeft");
            ApplyResizeBordersMethods("ResizeBorderBottomRight");

            ApplyMouseLeftButtonDown(GetBorder("TitleBar"), OnTitleBarDrag);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Apply methods for resize border components. </summary>
        /// <param name="borderName"> Border name. </param>
        private void ApplyResizeBordersMethods(string borderName)
        {
            var border = GetBorder(borderName);

            ApplyMouseLeftButtonDown(border, ResizeBorder_MouseLeftButtonDown);
            ApplyMouseLeftButtonUp(border, ResizeBorder_MouseLeftButtonUp);
            ApplyMouseMove(border, ResizeBorder_MouseMove);
        }

        #endregion TEMPLATE METHODS

    }
}
