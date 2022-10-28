using chkam05.Tools.ControlsEx.Example.Data.Config;
using chkam05.Tools.ControlsEx.Static;
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
    public partial class TextBlocksPage : Page, INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        public Configuration Configuration { get; private set; }
        public MarqueeTextBlockState _enableAnimation = MarqueeTextBlockState.Enabled;


        //  GETTERS & SETTERS

        public MarqueeTextBlockState EnableAnimation
        {
            get => _enableAnimation;
            set
            {
                _enableAnimation = value;
                OnPropertyChanged(nameof(EnableAnimation));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> TextBlocksPage class constructor. </summary>
        public TextBlocksPage()
        {
            //  Initialize data containers.
            Configuration = Configuration.Instance;

            //  Initialize interface components.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking start stop animation ButtonEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void StartStopAnimationButtonEx_Click(object sender, RoutedEventArgs e)
        {
            switch (EnableAnimation)
            {
                case MarqueeTextBlockState.Disabled:
                    EnableAnimation = MarqueeTextBlockState.Enabled;
                    return;

                case MarqueeTextBlockState.Enabled:
                    EnableAnimation = MarqueeTextBlockState.WhenTextIsTooLong;
                    return;

                case MarqueeTextBlockState.WhenTextIsTooLong:
                    EnableAnimation = MarqueeTextBlockState.Disabled;
                    return;
            }
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
