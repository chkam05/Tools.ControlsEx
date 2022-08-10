using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace chkam05.Tools.ControlsEx.InternalMessages
{
    public class StandardInternalMessageEx : BaseInternalMessageEx<InternalMessageCloseEventArgs>
    {

        //  VARIABLES

        protected InternalMessageButtons[] _buttons = new InternalMessageButtons[0];


        //  GETTERS & SETTERS

        public InternalMessageButtons[] Buttons
        {
            get => _buttons;
            set
            {
                _buttons = value;
                OnPropertyChanged(nameof(Buttons));

                if (IsLoadingComplete)
                    SetButtons(value);
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> StandardInternalMessageEx class constructor. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        public StandardInternalMessageEx(InternalMessagesExContainer parentContainer) : base(parentContainer)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static StandardInternalMessageEx class constructor. </summary>
        static StandardInternalMessageEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StandardInternalMessageEx),
                new FrameworkPropertyMetadata(typeof(StandardInternalMessageEx)));
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
        protected virtual void OnYesClick(object sender, RoutedEventArgs e)
        {
            Result = InternalMessageResult.Yes;
            Close();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking No Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnNoClick(object sender, RoutedEventArgs e)
        {
            Result = InternalMessageResult.No;
            Close();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Cancel Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnCancelClick(object sender, RoutedEventArgs e)
        {
            Result = InternalMessageResult.Cancel;
            Close();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Hide Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnHideClick(object sender, RoutedEventArgs e)
        {
            Hide();
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

            var buttonHide = GetButtonEx("hideButton");
            ApplyButtonExClickMethod(buttonHide, OnHideClick);

            OnAllowHideUpdate(AllowHide);
            SetButtons(_buttons);

            ApplyButtonExClickMethod(GetButtonEx("okButton"), OnOkClick);
            ApplyButtonExClickMethod(GetButtonEx("yesButton"), OnYesClick);
            ApplyButtonExClickMethod(GetButtonEx("noButton"), OnNoClick);
            ApplyButtonExClickMethod(GetButtonEx("cancelButton"), OnCancelClick);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set specified buttons set to be visible in Internal Message. </summary>
        /// <param name="buttons"> Set of buttons to be visible in Internal Message. </param>
        private void SetButtons(InternalMessageButtons[] buttons)
        {
            foreach (var buttonType in (InternalMessageButtons[])Enum.GetValues(typeof(InternalMessageButtons)))
            {
                ButtonEx button = null;
                bool showHide = buttons.Any(bt => bt == buttonType);

                switch (buttonType)
                {
                    case InternalMessageButtons.CancelButton:
                        button = GetButtonEx("cancelButton");
                        break;

                    case InternalMessageButtons.NoButton:
                        button = GetButtonEx("noButton");
                        break;

                    case InternalMessageButtons.OkButton:
                        button = GetButtonEx("okButton");
                        break;

                    case InternalMessageButtons.YesButton:
                        button = GetButtonEx("yesButton");
                        break;
                }

                if (button != null)
                    button.Visibility = showHide ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing AllowHide property. </summary>
        /// <param name="showHide"> True - allow hide; False - otherwise. </param>
        protected override void OnAllowHideUpdate(bool showHide = false)
        {
            var buttonHide = GetButtonEx("hideButton");
            buttonHide.Visibility = showHide ? Visibility.Visible : Visibility.Collapsed;
        }

        #endregion TEMPLATE METHODS

    }
}
