using System;

public class LinkedList<T> : System.Collections.Generic.IEnumerable<T>
{
    private LinkedListNode<T> head;
    private LinkedListNode<T> tail;

    public LinkedList()
    {
        this.Head = null;
        this.Tail = null;

    }
    public LinkedListNode<T> Head
    {
        get
        {
            return head;
        }
        private set
        {
            this.head = value;
        }
    }

    public LinkedListNode<T> Tail
    {
        get
        {
            return tail;
        }
        private set
        {
            this.tail = value;
        }
    }

    public int Count
    {
        get
        {
            int counter = 0;

            if (this.Head == null)
            {
                return 0;
            }

            LinkedListNode<T> node = this.Head;

            while (node != null)
            {
                counter++;
                node = node.Next;
            }

            return counter;
        }
    }

    public void AddFirst(T value)
    {
        LinkedListNode<T> temp = new LinkedListNode<T>(value);

        temp.Previous = null;
        temp.Next = null;

        if (this.Head == null)
        {
            this.Head = temp;
            this.Tail = temp;
        }
        else
        {
            this.Head.Previous = temp;
            temp.Next = this.Head;
            this.Head = temp;
        }
    }

    public void AddLast(T value)
    {
        LinkedListNode<T> temp = new LinkedListNode<T>(value);

        if (this.Head == null)
        {
            this.Head = temp;
            this.Tail = temp;
        }
        else
        {
            LinkedListNode<T> current = this.Head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = temp;
            temp.Previous = current;
            this.Tail = temp;
        }
    }

    public void InsertBefore(LinkedListNode<T> node, T value)
    {
        LinkedListNode<T> current = this.Head;
        LinkedListNode<T> nodeToInsert = new LinkedListNode<T>(value);

        if (node.Value.Equals(current.Value))
        {
            this.Head.Previous = nodeToInsert;
            nodeToInsert.Next = this.Head;
            this.Head = nodeToInsert;
        }
        else
        {
            current = current.Next;

            while (!current.Value.Equals(node.Value))
            {
                current = current.Next;
            }

            LinkedListNode<T> previousNode = current.Previous;

            nodeToInsert.Next = current;
            current.Previous = nodeToInsert;
            previousNode.Next = nodeToInsert;
            nodeToInsert.Previous = previousNode;
        }
    }

    public void InsertAfter(LinkedListNode<T> node, T value)
    {
        LinkedListNode<T> current = this.Head;
        LinkedListNode<T> nodeToInsert = new LinkedListNode<T>(value);

        while (!current.Value.Equals(node.Value))
        {
            current = current.Next;
            if (current == null)
            {
                throw new ArgumentException();
            }
        }
        if (current == this.Tail)
        {
            current.Next = nodeToInsert;
            nodeToInsert.Next = null;
            nodeToInsert.Previous = current;

            this.Tail = nodeToInsert;
        }
        else
        {
            LinkedListNode<T> nodeAfter = current.Next;

            nodeToInsert.Next = nodeAfter;
            current.Next = nodeToInsert;
            nodeAfter.Previous = nodeToInsert;
            nodeToInsert.Next = nodeAfter;
        }
    }

    public bool Remove(T value)
    {
        var temp = this.Head;
        while (!temp.Value.Equals(value))
        {
            if (temp.Next == null)
            {
                return false;
            }
            temp = temp.Next;
        }

        if (temp.Previous == null)
        {
            if (this.Count == 1)
            {
                this.Tail = null;
                this.Head = null;
            }
            else
            {
                this.Head = temp.Next;
            }
        }
        else if (temp.Next == null)
        {
            this.Tail = temp.Previous;
            temp.Previous.Next = null;
        }
        else
        {
            temp.Next.Previous = temp.Previous;
            temp.Previous.Next = temp.Next;
        }

        temp = null;

        return true;
    }

    public void RemoveFirst()
    {
        if (this.Count <= 1)
        {
            this.Head = null;
            this.Tail = null;
        }
        else
        {
            var temp = this.Head;
            this.Head = this.Head.Next;
            temp = null;
            this.Head.Previous = null;
        }
    }

    public void RemoveLast()
    {
        if (this.Count <= 1)
        {
            this.Head = null;
            this.Tail = null;
        }
        else
        {
            var temp = this.Tail;
            this.Tail = this.Tail.Previous;
            temp = null;
            this.Tail.Next = null;
        }
    }

    public bool Contains(T value)
    {
        var temp = this.Head;

        while (temp != null)
        {
            if (temp.Value.Equals(value))
            {
                return true;
            }
            temp = temp.Next;
        }

        return false;
    }

    public LinkedListNode<T> Find(T value)
    {
        var temp = this.Head;

        while (temp != null)
        {
            if (temp.Value.Equals(value))
            {
                return temp;
            }
            temp = temp.Next;
        }

        return null;
    }

    public void Clear()
    {
        LinkedListNode<T> current = this.Head;

        while (this.Head != null)
        {
            current = this.Head;
            this.Head = this.Head.Next;
            current = null;
        }

        this.Tail = null;
    }

    // Enumerates over the linked list values from Head to Tail
    System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
    {
        LinkedListNode<T> current = this.Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    // Enumerates over the linked list values from Head to Tail
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return ((System.Collections.Generic.IEnumerable<T>)this).GetEnumerator();
    }
}