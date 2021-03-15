using System;
using System.Collections.Generic;
using System.Text;

namespace BST
{
    class BinarySearchNode<T>
    {
        public BinarySearchNode(T value)
        {
            this.Value = value;
        }

        public T Value
        {
            get;
        }

        public BinarySearchNode<T> Left
        {
            get;
            set;
        }

        public BinarySearchNode<T> Right
        {
            get;
            set;
        }
    }
}
