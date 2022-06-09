using chkam05.Tools.ControlsEx.Example.Data.Config;
using chkam05.Tools.ControlsEx.Example.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Deployment.Application;
using System.Linq;
using System.Reflection;
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
    public partial class InfoPage : Page, INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private string _applicationTitle = ApplicationHelper.Instance.GetApplicationTitle();
        private string _applicationName = ApplicationHelper.Instance.GetApplicationName();
        private string _applicationAuthor = ApplicationHelper.Instance.GetApplicationCompany();
        private string _applicationCopyright = ApplicationHelper.Instance.GetApplicationCopyright();
        private string _applicationVersion = ApplicationHelper.Instance.GetApplicationVersion().ToString();

        private string _libraryTitle;
        private string _libraryName;
        private string _libraryAuthor;
        private string _libraryCopyright;
        private string _libraryVersion;

        public Configuration Configuration { get; private set; }


        //  GETTERS & SETTERS

        public string ApplicationTitle
        {
            get => _applicationTitle;
            set
            {
                _applicationTitle = value;
                OnPropertyChanged(nameof(ApplicationTitle));
            }
        }

        public string ApplicationName
        {
            get => _applicationName;
            set
            {
                _applicationName = value;
                OnPropertyChanged(nameof(ApplicationName));
            }
        }

        public string ApplicationAuthor
        {
            get => _applicationAuthor;
            set
            {
                _applicationAuthor = value;
                OnPropertyChanged(nameof(ApplicationAuthor));
            }
        }

        public string ApplicationCopyright
        {
            get => _applicationCopyright;
            set
            {
                _applicationCopyright = value;
                OnPropertyChanged(nameof(ApplicationCopyright));
            }
        }

        public string ApplicationVersion
        {
            get => _applicationVersion;
            set
            {
                _applicationVersion = value;
                OnPropertyChanged(nameof(ApplicationVersion));
            }
        }

        public string LibraryTitle
        {
            get => _libraryTitle;
            set
            {
                _libraryTitle = value;
                OnPropertyChanged(nameof(LibraryTitle));
            }
        }

        public string LibraryName
        {
            get => _libraryName;
            set
            {
                _libraryName = value;
                OnPropertyChanged(nameof(LibraryName));
            }
        }

        public string LibraryAuthor
        {
            get => _libraryAuthor;
            set
            {
                _libraryAuthor = value;
                OnPropertyChanged(nameof(LibraryAuthor));
            }
        }

        public string LibraryCopyright
        {
            get => _libraryCopyright;
            set
            {
                _libraryCopyright = value;
                OnPropertyChanged(nameof(LibraryCopyright));
            }
        }

        public string LibraryVersion
        {
            get => _libraryVersion;
            set
            {
                _libraryVersion = value;
                OnPropertyChanged(nameof(LibraryVersion));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> InfoPage class constructor. </summary>
        public InfoPage()
        {
            //  Initialize data containers.
            Configuration = Configuration.Instance;

            //  Get library informations.
            GetLibraryInformations();

            //  Initialize interface components.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region LIBRARY GET INFORMATIONS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Get library informations. </summary>
        public void GetLibraryInformations()
        {
            Assembly assembly = typeof(ButtonEx).Assembly;
            var company = assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), true);
            var copyright = assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), true);
            var title = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), true);

            if (title.Length > 0)
                LibraryTitle = ((AssemblyTitleAttribute)title.FirstOrDefault())?.Title;

            LibraryName = assembly.GetName()?.Name;

            if (company.Length > 0)
                LibraryAuthor = ((AssemblyCompanyAttribute)company.FirstOrDefault())?.Company;

            if (copyright.Length > 0)
                LibraryCopyright = ((AssemblyCopyrightAttribute)copyright.FirstOrDefault())?.Copyright;

            try
            {
                LibraryVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch (Exception)
            {
                LibraryVersion = assembly.GetName()?.Version?.ToString();
            }
        }

        #endregion LIBRARY GET INFORMATIONS METHODS

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
