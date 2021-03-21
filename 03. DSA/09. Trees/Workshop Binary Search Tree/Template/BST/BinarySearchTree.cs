using System;
using System.Collections.Generic;

namespace BST
{
	// Telerik Solution:
	public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable<T>
	{
		public BinarySearchTree(T value)
		{
			this.Value = value;
		}

		public T Value
		{
			get;
			private set;
		}

		public BinarySearchTree<T> Left
		{
			get;
			private set;
		}

		public BinarySearchTree<T> Right
		{
			get;
			private set;
		}

		public int Height
		{
			get
			{
				int leftHeight = this.Left != null ? this.Left.Height + 1 : 0;
				int rightHeight = this.Right != null ? this.Right.Height + 1 : 0;

				return Math.Max(leftHeight, rightHeight);
			}
		}

		public T GetRootValue() => this.Value;

		public IBinarySearchTree<T> GetLeftTree() => this.Left;

		public IBinarySearchTree<T> GetRightTree() => this.Right;

		public IList<T> GetBFS()
		{
			var output = new List<T>();

			this.GetBFS(this, output);

			return output;
		}

		private void GetBFS(BinarySearchTree<T> root, List<T> output)
		{
			if (root == null)
			{
				return;
			}

			var queue = new Queue<BinarySearchTree<T>>();

			queue.Enqueue(root);

			while (queue.Count > 0)
			{
				var node = queue.Dequeue();

				output.Add(node.Value);

				if (node.Left != null)
				{
					queue.Enqueue(node.Left);
				}

				if (node.Right != null)
				{
					queue.Enqueue(node.Right);
				}
			}
		}

		public IList<T> GetPreOrder()
		{
			var result = new List<T>();

			this.GetPreOrder(this, result);

			return result;
		}

		private void GetPreOrder(BinarySearchTree<T> root, List<T> output)
		{
			if (root == null)
			{
				return;
			}

			// visit
			output.Add(root.Value);

			this.GetPreOrder(root.Left, output);
			this.GetPreOrder(root.Right, output);
		}

		public IList<T> GetInOrder()
		{
			var output = new List<T>();

			this.GetInOrder(this, output);

			return output;
		}

		private void GetInOrder(BinarySearchTree<T> root, List<T> result)
		{
			if (root == null)
			{
				return;
			}

			this.GetInOrder(root.Left, result);

			// visit
			result.Add(root.Value);

			this.GetInOrder(root.Right, result);
		}

		public IList<T> GetPostOrder()
		{
			var output = new List<T>();

			this.GetPostOrder(this, output);

			return output;
		}

		private void GetPostOrder(BinarySearchTree<T> root, List<T> result)
		{
			if (root == null)
			{
				return;
			}

			this.GetPostOrder(root.Left, result);
			this.GetPostOrder(root.Right, result);

			// visit
			result.Add(root.Value);
		}

		public void Insert(T newValue)
		{
			if (this.Value.CompareTo(newValue) == 0)
			{
				throw new ArgumentException($"{newValue} already exists");
			}

			if (this.Value.CompareTo(newValue) > 0)
			{
				if (this.Left == null)
				{
					this.Left = new BinarySearchTree<T>(newValue);
				}
				else
				{
					this.Left.Insert(newValue);
				}
			}


			if (this.Value.CompareTo(newValue) < 0)
			{
				if (this.Right == null)
				{
					this.Right = new BinarySearchTree<T>(newValue);
				}
				else
				{
					this.Right.Insert(newValue);
				}
			}
		}

		public bool Search(T value)
		{
			if (this.Value.CompareTo(value) == 0)
			{
				return true;
			}

			if (this.Left != null && this.Value.CompareTo(value) > 0)
			{
				return this.Left.Search(value);
			}

			if (this.Right != null && this.Value.CompareTo(value) < 0)
			{
				return this.Right.Search(value);
			}

			return false;
		}

		// Advanced task!
		public bool Remove(T value)
		{
			if (this.Value.CompareTo(value) == 0)
			{
				BinarySearchTree<T> leafToRemove;

				if (this.Left != null)
				{
					leafToRemove = this.Left.GetMaxValueNode();
				}
				else
				{
					leafToRemove = this.Right.GetMinValueNode();
				}

				this.Value = leafToRemove.Value;
				return this.RemoveLeaf(leafToRemove);
			}
			else if (this.Left != null && this.Value.CompareTo(value) > 0)
			{
				return this.Left.Remove(value);
			}
			else if (this.Right != null)
			{
				return this.Right.Remove(value);
			}
			else
			{
				return false;
			}
		}

		private bool RemoveLeaf(BinarySearchTree<T> leaf)
		{
			if (this.Left == leaf)
			{
				this.Left = null;
				return true;
			}
			else if (this.Right == leaf)
			{
				this.Right = null;
				return true;
			}
			else if (this.Left != null)
			{
				return this.Left.RemoveLeaf(leaf);
			}
			else if (this.Right != null)
			{
				return this.Right.RemoveLeaf(leaf);
			}
			else
			{
				return false;
			}
		}

		private BinarySearchTree<T> GetMinValueNode()
		{
			if (this.Left == null)
			{
				return this;
			}

			return this.Left.GetMinValueNode();
		}

		private BinarySearchTree<T> GetMaxValueNode()
		{
			if (this.Right == null)
			{
				return this;
			}

			return this.Right.GetMaxValueNode();
		}

		public override string ToString()
		{
			return this.Value.ToString();
		}
	}



	// Buddy Group Solution:
	/*public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable<T>
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
        public void Insert(T element) // if equal?
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
            if (this.left != null && element.CompareTo(this.GetRootValue()) == -1)
            {
                return this.left.Search(element);
            }
            else if (this.right != null && element.CompareTo(this.GetRootValue()) == 1)
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
    }*/
}
