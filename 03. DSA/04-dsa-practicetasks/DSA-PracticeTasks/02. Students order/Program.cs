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

        List<string> extendedList = new List<string>();

        int extendedListCount = names.Count * seatChangesCount + names.Count + seatChangesCount;

        int emptyCellsCounter = 0;
        int fullCellsCounter = seatChangesCount;

        int multiplier = 1;

        for (int i = 0; i < extendedListCount; i++)
        {
            if (i == fullCellsCounter)
            {
                extendedList.Add(names[i - multiplier * seatChangesCount]);

                fullCellsCounter += seatChangesCount + 1;
                multiplier++;
            }
            else
            {
                extendedList.Add("0");

                emptyCellsCounter++;
            }

            if (emptyCellsCounter == seatChangesCount)
            {
                emptyCellsCounter = 0;
            }
        }

        for (int i = 0; i < seatChangesCount; i++)
        {
            string[] namePairs = Console.ReadLine().Split(' ');

            string leftName = namePairs[0];
            string rightName = namePairs[1];

            int removeCounter = 0;

            for (int j = extendedList.Count - 1; j >= 0; j--)
            {
                if (extendedList[j] == leftName && removeCounter == 0)
                {
                    extendedList.RemoveAt(j);
                    removeCounter++;
                }
                else if (extendedList[j] == rightName)
                {
                    extendedList[j - 1] = leftName;
                    j--;

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
