<img src="https://webassets.telerikacademy.com/images/default-source/logos/telerik-academy.svg" alt="logo" width="300px" style="margin-top: 20px;"/>

## Workshop - Queue and Stack

### 1. Project information

1. Use the `Program.cs` file to quickly test some of your implementations. Don't be surprised that it's empty - it's up to you what you use it for.

1. `Run All Tests` whenever you are ready to test your implementation.

### 2. Description

The workshop has tests which cover the functionality of both Queue and Stack. Use them to track your progress.
The purpose of the workshop is for you to practice your ability to implement queue and stack using linked-list approach. This is a **common interview task**.

### 3. Goal

You must implement the most common methods which the Queue and Stack ADTs provide. You will accomplish this by using the `LinkedList<T>` class from the `System.Collections.Generic` namespace.

The `LinkedList<T>` provides all the necessary methods to accomplish the task, so study it carefully. You are **not allowed to use another backing structure.**.

> ADT - Abstract Data Type

### 4. Stack
#### Description
The stack is a very useful data structure, providing *last-in first-out* element access. It is most useful when an algorithm depends on such an access (such as DFS, Undo/Redo functionality, the browser history, the function call stack).
#### Task
Finish the Stack class by providing the following functionality:
- `Push()` - adds an element to the top of the stack
- `Pop()` - removes the element from the top of the stack
- `Peek()` - returns the value of the top element without removing it
- `Clear` - removes all the elements from the stack
- `Count` - returns the number of elements in the stack

Note that some of the required implementations are methods and others are properties. Do not change the names, because the unit tests depend on them.

### 5. Queue
#### Description
Similar to the stack, the queue is a very useful data structure providing *first-in first-out* element access. It is most useful when an algorithm depends on such an access (such as Scheduling and BFS).
#### Task
Finish the Queue class by providing the following functionality:
- `Enqueue()` - adds an element to the end of the queue
- `Dequeue()` - removes the element from the front of the queue
- `Peek()` - returns the value of the front element without removing it
- `Clear` - removes all the elements from the queue
- `Count` - returns the number of elements in the queue

Note that some of the required implementations are methods and others are properties. Do not change the names, because the unit tests depend on them.
