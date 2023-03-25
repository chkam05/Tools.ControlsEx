using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Example.Data;
using chkam05.Tools.ControlsEx.Example.Data.Config;
using chkam05.Tools.ControlsEx.InternalMessages;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace chkam05.Tools.ControlsEx.Example.ExtendedControls
{
    public partial class ListViewInternalMessageEx : StandardInternalMessageEx
    {

        //  VARIABLES

        private ObservableCollection<ListViewIMData> _data;


        //  GETTERS & SETTERS

        public ObservableCollection<ListViewIMData> Data
        {
            get => _data;
            set
            {
                _data = value;
                _data.CollectionChanged += (s, e) => { OnPropertyChanged(nameof(Data)); };
                OnPropertyChanged(nameof(Data));
            }
        }

        public Configuration Configuration { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ListViewInternalMessageEx class constructor. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        public ListViewInternalMessageEx(InternalMessagesExContainer parentContainer) : base(parentContainer)
        {
            //  Setup data.
            Configuration = Configuration.Instance;
            SetupData();

            //  Initialize interface.
            InitializeComponent();
            SetupInterfaceAppearance();
        }

        #endregion CLASS METHODS

        #region SETUP METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Setup interface appearance. </summary>
        private void SetupInterfaceAppearance()
        {
            Background = Configuration.BackgroundColorBrush;
            BorderBrush = Configuration.AccentColorBrush;
            Foreground = Configuration.ForegroundColorBrush;
            ButtonBackground = Configuration.AccentColorBrush;
            ButtonBorderBrush = Configuration.AccentColorBrush;
            ButtonForeground = Configuration.AccentForegroundColorBrush;
            ButtonMouseOverBackground = Configuration.AccentMouseOverColorBrush;
            ButtonMouseOverBorderBrush = Configuration.AccentMouseOverColorBrush;
            ButtonMouseOverForeground = Configuration.AccentForegroundColorBrush;
            ButtonPressedBackground = Configuration.AccentPressedColorBrush;
            ButtonPressedBorderBrush = Configuration.AccentPressedColorBrush;
            ButtonPressedForeground = Configuration.AccentForegroundColorBrush;

            Buttons = new InternalMessageButtons[]
            {
                InternalMessageButtons.OkButton,
                InternalMessageButtons.CancelButton
            };
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Setup an example data. </summary>
        private void SetupData()
        {
            var data = new List<ListViewIMData>();
            var icons = Enum.GetValues(typeof(PackIconKind)).Cast<PackIconKind>().Distinct().ToList();
            Random rand = new Random();

            for (int i = 0; i < 20; i++)
            {
                int iconIndex = rand.Next(icons.Count);
                var country = ExampleData.EuropeanCountries[i];

                data.Add(new ListViewIMData(
                    icons[iconIndex],
                    $"{country.Name}", $"The capital city of {country.Name} country is: {country.Capital}."));
            }

            Data = new ObservableCollection<ListViewIMData>(data);
        }

        #endregion SETUP METHODS

    }
}
