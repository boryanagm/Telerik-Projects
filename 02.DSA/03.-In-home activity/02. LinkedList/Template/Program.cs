using System;
using System.Linq;

namespace DSA.Linear
{
    class Program
    {
        static void Main()
        {

            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            LinkedList<int> list = new LinkedList<int>(array);

            list.AddLast(4);

            foreach (int item in list)
            {
                Console.WriteLine(item);
            }

            int M = 3;
            int N = 2;

            ListNode<int> current = list.Head;

            while (current != null)
            {
                // 1. Skip M nodes
                for (int i = 1; i < M && current != null; i++)
                {
                    current = current.Next;
                }

                // 2. Break out of the loop if the end of the list has been reached
                if (current == null)
                {
                    break;
                }

                // 3. Delete N nodes
                for (int i = 1; i <= N && current != null; i++)
                {
                    list.RemoveAfter(current);
                }

                // 4. Update current for the next iteration
                current = current.Next;
            }

            foreach (int item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
