using System.Windows;


namespace chkam05.Tools.ControlsEx.InternalMessages
{
    public partial class InternalMessageEx : BaseInternalMessageEx
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
        /// <summary> InternalMessageEx class constructor. </summary>
        public InternalMessageEx() : base()
        {
            //  Initialize interface components.
            InitializeComponent();
        }

        #endregion CLASS METHODS

    }
}
