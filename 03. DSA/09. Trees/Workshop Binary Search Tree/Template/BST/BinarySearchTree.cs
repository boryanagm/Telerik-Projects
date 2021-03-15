using System;
using System.Collections.Generic;

namespace BST
{
	public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable<T>
	{
		private T value;
		private IBinarySearchTree<T> left;
		private IBinarySearchTree<T> right;

		public BinarySearchTree(T value)
		{
			this.value = value;
			this.left = null;
			this.right = null;
		}

		public int Height { get; }
		public IList<T> GetBFS()
		{
			throw new NotImplementedException();
		}
		public IList<T> GetInOrder()
		{
			throw new NotImplementedException();
		}
		public IBinarySearchTree<T> GetLeftTree()
		{
			return this.left;
		}
		public IList<T> GetPostOrder()
		{
			throw new NotImplementedException();
		}
		public IList<T> GetPreOrder()
		{
			throw new NotImplementedException();
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
			throw new NotImplementedException();
		}
		public bool Search(T element)
		{
			throw new NotImplementedException();
		}
		// Advanced task!
		public bool Remove(T value)
		{
			throw new NotImplementedException();
		}
	}
}
