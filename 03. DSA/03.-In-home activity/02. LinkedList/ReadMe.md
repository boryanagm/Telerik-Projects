<img src="https://webassets.telerikacademy.com/images/default-source/logos/telerik-academy.svg" alt="logo" width="300px" style="margin-top: 20px;"/>

## DSA - 02. Linked List

### Definition

**Linked List** is a linear data structure that implements the abstract data structure **List** **dynamically**. While using an array defines that elements of the Array List are stored sequentially in memory, Linked List's items are not.

The main idea is that each element knows what is / are its neighbours. There are two possible implementations:
- Singly linked list - each element knows what is the next one
- Doubly linked list - each element knows what are the next and the previous ones

### Singly Linked List

We will work today with a **singly-linked-list ​with only a head reference**. ​

### Operations

The operations that one may use with the Linked List are:​

- `AddFirst(value)`  →  adds a new node containing the specified value at the start of the list​  →  **​O(1)**
- `RemoveFirst()` →  removes the node at the start of the list​  →  **​O(1)**
- `AddAfter(node, value)`  →  adds a new node containing the specified value after the specified existing node in the list  →  ​**​O(1)**
- `RemoveAfter(node) `  →  removes the node after the specified existing node in the list  →  ​**​O(1)**
- `Find(value)`  →  finds and returns the first node that contains the specified value  →  **​O(n)**

*Note:* the functions and their complexity assume a singly-linked-list ​with only a head reference.

> Think why these operations have these complexities?

### Implementation

Now let's implement our own Singly Linked List.

1. In **ListNode.cs** add a _generic_ class **ListNode**. We will use this class to represent **singly linked node**. This class will represent our list's elements. Each element has a value and knows what is the next element.
   
    ```cs
    public class ListNode<T>
    {
        public ListNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public ListNode<T> Next { get; set; }
    }
    ```

2. In **LinkedList.cs** add a _generic_ class **LinkedList**
3. Add a property called **Head** and give it a public getter and private setter.

    ```cs
    public class LinkedList<T>
    {
      public ListNode<T> Head 
      { 
          get; 
          private set; 
      }
    }
    ```

3. Define the interface of your data structure. It should support all the operations mentioned above:

    ```cs   
    public class LinkedList<T>
    {
        public ListNode<T> Head
        {
            get; 
            private set;
        }

        public ListNode<T> AddFirst(T value)
        {
        }

        public T RemoveFirst()
        {
        }

        public ListNode<T> AddAfter(ListNode<T> node, T value)
        {
        }

        public void RemoveAfter(ListNode<T> node)
        {
        }

        public ListNode<T> Find(T value)
        {
        }
    }
    ```

4. Now let's implement them one by one
   1. The `AddFirst` method creates a node and prepends it at the beginning of the list. Also changes the head to be the new first element.
   
      ```cs 
      public ListNode<T> AddFirst(T value)
      {
          ListNode<T> node = new ListNode<T>(value);
          node.Next = this.Head;
          this.Head = node;
          return node;
      }
      ```

   2. To remove the first node, we need to make the second node **Head** and delete the memory allocated for the first node. Actually, we do not have to take care of the deletion - as soon as no references exist to the "old" first element, it will be automatically scraped by the Garbage Collector.
   
      > Don't forget to make sure you are not removing an item from an empty list!

      ```cs
      public T RemoveFirst()
      {
          if (this.Head == null)
              throw new System.NullReferenceException("List is empty.");

          T value = this.Head.Value;
          this.Head = this.Head.Next;

          return value;
      }
      ```

      > Will this method work if we have only one element? Why?

   3. Now for the `AddAfter` method we are given pointer to a node, and the new node is inserted after the given node:

        ```cs
        public ListNode<T> AddAfter(ListNode<T> node, T value)
        {
            ListNode<T> newNode = new ListNode<T>(value);
            newNode.Next = node.Next;
            node.Next = newNode;

            return newNode;
        }
        ```

        > Think about implementing a method that adds a new node at the end of the list - `AddLast(value)`. What would be the complexity?

   4. Our singly linked list nodes do not store the reference to the previous node and only have a pointer for the next node. To delete a node we need to know the address of the previous node of the actual node we want to delete so that we can keep the linked list connected after deletion of a node. This is what `RemoveAfter` method should do.


        > Make sure you are not trying to remove **after** the last element!

        ```cs
        public void RemoveAfter(ListNode<T> node)
        {
            if(node == null)
                throw new System.NullReferenceException("Can't remove after a null node.");

            if (node.Next != null)
            {
                node.Next = node.Next.Next;
            }
        }
        ```

      > In some implementations singly linked lists keep track of the last node (**Tail**) as well. Do you think having a **Tail** node would be useful when implementing the `RemoveAfter` method?

   5. To implement the `Find` method we would have be able to walk through the nodes in the list. To do that we can start at the **Head** of the list and use each node's **Next** until we either find a node with matching value or reach the end of the list. 

      ```cs
      public ListNode<T> Find(T value)
      {
          ListNode<T> current = this.Head;
          while(current != null)
          {
              if(current.Value.Equals(value))
              {
                  return current;
              }
              current = current.Next;
          }
          return null;
      }
      ```
      
      > Do you think the above changes the reference to the **Head**?

   6. Great! What remains is to allow our list to be enumerated using a `foreach` loop. We can do that by implementing a special method called `GetEnumerator()`.
      
       ```cs
       public System.Collections.Generic.IEnumerator<T> GetEnumerator()
       {
           ListNode<T> current = this.Head;
           while (current != null)
           {
               yield return current.Value;
               current = current.Next;
           }
       }
       ```

     Now our lst is **iterable**.

