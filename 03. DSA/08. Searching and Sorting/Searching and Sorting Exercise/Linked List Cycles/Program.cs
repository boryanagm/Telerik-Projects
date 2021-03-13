using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {

    }

    static bool DetectCycle(LinkedListNode<int> head)
    {
        var nodesValues = new HashSet<LinkedListNode<int>>();

        while (head != null)
        {
            if (nodesValues.Contains(head))
            {
                return true;
            }

            nodesValues.Add(head);
            head = head.Next;
        }

        return false;
    }
}
