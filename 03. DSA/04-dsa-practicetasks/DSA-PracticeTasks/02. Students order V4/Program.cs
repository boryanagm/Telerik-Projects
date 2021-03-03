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
        int temp = seatChangesCount;

        List<string> names = Console.ReadLine().Split(' ').ToList();

        int extendedListCount = names.Count * seatChangesCount + names.Count + seatChangesCount;

        List<string> extendedList = new List<string>(Enumerable.Repeat("0", extendedListCount)); 

        for (int i = 0; i < names.Count; i++)
        {
            extendedList[i + temp] = names[i];
            temp += seatChangesCount;
        }

        for (int i = 0; i < seatChangesCount; i++)
        {
            string[] namePairs = Console.ReadLine().Split(' ');

            string leftName = namePairs[0];
            string rightName = namePairs[1];

            int removeCounter = 0;
            int operationCompleteCounter = 0;

            for (int j = extendedList.Count - 1; j >= 0; j--)
            {
                if (extendedList[j] == leftName && removeCounter == 0)
                {
                    extendedList[j] = "0";

                    removeCounter++;
                    operationCompleteCounter++;
                }
                else if (extendedList[j] == rightName)
                {
                    extendedList[j - 1] = leftName;
                    j--;

                    operationCompleteCounter++;
                }

                if (operationCompleteCounter == 2)
                {
                    break;
                }
            }
        }

        for (int i = 0; i < extendedList.Count; i++)
        {
            if (extendedList[i] == "0")
            {
                extendedList.RemoveAt(i);
                i--;
            }
        }
        Console.WriteLine(string.Join(" ", extendedList));
    }
}
