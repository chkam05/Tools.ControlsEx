using MaterialDesignThemes.Wpf;
using System.Windows;


namespace chkam05.Tools.ControlsEx.InternalMessages
{
    public partial class ProgressInternalMessageEx : BaseProgressInternalMessageEx
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register(
            nameof(Message),
            typeof(string),
            typeof(ProgressInternalMessageEx),
            new PropertyMetadata(string.Empty));


        //  GETTERS & SETTERS

        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set
            {
                SetValue(MessageProperty, value);
                OnPropertyChanged(nameof(Message));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ProgressInternalMessageEx class constructor. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        /// <param name="title"> Message title. </param>
        /// <param name="message"> Message. </param>
        /// <param name="icon"> Message header icon kind. </param>
        public ProgressInternalMessageEx(InternalMessagesExContainer parentContainer, string title, string message,
            PackIconKind icon = PackIconKind.Hourglass) : base(parentContainer)
        {
            Title = title;
            Message = message;
            IconKind = icon;

            //  Initialize interface components.
            InitializeComponent();
        }

        #endregion CLASS METHODS

    }
}
