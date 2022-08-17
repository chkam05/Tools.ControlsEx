using chkam05.Tools.ControlsEx.Colors;
using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Events;
using chkam05.Tools.ControlsEx.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.InternalMessages
{
    public class BaseColorSelectorInternalMessageEx : BaseInternalMessageEx<ColorSelectorInternalMessageCloseEventArgs>
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty SelectedColorProperty = DependencyProperty.Register(
            nameof(SelectedColor),
            typeof(Color),
            typeof(BaseColorSelectorInternalMessageEx),
            new PropertyMetadata(ColorsPaletteItems.Blue.Color));

        public static readonly DependencyProperty SelectedColorCodeProperty = DependencyProperty.Register(
            nameof(SelectedColorCode),
            typeof(string),
            typeof(BaseColorSelectorInternalMessageEx),
            new PropertyMetadata(ColorsPaletteItems.Blue.ColorCode));

        public static readonly DependencyProperty SelectedColorNameProperty = DependencyProperty.Register(
            nameof(SelectedColorName),
            typeof(string),
            typeof(BaseColorSelectorInternalMessageEx),
            new PropertyMetadata(ColorsPaletteItems.Blue.Name));


        //  GETTERS & SETTERS

        public Color SelectedColor
        {
            get => (Color)GetValue(SelectedColorProperty);
            set
            {
                SetValue(SelectedColorProperty, value);
                OnPropertyChanged(nameof(SelectedColor));
            }
        }

        public string SelectedColorCode
        {
            get => (string)GetValue(SelectedColorCodeProperty);
            set
            {
                SetValue(SelectedColorCodeProperty, value);
                OnPropertyChanged(nameof(SelectedColorName));
                OnPropertyChanged(nameof(ShowColorCode));
            }
        }

        public string SelectedColorName
        {
            get => (string)GetValue(SelectedColorNameProperty);
            set
            {
                SetValue(SelectedColorNameProperty, value);
                OnPropertyChanged(nameof(SelectedColorName));
                OnPropertyChanged(nameof(ShowColorCode));
            }
        }

        public bool ShowColorCode
        {
            get => SelectedColorCode != SelectedColorName;
            set
            {
                throw new NotImplementedException();
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> BaseColorSelectorInternalMessageEx class constructor. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        public BaseColorSelectorInternalMessageEx(InternalMessagesExContainer parentContainer) : base(parentContainer)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static BaseColorSelectorInternalMessageEx class constructor. </summary>
        static BaseColorSelectorInternalMessageEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseColorSelectorInternalMessageEx),
                new FrameworkPropertyMetadata(typeof(BaseColorSelectorInternalMessageEx)));
        }

        #endregion CLASS METHODS

        #region BUTTONS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Ok Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnOkClick(object sender, RoutedEventArgs e)
        {
            Result = InternalMessageResult.Ok;
            Close();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Yes Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnCancelClick(object sender, RoutedEventArgs e)
        {
            Result = InternalMessageResult.Cancel;
            Close();
        }

        #endregion BUTTONS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Create close method event arguments. </summary>
        /// <returns> Close method event arguments. </returns>
        protected override ColorSelectorInternalMessageCloseEventArgs CreateCloseEventArgs()
        {
            return new ColorSelectorInternalMessageCloseEventArgs(Result, SelectedColor, SelectedColorName, SelectedColorCode);
        }

        #endregion INTERACTION METHODS

        #region TEMPLATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> When overridden in a derived class,cis invoked whenever 
        /// application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            //  Apply Template
            base.OnApplyTemplate();

            ApplyButtonExClickMethod(GetButtonEx("cancelButton"), OnCancelClick);
            ApplyButtonExClickMethod(GetButtonEx("okButton"), OnOkClick);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Message invoked after updating color. </summary>
        protected virtual void OnColorUpdated()
        {
            //
        }

        #endregion TEMPLATE METHODS

    }
}
