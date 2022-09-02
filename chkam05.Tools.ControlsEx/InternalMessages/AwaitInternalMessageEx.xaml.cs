using chkam05.Tools.ControlsEx.Utilities;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        /// <param name="title"> Message title. </param>
        /// <param name="message"> Message. </param>
        /// <param name="icon"> Message header icon kind. </param>
        public AwaitInternalMessageEx(InternalMessagesExContainer parentContainer, string title, string message,
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
