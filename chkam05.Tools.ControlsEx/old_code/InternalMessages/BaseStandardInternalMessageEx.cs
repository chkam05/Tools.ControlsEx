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
    public class BaseStandardInternalMessageEx : BaseInternalMessageEx, INotifyPropertyChanged
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty ButtonsProperty = DependencyProperty.Register(
            nameof(Buttons),
            typeof(InternalMessageButtons),
            typeof(BaseStandardInternalMessageEx),
            new PropertyMetadata(InternalMessageButtons.Ok));


        //  EVENTS

        public event StandardInternalMessageClose MessageClose;


        //  GETTERS & SETTERS

        public InternalMessageButtons Buttons
        {
            get => (InternalMessageButtons)GetValue(ButtonsProperty);
            set
            {
                SetValue(ButtonsProperty, value);
                OnPropertyChanged(nameof(ButtonsProperty));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Static BaseStandardInternalMessageEx class constructor. </summary>
        static BaseStandardInternalMessageEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseStandardInternalMessageEx),
                new FrameworkPropertyMetadata(typeof(BaseStandardInternalMessageEx)));
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
            ApplyButtonExClickMethod(GetButtonEx("yesButton"), OnYesClick);
            ApplyButtonExClickMethod(GetButtonEx("noButton"), OnNoClick);
            ApplyButtonExClickMethod(GetButtonEx("cancelButton"), OnCancelClick);
        }

        #endregion TEMPLATE METHODS

    }
}
