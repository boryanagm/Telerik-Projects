namespace DSA.Linear
{

    public class LinkedList<T> 
    {
        public ListNode<T> Head { get; private set; }

        public LinkedList()
        {
            this.Head = null;
        }

        public LinkedList(T[] array)
        {
            if (array == null)
            {
                throw new System.ArgumentException("Cannot create a list from a null array.");
            }

            for (int i = array.Length - 1; i >= 0; i--)
            {
                this.AddFirst(array[i]);
            }
        }

        public ListNode<T> AddFirst(T value)
        {
            ListNode<T> node = new ListNode<T>(value);

            node.Next = this.Head;
            this.Head = node;

            return node;
        }

        public T RemoveFirst()
        {
            if (this.Head == null)
            {
                throw new System.NullReferenceException("List is empty.");
            }

            T value = this.Head.Value;
            this.Head = this.Head.Next;

            return value;
        }

        public ListNode<T> AddAfter(ListNode<T> node, T value)
        {
            ListNode<T> newNode = new ListNode<T>(value);

            newNode.Next = node.Next;
            node.Next = newNode;

            return newNode;
        }

        public ListNode<T> AddLast(T value) 
        {
            ListNode<T> newNode = new ListNode<T>(value);

            if (this.Head == null)
            {
                this.Head = newNode;
            }

            ListNode<T> lastNode = this.Head;

            while (lastNode.Next != null)
            {
                lastNode = lastNode.Next;
            }

            lastNode.Next = newNode;
            
            return newNode;
        }

        public void RemoveAfter(ListNode<T> node)
        {
            if (node == null)
            {
                throw new System.NullReferenceException("Can't remove after a null node.");
            }

            if (node.Next != null)
            {
                node.Next = node.Next.Next;
            }
        }

        public ListNode<T> Find(T value)
        {
            ListNode<T> current = this.Head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }


        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            ListNode<T> current = this.Head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
    }
}
