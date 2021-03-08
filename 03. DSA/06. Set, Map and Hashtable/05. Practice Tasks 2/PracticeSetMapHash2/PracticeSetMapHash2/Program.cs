using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        SortedDictionary<int, int> lowerCase = new SortedDictionary<int, int>();
        SortedDictionary<int, int> upperCase = new SortedDictionary<int, int>();
        SortedDictionary<int, int> symbols = new SortedDictionary<int, int>();

        char lower = '-';
        char upper = '-';
        char symbol = '-';

        int lowerCount = 0;
        int upperCount = 0;
        int symbolCount = 0;

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsLower(input[i]))
            {
                if (!lowerCase.ContainsKey(input[i]))
                {
                    lowerCase[input[i]] = 0;
                }

                lowerCase[input[i]]++;
            }
            else if (char.IsUpper(input[i]))
            {
                if (!upperCase.ContainsKey(input[i]))
                {
                    upperCase[input[i]] = 0;
                }

                upperCase[input[i]]++;
            }
            else
            {
                if (!symbols.ContainsKey(input[i]))
                {
                    symbols[input[i]] = 0;
                }

                symbols[input[i]]++;
            }
        }

        foreach (var kvp in symbols)
        {
            if (kvp.Value > symbolCount)
            {
                symbolCount = kvp.Value;
                symbol = (char)kvp.Key;
            }
        }
        sb.AppendLine(AppendString(symbol, symbolCount));

        foreach (var kvp in lowerCase)
        {
            if (kvp.Value > lowerCount)
            {
                lowerCount = kvp.Value;
                lower = (char)kvp.Key;
            }
        }
        sb.AppendLine(AppendString(lower, lowerCount));
        
        foreach (var kvp in upperCase)
        {
            if (kvp.Value > upperCount)
            {
                upperCount = kvp.Value;
                upper = (char)kvp.Key;
            }
        }
        sb.AppendLine(AppendString(upper, upperCount));

        Console.WriteLine(sb);
    }

    public static string AppendString(char c, int count)
    {
        if (count == 0)
        {
           return $"{c}";
        }
        else
        {
           return $"{c} {count}";
        }
    }
}
