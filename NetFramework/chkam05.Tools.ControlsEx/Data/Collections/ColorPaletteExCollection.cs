using chkam05.Tools.ControlsEx.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Data.Collections
{
    public class ColorPaletteExCollection : ObservableCollection<ColorPaletteExItem>
    {

        //  CONST

        private readonly ColorPaletteExItem addItemPlaceholder = new ColorPaletteExItem(Colors.Transparent, "Add Color")
        {
            IsAddItem = true,
        };


        //  VARIABLES

        private bool showAddItem = false;


        //  GETTERS & SETTERS

        public bool ShowAddItem
        {
            get => showAddItem;
            set
            {
                if (showAddItem != value)
                {
                    showAddItem = value;
                    UpdateAddItem();
                }
            }
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        [JsonConstructor]
        public ColorPaletteExCollection()
        {

        }

        //  --------------------------------------------------------------------------------
        /// <summary> ColorPaletteExCollection class constructor. </summary>
        /// <param name="showAddItem"> Determines whether to show the "Add New Item" placeholder. </param>
        public ColorPaletteExCollection(bool showAddItem = false)
        {
            ShowAddItem = showAddItem;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> ColorPaletteExCollection class constructor. </summary>
        /// <param name="collection"> The collection whose elements are copied to the new collection. </param>
        /// <param name="showAddItem"> Determines whether to show the "Add New Item" placeholder. </param>
        public ColorPaletteExCollection(IEnumerable<ColorPaletteExItem> collection, bool showAddItem = false)
        {
            AddRange(collection);
            ShowAddItem = showAddItem;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> ColorPaletteExCollection class constructor. </summary>
        /// <param name="collection"> The list whose elements are initially contained in the collection. </param>
        /// <param name="showAddItem"> Determines whether to show the "Add New Item" placeholder. </param>
        public ColorPaletteExCollection(List<ColorPaletteExItem> list, bool showAddItem = false)
        {
            AddRange(list);
            ShowAddItem = showAddItem;
        }

        #endregion CONSTRUCTORS

        #region ITEMS MANAGEMENT

        //  --------------------------------------------------------------------------------
        /// <summary> Adds a new item to the collection. </summary>
        /// <param name="item"> The item to add. </param>
        public new void Add(ColorPaletteExItem item)
        {
            if (ShowAddItem)
                base.Insert(Count - 1, item);
            else
                base.Add(item);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Adds a new items to the collection. </summary>
        /// <param name="items"> The collection whose elements to be added to the new collection. </param>
        public void AddRange(IEnumerable<ColorPaletteExItem> items)
        {
            if (items != null && items.Any())
                foreach (var item in items)
                    Add(item);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Clears all items from the collection. </summary>
        public new void Clear()
        {
            base.Clear();

            if (ShowAddItem)
                base.Add(addItemPlaceholder);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Inserts an item at the specified index. </summary>
        /// <param name="index"> The zero-based index at which the item should be inserted. </param>
        /// <param name="item"> The item to insert. </param>
        protected override void InsertItem(int index, ColorPaletteExItem item)
        {
            if (ShowAddItem && index == Count && item != addItemPlaceholder)
                base.InsertItem(Count - 1, item);
            else
                base.InsertItem(index, item);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Removes the specified item from the collection. </summary>
        /// <param name="item"> The item to remove. </param>
        public new void Remove(ColorPaletteExItem item)
        {
            if (!Equals(item, addItemPlaceholder))
                base.Remove(item);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Removes the item at the specified index. </summary>
        /// <param name="index"> The zero-based index of the item to remove. </param>
        protected override void RemoveItem(int index)
        {
            if (ShowAddItem && index == Count - 1)
                return;

            base.RemoveItem(index);
        }

        #endregion ITEMS MANAGEMENT

        #region STATIC ITEMS

        //  --------------------------------------------------------------------------------
        /// <summary> Updates the presence of the "Add New Item" placeholder based on the value of ShowItemAdd.
        /// Adds or removes the placeholder as necessary. </summary>
        private void UpdateAddItem()
        {
            if (showAddItem)
            {
                if (!Contains(addItemPlaceholder))
                    base.Add(addItemPlaceholder);
            }
            else
            {
                if (Contains(addItemPlaceholder))
                    base.Remove(addItemPlaceholder);
            }
        }

        #endregion STATIC ITEMS

    }
}
