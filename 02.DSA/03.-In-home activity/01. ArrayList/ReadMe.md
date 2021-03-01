<img src="https://webassets.telerikacademy.com/images/default-source/logos/telerik-academy.svg" alt="logo" width="300px" style="margin-top: 20px;"/>

## DSA - 01. ArrayList

### Definition

**`ArrayList<T>`** is a linear data structure that implements the abstract data srtucture **List** by using an **array**. 

### Operations

The operations that one may use with the ArrayList are:​

- `Add(item)`  →  appends given element at the end  →  **​O(1)**
- `[index]` →  get or set an element at the specified index  →  **​O(1)**
- `Insert(index, item)`  →  insert item at index  →  ​**​O(n)**
- `RemoveAt(index)`  →  removes the item at index  →  ​**​O(n)**
- `Count`  →  return the current number of items​  →  **​O(1)**


> Think why these operations have these complexities?

### Structure

1. A `ArrayList.cs` containing a _generic_ class `ArrayList<T>` has already been provided in the template.

2. Define the interface of your data structure. The supported operations should be:
   ```cs
   public class ArrayList<T>
   {
       public void Add(T value) 
       { 
       }
       
       public void Insert(int index, T value) 
       { 
       }
       
       public void RemoveAt(int index) 
       {
       }
       
       public T Get(int index) 
       {
       }
       
       public void Set(int index, T value) 
       {
       }
       
       public int Count
       {
           get;
       }
       
       public int Capacity
       {
           get;
       }
   }
   ```   

### Implementation

1. First create a private array field called **items** and a private integer field called **count**.
    ```cs
    private T[] items;
    private int count;
    ```

2. Instantiate the fields in the constructor.
    ```cs
    public ArrayList()
    {
        // 4 is a good number for an initial size
        this.items = new T[4];
        // set count to 0 since no items have been added yet
        this.count = 0;
    }
    ```

3. Expose `count` and `items.Length` through their respective properties - `Count` and `Capacity`. These properties will be used to determine whether the array (`items`) has to be resized.
    ```cs
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
    ```

4. When implementing the **Add** method we should always check if there is a free cell for the new item. If the array is full, we have to resize it before adding the new item.
    ```cs
    public void Add(T value)
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
            System.Array.Copy(this.items, newItems, this.Count);
        
            // Point to the new array
            this.items = newItems;
        }

        // Add the new item at the end
        this.items[this.count] = value;
        // Increase the total count of items
        this.count++;
    }
    ```

5. The **Insert** has similar to **Add** logic.
    ```cs
    public void Insert(int index, T item)
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
            System.Array.Copy(this.items, newItems, this.Count);
        
            // Point to the new array
            this.items = newItems;
        }

        // Shift cells to the right
        System.Array.Copy(this.items, index, this.items, index + 1, this.count - index);
        // Insert the item
        this.items[index] = item;
        // Increase the total count of items
        this.count++;
    }
    ```

6. As we can see, the Add and Insert methods use an idential code for checking if the array should be resized. You should always try to follow the **D**on't **R**epeat **Y**ourself (**DRY**) principle. In this case we can remain **DRY** by moving the repeated code in a new method called **EnsureCapacity**.
    ```cs
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
            System.Array.Copy(this.items, newItems, this.Count);

            // Point to the new array
            this.items = newItems;
        }
    }
    ```

7. Use the **EnsureCapacity** method in the **Add** and **Insert** methods.
    ```cs
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
        System.Array.Copy(this.items, index, this.items, index + 1, this.count - index);
        // Insert the item
        this.items[index] = item;
        // Increase the total count of items
        this.count++;
    }
    ```
   
8. Now let's see how to do item removal. Remember that we had to shift the cells to the _right_ when implementing the **Insert** method? Well, the **RemoveAt** method works in a similar way but it shifts the cells to the _left_.
    ```cs
    public void RemoveAt(int index)
    {
            this.count--;

            // Shift cells to the left
            System.Array.Copy(this.items, index + 1, this.items, index, this.count - index);

            // Clear the last cell
            this.items[this.count] = default;
    }
    ```

9. Use the array's indexer (`[]`) to get or set values at an index.
    ```cs
    public T Get(int index)
    {
        return this.items[index];
    }

    public void Set(int index, T value)
    {
        this.items[index] = value;
    }
    ```

Great! Our list is feature complete and fully functional! But is it _bulletproof_?

### Improvements

#### Validation
We have lots of operations that use the array's index - **Insert**, **RemoveAt**, **Get** and **Set**. Validating the index first will ensure we are always working with an index that's within range. So, add a private method that validates the index and use it in every method that relies on a valid index:
```cs
private void ValidateIndex(int index)
{
    if(index < 0 || index >= this.items.Length)
    {
        throw new System.ArgumentException($"Index {index} is out of range.");
    }
}
```
   
To get you started, this is how the Get and Set methods should look like.

```cs
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
```
    
