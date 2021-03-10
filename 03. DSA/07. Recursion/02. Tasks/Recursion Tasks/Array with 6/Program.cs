using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] arr = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

        int index = int.Parse(Console.ReadLine());

        Console.WriteLine(FindSix(arr, index).ToString().ToLower());
    }

    static bool FindSix(int[] arr, int index)
    {
        if (index == arr.Length - 1)
        {
            if (arr[index] == 6)
            {
                return true;
            }
            return false;
        }

        if (arr[index] != 6)
        {
           return FindSix(arr, index + 1);
        }
        else
        {
            return true;
        }
    }
}
