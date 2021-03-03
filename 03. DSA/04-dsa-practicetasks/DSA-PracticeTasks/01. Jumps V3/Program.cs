using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int[] jumpLenghts = new int[n];

        int maxNum = int.MinValue;
        int maxJumps = 0;

        for (int i = n - 1; i >= 0; i--)
        {
            int currentJumps = 0;
            int currentNum = numbers[i];

            if (currentNum >= maxNum)
            {
                maxNum = currentNum;
                jumpLenghts[i] = 0;
                continue;
            }

            for (int j = i + 1; j < n; j++)
            {
                if (numbers[j] > currentNum)
                {
                    currentJumps = jumpLenghts[j] + 1;
                    break;
                }
            }

            if (currentJumps > maxJumps)
            {
                maxJumps = currentJumps;
            }

            jumpLenghts[i] = currentJumps;
        }

        Console.WriteLine(maxJumps);
        Console.WriteLine(string.Join(" ", jumpLenghts));
    }
}
