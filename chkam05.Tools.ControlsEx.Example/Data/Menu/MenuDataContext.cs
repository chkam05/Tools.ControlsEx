using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Example.Data.Menu
{
    public class MenuDataContext : INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangedEventHandler ItemPropertyChanged;


        //  VARIABLES

        private ObservableCollection<MenuItem> _dataContext;


        //  GETTERS & SETTERS

        public ObservableCollection<MenuItem> DataContext
        {
            get => _dataContext;
            set
            {
                _dataContext = value;
                _dataContext.CollectionChanged += ContentCollectionChanged;
                OnPropertyChanged(nameof(DataContext));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> MenuDataContext class constructor. </summary>
        public MenuDataContext()
        {
            DataContext = new ObservableCollection<MenuItem>();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> MenuDataContext class constructor. </summary>
        /// <param name="menuItems"> List of MenuItems. </param>
        public MenuDataContext(List<MenuItem> menuItems)
        {
            DataContext = new ObservableCollection<MenuItem>(
                menuItems != null ? menuItems : new List<MenuItem>());
        }

        #endregion CLASS METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing data collection. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Notify Collection Changed Event Arguments. </param>
        private void ContentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (MenuItem item in e.OldItems)
                    item.PropertyChanged -= OnItemPropertyChanged;
            }

            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (MenuItem item in e.NewItems)
                    item.PropertyChanged += OnItemPropertyChanged;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method for invoking PropertyChangedEventHandler external method. </summary>
        /// <param name="propertyName"> Changed property name. </param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after chaning any value in item. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Property Changed Event Arguments. </param>
        protected void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = ItemPropertyChanged;

            if (handler != null)
                handler(sender, e);
        }

        #endregion NOTIFY PROPERTIES CHANGED INTERFACE METHODS

    }
}
