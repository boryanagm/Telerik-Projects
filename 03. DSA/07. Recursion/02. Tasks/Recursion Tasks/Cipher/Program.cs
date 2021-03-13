using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    public static List<List<string>> possibleDigitCombinations = new List<List<string>>();
    public static SortedSet<string> validCodes = new SortedSet<string>();

    static void Main()
    {
        Dictionary<string, string> digitLetter = new Dictionary<string, string>();

        string digitMsg = Console.ReadLine();
        string cipherMsg = Console.ReadLine();

        string pattern = @"([0-9]+)";
        MatchCollection matches = Regex.Matches(cipherMsg, pattern);

        List<string> digitCodes = new List<string>();

        foreach (Match match in matches)
        {
            digitCodes.Add(match.Value);
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

        List<string> currentPart = new List<string>();

        FindDigitCombination(0, digitMsg.Length, digitMsg, currentPart);

        FindValidCombinations(digitCodes);

        Console.WriteLine(validCodes.Count);

        SortedSet<string> printResult = new SortedSet<string>();

        if (validCodes.Count > 0)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in validCodes)
            {
                var itemAsArr = item.Split(' ');

                for (int j = 0; j < itemAsArr.Length; j++)
                {
                    sb.Append(digitLetter[itemAsArr[j]]);
                }
                printResult.Add(sb.ToString());
                sb.Clear();
            }
            
            Console.WriteLine(string.Join(Environment.NewLine, printResult));
        }
    }

    static void FindValidCombinations(List<string> digitCodes)
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
                validCodes.Add(string.Join(" ", possibleDigitCombinations[j]));
            }
        }
    }


    static void FindDigitCombination(int start, int n, string digitMsg, List<string> currentPart)
    {
        if (start >= n)
        {
            possibleDigitCombinations.Add(new List<string>(currentPart));
            return;
        }

        for (int i = start; i < n; i++)
        {
            // Add the substring to result
            currentPart.Add(digitMsg.Substring(start, i + 1 - start));

            // Recur for remaining substring
            FindDigitCombination(i + 1, n, digitMsg, currentPart);

            // Remove substring str[start..i] from current 
            // partition 
            currentPart.RemoveAt(currentPart.Count - 1);
        }
    }

}
