using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.InternalMessages.Data
{
    public class FileTypeItem : INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private string[] _extensions;
        private string _title;


        //  GETTERS & SETTERS

        public string[] Extensions
        {
            get => _extensions;
            private set
            {
                _extensions = value;
                OnPropertyChanged(nameof(Extensions));
            }
        }

        public string Title
        {
            get => _title;
            private set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> FileTypeItem class constructor. </summary>
        /// <param name="extension"> Files types extensions. </param>
        /// <param name="title"> File type name. </param>
        public FileTypeItem(string title, string[] extensions)
        {
            Extensions = extensions;
            Title = title;
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

    }
}
