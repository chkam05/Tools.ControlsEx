using chkam05.Tools.ControlsEx.Data;
using MaterialDesignThemes.Wpf;
using System.Windows;


namespace chkam05.Tools.ControlsEx.InternalMessages
{
    public partial class InternalMessageEx : StandardInternalMessageEx
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register(
            nameof(Message),
            typeof(string),
            typeof(InternalMessageEx),
            new PropertyMetadata(string.Empty));


        //  GETTERS & SETTERS

        public string Message
        {
            get => (string)base.GetValue(MessageProperty);
            set
            {
                SetValue(MessageProperty, value);
                OnPropertyChanged(nameof(Message));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> InternalMessageEx class constructor. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        /// <param name="title"> Message title. </param>
        /// <param name="message"> Message. </param>
        /// <param name="icon"> Message header icon kind. </param>
        /// <param name="buttonsSet"> Set of buttons. </param>
        public InternalMessageEx(InternalMessagesExContainer parentContainer, string title, string message, 
            PackIconKind icon = PackIconKind.InfoCircleOutline, InternalMessagesButtonsSet buttonsSet = InternalMessagesButtonsSet.Ok) : base(parentContainer)
        {
            Title = title;
            Message = message;
            IconKind = icon;
            SetButtonsSet(buttonsSet);

            //  Initialize interface components.
            InitializeComponent();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create alert InternalMessageEx. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        /// <param name="title"> Message title. </param>
        /// <param name="message"> Message. </param>
        /// <returns> InternalMessageEx. </returns>
        public static InternalMessageEx CreateAlertMessage(InternalMessagesExContainer parentContainer, string title, string message)
            => new InternalMessageEx(parentContainer, title, message, PackIconKind.AlertOutline, InternalMessagesButtonsSet.Ok);

        //  --------------------------------------------------------------------------------
        /// <summary> Create error InternalMessageEx. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        /// <param name="title"> Message title. </param>
        /// <param name="message"> Message. </param>
        /// <returns> InternalMessageEx. </returns>
        public static InternalMessageEx CreateErrorMessage(InternalMessagesExContainer parentContainer, string title, string message)
            => new InternalMessageEx(parentContainer, title, message, PackIconKind.ErrorOutline, InternalMessagesButtonsSet.Ok);

        //  --------------------------------------------------------------------------------
        /// <summary> Create info InternalMessageEx. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        /// <param name="title"> Message title. </param>
        /// <param name="message"> Message. </param>
        /// <returns> InternalMessageEx. </returns>
        public static InternalMessageEx CreateInfoMessage(InternalMessagesExContainer parentContainer, string title, string message)
            => new InternalMessageEx(parentContainer, title, message);

        //  --------------------------------------------------------------------------------
        /// <summary> Create question InternalMessageEx. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        /// <param name="title"> Message title. </param>
        /// <param name="message"> Message. </param>
        /// <returns> InternalMessageEx. </returns>
        public static InternalMessageEx CreateQuestionMessage(InternalMessagesExContainer parentContainer, string title, string message)
            => new InternalMessageEx(parentContainer, title, message, PackIconKind.QuestionMarkCircleOutline, InternalMessagesButtonsSet.YesNo);

        #endregion CLASS METHODS

        #region TEMPLATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Setup buttons using InternalMessagesButtonsSet enum. </summary>
        /// <param name="buttonsSet"> InternalMessagesButtonsSet. </param>
        private void SetButtonsSet(InternalMessagesButtonsSet buttonsSet)
        {
            switch (buttonsSet)
            {
                case InternalMessagesButtonsSet.Ok:
                    Buttons = new InternalMessageButtons[]
                    {
                        InternalMessageButtons.OkButton
                    };
                    break;

                case InternalMessagesButtonsSet.OkCancel:
                    Buttons = new InternalMessageButtons[]
                    {
                        InternalMessageButtons.OkButton,
                        InternalMessageButtons.CancelButton
                    };
                    break;

                case InternalMessagesButtonsSet.YesNo:
                    Buttons = new InternalMessageButtons[]
                    {
                        InternalMessageButtons.YesButton,
                        InternalMessageButtons.NoButton
                    };
                    break;

                case InternalMessagesButtonsSet.YesNoCancel:
                    Buttons = new InternalMessageButtons[]
                    {
                        InternalMessageButtons.YesButton,
                        InternalMessageButtons.NoButton,
                        InternalMessageButtons.CancelButton
                    };
                    break;
            }
        }

        #endregion TEMPLATE METHODS

    }
}
