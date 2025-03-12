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

        public static readonly DependencyProperty CurrentPageProperty = DependencyProperty.Register(
            nameof(CurrentPage),
            typeof(Page),
            typeof(FrameEx),
            new PropertyMetadata(null, CurrentPagePropertyChangedCallback));

        public static readonly DependencyProperty CurrentPageIndexProperty = DependencyProperty.Register(
            nameof(CurrentPageIndex),
            typeof(int),
            typeof(FrameEx),
            new PropertyMetadata(-1, CurrentPageIndexPropertyChangedCallback));

        public static readonly DependencyProperty ForegroundInactiveProperty = DependencyProperty.Register(
            nameof(ForegroundInactive),
            typeof(Brush),
            typeof(FrameEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DarkInactive)));

        public static readonly DependencyProperty OpacityInactiveProperty = DependencyProperty.Register(
            nameof(OpacityInactive),
            typeof(double),
            typeof(FrameEx),
            new PropertyMetadata(0.56d));

        public static readonly DependencyProperty PagesProperty = DependencyProperty.Register(
            nameof(Pages),
            typeof(FrameExPagesCollection<Page>),
            typeof(FrameEx),
            new PropertyMetadata(new FrameExPagesCollection<Page>(), PagesPropertyChangedCallback));

        public static readonly DependencyProperty UnloadPageOnRemoveProperty = DependencyProperty.Register(
            nameof(UnloadPageOnRemove),
            typeof(bool),
            typeof(FrameEx),
            new PropertyMetadata(false, CurrentPageIndexPropertyChangedCallback));


        //  DELEGATES

        public delegate void FrameExPageLoadedEventHandler(object sender, FrameExPageChangedEventArgs e);
        public delegate void FrameExPageUnloadedEventHandler(object sender, FrameExPageChangedEventArgs e);


        //  EVENTS

        public event FrameExPageLoadedEventHandler FrameExPageLoaded;
        public event FrameExPageUnloadedEventHandler FrameExPageUnloaded;


        //  VARIABLES

        private Frame frame;
        private bool pageSwitching = false;


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

        public bool CanGoBack
        {
            get => Pages != null && Pages.Any() && CurrentPage != null && CurrentPageIndex > 0;
        }

        public bool CanGoForward
        {
            get => Pages != null && Pages.Any() && CurrentPage != null && CurrentPageIndex < PagesCount - 1;
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public Page CurrentPage
        {
            get => (Page)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }

        public int CurrentPageIndex
        {
            get => (int)GetValue(CurrentPageIndexProperty);
            set => SetValue(CurrentPageIndexProperty, value);
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

        public FrameExPagesCollection<Page> Pages
        {
            get => (FrameExPagesCollection<Page>)GetValue(PagesProperty);
            set => SetValue(PagesProperty, value);
        }

        public int PagesCount
        {
            get => Pages?.Count ?? 0;
        }

        public bool UnloadPageOnRemove
        {
            get => (bool)GetValue(UnloadPageOnRemoveProperty);
            set => SetValue(UnloadPageOnRemoveProperty, value);
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
        /// <summary> Remove currently loaded page from content frame method. </summary>
        private void ClearFrameContent()
        {
            frame.Content = null;
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

        #region NAVIGATION

        //  --------------------------------------------------------------------------------
        /// <summary> Loads previous page. </summary>
        public void GoBack()
        {
            if (CanGoBack)
            {
                var previousPage = Pages[CurrentPageIndex - 1];
                SwitchPage(previousPage);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Loads next page. </summary>
        public void GoForward()
        {
            if (CanGoForward)
            {
                var nextPage = Pages[CurrentPageIndex + 1];
                SwitchPage(nextPage);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Go to current loaded page. </summary>
        /// <param name="page"> Page (from pages collection) to load. </param>
        public void GoToPage(Page page)
        {
            if (Pages.Contains(page))
                SwitchPage(page);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Loads page at particular index in pages collection. </summary>
        /// <param name="pageIndex"> Index of page in pages collection. </param>
        public void GoToPage(int pageIndex)
        {
            if (pageIndex < 0 || pageIndex >= PagesCount)
                throw new ArgumentOutOfRangeException(nameof(pageIndex), $"{pageIndex} is out of bounds [0 - {PagesCount-1}]");

            var page = Pages[pageIndex];
            GoToPage(page);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Adds new page to pages collection navigates to it. </summary>
        /// <param name="page"> Page to add and load. </param>
        public void LoadPage(Page page)
        {
            if (!Pages.Contains(page))
            {
                Pages.Add(page);
                SwitchPage(page);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Switchs to page from pages collection. </summary>
        /// <param name="page"> Page from pages collection. </param>
        private void SwitchPage(Page page)
        {
            if (pageSwitching)
                return;

            InvokeActionInPageSwitchMode(() =>
            {
                CurrentPageIndex = Pages.IndexOf(page);
                CurrentPage = page;

                if (frame != null)
                {
                    frame.Content = page;
                    FrameExPageLoaded?.Invoke(this, new FrameExPageChangedEventArgs(page, FrameExPageAction.Loaded));
                }
            });
        }

        #endregion NAVIGATION

        #region PROPERTIES CHANGED CALLBACKS

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when CurrentPage property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void CurrentPagePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var frameEx = d as FrameEx;

            if (frameEx != null)
            {
                if (e.OldValue is Page oldPage)
                    frameEx.FrameExPageUnloaded?.Invoke(frameEx, new FrameExPageChangedEventArgs(oldPage, FrameExPageAction.Unloaded));

                if (e.NewValue is Page newPage)
                {
                    if (frameEx.Pages.Contains(newPage))
                        frameEx.SwitchPage(newPage);
                    else
                        frameEx.LoadPage(newPage);
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when CurrentPageIndex property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void CurrentPageIndexPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var frameEx = d as FrameEx;

            if (frameEx != null && e.NewValue is int pageIndex)
                frameEx.GoToPage(pageIndex);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when Pages property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void PagesPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var frameEx = d as FrameEx;

            if (frameEx != null)
            {
                if (e.OldValue is FrameExPagesCollection<Page> oldCollection)
                    oldCollection.CollectionChanged -= frameEx.OnPagesCollectionChanged;
                
                if (e.NewValue is FrameExPagesCollection<Page> newCollection)
                    newCollection.CollectionChanged += frameEx.OnPagesCollectionChanged;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after items change in Pages collection. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Notify collection changed event arguments. </param>
        private void OnPagesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Remove:
                    foreach (var removedPage in e.OldItems.OfType<Page>())
                        FrameExPageUnloaded?.Invoke(this, new FrameExPageChangedEventArgs(removedPage, FrameExPageAction.Removed));

                    if (IsCurrentPageTouched(e.OldItems))
                    {
                        if (UnloadPageOnRemove)
                        {
                            InvokeActionInPageSwitchMode(() =>
                            {
                                CurrentPageIndex = -1;
                                CurrentPage = null;
                                ClearFrameContent();
                            });
                            return;
                        }

                        int previousIndex = MathUtilities.Clamp(CurrentPageIndex - 1, 0, PagesCount - 1);

                        if (MathUtilities.IsInRange(previousIndex, 0, PagesCount - 1))
                        {
                            var previousPage = Pages[previousIndex];
                            SwitchPage(previousPage);
                        }
                    }
                    else
                    {
                        InvokeActionInPageSwitchMode(() =>
                        {
                            CurrentPageIndex = Pages.IndexOf(CurrentPage);
                        });
                    }
                    return;

                case NotifyCollectionChangedAction.Replace:
                    if (IsCurrentPageTouched(e.OldItems))
                    {
                        var newPage = e.NewItems.OfType<Page>().First();
                        SwitchPage(newPage);
                    }
                    return;

                case NotifyCollectionChangedAction.Move:
                    InvokeActionInPageSwitchMode(() =>
                    {
                        CurrentPageIndex = Pages.IndexOf(CurrentPage);
                    });
                    return;

                case NotifyCollectionChangedAction.Reset:
                    ClearFrameContent();
                    InvokeActionInPageSwitchMode(() =>
                    {
                        CurrentPageIndex = -1;
                        CurrentPage = null;
                    });
                    return;
            }
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

                if (CurrentPage != null && CurrentPageIndex >= 0)
                {
                    frame.Content = CurrentPage;
                    FrameExPageLoaded?.Invoke(this, new FrameExPageChangedEventArgs(CurrentPage, FrameExPageAction.Loaded));
                }
            }
        }

        #endregion TEMPLATE

        #region UTILITIES

        //  --------------------------------------------------------------------------------
        /// <summary> Invokes an action in page switching mode. </summary>
        /// <param name="action"> Action that will be ivoked in page switching mode. </param>
        private void InvokeActionInPageSwitchMode(Action action)
        {
            pageSwitching = true;
            action?.Invoke();
            pageSwitching = false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Check if list of modified pages in pages collection contains current loaded page. </summary>
        /// <param name="modifiedPages"> List of modified pages in pages collection. </param>
        /// <returns> True - current loaded page is in list of modified pages in pages collection; False - otherwise. </returns>
        private bool IsCurrentPageTouched(IList modifiedPages)
        {
            return modifiedPages.OfType<Page>().Contains(CurrentPage);
        }

        #endregion UTILITEIS

    }
}
