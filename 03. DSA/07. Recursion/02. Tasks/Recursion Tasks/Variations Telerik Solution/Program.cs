using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<string> variations = new List<string>();

    static void Main(string[] args)
    {
        int length = int.Parse(Console.ReadLine());

        List<char> symbols = Console.ReadLine().Split().Select(x => x[0]).ToList();

        symbols.Sort();

        char firstSymbol = symbols[0];
        char secondSymbol = symbols[1];

        GetVariations(firstSymbol, secondSymbol, length, "");

        Console.WriteLine(String.Join($"{Environment.NewLine}", variations));
    }

    static void GetVariations(char firstSymbol, char secondSymbol, int length, string current)
    {
        if (current.Length == length)
        {
            variations.Add(current);
            return;
        }

        GetVariations(firstSymbol, secondSymbol, length, current + firstSymbol);
        GetVariations(firstSymbol, secondSymbol, length, current + secondSymbol);
    }
}
