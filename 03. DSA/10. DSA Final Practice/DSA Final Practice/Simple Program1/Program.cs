using System;
using System.Collections.Generic;

namespace Slogan_DSA
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            var output = new List<string>();

            for (int i = 1; i <= N; i++)
            {
                HashSet<string> solutions = new HashSet<string>();
                var inputWords = Console.ReadLine().Split(' ');
                var words = new HashSet<string>(inputWords);
                var slogan = Console.ReadLine();
             
                FindSolutions(slogan, words, string.Empty, solutions);

                if (solutions.Count == 0)
                    output.Add("NOT VALID");
                else
                    output.AddRange(solutions);
            }

            foreach (string s in output)
                Console.WriteLine(s);
        }

        static void FindSolutions(string slogan, HashSet<string> words, string solution, HashSet<string> solutions)
        {
            if (slogan.Length == 0)
            {
                solutions.Add(solution.Trim());
                return;
            }

            foreach (string s in words)
            {
                if (s == slogan)
                {
                    solutions.Add($"{solution} {s}".Trim());
                }

                if (slogan.StartsWith(s))
                {
                    FindSolutions(slogan.Substring(s.Length), words, $"{solution} {s}", solutions);
                }
            }
        }
    }
}