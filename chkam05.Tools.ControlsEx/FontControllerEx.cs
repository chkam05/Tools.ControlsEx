using chkam05.Tools.ControlsEx.Colors;
using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Events;
using chkam05.Tools.ControlsEx.Static;
using chkam05.Tools.ControlsEx.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static chkam05.Tools.ControlsEx.Events.Delegates;
using TextDataFormat = chkam05.Tools.ControlsEx.Data.TextDataFormat;


namespace chkam05.Tools.ControlsEx
{
    public class FontControllerEx : Control, INotifyPropertyChanged
    {

        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty ButtonBackgroundProperty = DependencyProperty.Register(
            nameof(ButtonBackground),
            typeof(Brush),
            typeof(FontControllerEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty ButtonBorderBrushProperty = DependencyProperty.Register(
            nameof(ButtonBorderBrush),
            typeof(Brush),
            typeof(FontControllerEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty ButtonForegroundProperty = DependencyProperty.Register(
            nameof(ButtonForeground),
            typeof(Brush),
            typeof(FontControllerEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_FOREGROUND)));

        public static readonly DependencyProperty InternalBackgroundProperty = DependencyProperty.Register(
            nameof(InternalBackground),
            typeof(Brush),
            typeof(FontControllerEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_COLOR)));

        public static readonly DependencyProperty InternalBorderBrushProperty = DependencyProperty.Register(
            nameof(InternalBorderBrush),
            typeof(Brush),
            typeof(FontControllerEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty InternalForegroundProperty = DependencyProperty.Register(
            nameof(InternalForeground),
            typeof(Brush),
            typeof(FontControllerEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty ItemBackgroundProperty = DependencyProperty.Register(
            nameof(ItemBackground),
            typeof(Brush),
            typeof(FontControllerEx),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty ItemBorderBrushProperty = DependencyProperty.Register(
            nameof(ItemBorderBrush),
            typeof(Brush),
            typeof(FontControllerEx),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty ItemForegroundProperty = DependencyProperty.Register(
            nameof(ItemForeground),
            typeof(Brush),
            typeof(FontControllerEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty MouseOverBackgroundProperty = DependencyProperty.Register(
            nameof(MouseOverBackground),
            typeof(Brush),
            typeof(FontControllerEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty MouseOverBorderBrushProperty = DependencyProperty.Register(
            nameof(MouseOverBorderBrush),
            typeof(Brush),
            typeof(FontControllerEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty MouseOverForegroundProperty = DependencyProperty.Register(
            nameof(MouseOverForeground),
            typeof(Brush),
            typeof(FontControllerEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_FOREGROUND)));

        public static readonly DependencyProperty PressedBackgroundProperty = DependencyProperty.Register(
            nameof(PressedBackground),
            typeof(Brush),
            typeof(FontControllerEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_PRESSED)));

        public static readonly DependencyProperty PressedBorderBrushProperty = DependencyProperty.Register(
            nameof(PressedBorderBrush),
            typeof(Brush),
            typeof(FontControllerEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_PRESSED)));

        public static readonly DependencyProperty PressedForegroundProperty = DependencyProperty.Register(
            nameof(PressedForeground),
            typeof(Brush),
            typeof(FontControllerEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_FOREGROUND)));

        public static readonly DependencyProperty SelectedBackgroundProperty = DependencyProperty.Register(
            nameof(SelectedBackground),
            typeof(Brush),
            typeof(FontControllerEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_SELECTED)));

        public static readonly DependencyProperty SelectedBorderBrushProperty = DependencyProperty.Register(
            nameof(SelectedBorderBrush),
            typeof(Brush),
            typeof(FontControllerEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_SELECTED)));

        public static readonly DependencyProperty SelectedForegroundProperty = DependencyProperty.Register(
            nameof(SelectedForeground),
            typeof(Brush),
            typeof(FontControllerEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_FOREGROUND)));

        public static readonly DependencyProperty SelectedTextBackgroundProperty = DependencyProperty.Register(
            nameof(SelectedTextBackground),
            typeof(Brush),
            typeof(FontControllerEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_SELECTED)));

        #endregion Appearance Colors Properties

        #region Font Configuration Properties

        public static readonly DependencyProperty ShowFontSelectorProperty = DependencyProperty.Register(
            nameof(ShowFontSelector),
            typeof(bool),
            typeof(FontControllerEx),
            new PropertyMetadata(true));

        public static readonly DependencyProperty ShowFontSizeSelectorProperty = DependencyProperty.Register(
            nameof(ShowFontSizeSelector),
            typeof(bool),
            typeof(FontControllerEx),
            new PropertyMetadata(true));

        public static readonly DependencyProperty ShowFontBoldSelectorProperty = DependencyProperty.Register(
            nameof(ShowFontBoldSelector),
            typeof(bool),
            typeof(FontControllerEx),
            new PropertyMetadata(true));

        public static readonly DependencyProperty ShowFontItalicSelectorProperty = DependencyProperty.Register(
            nameof(ShowFontItalicSelector),
            typeof(bool),
            typeof(FontControllerEx),
            new PropertyMetadata(true));

        public static readonly DependencyProperty ShowFontUnderlineSelectorProperty = DependencyProperty.Register(
            nameof(ShowFontUnderlineSelector),
            typeof(bool),
            typeof(FontControllerEx),
            new PropertyMetadata(true));

        public static readonly DependencyProperty ShowFontStrikeSelectorProperty = DependencyProperty.Register(
            nameof(ShowFontStrikeSelector),
            typeof(bool),
            typeof(FontControllerEx),
            new PropertyMetadata(true));

        public static readonly DependencyProperty ShowTextAlignmentSelectorProperty = DependencyProperty.Register(
            nameof(ShowTextAlignmentSelector),
            typeof(bool),
            typeof(FontControllerEx),
            new PropertyMetadata(true));

        public static readonly DependencyProperty ShowFontColorSelectorProperty = DependencyProperty.Register(
            nameof(ShowFontColorSelector),
            typeof(bool),
            typeof(FontControllerEx),
            new PropertyMetadata(true));

        public static readonly DependencyProperty ShowFontBackgroundSelectorProperty = DependencyProperty.Register(
            nameof(ShowFontBackgroundSelector),
            typeof(bool),
            typeof(FontControllerEx),
            new PropertyMetadata(true));

        public static readonly DependencyProperty ShowTextDataFormatSelectorProperty = DependencyProperty.Register(
            nameof(ShowTextDataFormatSelector),
            typeof(bool),
            typeof(FontControllerEx),
            new PropertyMetadata(true));

        #endregion Font Configuration Properties

        #region Font Properties

        public static readonly DependencyProperty FontsProperty = DependencyProperty.Register(
            nameof(Fonts),
            typeof(ObservableCollection<FontFamilyInfo>),
            typeof(FontControllerEx),
            new PropertyMetadata(new ObservableCollection<FontFamilyInfo>(FontUtilities.SystemFonts)));

        public static readonly DependencyProperty SelectedFontProperty = DependencyProperty.Register(
            nameof(SelectedFont),
            typeof(FontFamilyInfo),
            typeof(FontControllerEx),
            new PropertyMetadata(FontUtilities.DefaultFont));

        public static readonly DependencyProperty SelectedFontSizeProperty = DependencyProperty.Register(
            nameof(SelectedFontSize),
            typeof(double),
            typeof(FontControllerEx),
            new PropertyMetadata(11d));

        public static readonly DependencyProperty FontSizeMaxProperty = DependencyProperty.Register(
            nameof(FontSizeMax),
            typeof(double),
            typeof(FontControllerEx),
            new PropertyMetadata(72d));

        public static readonly DependencyProperty FontSizeMinProperty = DependencyProperty.Register(
            nameof(FontSizeMin),
            typeof(double),
            typeof(FontControllerEx),
            new PropertyMetadata(9d));

        public static readonly DependencyProperty SelectedFontStrikeProperty = DependencyProperty.Register(
            nameof(SelectedFontStrike),
            typeof(bool),
            typeof(FontControllerEx),
            new PropertyMetadata(false));

        public static readonly DependencyProperty SelectedFontStyleProperty = DependencyProperty.Register(
            nameof(SelectedFontStyle),
            typeof(FontStyle),
            typeof(FontControllerEx),
            new PropertyMetadata(System.Windows.FontStyles.Normal));

        public static readonly DependencyProperty SelectedFontUnderlineProperty = DependencyProperty.Register(
            nameof(SelectedFontUnderline),
            typeof(bool),
            typeof(FontControllerEx),
            new PropertyMetadata(false));

        public static readonly DependencyProperty SelectedFontWeightProperty = DependencyProperty.Register(
            nameof(SelectedFontWeight),
            typeof(FontWeight),
            typeof(FontControllerEx),
            new PropertyMetadata(System.Windows.FontWeights.Normal));

        public static readonly DependencyProperty SelectedFontColorProperty = DependencyProperty.Register(
            nameof(SelectedFontColor),
            typeof(System.Windows.Media.Color),
            typeof(FontControllerEx),
            new PropertyMetadata(System.Windows.Media.Colors.Black));

        public static readonly DependencyProperty SelectedFontBackgroundProperty = DependencyProperty.Register(
            nameof(SelectedFontBackground),
            typeof(System.Windows.Media.Color),
            typeof(FontControllerEx),
            new PropertyMetadata(System.Windows.Media.Colors.Transparent));

        #endregion Font Properties

        #region Text Porperties

        public static readonly DependencyProperty DataFormatsProperty = DependencyProperty.Register(
            nameof(DataFormats),
            typeof(ObservableCollection<string>),
            typeof(FontControllerEx),
            new PropertyMetadata(new ObservableCollection<string>(TextDataFormat.ListData)));

        public static readonly DependencyProperty DataFormatProperty = DependencyProperty.Register(
            nameof(DataFormat),
            typeof(string),
            typeof(FontControllerEx),
            new PropertyMetadata(TextDataFormat.Text));

        public static readonly DependencyProperty SelectedTextAlignmentProperty = DependencyProperty.Register(
            nameof(SelectedTextAlignment),
            typeof(TextAlignment?),
            typeof(FontControllerEx),
            new PropertyMetadata(System.Windows.TextAlignment.Left));

        #endregion Text Properties

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(FontControllerEx),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;
        public event FontBackgroundChangedRequestEventHandler FontBackgroundChangeRequested;
        public event FontChangedEventHandler FontChanged;
        public event FontColorChangeRequestEventHandler FontColorChangeRequested;
        public event FontSizeChangedEventHandler FontSizeChanged;
        public event FontStrikeChangedEventHandler FontStrikeChanged;
        public event FontStyleChangedEventHandler FontStyleChanged;
        public event FontUnderlineChangedEventHandler FontUnderlineChanged;
        public event FontWeightChangedEventHandler FontWeightChanged;
        public event TextAlignmentChangedEventHandler TextAlignmentChanged;
        public event TextDataFormatChangedEventHandler TextDataFormatChanged;


        //  VARIABLES


        //  GETTERS & SETTERS

        #region Appearance Colors

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

        public Brush InternalBackground
        {
            get => (Brush)GetValue(InternalBackgroundProperty);
            set
            {
                SetValue(InternalBackgroundProperty, value);
                OnPropertyChanged(nameof(InternalBackground));
            }
        }

        public Brush InternalBorderBrush
        {
            get => (Brush)GetValue(InternalBorderBrushProperty);
            set
            {
                SetValue(InternalBorderBrushProperty, value);
                OnPropertyChanged(nameof(InternalBorderBrush));
            }
        }

        public Brush InternalForeground
        {
            get => (Brush)GetValue(InternalForegroundProperty);
            set
            {
                SetValue(InternalForegroundProperty, value);
                OnPropertyChanged(nameof(InternalForeground));
            }
        }

        public Brush ItemBackground
        {
            get => (Brush)GetValue(ItemBackgroundProperty);
            set
            {
                SetValue(ItemBackgroundProperty, value);
                OnPropertyChanged(nameof(ItemBackground));
            }
        }

        public Brush ItemBorderBrush
        {
            get => (Brush)GetValue(ItemBorderBrushProperty);
            set
            {
                SetValue(ItemBorderBrushProperty, value);
                OnPropertyChanged(nameof(ItemBorderBrush));
            }
        }

        public Brush ItemForeground
        {
            get => (Brush)GetValue(ItemForegroundProperty);
            set
            {
                SetValue(ItemForegroundProperty, value);
                OnPropertyChanged(nameof(ItemForeground));
            }
        }

        public Brush MouseOverBackground
        {
            get => (Brush)GetValue(MouseOverBackgroundProperty);
            set
            {
                SetValue(MouseOverBackgroundProperty, value);
                OnPropertyChanged(nameof(MouseOverBackground));
            }
        }

        public Brush MouseOverBorderBrush
        {
            get => (Brush)GetValue(MouseOverBorderBrushProperty);
            set
            {
                SetValue(MouseOverBorderBrushProperty, value);
                OnPropertyChanged(nameof(MouseOverBorderBrush));
            }
        }

        public Brush MouseOverForeground
        {
            get => (Brush)GetValue(MouseOverForegroundProperty);
            set
            {
                SetValue(MouseOverForegroundProperty, value);
                OnPropertyChanged(nameof(MouseOverForeground));
            }
        }

        public Brush PressedBackground
        {
            get => (Brush)GetValue(PressedBackgroundProperty);
            set
            {
                SetValue(PressedBackgroundProperty, value);
                OnPropertyChanged(nameof(PressedBackground));
            }
        }

        public Brush PressedBorderBrush
        {
            get => (Brush)GetValue(PressedBorderBrushProperty);
            set
            {
                SetValue(PressedBorderBrushProperty, value);
                OnPropertyChanged(nameof(PressedBorderBrush));
            }
        }

        public Brush PressedForeground
        {
            get => (Brush)GetValue(PressedForegroundProperty);
            set
            {
                SetValue(PressedForegroundProperty, value);
                OnPropertyChanged(nameof(PressedForeground));
            }
        }

        public Brush SelectedBackground
        {
            get => (Brush)GetValue(SelectedBackgroundProperty);
            set
            {
                SetValue(SelectedBackgroundProperty, value);
                OnPropertyChanged(nameof(SelectedBackground));
            }
        }

        public Brush SelectedBorderBrush
        {
            get => (Brush)GetValue(SelectedBorderBrushProperty);
            set
            {
                SetValue(SelectedBorderBrushProperty, value);
                OnPropertyChanged(nameof(SelectedBorderBrush));
            }
        }

        public Brush SelectedForeground
        {
            get => (Brush)GetValue(SelectedForegroundProperty);
            set
            {
                SetValue(SelectedForegroundProperty, value);
                OnPropertyChanged(nameof(SelectedForeground));
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

        #region Font Configuration

        public bool ShowFontSelector
        {
            get => (bool)GetValue(ShowFontSelectorProperty);
            set
            {
                SetValue(ShowFontSelectorProperty, value);
                OnPropertyChanged(nameof(ShowFontSelector));
            }
        }

        public bool ShowFontSizeSelector
        {
            get => (bool)GetValue(ShowFontSizeSelectorProperty);
            set
            {
                SetValue(ShowFontSizeSelectorProperty, value);
                OnPropertyChanged(nameof(ShowFontSizeSelector));
            }
        }

        public bool ShowFontBoldSelector
        {
            get => (bool)GetValue(ShowFontBoldSelectorProperty);
            set
            {
                SetValue(ShowFontBoldSelectorProperty, value);
                OnPropertyChanged(nameof(ShowFontBoldSelector));
            }
        }

        public bool ShowFontItalicSelector
        {
            get => (bool)GetValue(ShowFontItalicSelectorProperty);
            set
            {
                SetValue(ShowFontItalicSelectorProperty, value);
                OnPropertyChanged(nameof(ShowFontItalicSelector));
            }
        }

        public bool ShowFontUnderlineSelector
        {
            get => (bool)GetValue(ShowFontUnderlineSelectorProperty);
            set
            {
                SetValue(ShowFontUnderlineSelectorProperty, value);
                OnPropertyChanged(nameof(ShowFontUnderlineSelector));
            }
        }

        public bool ShowFontStrikeSelector
        {
            get => (bool)GetValue(ShowFontStrikeSelectorProperty);
            set
            {
                SetValue(ShowFontStrikeSelectorProperty, value);
                OnPropertyChanged(nameof(ShowFontStrikeSelector));
            }
        }

        public bool ShowTextAlignmentSelector
        {
            get => (bool)GetValue(ShowTextAlignmentSelectorProperty);
            set
            {
                SetValue(ShowTextAlignmentSelectorProperty, value);
                OnPropertyChanged(nameof(ShowTextAlignmentSelector));
            }
        }
        
        public bool ShowFontColorSelector
        {
            get => (bool)GetValue(ShowFontColorSelectorProperty);
            set
            {
                SetValue(ShowFontColorSelectorProperty, value);
                OnPropertyChanged(nameof(ShowFontColorSelector));
            }
        }

        public bool ShowFontBackgroundSelector
        {
            get => (bool)GetValue(ShowFontBackgroundSelectorProperty);
            set
            {
                SetValue(ShowFontBackgroundSelectorProperty, value);
                OnPropertyChanged(nameof(ShowFontBackgroundSelector));
            }
        }

        public bool ShowTextDataFormatSelector
        {
            get => (bool)GetValue(ShowTextDataFormatSelectorProperty);
            set
            {
                SetValue(ShowTextDataFormatSelectorProperty, value);
                OnPropertyChanged(nameof(ShowTextDataFormatSelector));
            }
        }

        #endregion Font Configuration

        #region Font

        public ObservableCollection<FontFamilyInfo> Fonts
        {
            get => (ObservableCollection<FontFamilyInfo>)GetValue(FontsProperty);
            set
            {
                value.CollectionChanged += OnFontsCollectionChanged;
                SetValue(FontsProperty, value);
                OnPropertyChanged(nameof(FontsProperty));
            }
        }

        public FontFamilyInfo SelectedFont
        {
            get => (FontFamilyInfo)GetValue(SelectedFontProperty);
            set
            {
                SetValue(SelectedFontProperty, value);
                OnPropertyChanged(nameof(SelectedFont));
            }
        }

        public double SelectedFontSize
        {
            get => (double)GetValue(SelectedFontSizeProperty);
            set
            {
                SetValue(SelectedFontSizeProperty, Math.Min(Math.Max(value, FontSizeMin), FontSizeMax));
                OnPropertyChanged(nameof(SelectedFontSize));
            }
        }

        public double FontSizeMax
        {
            get => (double)GetValue(FontSizeMaxProperty);
            set
            {
                SetValue(FontSizeMaxProperty, Math.Max(value, 0));
                OnPropertyChanged(nameof(FontSizeMax));
            }
        }

        public double FontSizeMin
        {
            get => (double)GetValue(FontSizeMinProperty);
            set
            {
                SetValue(FontSizeMinProperty, Math.Max(value, FontSizeMax));
                OnPropertyChanged(nameof(FontSizeMin));
            }
        }

        public bool SelectedFontStrike
        {
            get => (bool)GetValue(SelectedFontStrikeProperty);
            set
            {
                SetValue(SelectedFontStrikeProperty, value);
                OnPropertyChanged(nameof(SelectedFontStrike));
            }
        }

        public FontStyle SelectedFontStyle
        {
            get => (FontStyle)GetValue(SelectedFontStyleProperty);
            set
            {
                SetValue(SelectedFontStyleProperty, value);
                OnPropertyChanged(nameof(SelectedFontStyle));
            }
        }

        public bool SelectedFontUnderline
        {
            get => (bool)GetValue(SelectedFontUnderlineProperty);
            set
            {
                SetValue(SelectedFontUnderlineProperty, value);
                OnPropertyChanged(nameof(SelectedFontUnderline));
            }
        }

        public FontWeight SelectedFontWeight
        {
            get => (FontWeight)GetValue(SelectedFontWeightProperty);
            set
            {
                SetValue(SelectedFontWeightProperty, value);
                OnPropertyChanged(nameof(SelectedFontWeight));
            }
        }

        public System.Windows.Media.Color SelectedFontColor
        {
            get => (System.Windows.Media.Color)GetValue(SelectedFontColorProperty);
            set
            {
                SetValue(SelectedFontColorProperty, value);
                OnPropertyChanged(nameof(SelectedFontColor));
            }
        }

        public Brush SelectedFontColorBrush
        {
            get => new SolidColorBrush(SelectedFontColor);
        }

        public System.Windows.Media.Color SelectedFontBackground
        {
            get => (System.Windows.Media.Color)GetValue(SelectedFontBackgroundProperty);
            set
            {
                SetValue(SelectedFontBackgroundProperty, value);
                OnPropertyChanged(nameof(SelectedFontBackground));
            }
        }

        public Brush SelectedFontBackgroundBrush
        {
            get => new SolidColorBrush(SelectedFontBackground);
        }

        #endregion Font

        #region Text

        public ObservableCollection<string> DataFormats
        {
            get => (ObservableCollection<string>)GetValue(DataFormatsProperty);
            set
            {
                value.CollectionChanged += OnTextDataFormatCollectionChanged;
                SetValue(DataFormatsProperty, value);
                OnPropertyChanged(nameof(DataFormats));
            }
        }

        public string DataFormat
        {
            get => (string)GetValue(DataFormatProperty);
            set
            {
                if (!TextDataFormat.ListData.Contains(value))
                    throw new ArgumentException("Invalid DataFormat");

                SetValue(DataFormatProperty, value);
                OnPropertyChanged(nameof(DataFormat));
                OnPropertyChanged(nameof(ConversionMethod));
            }
        }

        public string ConversionMethod
        {
            get => TextDataConversionMethod.FromDataFormat(DataFormat);
        }

        public System.Windows.TextAlignment? SelectedTextAlignment
        {
            get => (System.Windows.TextAlignment?)GetValue(SelectedTextAlignmentProperty);
            set
            {
                if (value.HasValue)
                {
                    SetValue(SelectedTextAlignmentProperty, value);
                    OnPropertyChanged(nameof(SelectedTextAlignment));
                }
            }
        }

        #endregion Text

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
        /// <summary> FontControllerEx class constructor. </summary>
        public FontControllerEx()
        {
            DataContext = this;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static FontControllerEx class constructor. </summary>
        static FontControllerEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FontControllerEx),
                new FrameworkPropertyMetadata(typeof(FontControllerEx)));
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        protected virtual void OnFontChange(object sender, SelectionChangedEventArgs e)
        {
            FontChanged?.Invoke(this, new FontChangedEventArgs(SelectedFont));
        }

        //  --------------------------------------------------------------------------------
        protected virtual void OnFontSizeChange(object sender, TextModifiedEventArgs e)
        {
            FontSizeChanged?.Invoke(this, new FontSizeChangedEventArgs(SelectedFontSize));
            var x = SelectedFontSize;
        }

        //  --------------------------------------------------------------------------------
        protected virtual void OnFontBoldChange(object sender, RoutedEventArgs e)
        {
            FontWeightChanged?.Invoke(this, new FontWeightChangedEventArgs(SelectedFontWeight));
        }

        //  --------------------------------------------------------------------------------
        protected virtual void OnFontItalicChange(object sender, RoutedEventArgs e)
        {
            FontStyleChanged?.Invoke(this, new FontStyleChangedEventArgs(SelectedFontStyle));
        }

        //  --------------------------------------------------------------------------------
        protected virtual void OnFontUnderlineChange(object sender, RoutedEventArgs e)
        {
            FontUnderlineChanged?.Invoke(this, new FontUnderlineChangedEventArgs(SelectedFontUnderline));
        }

        //  --------------------------------------------------------------------------------
        protected virtual void OnFontStrikeChange(object sender, RoutedEventArgs e)
        {
            FontStrikeChanged?.Invoke(this, new FontStrikeChangedEventArgs(SelectedFontStrike));
        }

        //  --------------------------------------------------------------------------------
        protected virtual void OnTextAlignmentLeftChange(object sender, RoutedEventArgs e)
        {
            TextAlignmentChanged?.Invoke(this, new TextAlignmentChangedEventArgs(TextAlignment.Left));
        }

        //  --------------------------------------------------------------------------------
        protected virtual void OnTextAlignmentCenterChange(object sender, RoutedEventArgs e)
        {
            TextAlignmentChanged?.Invoke(this, new TextAlignmentChangedEventArgs(TextAlignment.Center));
        }

        //  --------------------------------------------------------------------------------
        protected virtual void OnTextAlignmentRightChange(object sender, RoutedEventArgs e)
        {
            TextAlignmentChanged?.Invoke(this, new TextAlignmentChangedEventArgs(TextAlignment.Right));
        }

        //  --------------------------------------------------------------------------------
        protected virtual void OnTextAlignmentJustifyChange(object sender, RoutedEventArgs e)
        {
            TextAlignmentChanged?.Invoke(this, new TextAlignmentChangedEventArgs(TextAlignment.Justify));
        }

        //  --------------------------------------------------------------------------------
        protected virtual void OnRequestFontBackgroundChange(object sender, RoutedEventArgs e)
        {
            FontBackgroundChangeRequested?.Invoke(
                this, new FontBackgroundChangedRequestEventArgs(SelectedFontBackground, true));
        }

        //  --------------------------------------------------------------------------------
        protected virtual void OnRequestFontColorChange(object sender, RoutedEventArgs e)
        {
            FontColorChangeRequested?.Invoke(
                this, new FontColorChangeRequestEventArgs(SelectedFontColor, true));
        }

        //  --------------------------------------------------------------------------------
        protected virtual void OnTextFormatDataChange(object sender, SelectionChangedEventArgs e)
        {
            TextDataFormatChanged?.Invoke(this, new TextDataFormatChangedEventArgs(DataFormat));
        }

        #endregion INTERACTION METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing fonts collection. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Notify Collection Changed Event Arguments. </param>
        protected void OnFontsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(FontsProperty));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing text data format collection. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Notify Collection Changed Event Arguments. </param>
        protected void OnTextDataFormatCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(DataFormats));
        }

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

            ApplyComboBoxExSelectionChangedMethod(GetCheckBoxEx("fontComboBox"), OnFontChange);
            ApplyUpDownTextBoxExTextModifiedMethod(GetUpDownTextBoxEx("fontSizeUpDownTextBox"), OnFontSizeChange);
            ApplyButtonExClickMethod(GetButtonEx("fontBoldButton"), OnFontBoldChange);
            ApplyButtonExClickMethod(GetButtonEx("fontItalicButton"), OnFontItalicChange);
            ApplyButtonExClickMethod(GetButtonEx("fontUnderlineButton"), OnFontUnderlineChange);
            ApplyButtonExClickMethod(GetButtonEx("fontStrikeButton"), OnFontStrikeChange);
            ApplyButtonExClickMethod(GetButtonEx("textAlignLeftButton"), OnTextAlignmentLeftChange);
            ApplyButtonExClickMethod(GetButtonEx("textAlignCenterButton"), OnTextAlignmentCenterChange);
            ApplyButtonExClickMethod(GetButtonEx("textAlignRightButton"), OnTextAlignmentRightChange);
            ApplyButtonExClickMethod(GetButtonEx("textAlignJustifyButton"), OnTextAlignmentJustifyChange);
            ApplyButtonExClickMethod(GetButtonEx("fontColorButton"), OnRequestFontColorChange);
            ApplyButtonExClickMethod(GetButtonEx("fontBackgroundButton"), OnRequestFontBackgroundChange);
            ApplyComboBoxExSelectionChangedMethod(GetCheckBoxEx("textFormatDataComboBox"), OnTextFormatDataChange);
        }

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
        /// <summary> Apply Click method on ComboBoxEx. </summary>
        /// <param name="buttonEx"> ButtonEx. </param>
        /// <param name="eventHandler"> Click method. </param>
        protected void ApplyComboBoxExSelectionChangedMethod(ComboBoxEx comboBoxEx, SelectionChangedEventHandler eventHandler)
        {
            if (comboBoxEx != null)
                comboBoxEx.SelectionChanged += eventHandler;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Apply Click method on ComboBoxEx. </summary>
        /// <param name="buttonEx"> ButtonEx. </param>
        /// <param name="eventHandler"> Click method. </param>
        protected void ApplyUpDownTextBoxExTextModifiedMethod(UpDownTextBoxEx upDownTextBoxEx, TextModifiedEventHandler eventHandler)
        {
            if (upDownTextBoxEx != null)
                upDownTextBoxEx.TextModified += eventHandler;
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
        /// <summary> Get ComboBoxEx from ContentTemplate. </summary>
        /// <param name="comboBoxName"> ComboBoxEx name. </param>
        /// <returns> ComboBoxEx or null. </returns>
        protected ComboBoxEx GetCheckBoxEx(string comboBoxName)
        {
            return this.Template.FindName(comboBoxName, this) as ComboBoxEx;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get UpDownTextBoxEx from ContentTemplate. </summary>
        /// <param name="upDownTextBoxName"> UpDownTextBoxEx name. </param>
        /// <returns> UpDownTextBoxEx or null. </returns>
        protected UpDownTextBoxEx GetUpDownTextBoxEx(string upDownTextBoxName)
        {
            return this.Template.FindName(upDownTextBoxName, this) as UpDownTextBoxEx;
        }

        #endregion TEMPLATE METHODS

    }
}
