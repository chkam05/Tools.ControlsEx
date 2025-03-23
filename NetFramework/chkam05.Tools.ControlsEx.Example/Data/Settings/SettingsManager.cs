using chkam05.Tools.ControlsEx.Data.Theme;
using chkam05.Tools.ControlsEx.Example.Resources;
using chkam05.Tools.ControlsEx.Example.Utilities;
using chkam05.Tools.ControlsEx.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Example.Data.Settings
{
    public class SettingsManager : BaseViewModel
    {

        //  VARIABLES

        private static SettingsManager instance;
        private static object instanceLock = new object();

        private SettingsDataContext settings;
        private string settingsDirectoryPath;


        //  GETTERS & SETTERS

        public static SettingsManager Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new SettingsManager();

                    return instance;
                }
            }
        }

        public SettingsDataContext Settings
        {
            get
            {
                if (settings == null)
                    LoadSettings();

                return settings;
            }
            set => UpdateSettingsProperty(value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> SettingsManager class constructor. </summary>
        private SettingsManager()
        {
            settingsDirectoryPath = AppUtilities.GetAppSettingsDirectory();
            LoadSettings();
        }

        #endregion CONSTRUCTORS

        #region LOAD & SAVE

        //  --------------------------------------------------------------------------------
        /// <summary> Load settings from application settings file. </summary>
        public void LoadSettings()
        {
            try
            {
                var settingsFilePath = Path.Combine(settingsDirectoryPath, StaticResources.SETTINGS_FILE_NAME);
                var settingsFileContent = File.ReadAllText(settingsFilePath, StaticResources.SETTINGS_FILE_ENCODING);
                var settings = JsonConvert.DeserializeObject<SettingsDataContext>(settingsFileContent);

                Settings = settings ?? new SettingsDataContext();
            }
            catch (Exception)
            {
                Settings = new SettingsDataContext();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Save settings to application settings file. </summary>
        public void SaveSettings()
        {
            if (!Directory.Exists(settingsDirectoryPath))
                Directory.CreateDirectory(settingsDirectoryPath);

            var settingsFilePath = Path.Combine(settingsDirectoryPath, StaticResources.SETTINGS_FILE_NAME);
            var settingsFileContent = JsonConvert.SerializeObject(Settings, Formatting.Indented);
            File.WriteAllText(settingsFilePath, settingsFileContent, StaticResources.SETTINGS_FILE_ENCODING);
        }

        #endregion LOAD & SAVE

        #region PROPERTIES CHANGED NOTIFICATION

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when Settings property changes. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Property changed event arguments. </param>
        private void SettingsPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Settings.Theme))
                ThemeManager.Instance.DataContext = Settings.Theme;
        }

        #endregion PROPERTIES CHANGED NOTIFICATION

        #region PROPERTIES MANAGEMENT

        //  --------------------------------------------------------------------------------
        // <summary> Sets a value in Settings property and triggers a property changed notification event. </summary>
        /// <param name="newValue"> Value to set. </param>
        private void UpdateSettingsProperty(SettingsDataContext newValue)
        {
            if (settings != null)
                settings.PropertyChanged -= SettingsPropertyChanged;

            settings = newValue;
            settings.PropertyChanged += SettingsPropertyChanged;

            NotifyPropertyChanged(nameof(Settings));

            ThemeManager.Instance.DataContext = Settings.Theme;
        }

        #endregion PROPERTIES MANAGEMENT

    }
}
