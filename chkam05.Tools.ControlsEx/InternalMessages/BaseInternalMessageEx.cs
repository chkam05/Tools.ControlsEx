using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Events;
using chkam05.Tools.ControlsEx.Static;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static chkam05.Tools.ControlsEx.Events.Delegates;

namespace chkam05.Tools.ControlsEx.InternalMessages
{
    public class BaseInternalMessageEx<CloseEventArgs> : Page, IInternalMessageEx, INotifyPropertyChanged 
        where CloseEventArgs : InternalMessageCloseEventArgs
    {

        //  CONST

        protected readonly static double ICON_HEIGHT = 32d;
        protected readonly static double ICON_WIDTH = 32d;
        protected readonly static double TITLE_FONT_SIZE = 20d;


        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.Register(
            nameof(BorderBrush),
            typeof(Brush),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        #endregion Appearance Colors Properties

        #region Appearance Buttons Colors Properties

        public static readonly DependencyProperty ButtonBackgroundProperty = DependencyProperty.Register(
            nameof(ButtonBackground),
            typeof(Brush),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty ButtonBorderBrushProperty = DependencyProperty.Register(
            nameof(ButtonBorderBrush),
            typeof(Brush),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty ButtonForegroundProperty = DependencyProperty.Register(
            nameof(ButtonForeground),
            typeof(Brush),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty ButtonMouseOverBackgroundProperty = DependencyProperty.Register(
            nameof(ButtonMouseOverBackground),
            typeof(Brush),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty ButtonMouseOverBorderBrushProperty = DependencyProperty.Register(
            nameof(ButtonMouseOverBorderBrush),
            typeof(Brush),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty ButtonMouseOverForegroundProperty = DependencyProperty.Register(
            nameof(ButtonMouseOverForeground),
            typeof(Brush),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty ButtonPressedBackgroundProperty = DependencyProperty.Register(
            nameof(ButtonPressedBackground),
            typeof(Brush),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_PRESSED)));

        public static readonly DependencyProperty ButtonPressedBorderBrushProperty = DependencyProperty.Register(
            nameof(ButtonPressedBorderBrush),
            typeof(Brush),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_PRESSED)));

        public static readonly DependencyProperty ButtonPressedForegroundProperty = DependencyProperty.Register(
            nameof(ButtonPressedForeground),
            typeof(Brush),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        #endregion Appearance Buttons Colors Properties

        #region Buttons Properties

        public static readonly DependencyProperty ButtonBorderThicknessProperty = DependencyProperty.Register(
            nameof(ButtonBorderThickness),
            typeof(Thickness),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(new Thickness(0)));

        #endregion Buttons Properties

        #region Icon Properties

        public static readonly DependencyProperty IconHeightProperty = DependencyProperty.Register(
            nameof(IconHeight),
            typeof(double),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(ICON_HEIGHT));

        public static readonly DependencyProperty IconKindProperty = DependencyProperty.Register(
            nameof(IconKind),
            typeof(PackIconKind),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(PackIconKind.InfoCircle));

        public static readonly DependencyProperty IconMarginProperty = DependencyProperty.Register(
            nameof(IconMargin),
            typeof(Thickness),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(new Thickness(0, 0, 8, 0)));

        public static readonly DependencyProperty IconMaxHeightProperty = DependencyProperty.Register(
            nameof(IconMaxHeight),
            typeof(double),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(double.NaN));

        public static readonly DependencyProperty IconMaxWidthProperty = DependencyProperty.Register(
            nameof(IconMaxWidth),
            typeof(double),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(double.NaN));

        public static readonly DependencyProperty IconMinHeightProperty = DependencyProperty.Register(
            nameof(IconMinHeight),
            typeof(double),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(0d));

        public static readonly DependencyProperty IconMinWidthProperty = DependencyProperty.Register(
            nameof(IconMinWidth),
            typeof(double),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(0d));

        public static readonly DependencyProperty IconWidthProperty = DependencyProperty.Register(
            nameof(IconWidth),
            typeof(double),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(ICON_WIDTH));

        #endregion Icon Properties

        #region Title Properties

        public static readonly DependencyProperty TitleFontFamilyProperty = DependencyProperty.Register(
            nameof(TitleFontFamily),
            typeof(FontFamily),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(new FontFamily()));

        public static readonly DependencyProperty TitleFontSizeProperty = DependencyProperty.Register(
            nameof(TitleFontSize),
            typeof(double),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(TITLE_FONT_SIZE));

        public static readonly DependencyProperty TitleFontStretchProperty = DependencyProperty.Register(
            nameof(TitleFontStretch),
            typeof(FontStretch),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(FontStretches.Normal));

        public static readonly DependencyProperty TitleFontStyleProperty = DependencyProperty.Register(
            nameof(TitleFontStyle),
            typeof(FontStyle),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(FontStyles.Normal));

        public static readonly DependencyProperty TitleFontWeightProperty = DependencyProperty.Register(
            nameof(TitleFontWeight),
            typeof(FontWeight),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(FontWeights.SemiBold));

        #endregion Title Properties

        public static readonly DependencyProperty BorderThicknessProperty = DependencyProperty.Register(
            nameof(BorderThickness),
            typeof(Thickness),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(new Thickness(1)));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));

        public static readonly DependencyProperty ContentPaddingProperty = DependencyProperty.Register(
            nameof(ContentPadding),
            typeof(Thickness),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(new Thickness(8)));

        public static readonly DependencyProperty PaddingProperty = DependencyProperty.Register(
            nameof(Padding),
            typeof(Thickness),
            typeof(BaseInternalMessageEx<CloseEventArgs>),
            new PropertyMetadata(new Thickness(8)));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;
        public event InternalMessageClose<CloseEventArgs> OnClose;
        public event InternalMessageHide OnHide;


        //  VARIABLES

        private bool _allowHide = false;
        internal InternalMessagesExContainer _parentContainer = null;


        //  GETTERS & SETTERS

        #region Appearance Colors

        public Brush BorderBrush
        {
            get => (Brush)GetValue(BorderBrushProperty);
            set
            {
                SetValue(BorderBrushProperty, value);
                OnPropertyChanged(nameof(BorderBrush));
            }
        }

        #endregion Appearance Colors

        #region Appearance Buttons Colors

        public Brush ButtonBackground
        {
            get => (Brush)GetValue(ButtonBackgroundProperty);
            set
            {
                SetValue(ButtonBackgroundProperty, value);
                OnPropertyChanged(nameof(ButtonBackground));
            }
        }

        public Brush ButtonBorderBrush
        {
            get => (Brush)GetValue(ButtonBorderBrushProperty);
            set
            {
                SetValue(ButtonBorderBrushProperty, value);
                OnPropertyChanged(nameof(ButtonBorderBrush));
            }
        }

        public Brush ButtonForeground
        {
            get => (Brush)GetValue(ButtonForegroundProperty);
            set
            {
                SetValue(ButtonForegroundProperty, value);
                OnPropertyChanged(nameof(ButtonForeground));
            }
        }

        public Brush ButtonMouseOverBackground
        {
            get => (Brush)GetValue(ButtonMouseOverBackgroundProperty);
            set
            {
                SetValue(ButtonMouseOverBackgroundProperty, value);
                OnPropertyChanged(nameof(ButtonMouseOverBackground));
            }
        }

        public Brush ButtonMouseOverBorderBrush
        {
            get => (Brush)GetValue(ButtonMouseOverBorderBrushProperty);
            set
            {
                SetValue(ButtonMouseOverBorderBrushProperty, value);
                OnPropertyChanged(nameof(ButtonMouseOverBorderBrush));
            }
        }

        public Brush ButtonMouseOverForeground
        {
            get => (Brush)GetValue(ButtonMouseOverForegroundProperty);
            set
            {
                SetValue(ButtonMouseOverForegroundProperty, value);
                OnPropertyChanged(nameof(ButtonMouseOverForeground));
            }
        }

        public Brush ButtonPressedBackground
        {
            get => (Brush)GetValue(ButtonPressedBackgroundProperty);
            set
            {
                SetValue(ButtonPressedBackgroundProperty, value);
                OnPropertyChanged(nameof(ButtonPressedBackground));
            }
        }

        public Brush ButtonPressedBorderBrush
        {
            get => (Brush)GetValue(ButtonPressedBorderBrushProperty);
            set
            {
                SetValue(ButtonPressedBorderBrushProperty, value);
                OnPropertyChanged(nameof(ButtonPressedBorderBrush));
            }
        }

        public Brush ButtonPressedForeground
        {
            get => (Brush)GetValue(ButtonPressedForegroundProperty);
            set
            {
                SetValue(ButtonPressedForegroundProperty, value);
                OnPropertyChanged(nameof(ButtonPressedForeground));
            }
        }

        #endregion Appearance Buttons Colors

        #region Buttons

        public Thickness ButtonBorderThickness
        {
            get => (Thickness)GetValue(ButtonBorderThicknessProperty);
            set
            {
                SetValue(ButtonBorderThicknessProperty, value);
                OnPropertyChanged(nameof(ButtonBorderThickness));
            }
        }

        #endregion Buttons

        #region Icon

        public double IconHeight
        {
            get => (double)GetValue(IconHeightProperty);
            set
            {
                SetValue(IconHeightProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(IconHeight));
            }
        }

        public PackIconKind IconKind
        {
            get => (PackIconKind)GetValue(IconKindProperty);
            set
            {
                SetValue(IconKindProperty, value);
                OnPropertyChanged(nameof(IconKindProperty));
            }
        }

        public Thickness IconMargin
        {
            get => (Thickness)GetValue(IconMarginProperty);
            set
            {
                SetValue(IconMarginProperty, value);
                OnPropertyChanged(nameof(IconMargin));
            }
        }

        public double IconMaxHeight
        {
            get => (double)GetValue(IconMaxHeightProperty);
            set
            {
                SetValue(IconMaxHeightProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(IconMaxHeight));
            }
        }

        public double IconMaxWidth
        {
            get => (double)GetValue(IconMaxWidthProperty);
            set
            {
                SetValue(IconMaxWidthProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(IconMaxWidth));
            }
        }

        public double IconMinHeight
        {
            get => (double)GetValue(IconMinHeightProperty);
            set
            {
                SetValue(IconMinHeightProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(IconMinHeight));
            }
        }

        public double IconMinWidth
        {
            get => (double)GetValue(IconMinWidthProperty);
            set
            {
                SetValue(IconMinWidthProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(IconMinWidth));
            }
        }

        public double IconWidth
        {
            get => (double)GetValue(IconWidthProperty);
            set
            {
                SetValue(IconWidthProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(IconWidth));
            }
        }

        #endregion Icon

        #region Title

        public FontFamily TitleFontFamily
        {
            get => (FontFamily)GetValue(TitleFontFamilyProperty);
            set
            {
                SetValue(TitleFontFamilyProperty, value);
                OnPropertyChanged(nameof(TitleFontFamily));
            }
        }

        public double TitleFontSize
        {
            get => (double)GetValue(TitleFontSizeProperty);
            set
            {
                SetValue(TitleFontSizeProperty, value);
                OnPropertyChanged(nameof(TitleFontSize));
            }
        }

        public FontStretch TitleFontStretch
        {
            get => (FontStretch)GetValue(TitleFontStretchProperty);
            set
            {
                SetValue(TitleFontStretchProperty, value);
                OnPropertyChanged(nameof(TitleFontStretch));
            }
        }

        public FontStyle TitleFontStyle
        {
            get => (FontStyle)GetValue(TitleFontStyleProperty);
            set
            {
                SetValue(TitleFontStyleProperty, value);
                OnPropertyChanged(nameof(TitleFontStyle));
            }
        }

        public FontWeight TitleFontWeight
        {
            get => (FontWeight)GetValue(TitleFontWeightProperty);
            set
            {
                SetValue(TitleFontWeightProperty, value);
                OnPropertyChanged(nameof(TitleFontWeight));
            }
        }

        #endregion Title

        public Thickness BorderThickness
        {
            get => (Thickness)GetValue(BorderThicknessProperty);
            set
            {
                SetValue(BorderThicknessProperty, value);
                OnPropertyChanged(nameof(BorderThickness));
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

        public Thickness ContentPadding
        {
            get => (Thickness)GetValue(ContentPaddingProperty);
            set
            {
                SetValue(ContentPaddingProperty, value);
                OnPropertyChanged(nameof(ContentPadding));
            }
        }

        public Thickness Padding
        {
            get => (Thickness)GetValue(PaddingProperty);
            set
            {
                SetValue(PaddingProperty, value);
                OnPropertyChanged(nameof(Padding));
            }
        }


        public bool AllowHide
        {
            get => _allowHide;
            set
            {
                _allowHide = value;
                OnPropertyChanged(nameof(AllowHide));

                if (IsLoadingComplete)
                    OnAllowHideUpdate(value);
            }
        }

        public bool IsHidden { get; private set; }

        public bool IsLoadingComplete { get; protected set; } = false;

        public InternalMessageResult Result { get; internal set; } = InternalMessageResult.None;


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> BaseInternalMessageEx class constructor. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        public BaseInternalMessageEx(InternalMessagesExContainer parentContainer) : base()
        {
            _parentContainer = parentContainer;
            Loaded += MessageLoaded;
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Close InternalMessage. </summary>
        public void Close()
        {
            InvokeClose((CloseEventArgs) new InternalMessageCloseEventArgs(Result));
            _parentContainer.CloseMessage(this);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoke close event. </summary>
        /// <param name="e"> Event arguments based on InternalMessageCloseEventArgs. </param>
        protected void InvokeClose(CloseEventArgs e)
        {
            OnClose?.Invoke(this, e);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Hide InternalMessage if it is allowed. </summary>
        public void Hide()
        {
            if (AllowHide)
            {
                IsHidden = true;
                InvokeHide(new InternalMessageHideEventArgs(true));
                _parentContainer.HideMessage(this);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoke hide event. </summary>
        /// <param name="e"> Internal Message Hide Event Arguments. </param>
        protected void InvokeHide(InternalMessageHideEventArgs e)
        {
            OnHide?.Invoke(this, e);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Show hidden InternalMessage. </summary>
        public void Show()
        {
            if (IsHidden)
            {
                IsHidden = false;
                _parentContainer.ShowMessage(this);
            }
        }

        #endregion INTERACTION METHODS

        #region MESSAGE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading InternalMessage into parent container. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void MessageLoaded(object sender, RoutedEventArgs e)
        {
            if (_parentContainer == null)
                throw new NullReferenceException($"Parent InternalMessage container has not been set.");

            IsLoadingComplete = true;
        }

        #endregion MESSAGE METHODS

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

        #region TEMPLATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Apply Click method on ButtonEx. </summary>
        /// <param name="buttonEx"> ButtonEx. </param>
        /// <param name="eventHandler"> Click method. </param>
        protected void ApplyButtonExClickMethod(ButtonEx buttonEx, RoutedEventHandler eventHandler)
        {
            if (buttonEx != null)
                buttonEx.Click += eventHandler;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get ButtonEx from ContentTemplate. </summary>
        /// <param name="buttonName"> ButtonEx name. </param>
        /// <returns> ButtonEx or null. </returns>
        protected ButtonEx GetButtonEx(string buttonName)
        {
            return this.Template.FindName(buttonName, this) as ButtonEx;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing AllowHide property. </summary>
        /// <param name="showHide"> True - allow hide; False - otherwise. </param>
        protected virtual void OnAllowHideUpdate(bool showHide = false)
        {
            var buttonHide = GetButtonEx("hideButton");
            buttonHide.Visibility = showHide ? Visibility.Visible : Visibility.Collapsed;
        }

        #endregion TEMPLATE METHODS

    }
}
