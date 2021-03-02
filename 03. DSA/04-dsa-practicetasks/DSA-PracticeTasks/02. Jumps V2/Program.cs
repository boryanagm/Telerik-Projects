using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        List<int> jumpLenghts = new List<int>();

        Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();

        List<int> numbersToList = numbers.ToList();

        for (int i = 0; i < numbers.Length; i++)
        {
            dict.Add(numbersToList.Count, numbersToList);
        }

        //int currentNum = numbers[1];

        for (int i = 0; i < numbers.Length; i++)
        {
            int currentNum = numbers[i];

            //if (currentNum > dict.Keys[])
            //{

            //}
        }








        for (int i = 0; i < numbers.Length; i++)
        {
            int jumpsCounter = 0;

            int previousNum = numbers[i];

            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[j] > previousNum)
                {
                    jumpsCounter++;

                    previousNum = numbers[j];
                }
            }

            jumpLenghts.Add(jumpsCounter);
        }

        int maxJumpsLength = jumpLenghts.Max();

        Console.WriteLine(maxJumpsLength);

        Console.WriteLine(string.Join(" ", jumpLenghts));
    }
}
