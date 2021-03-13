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

    static bool AreThereTwoMovies(int flightLength, int[] moviesLengths)
    {
        var seenMoviesLengths = new HashSet<int>();

        foreach (int firstMovieLength in moviesLengths)
        {
            int matchingSecondMovieLength = flightLength - firstMovieLength;

            if (seenMoviesLengths.Contains(matchingSecondMovieLength))
            {
                return true;
            }
            else
            {
                seenMoviesLengths.Add(firstMovieLength);
            }
        }

        return false;
    }
}
