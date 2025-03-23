using chkam05.Tools.ControlsEx.Data.Enums;
using chkam05.Tools.ControlsEx.Data.Events;
using chkam05.Tools.ControlsEx.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace chkam05.Tools.ControlsEx.Data.Collections
{
    public class FrameNavigationServiceEx<T> : ObservableCollection<T>, IFrameExPagesCollection<T>, 
        IFrameNavigationServiceEx<T>, INotifyPropertyChanged where T : Page
    {

        //  DELEGATES

        public delegate void FrameNavigationServiceExPageLoadedEventHandler
            (object sender, FrameNavigationServiceExPageLoadedEventArgs<T> e);


        //  EVENTS

        public event FrameNavigationServiceExPageLoadedEventHandler PageLoaded;
        public new event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private T currentPage = null;
        private FrameNavigationServiceExRemovePolicy removePolicy = FrameNavigationServiceExRemovePolicy.LoadPreviousPage;


        //  GETTERS & SETTERS

        public bool CanGoBack
        {
            get => this.Any() && CurrentPage != null && CurrentPageIndex > 0;
        }

        public bool CanGoForward
        {
            get => this.Any() && CurrentPage != null && CurrentPageIndex < Count - 1;
        }

        public T CurrentPage
        {
            get => currentPage;
            set => LoadPage(value);
        }

        public int CurrentPageIndex
        {
            get => CurrentPage != null && Contains(CurrentPage) ? IndexOf(CurrentPage) : -1;
            set => LoadPage(value);
        }

        public FrameNavigationServiceExRemovePolicy RemovePolicy
        {
            get => removePolicy;
            set => UpdateProperty(ref removePolicy, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> FrameNavigationServiceEx class constructor. </summary>
        public FrameNavigationServiceEx()
        {
        }

        //  --------------------------------------------------------------------------------
        /// <summary> FrameNavigationServiceEx class constructor. </summary>
        /// <param name="collection"> The collection whose elements are copied to the new collection. </param>
        public FrameNavigationServiceEx(IEnumerable<T> collection)
        {
            AddRange(collection);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> FrameNavigationServiceEx class constructor. </summary>
        /// <param name="list"> The list whose elements are initially contained in the collection. </param>
        public FrameNavigationServiceEx(List<T> list)
        {
            AddRange(list);
        }

        #endregion CONSTRUCTORS

        #region EVENTS INVOKERS

        //  --------------------------------------------------------------------------------
        /// <summary> Invokes PageLoaded event. </summary>
        /// <param name="loadedPage"> Loaded page. </param>
        protected virtual void InvokePageLoaded(T loadedPage, T unloadedPage)
        {
            PageLoaded?.Invoke(this, new FrameNavigationServiceExPageLoadedEventArgs<T>(loadedPage, unloadedPage));
        }

        #endregion EVENTS INVOKERS

        #region ITEMS MANAGEMENT

        //  --------------------------------------------------------------------------------
        /// <summary> Adds a new item to the collection. </summary>
        /// <param name="item"> The item to add. </param>
        public new virtual void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            base.Add(item);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Adds a new item to the collection. </summary>
        /// <param name="item"> The item to add. </param>
        public virtual void AddAndLoad(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            base.Add(item);
            LoadPage(item);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Adds a new items to the collection. </summary>
        /// <param name="items"> The collection whose elements to be added to the new collection. </param>
        public virtual void AddRange(IEnumerable<T> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            foreach (var item in items)
                Add(item);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Clears all items from the collection. </summary>
        public new virtual void Clear()
        {
            base.Clear();
            ApplyRemovePolicy(true, -1);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Inserts an item at the specified index. </summary>
        /// <param name="index"> The zero-based index at which the item should be inserted. </param>
        /// <param name="item"> The item to insert. </param>
        private new void Insert(int index, T item)
        {
            base.Insert(index, item);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Removes the specified item from the collection. </summary>
        /// <param name="item"> The item to remove. </param>
        public new virtual bool Remove(T item)
        {
            bool result = base.Remove(item);
            ApplyRemovePolicy(item == CurrentPage, CurrentPageIndex - 1);
            return result;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Removes the item at the specified index. </summary>
        /// <param name="index"> The zero-based index of the item to remove. </param>
        public new virtual void RemoveAt(int index)
        {
            if (!MathUtilities.IsInRange(index, 0, Count - 1))
                throw new ArgumentOutOfRangeException(nameof(index));

            var pageToRemove = this[index];
            Remove(pageToRemove);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Removes specified items from the collection. </summary>
        /// <param name="items"> Items to remove. </param>
        public virtual void RemoveRange(IEnumerable<T> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            int newCurrentPageIndex = CurrentPageIndex;

            foreach (var item in items)
            {
                if (Contains(item))
                {
                    var pageIndex = IndexOf(item);

                    if (pageIndex <= newCurrentPageIndex)
                        newCurrentPageIndex--;
                }

                base.Remove(item);
            }

            ApplyRemovePolicy(items.Contains(CurrentPage), newCurrentPageIndex);
        }

        #endregion ITEMS MANAGEMENT

        #region NAVIGATION

        //  --------------------------------------------------------------------------------
        /// <summary> Loads previous page. </summary>
        public void GoBack()
        {
            if (CanGoBack)
            {
                var previousPage = this[CurrentPageIndex - 1];
                LoadPage(previousPage);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Loads next page. </summary>
        public void GoForward()
        {
            if (CanGoForward)
            {
                var nextPage = this[CurrentPageIndex + 1];
                LoadPage(nextPage);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Loads the page for display. </summary>
        /// <param name="page"> Page to load. </param>
        public virtual void LoadPage(T page)
        {
            if (page != null && !Contains(page))
                throw new ArgumentException("Page not found in collection. To load page, you must add it first.", nameof(page));

            UpdateCurrentPageProperty(page);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Loads the page with the specified index for display. </summary>
        /// <param name="pageIndex"> Index of page to load. </param>
        public virtual void LoadPage(int pageIndex)
        {
            if (!MathUtilities.IsInRange(pageIndex, 0, Count - 1))
                throw new ArgumentOutOfRangeException(nameof(pageIndex));

            UpdateCurrentPageProperty(this[pageIndex]);
        }

        #endregion NAVIGATION

        #region PROPERTIES CHANGED NOTIFICATION

        //  --------------------------------------------------------------------------------
        /// <summary> Triggers a property changed notification event. </summary>
        /// <param name="propertyName"> Property name. </param>
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            var propertyChangedEventArgs = new PropertyChangedEventArgs(propertyName);

            base.OnPropertyChanged(propertyChangedEventArgs);
            PropertyChanged?.Invoke(this, propertyChangedEventArgs);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Raises the CollectionChanged event with the provided arguments. </summary>
        /// <param name="e"> Arguments of the event being raised. </param>
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                if (e.OldItems.Contains(CurrentPage))
                    CurrentPage = e.NewItems[0] as T;
            }

            base.OnCollectionChanged(e);
        }

        #endregion PROPERTIES CHANGED NOTIFIACTION

        #region PROPERTIES MANAGEMENT

        //  --------------------------------------------------------------------------------
        /// <summary> Set CurrentPage value and trigger property changed modification event. </summary>
        /// <param name="page"> CurrentPage value to set. </param>
        private void UpdateCurrentPageProperty(T page)
        {
            var unloadedPage = CurrentPage;

            UpdateProperty(ref currentPage, page, nameof(CurrentPage));
            NotifyPropertyChanged(nameof(CurrentPageIndex));
            NotifyPropertyChanged(nameof(CanGoBack));
            NotifyPropertyChanged(nameof(CanGoForward));

            InvokePageLoaded(page, unloadedPage);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Sets a value in a property and triggers a property changed notification event. </summary>
        /// <typeparam name="T"> Property value type. </typeparam>
        /// <param name="field"> Reference to property. </param>
        /// <param name="newValue"> Value to set. </param>
        /// <param name="propertyName"> Property name. </param>
        protected void UpdateProperty<T1>(ref T1 field, T1 newValue, [CallerMemberName] string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException("Property update failed. Property name cannot be null or empty.");

            field = newValue;

            NotifyPropertyChanged(propertyName);
        }

        #endregion PROPERTIES MANAGEMENT

        #region UTILITIES

        //  --------------------------------------------------------------------------------
        /// <summary> Apply remove page policy rule. </summary>
        /// <param name="pageRemoved"> Is page removed. </param>
        /// <param name="decreasedCurrentPageIndex"> Decreased CurrentPageIndex value. </param>
        private void ApplyRemovePolicy(bool pageRemoved, int decreasedCurrentPageIndex)
        {
            if (pageRemoved)
            {
                switch (removePolicy)
                {
                    case FrameNavigationServiceExRemovePolicy.LoadPreviousPage:
                        if (this.Any())
                        {
                            var previousPageIndex = MathUtilities.Clamp(decreasedCurrentPageIndex, 0, Count);
                            LoadPage(previousPageIndex);
                        }
                        else
                        {
                            CurrentPage = null;
                        }
                        return;

                    case FrameNavigationServiceExRemovePolicy.LoadNextPage:
                        if (this.Any())
                        {
                            var nextPageIndex = MathUtilities.Clamp(decreasedCurrentPageIndex + 1, 0, Count);
                            LoadPage(nextPageIndex);
                        }
                        else
                        {
                            CurrentPage = null;
                        }
                        return;

                    case FrameNavigationServiceExRemovePolicy.UnloadPage:
                        CurrentPage = null;
                        return;

                    case FrameNavigationServiceExRemovePolicy.LeavePage:
                        break;
                }
            }

            NotifyPropertyChanged(nameof(CurrentPageIndex));
        }

        #endregion UTILITIES

    }
}
