using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] kn = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int k = kn[0];
        int n = kn[1];

        int[] sequence = new int[n];

        sequence[0] = k;
        int index = 1;
        int counter = 1;

        for (int i = 1; i <= n; i++)
        {
            if (index >= n)
            {
                break;
            }
            sequence[index] = sequence[index - counter] + 1;

            if (index + 1 >= n)
            {
                break;
            }
            sequence[index + 1] = 2 * sequence[index - counter] + 1;

            if (index + 2 >= n)
            {
                break;
            }
            sequence[index + 2] = sequence[index - counter] + 2;

            index += 3;
            counter += 2;
        }
       
        int result = sequence[n - 1];

        Console.WriteLine(result);
    }
}
