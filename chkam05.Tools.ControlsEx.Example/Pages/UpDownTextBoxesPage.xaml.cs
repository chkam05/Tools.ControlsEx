using chkam05.Tools.ControlsEx.Example.Data.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace chkam05.Tools.ControlsEx.Example.Pages
{
    public partial class UpDownTextBoxesPage : Page, INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        public Configuration Configuration { get; private set; }

        private double _doubleValue = 0d;
        private long _longValue = 0L;


        //  GETTERS & SETTERS

        public double DoubleValue
        {
            get => _doubleValue;
            set
            {
                _doubleValue = value;
                OnPropertyChanged(nameof(DoubleValue));
            }
        }

        public long LongValue
        {
            get => _longValue;
            set
            {
                _longValue = value;
                OnPropertyChanged(nameof(LongValue));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> UpDownTextBoxesPage class constructor. </summary>
        public UpDownTextBoxesPage()
        {
            //  Initialize data containers.
            Configuration = Configuration.Instance;

            //  Initialize interface components.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        private void UpDownLongTextBoxEx_ValueModified(object sender, Events.UpDownLongModifiedEventArgs e)
        {
            longTextBlockEx.Text = e.NewValue.ToString();
        }

        //  --------------------------------------------------------------------------------
        private void UpDownDoubleTextBoxEx_ValueModified(object sender, Events.UpDownDoubleModifiedEventArgs e)
        {
            doubleTextBlockEx.Text = e.NewValue.ToString();
        }

        #endregion INTERACTION METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

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

    }
}
