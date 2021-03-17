using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        int numberOfSuggestions = int.Parse(Console.ReadLine());
        var output = new StringBuilder();

        for (int i = 0; i < numberOfSuggestions; i++)
        {
            var solutions = new HashSet<string>();

            var words = Console.ReadLine().Split(' ');
            var setWords = new HashSet<string>(words);

            string slogan = Console.ReadLine();

            ReadSlogan(slogan, setWords, "", solutions);

            if (solutions.Count == 0)
            {
                output.AppendLine("NOT VALID");
            }
            else
            {
                output.AppendLine(string.Join(" ", solutions));
            }
        }

        Console.WriteLine(output.ToString());
    }

    static void ReadSlogan(string slogan, HashSet<string> words, string solution, HashSet<string> solutions)
    {
        if (slogan.Length == 0)
        {
            solutions.Add(solution.Trim());
            return;
        }

        foreach (string item in words)
        {
            if (item == slogan)
            {
                solutions.Add($"{solution} {item}".Trim());
            }

            if (slogan.StartsWith(item))
            {
                ReadSlogan(slogan.Substring(item.Length), words, $"{solution} {item}", solutions);
            }
        }
    }
}
