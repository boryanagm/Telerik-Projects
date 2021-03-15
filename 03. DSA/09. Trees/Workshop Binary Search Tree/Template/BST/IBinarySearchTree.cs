using System;
using System.Collections.Generic;

namespace BST
{
	public interface IBinarySearchTree<T> where T : IComparable<T>
    {
		int Height { get; }
		IList<T> GetBFS();
		IList<T> GetInOrder();
		IBinarySearchTree<T> GetLeftTree();
		IList<T> GetPostOrder();
		IList<T> GetPreOrder();
		IBinarySearchTree<T> GetRightTree();
		T GetRootValue();
		void Insert(T element);
		bool Search(T element);
		// Advanced task!
		bool Remove(T value);
	}
}
