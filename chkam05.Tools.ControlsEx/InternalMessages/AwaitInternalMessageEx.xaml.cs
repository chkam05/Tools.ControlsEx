using System.Windows;


namespace chkam05.Tools.ControlsEx.InternalMessages
{
    public partial class AwaitInternalMessageEx : BaseAwaitInternalMessageEx
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register(
            nameof(Message),
            typeof(string),
            typeof(AwaitInternalMessageEx),
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
        /// <summary> AwaitInternalMessageEx class constructor. </summary>
        public AwaitInternalMessageEx() : base()
        {
            //  Initialize interface components.
            InitializeComponent();
        }

        #endregion CLASS METHODS

    }
}
