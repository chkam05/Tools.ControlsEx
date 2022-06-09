using chkam05.Tools.ControlsEx.Example.Data;
using chkam05.Tools.ControlsEx.Example.Data.Config;
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
    public partial class ListViewsPage : Page, INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private ObservableCollection<Country> _gridViewDataContext;
        private ObservableCollection<string> _listViewDataContext;

        public Configuration Configuration { get; private set; }


        //  GETTERS & SETTERS

        public ObservableCollection<Country> GridViewDataContext
        {
            get => _gridViewDataContext;
            set
            {
                _gridViewDataContext = value;
                OnPropertyChanged(nameof(GridViewDataContext));
            }
        }

        public ObservableCollection<string> ListViewDataContext
        {
            get => _listViewDataContext;
            set
            {
                _listViewDataContext = value;
                OnPropertyChanged(nameof(ListViewDataContext));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ListViewsPage class constructor. </summary>
        public ListViewsPage()
        {
            //  Initialize data containers.
            Configuration = Configuration.Instance;
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
            GridViewDataContext = new ObservableCollection<Country>(
                ExampleData.EuropeanCountries.Select(c => c));

            ListViewDataContext = new ObservableCollection<string>(
                ExampleData.EuropeanCountries.Select(c => c.Name));
        }

        #endregion SETUP DATA METHODS

    }
}