Now if we have for example a list with 10 items and someone tries to get or set the 100th item, they will get nice and explanatory error.

#### Indexer
Another improvement is to add an _indexer_. Indexers are just a syntactic sugar that will enable the **Get** and **Set** methods of our list to be used in a more convenient way. For example, instead of getting an item like:
```cs
var item = list.Get(0);
```
We can do it with:
```cs
var element = list[0];
```
Setting an item at an index changes from:  
```cs
list.Set(0, 3);
```
To:  
```cs
list[0] = 3;
```
To enable such functionality in our list we can do the following:  
```cs
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
```

### Iteration
The final improvement is to make the list usable in a `foreach` loop. To enable enumeration we have to create a special method - `GetEnumerator()`.
```cs
public System.Collections.Generic.IEnumerator<T> GetEnumerator()
{
    for (int index = 0; index < this.count; index++)
    {
        yield return this.items[index];
    }
}
```

---

### Testing

Now you can test your code. Try different operations. Here's something to get you started.
```cs
static void Main()
{
    Console.WriteLine("Test Count and Capacity");
    var list = new ArrayList<int>();
    Console.WriteLine($"  ArrayList created, Count: {list.Count}, Capacity: {list.Capacity}");
    list.Add(12);
    Console.WriteLine($"  Add(12), Count: {list.Count}, Capacity: {list.Capacity}");
    list.Add(15);
    Console.WriteLine($"  Add(15), Count: {list.Count}, Capacity: {list.Capacity}");
    list.Add(17);
    Console.WriteLine($"  Add(17), Count: {list.Count}, Capacity: {list.Capacity}");
    list.Add(1);
    Console.WriteLine($"  Add(1), Count: {list.Count}, Capacity: {list.Capacity}");
    list.Add(10);
    Console.WriteLine($"  Add(10), Count: {list.Count}, Capacity: {list.Capacity}");
    list.Add(17);
    Console.WriteLine($"  Add(17), Count: {list.Count}, Capacity: {list.Capacity}");

    Console.WriteLine("Indexer test");
    Console.WriteLine($"  list[0] == 12? {list[0] == 12}");
    Console.WriteLine($"  list[1] == 15? {list[1] == 15}");
    Console.WriteLine($"  list[2] == 17? {list[2] == 17}");
    Console.WriteLine($"  list[3] == 1? {list[3] == 1}");
    Console.WriteLine($"  list[4] == 10? {list[4] == 10}");
    Console.WriteLine($"  list[5] == 17? {list[5] == 17}");

    Console.WriteLine("Iteration test");
    Console.WriteLine("  Using the list in foreach loop");
    foreach (var element in list)
        Console.WriteLine($"    Element: {element}");

    Console.WriteLine("  Using the list in FOR loop");
    for (int index = 0; index < list.Count; index++)
        Console.WriteLine($"    Index: {index}, Element: {list[index]}");
}
```
The expected console output is:
```
Test Count and Capacity
  ArrayList created, Count: 0, Capacity: 4
  Add(12), Count: 1, Capacity: 4
  Add(15), Count: 2, Capacity: 4
  Add(17), Count: 3, Capacity: 4
  Add(1), Count: 4, Capacity: 4
  Add(10), Count: 5, Capacity: 8
  Add(17), Count: 6, Capacity: 8
Indexer test
  list[0] == 12? True
  list[1] == 15? True
  list[2] == 17? True
  list[3] == 1? True
  list[4] == 10? True
  list[5] == 17? True
Iteration test
  Using the list in foreach loop
    Element: 12
    Element: 15
    Element: 17
    Element: 1
    Element: 10
    Element: 17
  Using the list in FOR loop
    Index: 0, Element: 12
    Index: 1, Element: 15
    Index: 2, Element: 17
    Index: 3, Element: 1
    Index: 4, Element: 10
    Index: 5, Element: 17
```

---

### Task

Find the biggest number in a list of integers and move it at the beginning of the list. Use the **ArrayList** that we've created.

Firs, you need to create a list with the following items.
```
12, 15, 17, 1, 10, 17
```

Then, using a loop, find the max element.
```cs
int max = int.MinValue;
int maxIndex = -1;

for (int index = 0; index < list.Count; index++)
{
    int current = list[index];

    if (current > max)
    {
        max = current;
        maxIndex = index;
    }
}
```

Now move the lement in front of the list. This are actually two operations:
   1. Remove the element at `maxIndex`
   2. Insert `max` at the beginning

```cs
list.RemoveAt(maxIndex);
list.Insert(0, max);
```

Print the elements in the list to check the result.
   
```cs
foreach (int element in list)
{
    Console.Write($" {element} ");
}
```

The expected result should be:
```
 17  12  15  1  10  17
```

### Conclusion

> What do you think is the complexity of finding this element? Why?

> What if you needed to remove all elements that have maximum value and keep only one in the head of the list? How you'd change the code to solve this task?

