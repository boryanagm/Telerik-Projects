using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] arr = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

        int index = int.Parse(Console.ReadLine());

        Console.WriteLine(IsTenTimesValue(arr, index).ToString().ToLower());
    }

    static bool IsTenTimesValue(int[] arr, int index)
    {
        if (index == arr.Length - 1)
        {
            return false;
        }

        if (arr[index] * 10 == arr[index + 1])
        {   
            return true;
        }
        else
        {
            return IsTenTimesValue(arr, index + 1);
        }
    }
}
