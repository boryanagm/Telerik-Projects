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

        string[] names = Console.ReadLine().Split(' ');

        LinkedList<string> namesList = new LinkedList<string>(names);

        for (int i = 0; i < seatChangesCount; i++)
        {
            string[] namePairs = Console.ReadLine().Split(' ');

            string leftName = namePairs[0];
            string rightName = namePairs[1];
            
            namesList.Remove(leftName);

            namesList.AddBefore(namesList.Find(rightName), leftName);
        }

        Console.WriteLine(string.Join(" ", namesList));
    }
}

