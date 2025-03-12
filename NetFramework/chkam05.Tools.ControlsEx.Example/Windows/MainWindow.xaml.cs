using chkam05.Tools.ControlsEx.Data.Collections;
using chkam05.Tools.ControlsEx.Example.Data;
using chkam05.Tools.ControlsEx.Interfaces;
using chkam05.Tools.ControlsEx.ViewModels;
using MaterialDesignThemes.Wpf;
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
using System.Windows.Shapes;

namespace chkam05.Tools.ControlsEx.Example.Windows
{
    public partial class MainWindow : WindowEx
    {

        //  VARIABLES

        public MainWindowDataContext MainWindowDataContext
        {
            get => base.DataContext as MainWindowDataContext;
            set => base.DataContext = value;
        }
        public IFrameEx<Page> PagesNavigationContainer
        {
            get => this.pagesNavigationContainer;
        }


        //  METHODS

        public MainWindow(object args)
        {
            DataContext = new MainWindowDataContext();

            InitializeComponent();

            MainWindowDataContext.AssignPagesNavigationContainer(PagesNavigationContainer);
        }
    }
}
