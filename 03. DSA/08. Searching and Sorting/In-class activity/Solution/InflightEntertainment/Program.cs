using System;
using System.Collections.Generic;

namespace InflightEntertainment
{
	class Program
	{
		public static void Main()
		{
			Console.WriteLine("Expected: True; Actual: " + CheckTimes(new int[] { 1, 2, 3, 4, 5, 6 }, 7));
			Console.WriteLine("Expected: False; Actual: " + CheckTimes(new int[] { 6 }, 6));
			Console.WriteLine("Expected: True; Actual: " + CheckTimes(new int[] { 2, 4 }, 6));
			Console.WriteLine("Expected: False; Actual: " + CheckTimes(new int[] { }, 6));

			Console.WriteLine("Expected: True; Actual: " + CheckTimesImproved(new int[] { 1, 2, 3, 4, 5, 6 }, 7));
			Console.WriteLine("Expected: False; Actual: " + CheckTimesImproved(new int[] { 6 }, 6));
			Console.WriteLine("Expected: True; Actual: " + CheckTimesImproved(new int[] { 2, 4 }, 6));
			Console.WriteLine("Expected: False; Actual: " + CheckTimesImproved(new int[] { }, 6));
		}

		private static bool CheckTimes(int[] movieTimes, int flightLength)
		{
			var set = new HashSet<int>();

			foreach (int i in movieTimes)
			{
				set.Add(i);
			}

			foreach (int i in set)
			{
				if (set.Contains(flightLength - i))
				{
					return true;
				}
			}

			return false;
		}

		private static bool CheckTimesImproved(int[] movieTimes, int flightLength)
		{
			var movieLengthsSeen = new HashSet<int>();

			foreach (int firstMovieLength in movieTimes)
			{
				int matchingSecondMovieLength = flightLength - firstMovieLength;
				if (movieLengthsSeen.Contains(matchingSecondMovieLength))
				{
					return true;
				}
				else
				{
					movieLengthsSeen.Add(firstMovieLength);
				}
			}

			return false;
		}
	}
}
