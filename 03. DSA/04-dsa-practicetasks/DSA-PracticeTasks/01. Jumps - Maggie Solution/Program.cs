using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int[] myNumbers = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        int[] myResult = new int[number];
        var myNumsUnique = new HashSet<int>();
        for (int i = myNumbers.Length - 1; i >= 0; i--)
        {
            if (myNumsUnique.Any(x => x > myNumbers[i]))
            {
                for (int j = 0; j < myNumbers.Length; j++)
                {
                    if (myNumbers[j] > myNumbers[i])
                    {
                        myResult[i] = 1 + myResult[j];
                        break;
                    }
                }
            }
            myNumsUnique.Add(myNumbers[i]);
        }
    }
}
