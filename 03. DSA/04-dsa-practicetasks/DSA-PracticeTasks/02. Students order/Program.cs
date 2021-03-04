using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        int[] studentsSeatsPair = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int studentsCount = studentsSeatsPair[0];
        int seatChangesCount = studentsSeatsPair[1];
       
        int temp = seatChangesCount;

        string[] names = Console.ReadLine().Split(' ');
       
        int extendedListCount = names.Length + (names.Length + 1) * seatChangesCount;

        List<string> extendedList = new List<string>(Enumerable.Repeat("=", extendedListCount)); //Or for loop to populate

        //List<string> extendedList = new List<string>(); 

        //for (int i = 0; i < extendedListCount; i++)
        //{
        //    extendedList.Add("=");
        //}

        for (int i = 0; i < names.Length; i++)
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
            int addCounter = 0;
            int operationCompleteCounter = 0;

            for (int j = 0; j < extendedList.Count; j++)
            {
                if (extendedList[j] == leftName && removeCounter == 0)
                {
                    extendedList[j] = "=";

                    removeCounter++;
                    operationCompleteCounter++;
                }
                else if (extendedList[j] == rightName && addCounter == 0)
                {
                    extendedList[j - 1] = leftName;
                 //   j--;

                    addCounter++;
                    operationCompleteCounter++;
                }

                if (operationCompleteCounter == 2)
                {
                    break;
                }
            }
        }

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < extendedList.Count; i++)
        {
           
            if (extendedList[i] != "=")
            {
                sb.Append(extendedList[i] + " ");
            }

        }

        //for (int i = 0; i < extendedList.Count; i++)
        //{
        //    if (extendedList[i] == "=")
        //    {
        //        extendedList.RemoveAt(i);
        //        i--;
        //    }

        //    //if (extendedList.Count == names.Count)
        //    //{
        //    //    break;
        //    //}
        //}

        //for (int i = 0; i < extendedList.Count; i++)
        //{
        //    if (extendedList[i] != "=")
        //    {
        //        Console.Write(extendedList[i] + " ");
        //    }
        //}
        Console.WriteLine(string.Join(" ", sb));
    }
}
