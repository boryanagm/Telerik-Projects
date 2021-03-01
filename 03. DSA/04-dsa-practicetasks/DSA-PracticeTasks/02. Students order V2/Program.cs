using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] studentsSeatsPair = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int studentsCount = studentsSeatsPair[0];
        int seatChangesCount = studentsSeatsPair[1];

        List<string> names = Console.ReadLine().Split(' ').ToList();

        Dictionary<string, string> namePairs = new Dictionary<string, string>();

        for (int i = 0; i < seatChangesCount; i++)
        {
            string[] namesToSwitch = Console.ReadLine().Split(' ');

            namePairs[namesToSwitch[0]] = namesToSwitch[1];
        }

        for (int i = 0; i < names.Count; i++)
        {
            
        }
    }
}
