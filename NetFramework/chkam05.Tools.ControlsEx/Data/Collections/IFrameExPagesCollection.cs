using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace chkam05.Tools.ControlsEx.Data.Collections
{
    public interface IFrameExPagesCollection<T> where T : Page
    {

        //  VARIABLES

        T this[int index] { get; set; }
        int Count { get; }


        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Adds a new item to the collection. </summary>
        /// <param name="item"> The item to add. </param>
        void Add(T item);

        //  --------------------------------------------------------------------------------
        /// <summary> Adds a new items to the collection. </summary>
        /// <param name="items"> The collection whose elements to be added to the new collection. </param>
        void AddRange(IEnumerable<T> items);

        //  --------------------------------------------------------------------------------
        /// <summary> Clears all items from the collection. </summary>
        void Clear();

        //  --------------------------------------------------------------------------------
        /// <summary> Removes the specified item from the collection. </summary>
        /// <param name="item"> The item to remove. </param>
        bool Remove(T item);

        //  --------------------------------------------------------------------------------
        /// <summary> Removes the item at the specified index. </summary>
        /// <param name="index"> The zero-based index of the item to remove. </param>
        void RemoveAt(int index);

        //  --------------------------------------------------------------------------------
        /// <summary> Removes specified items from the collection. </summary>
        /// <param name="items"> Items to remove. </param>
        void RemoveRange(IEnumerable<T> items);

    }
}
