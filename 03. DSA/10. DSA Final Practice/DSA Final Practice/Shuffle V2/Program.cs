using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] nk = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int maxNum = nk[0];
        int shuffleCounter = nk[1];

        int[] allNums = new int[maxNum];

        for (int i = 1; i <= maxNum; i++)
        {
            allNums[i - 1] = i;
        }

        var nums = new Dictionary<int, LinkedListNode<int>>();

        var linkedList = new LinkedList<int>();
        foreach (var number in allNums)
        {
            nums.Add(number, linkedList.AddLast(number));
        }

        int numToMoveAfter = -1;
        for (int i = 0; i < shuffleCounter; i++)
        {
            int numToMove = numbers[i];

            if (numToMove % 2 == 0)
            {
                numToMoveAfter = numToMove / 2;
            }
            else
            {
                numToMoveAfter = numToMove * 2;

                if (numToMoveAfter > maxNum)
                {
                    numToMoveAfter = maxNum;
                }

                if (numToMoveAfter == numToMove)
                {
                    continue;
                }
            }

            linkedList.Remove(nums[numbers[i]]);
            linkedList.AddAfter(nums[numToMoveAfter], nums[numbers[i]]);
        }
        Console.WriteLine(string.Join(" ", linkedList));
    }
}
