using System;
using System.Collections.Generic;

namespace BST
{
    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable<T>
    {
        private T value;
        private BinarySearchTree<T> left;
        private BinarySearchTree<T> right;
        private static List<T> inOrder = new List<T>();
        private static List<T> preOrder = new List<T>();
        private static List<T> postOrder = new List<T>();
        private static List<T> collection = new List<T>();

        public BinarySearchTree(T value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
        }
        private int GetTreeDepth(BinarySearchTree<T> parent)
        {
            int height = 0;
            if (parent != null)
            {
                if (parent.left == null && parent.right == null)
                {
                    height = 0;
                }
                else
                {
                    height = Math.Max(GetTreeDepth(parent.left), GetTreeDepth(parent.right)) + 1;
                }
            }
            else
            {
                height = 0;
            }
            return height;
        }

        public int Height
        {
            get => GetTreeDepth(this);
        }
        public IList<T> GetBFS()
        {
            var queue = new Queue<BinarySearchTree<T>>();

            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                BinarySearchTree<T> current = queue.Dequeue();

                collection.Add(current.GetRootValue());

                if (current.left != null)
                {
                    queue.Enqueue(current.left);
                }
                if (current.right != null)
                {
                    queue.Enqueue(current.right);
                }
            }

            return collection;
        }
        public IList<T> GetInOrder()
        {
            if (this.left != null)
            {
                this.left.GetInOrder();
            }
            inOrder.Add(this.value);
            if (this.right != null)
            {
                this.right.GetInOrder();
            }
            return inOrder;
        }
        public IBinarySearchTree<T> GetLeftTree()
        {
            return this.left;
        }
        public IList<T> GetPostOrder()
        {
            if (this.left != null)
            {
                this.left.GetPostOrder();
            }
            if (this.right != null)
            {
                this.right.GetPostOrder();
            }
            postOrder.Add(this.value);
            return postOrder;
        }
        public IList<T> GetPreOrder()
        {
            preOrder.Add(this.value);
            if (this.left != null)
            {
                this.left.GetPreOrder();
            }
            if (this.right != null)
            {
                this.right.GetPreOrder();
            }
            return preOrder;
        }
        public IBinarySearchTree<T> GetRightTree()
        {
            return this.right;
        }
        public T GetRootValue()
        {
            return this.value;
        }
        public void Insert(T element)
        {
            if (element.CompareTo(this.GetRootValue()) == -1)
            {
                if (this.left == null)
                {
                    this.left = new BinarySearchTree<T>(element);
                    return;
                }
                this.GetLeftTree().Insert(element);
            }
            else
            {
                if (this.right == null)
                {
                    this.right = new BinarySearchTree<T>(element);
                    return;
                }
                this.GetRightTree().Insert(element);
            }
        }
        public bool Search(T element)
        {
            if (this.GetRootValue() == null)
            {
                return false;
            }
            if (this.GetRootValue().Equals(element))
            {
                return true;
            }
            if (element.CompareTo(this.GetRootValue()) == -1 && this.left != null)
            {
                return this.left.Search(element);
            }
            else if (element.CompareTo(this.GetRootValue()) == 1 && this.right != null)
            {
                return this.right.Search(element);
            }
            return false;
        }
        // Advanced task!
        public bool Remove(T value)
        {
            if (this == null)
            {
                return false;
            }
            if (value.CompareTo(this.GetRootValue()) == -1)
            {
                if (this.left != null)
                {
                    return this.left.Remove(value);
                }
                else return false;
            }
            else if (value.CompareTo(this.GetRootValue()) == 1)
            {
                if (this.right != null)
                {
                    return this.right.Remove(value);
                }
                else return false;
            }
            else
            {
                if (this.left != null && this.right != null)
                {
                    this.value = maxValue(this.left);
                    if (this.left == null && this.right == null)
                    {
                        return this.left.Remove(value);
                    }
                }
                else if (this.left == null)
                {
                    this.value = this.right.GetRootValue();
                }
                else if (this.right == null)
                {
                    this.value = this.left.GetRootValue();
                }
                return true;
            }
        }
        public T maxValue(BinarySearchTree<T> node)
        {
            if (node.right == null)
            {
                return node.GetRootValue();
            }
            return maxValue(node.right);
        }
    }
}
