<img src="https://webassets.telerikacademy.com/images/default-source/logos/telerik-academy.svg)" alt="logo" width="300px" style="margin-top: 20px;"/>

# DSA Workshop (Binary Search Tree)

A binary search tree (BST), is a node-based data structure in which each node has **no more than two child nodes.** Each child must either be a leaf node or the root of another binary search tree. The left sub-tree contains only nodes with values less than the parent node; the right sub-tree contains only nodes with values greater than the parent node. 

## Binary search tree characteristics:

- The root is a special node with no parents;
- A leaf is a node with no child nodes;
- A tree is balanced when for each node X the difference in height of the left and the right sub-trees is <= 1
- Balanced tree is optimized for searching, inserting and deleting which are done with $`O(logn)`$;

### Common operations and their time complexities (in a balanced tree):

- Insert new node: $`O(logn)`$
- Search: $`O(logn)`$
- Remove a node: $`O(logn)`$

## Binary search tree example:

![picture](Images/bst.png)

## Binary search tree practical use-cases:

- Have a sorted list of values where you can quickly add elements and still have them sorted (Consider using an array for this purpose. You have very fast access to read random values, but if you want to add a new value, you have to find the place in the array where it belongs, shift everything over, and then insert the new value);
- Maintaining a dynamically changing dataset in sorted order, for some "sortable / comparable" type;
- Implementing sets & maps in core language libraries (HashSet/Dictionary in C#, TreeMap/TreeSet in Java);
- In implementing more complex structures such as Binary Heap / Trie;

## Task

Your task is to implement a binary search tree, using the skeleton provided.

### Before you begin:

- Get a better understanding of trees by playing around in [Visualgo](https://visualgo.net/en/bst);
- Draw a BST. Think about the algorithms to insert and find a node. What about deleting? How would you implement removing a node;

### Steps:

1. Implement all methods from the *IBinarySearchTree* interface.
2. Implement 2 constructors.
3. All tests should pass.

## Practice

- [Minimum Absolute Difference in BST](https://leetcode.com/problems/minimum-absolute-difference-in-bst/)  
- [Longest Univalue Path](https://leetcode.com/problems/longest-univalue-path/description/)  
- [Binary Tree Paths](https://leetcode.com/problems/binary-tree-paths/description/)  
- [More](https://leetcode.com/problemset/all/?search=bst)

### Advanced task

- Implement remove method. There are unit tests for it.
