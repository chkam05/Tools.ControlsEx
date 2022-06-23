using chkam05.Tools.ControlsEx.Colors;
using chkam05.Tools.ControlsEx.Events;
using chkam05.Tools.ControlsEx.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static chkam05.Tools.ControlsEx.Events.Delegates;

namespace chkam05.Tools.ControlsEx.InternalMessages
{
    public class BaseColorInternalMessageEx : BaseInternalMessageEx, INotifyPropertyChanged
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty SelectedColorProperty = DependencyProperty.Register(
            nameof(SelectedColor),
            typeof(ColorPaletteItem),
            typeof(BaseStandardInternalMessageEx),
            new PropertyMetadata(new ColorPaletteItem(System.Windows.Media.Colors.Transparent, "Transparent")));


        //  EVENTS

        public event ColorsInternalMessageClose MessageClose;


        //  GETTERS & SETTERS

        public ColorPaletteItem SelectedColor
        {
            get => (ColorPaletteItem)GetValue(SelectedColorProperty);
            set
            {
                SetValue(SelectedColorProperty, value);
                OnPropertyChanged(nameof(SelectedColor));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> BaseColorInternalMessageEx class constructor. </summary>
        public BaseColorInternalMessageEx()
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static BaseColorInternalMessageEx class constructor. </summary>
        static BaseColorInternalMessageEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseColorInternalMessageEx),
                new FrameworkPropertyMetadata(typeof(BaseColorInternalMessageEx)));
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
            MessageClose?.Invoke(this, new ColorsInternalMessageCloseEventArgs(Result, SelectedColor));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Cancel Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnCancelClick(object sender, RoutedEventArgs e)
        {
            Result = InternalMessageResult.Cancel;
            MessageClose?.Invoke(this, new ColorsInternalMessageCloseEventArgs(Result, null));
        }

        #endregion BUTTONS METHODS

        #region TEMPLATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> When overridden in a derived class,cis invoked whenever 
        /// application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            //  Apply Template
            base.OnApplyTemplate();

            ApplyButtonExClickMethod(GetButtonEx("okButton"), OnOkClick);
            ApplyButtonExClickMethod(GetButtonEx("cancelButton"), OnCancelClick);
        }

        #endregion TEMPLATE METHODS

    }
}
