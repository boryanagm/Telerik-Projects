using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<string> openingList = new List<string>();

        List<string> closingList = new List<string>();

        List<int> nestingLevels = new List<int>();

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            nestingLevels.Add(int.Parse(input[1].ToString()));

            openingList.Add("<" + input + ">");
            closingList.Add("<" + "/" + input + ">");
        }

        List<string> collectionToPrint = new List<string> { openingList[0] };

        int current = nestingLevels[0]; // 1 2 3 3 2 3 2 1 2

        for (int i = 1; i < n; i++)
        {

            if (nestingLevels[i] > current)
            {
                collectionToPrint.Add(" " + openingList[i]);
                collectionToPrint.Add(" " + closingList[i]);


              //  current = nestingLevels[i];
            }
            else
            {
                collectionToPrint.Add(closingList[0]);

                collectionToPrint.Add(openingList[i]);
                collectionToPrint.Add(closingList[i]);
            }
        }

        Console.WriteLine(string.Join(Environment.NewLine, collectionToPrint));
    }
}
