using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A Last In First Out (LIFO) collection implemented with a System.Collections.Generic.LinkedList<T>.
/// </summary>
public class Stack<T> : IEnumerable<T>
{
    private readonly LinkedList<T> list;

    public Stack()
    {
        this.list = new LinkedList<T>();
    }

    public void Push(T item)
    {
        list.AddFirst(item);
    }

    public T Pop()
    {
        if (this.list.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        var firstNode = this.list.First;

        this.list.RemoveFirst();

        return firstNode.Value;
    }

    public T Peek()
    {
        if (this.list.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        var firstNode = this.list.First;

        return firstNode.Value;
    }

    public void Clear()
    {
        this.list.Clear();
    }

    public int Count
    {
        get
        {
            return this.list.Count;
        }
    }

    // Enumerates each item in the stack in LIFO order. 
    public IEnumerator<T> GetEnumerator()
    {
        return this.list.GetEnumerator();
    }

    // Enumerates each item in the stack in LIFO order.
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.list.GetEnumerator();
    }
}
