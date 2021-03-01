using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A First In First Out (FIFO) collection implemented with a System.Collections.Generic.LinkedList<T>.
/// </summary>
public class Queue<T> : IEnumerable<T>
{
    private readonly LinkedList<T> list;

    public Queue()
    {
        this.list = new LinkedList<T>();
    }

    public void Enqueue(T item)
    {
        this.list.AddLast(item);
    }

    public T Dequeue()
    {
        if (this.list.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        var firstNode = this.list.First;

        this.list.RemoveFirst();

        return firstNode.Value;
    }

    public T Peek()
    {
        if (this.list.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
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

    // Enumerates each item in the stack in FIFO order. 
    public IEnumerator<T> GetEnumerator()
    {
        return this.list.GetEnumerator();
    }

    // Enumerates each item in the stack in FIFO order. 
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.list.GetEnumerator();
    }
}