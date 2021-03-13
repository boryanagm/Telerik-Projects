using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {

    }

    static bool DetectCycle(LinkedListNode<int> head)
    {
        var slowRunner = head;
        var fastRunner = head;

        while (fastRunner != null && fastRunner.Next != null)
        {
            slowRunner = slowRunner.Next;
            fastRunner = fastRunner.Next.Next;

            if (fastRunner == slowRunner)
            {
                return true;
            }
        }

        return false;
    }
}
