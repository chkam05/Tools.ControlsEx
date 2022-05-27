using chkam05.Tools.ControlsEx.Example.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class ComboBoxesPage : Page, INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private ObservableCollection<string> _comboBoxDataContext;


        //  GETTERS & SETTERS

        public ObservableCollection<string> ComboBoxDataContext
        {
            get => _comboBoxDataContext;
            set
            {
                _comboBoxDataContext = value;
                OnPropertyChanged(nameof(ComboBoxDataContext));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ComboBoxesPage class constructor. </summary>
        public ComboBoxesPage()
        {
            //  Setup data containers.
            SetupExampleData();

            //  Initialize interface components.
            InitializeComponent();
        }

        #endregion CLASS METHODS

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

        #region SETUP DATA METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Setup example data. </summary>
        private void SetupExampleData()
        {
            ComboBoxDataContext = new ObservableCollection<string>(
                ExampleData.EuropeanCountries.Select(c => c.Name));
        }

        #endregion SETUP DATA METHODS

    }
}
