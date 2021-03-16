using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] nk = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int lastNum = nk[0];
        int shuffleCounter = nk[1];

        //  int[] allNums = new int[lastNum];
        SortedDictionary<int, int> dict = new SortedDictionary<int, int>();

        for (int i = 1; i <= lastNum; i++)
        {
            // allNums[i - 1] = i;
            dict[i] = i - 1;
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            int currentNum = numbers[i];

            if (currentNum % 2 == 0)
            {
                int temp = currentNum / 2;

                int value = dict[temp + 1];
                dict[temp + 1] = dict[currentNum];
                dict[currentNum] = value;
            }
            else
            {
                int temp = currentNum * 2;

                if (temp > lastNum)
                {
                    temp = lastNum;
                }

                if (!dict.ContainsKey(temp + 1))
                {
                    int value = dict[currentNum];

                    dict[currentNum] = dict[temp];
                    dict[temp] = value;
                    
                }
                else
                {
                    int value = dict[temp + 1];

                    dict[currentNum] = dict[temp + 1];
                    dict[temp + 1] = value;
                }
            }
        }

        var orderedDict = dict.OrderBy(x => x.Value);

        foreach (var kvp in orderedDict)
        {
            Console.Write(kvp.Key + " ");
        }
    }
}
