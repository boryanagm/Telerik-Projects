using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    public static List<List<int>> possibleDigitCombinations = new List<List<int>>();
    public static List<List<int>> validCodes = new List<List<int>>();

    static void Main()
    {
        Dictionary<int, string> digitLetter = new Dictionary<int, string>();

        string digitMsg = Console.ReadLine();
        string cipherMsg = Console.ReadLine();

        string pattern = @"([0-9]+)";
        MatchCollection matches = Regex.Matches(cipherMsg, pattern);

        List<int> digitCodes = new List<int>();

        foreach (Match match in matches)
        {
            digitCodes.Add(int.Parse(match.Value));
        }

        string letterPattern = @"([A-Z]+)";
        MatchCollection matches2 = Regex.Matches(cipherMsg, letterPattern);

        List<string> letters = new List<string>();

        foreach (Match match in matches2)
        {
            letters.Add(match.Value);
        }

        for (int i = 0; i < letters.Count; i++)
        {
            digitLetter[digitCodes[i]] = letters[i];
        }

        List<int> currentPart = new List<int>();

        FindDigitCombination(0, digitMsg.Length, digitMsg, currentPart);

        FindValidCombinations(digitCodes);

        Console.WriteLine(validCodes.Count);

        SortedSet<string> printResult = new SortedSet<string>();

        if (validCodes.Count > 0)
        {
            for (int i = 0; i < validCodes.Count; i++)
            {
                StringBuilder sb = new StringBuilder();

                for (int j = 0; j < validCodes[i].Count; j++)
                {
                    sb.Append(digitLetter[validCodes[i][j]]);
                }
                printResult.Add(sb.ToString());
            }
            Console.WriteLine(string.Join(Environment.NewLine, printResult));

        }

        // Console.WriteLine(string.Join(Environment.NewLine, printResult));
    }

    static void FindValidCombinations(List<int> digitCodes)
    {
        for (int j = 0; j < possibleDigitCombinations.Count; j++)
        {
            bool isValid = true;

            for (int i = 0; i < possibleDigitCombinations[j].Count; i++)
            {
                if (!digitCodes.Contains(possibleDigitCombinations[j][i]))
                {
                    isValid = false;
                    break;
                }
            }
            if (isValid == true)
            {
                validCodes.Add(possibleDigitCombinations[j]);
            }
        }
    }


    static void FindDigitCombination(int start, int n, string digitMsg, List<int> currentPart)
    {
        if (start >= n)
        {
            possibleDigitCombinations.Add(new List<int>(currentPart));
            return;
        }

        for (int i = start; i < n; i++)
        {
            // Add the substring to result
            currentPart.Add(int.Parse(digitMsg.Substring(start, i + 1 - start)));

            // Recur for remaining substring
            FindDigitCombination(i + 1, n, digitMsg, currentPart);

            // Remove substring str[start..i] from current 
            // partition 
            currentPart.RemoveAt(currentPart.Count - 1);
        }
    }
}
