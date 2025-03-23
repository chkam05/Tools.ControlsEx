using chkam05.Tools.ControlsEx.Data.Enums;
using chkam05.Tools.ControlsEx.ViewModels;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Data.Collections
{
    public class HamburgerMenuExCollection : ObservableCollection<HamburgerMenuExItem>
    {

        //  CONST

        private readonly HamburgerMenuExItem headerItemPlaceholder = new HamburgerMenuExItem()
        {
            Title = "Main Menu",
            Description = "Expands and collapses the menu",
            IconKind = PackIconKind.Menu,
            ItemType = HamburgerMenuExItemType.Header,
        };


        //  VARIABLES

        private bool showHeaderItem;


        //  GETTERS & SETTERS

        public bool ShowHeaderItem
        {
            get => showHeaderItem;
            set
            {
                if (showHeaderItem != value)
                {
                    showHeaderItem = value;
                    UpdateStaticItems();
                }
            }
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> HamburgerMenuExCollection class constructor. </summary>
        /// <param name="showHeaderItem"> Determines whether to show the "Header" placeholder. </param>
        public HamburgerMenuExCollection(bool showHeaderItem = true)
        {
            ShowHeaderItem = showHeaderItem;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> HamburgerMenuExCollection class constructor. </summary>
        /// <param name="collection"> The collection whose elements are copied to the new collection. </param>
        /// <param name="showHeaderItem"> Determines whether to show the "Header" placeholder. </param>
        public HamburgerMenuExCollection(IEnumerable<HamburgerMenuExItem> collection, bool showHeaderItem = true)
        {
            AddRange(collection);
            ShowHeaderItem = showHeaderItem;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> HamburgerMenuExCollection class constructor. </summary>
        /// <param name="collection"> The list whose elements are initially contained in the collection. </param>
        /// <param name="showHeaderItem"> Determines whether to show the "Header" placeholder. </param>
        public HamburgerMenuExCollection(List<HamburgerMenuExItem> list, bool showHeaderItem = true)
        {
            AddRange(list);
            ShowHeaderItem = showHeaderItem;
        }

        #endregion CONSTRUCTORS

        #region ITEMS MANAGEMENT

        //  --------------------------------------------------------------------------------
        /// <summary> Adds a new item to the collection. </summary>
        /// <param name="item"> The item to add. </param>
        public new void Add(HamburgerMenuExItem item)
        {
            base.Add(item);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Adds a new items to the collection. </summary>
        /// <param name="items"> The collection whose elements to be added to the new collection. </param>
        public void AddRange(IEnumerable<HamburgerMenuExItem> items)
        {
            foreach (var item in items)
                Add(item);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Clears all items from the collection. </summary>
        public new void Clear()
        {
            base.Clear();

            if (ShowHeaderItem)
                base.Add(headerItemPlaceholder);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Inserts an item at the specified index. </summary>
        /// <param name="index"> The zero-based index at which the item should be inserted. </param>
        /// <param name="item"> The item to insert. </param>
        protected override void InsertItem(int index, HamburgerMenuExItem item)
        {
            if (item.Equals(headerItemPlaceholder))
                base.InsertItem(index, item);
            else if (ShowHeaderItem && index < 1)
                base.InsertItem(1, item);
            else
                base.InsertItem(index, item);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Removes the specified item from the collection. </summary>
        /// <param name="item"> The item to remove. </param>
        public new void Remove(HamburgerMenuExItem item)
        {
            if (item.ItemType != HamburgerMenuExItemType.Header)
                base.Remove(item);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Removes the item at the specified index. </summary>
        /// <param name="index"> The zero-based index of the item to remove. </param>
        protected override void RemoveItem(int index)
        {
            if (ShowHeaderItem && index < 1)
                return;

            base.RemoveItem(index);
        }

        #endregion ITEMS MANAGEMENT

        #region STATIC ITEMS

        //  --------------------------------------------------------------------------------
        /// <summary> Updates the presence of the statick placeholder based on the value of showHeaderItem and showBackItem.
        /// Adds or removes the placeholder as necessary. </summary>
        private void UpdateStaticItems()
        {
            if (showHeaderItem)
            {
                if (!Contains(headerItemPlaceholder))
                    base.Insert(0, headerItemPlaceholder);
            }
            else
            {
                if (Contains(headerItemPlaceholder))
                    base.Remove(headerItemPlaceholder);
            }
        }

        #endregion STATIC ITEMS

    }
}
