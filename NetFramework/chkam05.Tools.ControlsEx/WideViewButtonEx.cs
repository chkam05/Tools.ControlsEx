using chkam05.Tools.ControlsEx.Data.Enums;
using chkam05.Tools.ControlsEx.Resources;
using chkam05.Tools.ControlsEx.Utilities;
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

namespace chkam05.Tools.ControlsEx
{
    public class WideViewButtonEx : ContentControl
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundInactiveProperty = DependencyProperty.Register(
            nameof(BackgroundInactive),
            typeof(Brush),
            typeof(WideViewButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty BackgroundMouseOverProperty = DependencyProperty.Register(
            nameof(BackgroundMouseOver),
            typeof(Brush),
            typeof(WideViewButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty BackgroundPressedProperty = DependencyProperty.Register(
            nameof(BackgroundPressed),
            typeof(Brush),
            typeof(WideViewButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorPressed)));

        public static readonly DependencyProperty BorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(BorderBrushInactive),
            typeof(Brush),
            typeof(WideViewButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty BorderBrushMouseOverProperty = DependencyProperty.Register(
            nameof(BorderBrushMouseOver),
            typeof(Brush),
            typeof(WideViewButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty BorderBrushPressedProperty = DependencyProperty.Register(
            nameof(BorderBrushPressed),
            typeof(Brush),
            typeof(WideViewButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorPressed)));

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            nameof(Command),
            typeof(ICommand),
            typeof(WideViewButtonEx),
            new PropertyMetadata(null, CommandPropertyChangedCallback));

        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register(
            nameof(CommandParameter),
            typeof(object),
            typeof(WideViewButtonEx),
            new PropertyMetadata(null));

        public static readonly DependencyProperty ContentMarginProperty = DependencyProperty.Register(
            nameof(ContentMargin),
            typeof(Thickness),
            typeof(WideViewButtonEx),
            new PropertyMetadata(new Thickness(4,0,8,0)));

        public static readonly DependencyProperty ContentMinWidthProperty = DependencyProperty.Register(
            nameof(ContentMinWidth),
            typeof(double),
            typeof(WideViewButtonEx),
            new PropertyMetadata(128d));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(WideViewButtonEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(
            nameof(Description),
            typeof(string),
            typeof(WideViewButtonEx),
            new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty ForegroundInactiveProperty = DependencyProperty.Register(
            nameof(ForegroundInactive),
            typeof(Brush),
            typeof(WideViewButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty ForegroundMouseOverProperty = DependencyProperty.Register(
            nameof(ForegroundMouseOver),
            typeof(Brush),
            typeof(WideViewButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty ForegroundPressedProperty = DependencyProperty.Register(
            nameof(ForegroundPressed),
            typeof(Brush),
            typeof(WideViewButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty IconHeightProperty = DependencyProperty.Register(
            nameof(IconHeight),
            typeof(double),
            typeof(WideViewButtonEx),
            new PropertyMetadata(28d));

        public static readonly DependencyProperty IconKindProperty = DependencyProperty.Register(
            nameof(IconKind),
            typeof(PackIconKind),
            typeof(WideViewButtonEx),
            new PropertyMetadata(PackIconKind.CursorDefaultClick));

        public static readonly DependencyProperty IconMarginProperty = DependencyProperty.Register(
            nameof(IconMargin),
            typeof(Thickness),
            typeof(WideViewButtonEx),
            new PropertyMetadata(new Thickness(4)));

        public static readonly DependencyProperty IconWidthProperty = DependencyProperty.Register(
            nameof(IconWidth),
            typeof(double),
            typeof(WideViewButtonEx),
            new PropertyMetadata(28d));

        public static readonly DependencyProperty IsClickAssignedProperty = DependencyProperty.Register(
            nameof(IsClickAssigned),
            typeof(bool),
            typeof(WideViewButtonEx),
            new PropertyMetadata(false));

        public static readonly DependencyProperty IsPressedProperty = DependencyProperty.Register(
            nameof(IsPressed),
            typeof(bool),
            typeof(WideViewButtonEx),
            new PropertyMetadata(false));

        public static readonly DependencyProperty NavIconMarginProperty = DependencyProperty.Register(
            nameof(NavIconMargin),
            typeof(Thickness),
            typeof(WideViewButtonEx),
            new PropertyMetadata(new Thickness(0)));

        public static readonly DependencyProperty OpacityInactiveProperty = DependencyProperty.Register(
            nameof(OpacityInactive),
            typeof(double),
            typeof(WideViewButtonEx),
            new PropertyMetadata(0.56d));

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(WideViewButtonEx),
            new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty TitleDescriptionMarginProperty = DependencyProperty.Register(
            nameof(TitleDescriptionMargin),
            typeof(Thickness),
            typeof(WideViewButtonEx),
            new PropertyMetadata(new Thickness(8, 2, 4, 2)));


        //  EVENTS

        private event RoutedEventHandler click;

        public event RoutedEventHandler Click
        {
            add
            {
                click += value;
                UpdateIsClickAssigned(click);
            }
            remove
            {
                click -= value;
                UpdateIsClickAssigned(click);
            }
        }


        //  VARIABLES

        private bool IsActionable => Content == null && (click != null || Command != null);


        //  GETTERS & SETTERS

        public Brush BackgroundInactive
        {
            get => (Brush)GetValue(BackgroundInactiveProperty);
            set => SetValue(BackgroundInactiveProperty, value);
        }

        public Brush BackgroundMouseOver
        {
            get => (Brush)GetValue(BackgroundMouseOverProperty);
            set => SetValue(BackgroundMouseOverProperty, value);
        }

        public Brush BackgroundPressed
        {
            get => (Brush)GetValue(BackgroundPressedProperty);
            set => SetValue(BackgroundPressedProperty, value);
        }

        public Brush BorderBrushInactive
        {
            get => (Brush)GetValue(BorderBrushInactiveProperty);
            set => SetValue(BorderBrushInactiveProperty, value);
        }

        public Brush BorderBrushMouseOver
        {
            get => (Brush)GetValue(BorderBrushMouseOverProperty);
            set => SetValue(BorderBrushMouseOverProperty, value);
        }

        public Brush BorderBrushPressed
        {
            get => (Brush)GetValue(BorderBrushPressedProperty);
            set => SetValue(BorderBrushPressedProperty, value);
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public Thickness ContentMargin
        {
            get => (Thickness)GetValue(ContentMarginProperty);
            set => SetValue(ContentMarginProperty, value);
        }

        public double ContentMinWidth
        {
            get => (double)GetValue(ContentMinWidthProperty);
            set => SetValue(ContentMinWidthProperty, value);
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        public Brush ForegroundInactive
        {
            get => (Brush)GetValue(ForegroundInactiveProperty);
            set => SetValue(ForegroundInactiveProperty, value);
        }

        public Brush ForegroundMouseOver
        {
            get => (Brush)GetValue(ForegroundMouseOverProperty);
            set => SetValue(ForegroundMouseOverProperty, value);
        }

        public Brush ForegroundPressed
        {
            get => (Brush)GetValue(ForegroundPressedProperty);
            set => SetValue(ForegroundPressedProperty, value);
        }

        public double IconHeight
        {
            get => (double)GetValue(IconHeightProperty);
            set => SetValue(IconHeightProperty, value);
        }

        public PackIconKind IconKind
        {
            get => (PackIconKind)GetValue(IconKindProperty);
            set => SetValue(IconKindProperty, value);
        }

        public Thickness IconMargin
        {
            get => (Thickness)GetValue(IconMarginProperty);
            set => SetValue(IconMarginProperty, value);
        }

        public double IconWidth
        {
            get => (double)GetValue(IconWidthProperty);
            set => SetValue(IconWidthProperty, value);
        }

        public bool IsClickAssigned
        {
            get => (bool)GetValue(IsClickAssignedProperty);
            private set => SetValue(IsClickAssignedProperty, value);
        }

        public bool IsPressed
        {
            get => (bool)GetValue(IsPressedProperty);
            set => SetValue(IsPressedProperty, value);
        }

        public Thickness NavIconMargin
        {
            get => (Thickness)GetValue(NavIconMarginProperty);
            set => SetValue(NavIconMarginProperty, value);
        }

        public double OpacityInactive
        {
            get => (double)GetValue(OpacityInactiveProperty);
            set => SetValue(OpacityInactiveProperty, MathUtilities.Clamp(value, 0d, 1d));
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public Thickness TitleDescriptionMargin
        {
            get => (Thickness)GetValue(TitleDescriptionMarginProperty);
            set => SetValue(TitleDescriptionMarginProperty, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> WideViewButtonEx class constructor. </summary>
        static WideViewButtonEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WideViewButtonEx),
                new FrameworkPropertyMetadata(typeof(WideViewButtonEx)));
        }

        #endregion CONSTRUCTORS

        #region COMMANDS

        //  --------------------------------------------------------------------------------
        /// <summary> Invokes binded command. </summary>
        protected virtual void InvokeCommand()
        {
            if (Command != null && Command.CanExecute(CommandParameter))
            {
                Command.Execute(CommandParameter);
            }
        }

        #endregion COMMANDS

        #region CONTROL

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when an unhandled MouseLeftButtonDown routed event is raised on this element. </summary>
        /// <param name="e"> Mouse button event arguments. </param>
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (IsActionable)
            {
                IsPressed = true;
                CaptureMouse();
                VisualStateManager.GoToState(this, "Pressed", true);
            }

            base.OnMouseLeftButtonDown(e);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when an unhandled MouseLeftButtonUp routed event reaches an element in its route that is derived from this class</summary>
        /// <param name="e"> Mouse button event arguments. </param>
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            if (IsActionable)
            {
                if (IsPressed)
                {
                    IsPressed = false;
                    ReleaseMouseCapture();
                    VisualStateManager.GoToState(this, "Normal", true);
                    OnClick();
                    InvokeCommand();
                }
            }

            base.OnMouseLeftButtonUp(e);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invokes Click event. </summary>
        protected virtual void OnClick()
        {
            click?.Invoke(this, new RoutedEventArgs());
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when an unhandled MouseEnter attached event is raised on this element.</summary>
        /// <param name="e"> Mouse event arguments. </param>
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            if (IsActionable)
                VisualStateManager.GoToState(this, "MouseOver", true);

            base.OnMouseEnter(e);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when an unhandled MouseLeave attached event is raised on this element</summary>
        /// <param name="e"> Mouse event arguments. </param>
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            if (IsActionable)
            {
                IsPressed = false;
                ReleaseMouseCapture();
                VisualStateManager.GoToState(this, "Normal", true);
            }

            base.OnMouseLeave(e);
        }

        #endregion CONTROL

        #region PROPERTIES CHANGED CALLBACKS

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when Command property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void CommandPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is WideViewButtonEx wideViewButtonEx)
                wideViewButtonEx.UpdateIsClickAssigned(e.NewValue as ICommand);
        }

        #endregion PROPERTIES CHANGED CALLBACKS

        #region PROPERTIES UPDATE

        //  --------------------------------------------------------------------------------
        /// <summary> Update IsClickAssigned property value. </summary>
        /// <param name="newClickEvent"> New click event handler value. </param>
        private void UpdateIsClickAssigned(RoutedEventHandler newClickEvent)
        {
            IsClickAssigned = newClickEvent != null || Command != null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update IsClickAssigned property value. </summary>
        /// <param name="newCommand"> New command value. </param>
        private void UpdateIsClickAssigned(ICommand newCommand)
        {
            IsClickAssigned = click != null || newCommand != null;
        }

        #endregion PROPERTIES UPDATE

    }
}
