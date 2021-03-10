using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] arr = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

        int index = int.Parse(Console.ReadLine());

        Console.WriteLine(CountElevens(arr, index));
    }

    static int CountElevens(int[] arr, int index)
    {
        if (index == arr.Length) 
        {
            return 0;
        }

        if (arr[index] == 11)
        {
            return CountElevens(arr, index + 1) + 1;
        }
        else
        {
            return CountElevens(arr, index + 1);
        }
    }
}
