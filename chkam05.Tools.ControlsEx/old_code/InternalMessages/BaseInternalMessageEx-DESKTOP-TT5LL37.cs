using chkam05.Tools.ControlsEx.Events;
using chkam05.Tools.ControlsEx.Static;
using MaterialDesignThemes.Wpf;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static chkam05.Tools.ControlsEx.Events.Delegates;


namespace chkam05.Tools.ControlsEx.InternalMessages
{
    public class BaseInternalMessageEx : Page, INotifyPropertyChanged
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
            typeof(BaseInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        #endregion Appearance Colors Properties

        #region Icon Properties

        public static readonly DependencyProperty IconHeightProperty = DependencyProperty.Register(
            nameof(IconHeight),
            typeof(double),
            typeof(BaseInternalMessageEx),
            new PropertyMetadata(ICON_HEIGHT));

        public static readonly DependencyProperty IconKindProperty = DependencyProperty.Register(
            nameof(IconKind),
            typeof(PackIconKind),
            typeof(BaseInternalMessageEx),
            new PropertyMetadata(PackIconKind.InfoCircle));

        public static readonly DependencyProperty IconMarginProperty = DependencyProperty.Register(
            nameof(IconMargin),
            typeof(Thickness),
            typeof(BaseInternalMessageEx),
            new PropertyMetadata(new Thickness(0, 0, 8, 0)));

        public static readonly DependencyProperty IconMaxHeightProperty = DependencyProperty.Register(
            nameof(IconMaxHeight),
            typeof(double),
            typeof(BaseInternalMessageEx),
            new PropertyMetadata(double.NaN));

        public static readonly DependencyProperty IconMaxWidthProperty = DependencyProperty.Register(
            nameof(IconMaxWidth),
            typeof(double),
            typeof(BaseInternalMessageEx),
            new PropertyMetadata(double.NaN));

        public static readonly DependencyProperty IconMinHeightProperty = DependencyProperty.Register(
            nameof(IconMinHeight),
            typeof(double),
            typeof(BaseInternalMessageEx),
            new PropertyMetadata(0d));

        public static readonly DependencyProperty IconMinWidthProperty = DependencyProperty.Register(
            nameof(IconMinWidth),
            typeof(double),
            typeof(BaseInternalMessageEx),
            new PropertyMetadata(0d));

        public static readonly DependencyProperty IconWidthProperty = DependencyProperty.Register(
            nameof(IconWidth),
            typeof(double),
            typeof(BaseInternalMessageEx),
            new PropertyMetadata(ICON_WIDTH));

        #endregion Icon Properties

        #region Title Properties

        public static readonly DependencyProperty TitleFontFamilyProperty = DependencyProperty.Register(
            nameof(TitleFontFamily),
            typeof(FontFamily),
            typeof(BaseInternalMessageEx),
            new PropertyMetadata(new FontFamily()));

        public static readonly DependencyProperty TitleFontSizeProperty = DependencyProperty.Register(
            nameof(TitleFontSize),
            typeof(double),
            typeof(BaseInternalMessageEx),
            new PropertyMetadata(TITLE_FONT_SIZE));

        public static readonly DependencyProperty TitleFontStretchProperty = DependencyProperty.Register(
            nameof(TitleFontStretch),
            typeof(FontStretch),
            typeof(BaseInternalMessageEx),
            new PropertyMetadata(FontStretches.Normal));

        public static readonly DependencyProperty TitleFontStyleProperty = DependencyProperty.Register(
            nameof(TitleFontStyle),
            typeof(FontStyle),
            typeof(BaseInternalMessageEx),
            new PropertyMetadata(FontStyles.Normal));

        public static readonly DependencyProperty TitleFontWeightProperty = DependencyProperty.Register(
            nameof(TitleFontWeight),
            typeof(FontWeight),
            typeof(BaseInternalMessageEx),
            new PropertyMetadata(FontWeights.SemiBold));

        #endregion Title Properties

        public static readonly DependencyProperty AllowHideProperty = DependencyProperty.Register(
            nameof(AllowHide),
            typeof(bool),
            typeof(BaseInternalMessageEx),
            new PropertyMetadata(false));

        public static readonly DependencyProperty ButtonsProperty = DependencyProperty.Register(
            nameof(Buttons),
            typeof(InternalMessageButtons),
            typeof(BaseInternalMessageEx),
            new PropertyMetadata(InternalMessageButtons.Ok));

        public static readonly DependencyProperty BorderThicknessProperty = DependencyProperty.Register(
            nameof(BorderThickness),
            typeof(Thickness),
            typeof(BaseInternalMessageEx),
            new PropertyMetadata(new Thickness(1)));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(BaseInternalMessageEx),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));

        public static readonly DependencyProperty PaddingProperty = DependencyProperty.Register(
            nameof(Padding),
            typeof(Thickness),
            typeof(BaseInternalMessageEx),
            new PropertyMetadata(new Thickness(8)));

        public static readonly DependencyProperty ResultProperty = DependencyProperty.Register(
            nameof(Result),
            typeof(InternalMessageResult),
            typeof(BaseInternalMessageEx),
            new PropertyMetadata(InternalMessageResult.None));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual event InternalMessageClose<InternalMessageCloseEventArgs> MessageClose;
        public virtual event InternalMessageHide MessageHide;


        //  VARIABLES

        private bool _isHidden = false;


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

        public bool AllowHide
        {
            get => (bool)GetValue(AllowHideProperty);
            set
            {
                SetValue(AllowHideProperty, value);
                OnPropertyChanged(nameof(AllowHide));
            }
        }

        public Thickness BorderThickness
        {
            get => (Thickness)GetValue(BorderThicknessProperty);
            set
            {
                SetValue(BorderThicknessProperty, value);
                OnPropertyChanged(nameof(BorderThickness));
            }
        }

        public InternalMessageButtons Buttons
        {
            get => (InternalMessageButtons)GetValue(ButtonsProperty);
            set
            {
                SetValue(ButtonsProperty, value);
                OnPropertyChanged(nameof(ButtonsProperty));
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

        public bool IsHidden
        {
            get => _isHidden;
            set
            {
                _isHidden = AllowHide && value == true ? value : false;

                if (AllowHide || value == false)
                {
                    MessageHide?.Invoke(this, new InternalMessageHideEventArgs(_isHidden));
                    OnPropertyChanged(nameof(INotifyPropertyChanged));
                }
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

        public InternalMessageResult Result
        {
            get => (InternalMessageResult)GetValue(ResultProperty);
            set
            {
                SetValue(ResultProperty, value);
                OnPropertyChanged(nameof(Result));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Static InternalMessageEx class constructor. </summary>
        static BaseInternalMessageEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseInternalMessageEx),
                new FrameworkPropertyMetadata(typeof(BaseInternalMessageEx)));
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Ok Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnOkClick(object sender, RoutedEventArgs e)
        {
            Result = InternalMessageResult.Ok;
            MessageClose?.Invoke(this, new InternalMessageCloseEventArgs(Result));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Yes Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnYesClick(object sender, RoutedEventArgs e)
        {
            Result = InternalMessageResult.Yes;
            MessageClose?.Invoke(this, new InternalMessageCloseEventArgs(Result));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking No Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnNoClick(object sender, RoutedEventArgs e)
        {
            Result = InternalMessageResult.No;
            MessageClose?.Invoke(this, new InternalMessageCloseEventArgs(Result));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Cancel Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnCancelClick(object sender, RoutedEventArgs e)
        {
            Result = InternalMessageResult.Cancel;
            MessageClose?.Invoke(this, new InternalMessageCloseEventArgs(Result));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Hide Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnHideClick(object sender, RoutedEventArgs e)
        {
            IsHidden = true;
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

        #region TEMPLATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> When overridden in a derived class,cis invoked whenever 
        /// application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            //  Apply Template
            base.OnApplyTemplate();

            ApplyClickMethod(GetButton("okButton"), OnOkClick);
            ApplyClickMethod(GetButton("yesButton"), OnYesClick);
            ApplyClickMethod(GetButton("noButton"), OnNoClick);
            ApplyClickMethod(GetButton("cancelButton"), OnCancelClick);
            ApplyClickMethod(GetButton("hideButton"), OnHideClick);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get ButtonEx from ContentTemplate. </summary>
        /// <param name="buttonName"> ButtonEx name. </param>
        /// <returns> ButtonEx or null. </returns>
        protected ButtonEx GetButton(string buttonName)
        {
            return this.Template.FindName(buttonName, this) as ButtonEx;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Apply Click method on ButtonEx. </summary>
        /// <param name="buttonEx"> ButtonEx. </param>
        /// <param name="eventHandler"> Click method. </param>
        protected void ApplyClickMethod(ButtonEx buttonEx, RoutedEventHandler eventHandler)
        {
            if (buttonEx != null)
                buttonEx.Click += eventHandler;
        }

        #endregion TEMPLATE METHODS

    }
}
