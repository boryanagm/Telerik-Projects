using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string[] inputNames = Console.ReadLine().Split();

        var names = new Dictionary<string, LinkedListNode<string>>();
        var linkedList = new LinkedList<string>();
        foreach (var name in inputNames)
        {
            names.Add(name, linkedList.AddLast(name));
        }

        var seats = new string[2];
        for (int i = 0; i < nums[1]; i++)
        {
            seats = Console.ReadLine().Split();
            linkedList.Remove(names[seats[0]]);
            linkedList.AddBefore(names[seats[1]], names[seats[0]]);
            //linkedList.AddBefore(names.GetValueOrDefault(seats[1]), names.GetValueOrDefault(seats[0]));
        }

        Console.WriteLine(string.Join(" ", linkedList));
    }
}

