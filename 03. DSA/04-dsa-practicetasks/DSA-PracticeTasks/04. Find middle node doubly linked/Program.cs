using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        LinkedList<int> list = new LinkedList<int>();

        list.AddFirst(5);
        list.AddFirst(4);
        list.AddFirst(3);
        list.AddFirst(7);
        list.AddFirst(2);
        list.AddFirst(1);

        LinkedListNode<int> middleNode = list.First;
        LinkedListNode<int> evenNode = list.First;

        if (list.Count % 2 == 0)
        {
            while (evenNode.Next != null)
            {
                middleNode = middleNode.Next;
                evenNode = evenNode.Next.Next;
                if (evenNode.Next.Next == null)
                {
                    break;
                }
            }
        }
        else
        {
            while (evenNode.Next != null)
            {
                middleNode = middleNode.Next;
                evenNode = evenNode.Next.Next;
            }
        }

        Console.WriteLine(middleNode.Value);
        Console.WriteLine(string.Join(" ", list));
    }
}
