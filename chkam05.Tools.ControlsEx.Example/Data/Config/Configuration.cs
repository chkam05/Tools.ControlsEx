using chkam05.Tools.ControlsEx.Colors;
using chkam05.Tools.ControlsEx.Example.Utilities;
using chkam05.Tools.ControlsEx.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Example.Data.Config
{
    public class Configuration : INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private static Configuration _instance;

        private Color _accentColor = Color.FromArgb(255, 0, 120, 215);
        private Color _themeColor = System.Windows.Media.Colors.White;

        /* Color lightness configuration:
         * 255 = (L 100.0 -> -0.0)
         * 224 = (L 87.5 -> -12.5)
         * 192 = (L 75.0 -> -25.0)
         * 160 = (L 62.5 -> -37.5)
         * 128 = (L 50.0 -> -50.0)
         *  96 = (L 37.5 -> -62.5)
         *  64 = (L 25.0 -> -75.0)
         *  32 = (L 12.5 -> -87.5)
         *   0 = (L 0.0 -> -100.0)
         */

        private Brush _accentColorBrush = new SolidColorBrush(Color.FromArgb(255, 0, 120, 215));
        private Brush _accentForegroundColorBrush = new SolidColorBrush(System.Windows.Media.Colors.White);
        private Brush _accentMouseOverColorBrush = new SolidColorBrush(Color.FromArgb(255, 32, 152, 247));
        private Brush _accentPressedColorBrush = new SolidColorBrush(Color.FromArgb(255, 0, 88, 183));
        private Brush _accentSelectedColorBrush = new SolidColorBrush(Color.FromArgb(255, 0, 88, 183));

        private Brush _backgroundColorBrush = new SolidColorBrush(System.Windows.Media.Colors.White);
        private Brush _backgroundToolbarColorBrush = new SolidColorBrush(Color.FromArgb(255, 224, 224, 224));
        private Brush _borderToolbarColorBrush = new SolidColorBrush(Color.FromArgb(255, 160, 160, 160));
        private Brush _foregroundColorBrush = new SolidColorBrush(System.Windows.Media.Colors.Black);
        private Brush _selectedInactiveColorBrush = new SolidColorBrush(Color.FromArgb(255, 192, 192, 192));


        //  GETTERS & SETTERS

        public static Configuration Instance
        {
            get
            {
                if (_instance == null)
                    _instance = LoadConfiguration();

                return _instance;
            }
        }

        public Color AccentColor
        {
            get => _accentColor;
            set
            {
                UpdateAccentColor(value);
                OnPropertyChanged(nameof(AccentColor));
            }
        }

        public Color ThemeColor
        {
            get => _themeColor;
            set
            {
                UpdateThemeColor(value);
                OnPropertyChanged(nameof(ThemeColor));
            }
        }

        [JsonIgnore]
        public Brush AccentColorBrush
        {
            get => _accentColorBrush;
            set
            {
                _accentColorBrush = value;
                OnPropertyChanged(nameof(AccentColorBrush));
            }
        }

        [JsonIgnore]
        public Brush AccentForegroundColorBrush
        {
            get => _accentForegroundColorBrush;
            set
            {
                _accentForegroundColorBrush = value;
                OnPropertyChanged(nameof(AccentForegroundColorBrush));
            }
        }

        [JsonIgnore]
        public Brush AccentMouseOverColorBrush
        {
            get => _accentMouseOverColorBrush;
            set
            {
                _accentMouseOverColorBrush = value;
                OnPropertyChanged(nameof(AccentMouseOverColorBrush));
            }
        }

        [JsonIgnore]
        public Brush AccentPressedColorBrush
        {
            get => _accentPressedColorBrush;
            set
            {
                _accentPressedColorBrush = value;
                OnPropertyChanged(nameof(AccentPressedColorBrush));
            }
        }

        [JsonIgnore]
        public Brush AccentSelectedColorBrush
        {
            get => _accentSelectedColorBrush;
            set
            {
                _accentSelectedColorBrush = value;
                OnPropertyChanged(nameof(AccentSelectedColorBrush));
            }
        }

        [JsonIgnore]
        public Brush BackgroundColorBrush
        {
            get => _backgroundColorBrush;
            set
            {
                _backgroundColorBrush = value;
                OnPropertyChanged(nameof(BackgroundColorBrush));
            }
        }

        [JsonIgnore]
        public Brush BackgroundToolbarColorBrush
        {
            get => _backgroundToolbarColorBrush;
            set
            {
                _backgroundToolbarColorBrush = value;
                OnPropertyChanged(nameof(BackgroundToolbarColorBrush));
            }
        }

        [JsonIgnore]
        public Brush BorderToolbarColorBrush
        {
            get => _borderToolbarColorBrush;
            set
            {
                _borderToolbarColorBrush = value;
                OnPropertyChanged(nameof(BorderToolbarColorBrush));
            }
        }

        [JsonIgnore]
        public Brush ForegroundColorBrush
        {
            get => _foregroundColorBrush;
            set
            {
                _foregroundColorBrush = value;
                OnPropertyChanged(nameof(ForegroundColorBrush));
            }
        }

        [JsonIgnore]
        public Brush SelectedInactiveColorBrush
        {
            get => _selectedInactiveColorBrush;
            set
            {
                _selectedInactiveColorBrush = value;
                OnPropertyChanged(nameof(SelectedInactiveColorBrush));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Configuration class constructor. </summary>
        private Configuration()
        {
            //
        }

        #endregion CLASS METHODS

        #region COLORS UPDATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Update accent color. </summary>
        /// <param name="color"> New accent color. </param>
        private void UpdateAccentColor(Color color)
        {
            _accentColor = color;
            var ahslAccentColor = AHSLColor.FromColor(color);

            AccentColorBrush = new SolidColorBrush(color);

            AccentForegroundColorBrush = new SolidColorBrush(
                ColorsUtilities.FoundFontColorContrastingWithBackground(color));

            AccentMouseOverColorBrush = new SolidColorBrush(
                ColorsUtilities.UpdateColor(ahslAccentColor, lightness: ahslAccentColor.L + 15).ToColor());

            AccentPressedColorBrush = new SolidColorBrush(
                ColorsUtilities.UpdateColor(ahslAccentColor, lightness: ahslAccentColor.L - 10).ToColor());

            AccentSelectedColorBrush = new SolidColorBrush(
                ColorsUtilities.UpdateColor(ahslAccentColor, lightness: ahslAccentColor.L - 10).ToColor());
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update theme color. </summary>
        /// <param name="color"> New theme color. </param>
        private void UpdateThemeColor(Color color)
        {
            _themeColor = color;
            var ahslThemeColor = AHSLColor.FromColor(color);
            int change32 = ahslThemeColor.S < 50 ? 12 : -12;
            int change64 = ahslThemeColor.S < 50 ? 25 : -25;
            int change96 = ahslThemeColor.S < 50 ? 37 : -37;

            BackgroundColorBrush = new SolidColorBrush(color);
            ForegroundColorBrush = new SolidColorBrush(ColorsUtilities.InverseColor(color));

            BackgroundToolbarColorBrush = new SolidColorBrush(
                ColorsUtilities.UpdateColor(ahslThemeColor, saturation: 0, lightness: ahslThemeColor.S + change32).ToColor());

            BorderToolbarColorBrush = new SolidColorBrush(
                ColorsUtilities.UpdateColor(ahslThemeColor, saturation: 0, lightness: ahslThemeColor.S + change96).ToColor());

            SelectedInactiveColorBrush = new SolidColorBrush(
                ColorsUtilities.UpdateColor(ahslThemeColor, saturation: 0, lightness: ahslThemeColor.S + change64).ToColor());
        }

        #endregion COLORS UPDATE METHODS

        #region LOAD & SAVE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Load configuration from file. </summary>
        /// <returns> Loaded configuration from file or newly created configuration. </returns>
        private static Configuration LoadConfiguration()
        {
            try
            {
                var configurationFilePath = ApplicationHelper.Instance.ConfigurationFilePath;

                if (File.Exists(configurationFilePath))
                {
                    var serializedData = File.ReadAllText(configurationFilePath);
                    var loadedConfiguration = JsonConvert.DeserializeObject<Configuration>(serializedData);

                    if (loadedConfiguration != null)
                        return loadedConfiguration;
                }
            }
            catch (Exception)
            {
                //  Could not load configuration from file.
            }

            return new Configuration();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Save configuration to file. </summary>
        public void SaveConfiguration()
        {
            try
            {
                var configurationFilePath = ApplicationHelper.Instance.ConfigurationFilePath;
                var serializedData = JsonConvert.SerializeObject(this, Formatting.Indented);
                File.WriteAllText(configurationFilePath, serializedData);
            }
            catch (Exception)
            {
                //  Could not save configuration to file.
            }
        }

        #endregion LOAD & SAVE METHODS

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
