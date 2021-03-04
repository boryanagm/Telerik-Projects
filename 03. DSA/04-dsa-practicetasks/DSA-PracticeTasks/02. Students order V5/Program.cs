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

        Dictionary<string, int> namesIndexes = new Dictionary<string, int>();

        for (int i = 0; i < studentsCount; i++)
        {
            namesIndexes[names[i]] = i + 1;
        }

        List<string> namesList = new List<string>(6);
        namesList.Add(null);

        for (int i = 1; i < names.Length + 1; i++)
        {
            namesList.Add(names[i - 1]);
        }

        for (int i = 0; i < seatChangesCount; i++)
        {
            string[] namePairs = Console.ReadLine().Split(' ');

            string leftName = namePairs[0];
            string rightName = namePairs[1];

            int insertAt = namesIndexes[rightName] - 1;
            // namesList[namesIndexes[leftName]] = null;
            namesList.RemoveAt(namesIndexes[leftName]);
            namesList.Insert(insertAt, leftName);


            // move names to the right
            for (int j = namesList.Count - 1; j >= 0; j--)
            {
                if (namesList[0] == null)
                {
                    break;
                }
                if (namesList[j] == null && j > 0)
                {
                    namesList[j] = namesList[j - 1];
                    namesList[j - 1] = null;
                }
            }

            // change indexes in dictionary
            for (int k = 1; k < namesList.Count; k++)
            {
                namesIndexes[namesList[k]] = k;
            }

        }

        namesList.RemoveAt(0);

        Console.WriteLine(string.Join(" ", namesList));
    }
}

