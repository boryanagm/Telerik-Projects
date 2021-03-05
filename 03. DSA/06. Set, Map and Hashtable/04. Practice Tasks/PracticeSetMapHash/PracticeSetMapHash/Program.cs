using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        SortedDictionary<string, int> noahsArk = new SortedDictionary<string, int>();

        for (int i = 0; i < n; i++)
        {
            string specie = Console.ReadLine();

            if (!noahsArk.ContainsKey(specie))
            {
                noahsArk[specie] = 0;
            }

            noahsArk[specie]++;
        }

        string isEven = string.Empty;

        foreach (var kvp in noahsArk)
        {
            if (kvp.Value % 2 == 0)
            {
                isEven = "Yes";
            }
            else
            {
                isEven = "No";
            }

            Console.WriteLine($"{kvp.Key} {kvp.Value} {isEven}");
        }
    }
}