### Testing

Now you can test out your code. Try different operations and make sure your implementation works as the abstract data type should.

```cs
static void Main()
{
    LinkedList<int> list = new LinkedList<int>();

    list.AddFirst(4);
    list.AddFirst(3);
    list.AddFirst(2);
    list.AddFirst(1);

    foreach (int item in list)
        Console.WriteLine(item);

    Console.WriteLine("Remove after 2");

    ListNode<int> nodeToRemoveAfter = list.Find(2);
    list.RemoveAfter(nodeToRemoveAfter);

    foreach (int item in list)
        Console.WriteLine(item);
}
```

The result on the console should be:
```
1
2
3
4
Remove after 2
1
2
4
```

It's a bit tedious to add elements one by one. Perhaps we can add a constructor that accepts an array (`T[]`) as an input parameter.

> How would you go about implementing it? Remember, the only available method for adding elements is `AddFirst()`.

Is your implementation similar to this:

```cs
// constructor
public LinkedList(T[] array)
{
    if (array == null)
    {
        throw new System.ArgumentNullException("Can't create a list from a null array.");
    }

    for (int i = array.Length - 1; i >= 0; i--)
    {
        this.AddFirst(array[i]);
    }
}
```

---

### Task

**Delete `N` nodes after `M` nodes of a linked list**

You are given a linked list and two integers `M` and `N`.  
Your task is to traverse the list by first skipping `M` nodes then deleting `N` nodes. You have to repeat this pattern until the end of the list.

Example:
```
Input:
Linked List: 1->2->3->4->5->6->7->8
M = 2, N = 2

Output:
Linked List: 1->2->5->6
```

1. Start by constructing the linked list by using the previously created constructor overload. Also, create two fields for `M` and `N`.

    ```cs
    int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
    LinkedList<int> list = new LinkedList<int>(array);
    int M = 2;
    int N = 2;
    ```

2. Create a variable that points to the **Head** of the list and use it to iterate through the list.
    ```cs
    ListNode<int> current = list.Head;

    while (current != null)
    {
    }
    ```

3. Now, it's inside the `while` loop where it gets interesting. We can break the body of the loop into 4 parts.
    ```cs
    while (current != null)
    {
        // 1. Skip M nodes
        // 2. Break out of the loop if the end of the list has been reached
        // 3. Delete N nodes
        // 4. Update current for the next iteration
    }
    ```

4. Translating the above into code gives us:
    ```cs
    while (current != null)
    {
        // 1. Skip M nodes
        for (int count = 1; count < M && current != null; count++)
        {
            current = current.Next;
        }
        
        // 2. Break out of the loop if the end of the list has been reached
        if (current == null)
        {
            break;
        }
          
        // 3. Delete N nodes
        for (int count = 1; count <= N && current.Next != null; count++)
        {
            list.RemoveAfter(current);
        }
          
        // 4. Update current for the next iteration
        current = current.Next;
    }
    ```

5. Print the contents of the list and check the result.
    ```cs
    foreach (int item in list)
    {
        Console.WriteLine(item);
    }
    ```

    Should be 
    ```
    1
    2
    5
    6
    ```

6. Here are couple more examples to test your solution.
    ```
    Input:
    Linked List: 1->2->3->4->5->6->7->8->9->10
    M = 3, N = 2

    Output:
    Linked List: 1->2->3->6->7->8
    ```
    ```
    Input:
    Linked List: 1->2->3->4->5->6->7->8->9->10
    M = 1, N = 1

    Output:
    Linked List: 1->3->5->7->9
    ```

### Conclusion

> What are the main differences between a `LinkedList<T>` and `List<T>`?

> Which data structure would you use if you have to frequently add or remove elements? Why?

> Which data structure would you use if you need frequent access to its elements, but would rarely have to modify them? Why?