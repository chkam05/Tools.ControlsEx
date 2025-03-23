using chkam05.Tools.ControlsEx.Data.Collections;
using chkam05.Tools.ControlsEx.Data.Enums;
using chkam05.Tools.ControlsEx.Data.Events;
using chkam05.Tools.ControlsEx.Interfaces;
using chkam05.Tools.ControlsEx.Resources;
using chkam05.Tools.ControlsEx.Utilities;
using chkam05.Tools.ControlsEx.Utilities.Interfaces;
using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using static MaterialDesignThemes.Wpf.Theme;

namespace chkam05.Tools.ControlsEx
{
    public class FrameEx : Control, IFrameEx<Page>
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundInactiveProperty = DependencyProperty.Register(
            nameof(BackgroundInactive),
            typeof(Brush),
            typeof(FrameEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty BorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(BorderBrushInactive),
            typeof(Brush),
            typeof(FrameEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(FrameEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty ForegroundInactiveProperty = DependencyProperty.Register(
            nameof(ForegroundInactive),
            typeof(Brush),
            typeof(FrameEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DarkInactive)));

        public static readonly DependencyProperty NavigationServiceProperty = DependencyProperty.Register(
            nameof(NavigationService),
            typeof(FrameNavigationServiceEx<Page>),
            typeof(FrameEx),
            new PropertyMetadata(new FrameNavigationServiceEx<Page>(), NavigationServicePropertyChangedCallback));

        public static readonly DependencyProperty OpacityInactiveProperty = DependencyProperty.Register(
            nameof(OpacityInactive),
            typeof(double),
            typeof(FrameEx),
            new PropertyMetadata(0.56d));


        //  VARIABLES

        private Frame frame;


        //  GETTERS & SETTERS

        public Brush BackgroundInactive
        {
            get => (Brush)GetValue(BackgroundInactiveProperty);
            set => SetValue(BackgroundInactiveProperty, value);
        }

        public Brush BorderBrushInactive
        {
            get => (Brush)GetValue(BorderBrushInactiveProperty);
            set => SetValue(BorderBrushInactiveProperty, value);
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public Brush ForegroundInactive
        {
            get => (Brush)GetValue(ForegroundInactiveProperty);
            set => SetValue(ForegroundInactiveProperty, value);
        }

        public double OpacityInactive
        {
            get => (double)GetValue(OpacityInactiveProperty);
            set => SetValue(OpacityInactiveProperty, MathUtilities.Clamp(value, 0d, 1d));
        }

        public FrameNavigationServiceEx<Page> NavigationService
        {
            get => (FrameNavigationServiceEx<Page>)GetValue(NavigationServiceProperty);
            set => SetValue(NavigationServiceProperty, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> FrameEx class constructor. </summary>
        static FrameEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FrameEx),
                new FrameworkPropertyMetadata(typeof(FrameEx)));
        }

        #endregion CONSTRUCTORS

        #region COMPONENT

        //  --------------------------------------------------------------------------------
        /// <summary> Loads page into frame. </summary>
        /// <param name="page"> Page to load. </param>
        private void LoadPage(Page page)
        {
            if (frame != null)
                frame.Content = page;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked during loading content into the Frame component. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Navigation event arguments. </param>
        /// <exception cref="NotImplementedException"></exception>
        private void OnFrameNavigated(object sender, NavigationEventArgs e)
        {
            //  Remove previous pages from content frame back entry.
            RemoveBackEntry();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Removes previous pages from content frame back entry method. </summary>
        private void RemoveBackEntry()
        {
            //  Get previous pages from content frame navigation service.
            var backEntry = frame.NavigationService.RemoveBackEntry();

            //  While previous pages are available - try to remove it.
            while (backEntry != null)
                backEntry = frame.NavigationService.RemoveBackEntry();
        }

        #endregion COMPONENT

        #region PROPERTIES CHANGED CALLBACKS

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when Pages property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void NavigationServicePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var frameEx = d as FrameEx;

            if (frameEx != null)
            {
                if (e.OldValue is FrameNavigationServiceEx<Page> oldNavSrv)
                {
                    oldNavSrv.PageLoaded -= frameEx.NavigationServicePageLoaded;
                }

                if (e.NewValue is FrameNavigationServiceEx<Page> newNavSrv)
                {
                    newNavSrv.PageLoaded += frameEx.NavigationServicePageLoaded;
                    frameEx.LoadPage(newNavSrv.CurrentPage);
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when NavigationService reported a page change. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> FrameNavigationServiceEx page loaded event arguments. </param>
        private void NavigationServicePageLoaded(object sender, FrameNavigationServiceExPageLoadedEventArgs<Page> e)
        {
            LoadPage(e.LoadedPage);
        }

        #endregion PROPERTIES CHANGED CALLBACKS

        #region TEMPLATE

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked whenever application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            frame = GetTemplateChild("frame") as Frame;

            if (frame != null)
            {
                frame.Navigated += OnFrameNavigated;

                if (NavigationService?.CurrentPage != null)
                    LoadPage(NavigationService.CurrentPage);
            }
        }

        #endregion TEMPLATE

    }
}
