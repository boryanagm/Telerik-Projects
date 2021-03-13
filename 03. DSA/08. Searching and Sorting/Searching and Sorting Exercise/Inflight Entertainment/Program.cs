using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int flightLength = int.Parse(Console.ReadLine());

        int[] moviesLengths = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        bool areThereTwoMovies = AreThereTwoMovies(flightLength, moviesLengths);

        Console.WriteLine(areThereTwoMovies);
    }
    // My solution assuming that there are movies with the same length

    static bool AreThereTwoMovies(int flightLength, int[] moviesLengths)
    {
        for (int i = 0; i < moviesLengths.Length; i++)
        {
            int diff = flightLength - moviesLengths[i];
            List<int> current = moviesLengths.ToList();
            current.RemoveAt(i);

            if (current.Contains(diff))
            {
                return true;
            }
        }

        return false;
    }
}
