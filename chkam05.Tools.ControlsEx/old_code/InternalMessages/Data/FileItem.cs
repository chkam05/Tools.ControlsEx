using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.InternalMessages.Data
{
    public class FileItem : INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private PackIconKind _icon = PackIconKind.None;
        private bool _isDirectory = false;
        private string _name = string.Empty;
        private string _path = string.Empty;
        private bool _selected = false;


        //  GETTERS & SETTERS

        public PackIconKind Icon
        {
            get => _icon;
            private set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        public bool IsDirectory
        {
            get => _isDirectory;
            private set
            {
                _isDirectory = value;
                OnPropertyChanged(nameof(IsDirectory));
            }
        }

        public string Name
        {
            get => _name;
            private set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                UpdateMetadata(value);
                OnPropertyChanged(nameof(Path));
            }
        }

        public bool Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                OnPropertyChanged(nameof(Selected));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> FileItem class constructor. </summary>
        /// <param name="path"> File or directory path. </param>
        public FileItem(string path)
        {
            Path = path;
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

        #region UPDATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Update file or directory metadata. </summary>
        /// <param name="path"> File od directory path. </param>
        private void UpdateMetadata(string path)
        {
            IsDirectory = Directory.Exists(path);
            var isDrive = IsDirectory && string.IsNullOrEmpty(System.IO.Path.GetDirectoryName(path));

            Icon = isDrive ? PackIconKind.Harddisk : IsDirectory ? PackIconKind.Folder : PackIconKind.File;
            Name = isDrive ? path.Replace(":\\", "") : System.IO.Path.GetFileName(path);
        }

        #endregion UPDATE METHODS

    }
}
