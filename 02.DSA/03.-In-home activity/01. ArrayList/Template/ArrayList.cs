using System;

namespace DSA.Linear
{
    public class ArrayList<T>
    {
        private T[] items;
        private int count;


        public ArrayList()
        {
            // 4 is a good number for an initial size
            this.items = new T[4];
            // set count to 0 since no items have been added yet
            this.count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public int Capacity
        {
            get
            {
                return this.items.Length;
            }
        }

        public void Add(T value)
        {
            this.EnsureCapacity();

            // Add the new item at the end
            this.items[this.count] = value;

            // Increase the total count of items
            this.count++;
        }

        public void Insert(int index, T item)
        {
            this.EnsureCapacity();

            // Shift cells to the right
            Array.Copy(this.items, index, this.items, index + 1, this.count - index);

            // Insert the item
            this.items[index] = item;

            // Increase the total count of items
            this.count++;
        }

        public void RemoveAt(int index)
        {
            this.count--;

            // Shift cells to the left
            Array.Copy(this.items, index + 1, this.items, index, this.count - index);

            // Clear the last cell
            this.items[this.count] = default;
        }

        private void EnsureCapacity()
        {
            // Check if we should resize the array
            // Resize is necessary as soon as the number of elements becomes equal to the length of the array.
            if (this.Count == this.Capacity)
            {
                // Create a new array with twice the capacity
                T[] newItems = new T[this.Capacity * 2];

                // items      : the source array
                // newItems   : the destination array
                // this.count : the number of elements to copy
                Array.Copy(this.items, newItems, this.Count);

                // Point to the new array
                this.items = newItems;
            }
        }

        public T Get(int index)
        {
            this.ValidateIndex(index);

            return this.items[index];
        }

        public void Set(int index, T value)
        {
            this.ValidateIndex(index);

            this.items[index] = value;
        }

        // Indexer
        public T this[int index]
        {
            get
            {
                return this.Get(index);
            }
            set
            {
                this.Set(index, value);
            }

        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.items.Length)
            {
                throw new ArgumentException($"Index {index} is out of range.");
            }
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.count; i++)
            {
                yield return this.items[i];
            }
        }
    }
}
