using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    public static SortedSet<string> validCodes = new SortedSet<string>();

    static void Main()
    {
        string digitMsg = Console.ReadLine();
        string cipherMsg = Console.ReadLine();

        string digitPattern = @"([0-9]+)";
        string letterPattern = @"([A-Z]+)";

        string[] digitCodes = Regex.Matches(cipherMsg, digitPattern).Cast<Match>().Select(m => m.Value).ToArray();
        string[] letters = Regex.Matches(cipherMsg, letterPattern).Cast<Match>().Select(m => m.Value).ToArray();

        Dictionary<string, string> digitLetter = new Dictionary<string, string>();

        for (int i = 0; i < letters.Length; i++)
        {
            digitLetter[digitCodes[i]] = letters[i];
        }

        FindValidCodes(digitMsg, digitLetter, "");

        int validCombinationsCount = validCodes.Count;

        Console.WriteLine(validCombinationsCount); // It gave "time limit exceeded" when it was Console.WriteLine(validCodes.Count);

        if (validCodes.Count > 0)
        {
            Console.WriteLine(string.Join(Environment.NewLine, validCodes));
        }
    }

    static void FindValidCodes(string digitMsg, Dictionary<string, string> digitLetter, string message)
    {
        if (digitMsg.Length == 0)
        {
            validCodes.Add(message);
            return;
        }

        foreach (var kvp in digitLetter)
        {
            if (kvp.Key == digitMsg)
            {
                validCodes.Add(message + kvp.Value);
            }

            if (digitMsg.StartsWith(kvp.Key))
            {
                FindValidCodes(digitMsg.Substring(kvp.Key.Length), digitLetter, message + kvp.Value);
            }
        }
    }
}
