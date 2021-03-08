using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string first =  "look for repeating strings in this sentence" ;
        string second =  "look for strings" ;

        string[] arr = second.Split(' ');

        for (int i = 0; i < arr.Length; i++)
        {
            if (!first.Contains(arr[i]))
            {
                Console.WriteLine("No");
                return;
            }

            first = first.Replace(arr[i], " "); // will remove all the occurencies
        }

        Console.WriteLine("Yes");
    }
}
