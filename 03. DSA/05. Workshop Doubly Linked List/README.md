<img src="https://webassets.telerikacademy.com/images/default-source/logos/telerik-academy.svg" alt="logo" width="300px" style="margin-top: 20px;"/>

## Workshop - Doubly Linked List

### 1. Project information

1. Use the `Program.cs` file to quickly test some of your implementations. Don't be surprised that it's empty - it's up to you what you use it for.

1. `Run All Tests` whenever you are ready to test your implementation.

### 2. Description

The workshop has tests which cover the implementation of a DoublyLinkedList.
In most programming interviews, linked list themed tasks are given in order to test the ability of the candidate to **maintain and update references**. The LinkedList methods `add/insert` and `remove` are excellent tasks to practice your skills with references.

### 3. Goal

You must implement the most commonly used methods of the DoublyLinkedList data structure.

The `LinkedListNode` class is already provided. Study it carefully. You are **not allowed to modify it**.

### 4. DoublyLinkedList
#### Description
The DoublyLinkedList is a very useful data structure providing very fast insertion and removals at the cost of random access. They are useful for implementing features such as browser history and text editors.

#### Task
Finish the DoublyLinkedList class by providing the following functionality:
- `AddFirst(value)` - adds an element to the head of the list
- `AddLast(value)` - adds an element to the tail of the list
- `InsertBefore(node, value)` - insert an element with the given value before the given node
- `InsertAfter(node, value)` - insert an element with the given value after the given node
- `RemoveFirst()` - removes the first node and returns its value
- `RemoveLast()` - removes the last node and returns its value
- `Remove(value)` - removes the first occurrence of the specified value from the list
- `Contains(value)` - determines whether a value exists in the list. Returns true if the value is found; otherwise false
- `Find(value)` - returns the first node that has the given value or `null` if no such value exists
- `Clear()` - removes all nodes from the list
- `Head` - reference to the head node
- `Tail` - reference to the tail node
- `Count` - returns the number of nodes

Note that some of the required implementations are methods and others are properties. Do not change the names, because the unit tests depend on them.
